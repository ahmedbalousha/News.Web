using System.ComponentModel.DataAnnotations;

namespace News.Web.Models
{
    public class Post : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
       
    }
}
