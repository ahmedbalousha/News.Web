using System.ComponentModel.DataAnnotations;

namespace News.Web.Dtos
{
    public class CreateCategoryDto
    {
        [Required]
        [Display(Name = "اسم التصنيف")]
        public string Name { get; set; }
    }
}
