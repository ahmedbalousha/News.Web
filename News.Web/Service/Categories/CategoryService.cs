using AutoMapper;
using Microsoft.EntityFrameworkCore;
using News.Dtos.Helpers;
using News.Exceptions;
using News.Web.Data;
using News.Web.Dtos;
using News.Web.Models;
using News.Web.ViewModels;

namespace News.Web.Service.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly NewsDbContext _db;
        private readonly IMapper _mapper;
        public CategoryService(NewsDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            
        }
        public async Task<ResponseDto> GetAll(Pagination pagination, string GeneralSearch)
        {
            var queryString = _db.Categories.Where( x =>  (x.Name.Contains(GeneralSearch) || string.IsNullOrWhiteSpace(GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var categories = _mapper.Map<List<CategoryViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = categories,
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
        public async Task<List<CategoryViewModel>> GetCategoryList()
        {
            var categories = await _db.Categories.ToListAsync();
            return _mapper.Map<List<CategoryViewModel>>(categories);
        }
        public async Task<List<CategoryViewModel>> GetAll()
        {
            var category = await _db.Posts.ToListAsync();
            var categoryVM = _mapper.Map<List<CategoryViewModel>>(category);

            return categoryVM;
        }
        public async Task<CategoryViewModel> GetById(int id)
        {
            var category = await _db.Posts.FindAsync(id);
            var categoryVM = _mapper.Map<CategoryViewModel>(category);
            return categoryVM;
        }


        public async Task<int> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return category.Id;
        }


        public async Task<int> Update(UpdateCategoryDto dto)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(x =>  x.Id == dto.Id);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedCategory = _mapper.Map<UpdateCategoryDto, Category>(dto, category);
            _db.Categories.Update(updatedCategory);
            await _db.SaveChangesAsync();
            return updatedCategory.Id;
        }


        public async Task<UpdateCategoryDto> Get(int Id)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(x => x.Id == Id );
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateCategoryDto>(category);
        }


        public async Task<int> Delete(int Id)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(x => x.Id == Id);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return category.Id;
        }
    }
}
