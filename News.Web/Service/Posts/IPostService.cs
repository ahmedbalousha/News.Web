using News.Dtos.Helpers;
using News.Web.Dtos;
using News.Web.ViewModels;

namespace News.Web.Service.Posts
{
    public interface IPostService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Delete(int id);
        Task<int> Create(CreatePostDto dto);
        Task<UpdatePostDto> Get(int id);
        Task<int> Update(UpdatePostDto dto);
        Task<PostViewModel> GetById(int id);
        Task<List<PostViewModel>> GetAll();
    }
}
