using News.Dtos.Helpers;
using News.Web.Dtos;
using News.Web.ViewModels;

namespace News.Web.Service.Categories
{
    public interface ICategoryService
    {
        Task<int> Delete(int Id);
        Task<UpdateCategoryDto> Get(int Id);
        Task<int> Update(UpdateCategoryDto dto);
        Task<int> Create(CreateCategoryDto dto);
        Task<List<CategoryViewModel>> GetCategoryList();
        Task<ResponseDto> GetAll(Pagination pagination, string GeneralSearch);
        Task<CategoryViewModel> GetById(int id);
        Task<List<CategoryViewModel>> GetAll();

    }    
}
