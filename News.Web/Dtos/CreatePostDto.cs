using News.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace News.Web.Dtos
{
    public class CreatePostDto
    {
        [Required]
        [Display(Name = "عنوان الخبر")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "تفاصيل الخبر")]
        public string Body { get; set; }
        [Required]
        [Display(Name = "صورة الخبر")]
        public IFormFile Image { get; set; } 
        public int CategoryId { get; set; }
        
    }
}
