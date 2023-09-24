using AutoMapper;
using News.Web.Dtos;
using News.Web.Models;
using News.Web.ViewModels;

namespace BookStore.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();

            CreateMap<Post, PostViewModel>()
                .ForMember(x => x.CreatedAt, x => x.MapFrom(x => x.CreatedAt.ToString("yyyy:MM:dd")));
              
            CreateMap<CreatePostDto, Post>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdatePostDto, Post>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<Post, UpdatePostDto>().ForMember(x => x.Image, x => x.Ignore());





        }


    }
}
