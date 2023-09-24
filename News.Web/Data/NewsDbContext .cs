using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News.Web.Models;

namespace News.Web.Data
{
    public class NewsDbContext : IdentityDbContext<User>
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options)
          : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
