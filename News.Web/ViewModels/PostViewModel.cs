using News.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace News.Web.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; } 
        public CategoryViewModel Category { get; set; }
        public string CreatedAt { get; set; }
    }
}
