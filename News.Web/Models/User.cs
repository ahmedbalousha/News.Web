using Microsoft.AspNetCore.Identity;

namespace News.Web.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
    }
}
