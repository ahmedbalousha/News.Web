using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using News.Dtos.Helpers;
using News.Exceptions;
using News.Services;
using News.Web.Data;
using News.Web.Dtos;
using News.Web.Models;
using News.Web.ViewModels;

namespace News.Web.Service.Posts
{
    public class PostService : IPostService
    {
        private readonly NewsDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public PostService(NewsDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Posts.Include(x => x.Category).AsQueryable();
            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var posts = _mapper.Map<List<PostViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = posts,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;


        }
        public async Task<List<PostViewModel>> GetAll()
        {
            var post =await _db.Posts.Include(x=> x.Category).ToListAsync();
            var postsVM = _mapper.Map<List<PostViewModel>>(post);

            return postsVM;
        }
        public async Task<PostViewModel> GetById(int id)
        {
            var post = await _db.Posts.FindAsync(id);
            var postVM = _mapper.Map<PostViewModel>(post);
            return postVM;
        }      
        public async Task<int> Delete(int id)
        {
            var Post = await _db.Posts.SingleOrDefaultAsync(x => x.Id == id);
            if (Post == null)
            {
                throw new EntityNotFoundException();
            }
            _db.Posts.Remove(Post);
            await _db.SaveChangesAsync();
            return Post.Id;

        }
        public async Task<int> Create(CreatePostDto dto)
        {
            var post = _mapper.Map<Post>(dto);
            if (dto.Image != null)
            {
                post.ImageUrl = await _fileService.SaveFile(dto.Image, "Images");
            }
            await _db.Posts.AddAsync(post);
            await _db.SaveChangesAsync();
            return post.Id;
        }
        public async Task<UpdatePostDto> Get(int id)
        {
            var post = await _db.Posts.SingleOrDefaultAsync(x => x.Id == id);
            if (post == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdatePostDto>(post);

        }
        public async Task<int> Update(UpdatePostDto dto)
        {
           
            var Post = await _db.Posts.SingleOrDefaultAsync(x => x.Id == dto.Id);
            if (Post == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedPost = _mapper.Map(dto, Post);
            if (dto.Image != null)
            {
                updatedPost.ImageUrl = await _fileService.SaveFile(dto.Image, "Images");
            }

            _db.Posts.Update(updatedPost);
            await _db.SaveChangesAsync();
            return Post.Id;



        }

        public async Task<List<PostViewModel>> GetByCategory (int id)
        {
            var posts = await _db.Posts.Include(x => x.Category).Where(x => x.CategoryId == id).ToListAsync();
            var postVM =  _mapper.Map<List<PostViewModel>>(posts);
            return postVM;
        }
    }
}
