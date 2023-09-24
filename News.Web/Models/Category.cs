using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace News.Web.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Post> Posts { get; set; }

    }
}
