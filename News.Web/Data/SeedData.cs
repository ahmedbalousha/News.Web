using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using News.Web.Data;
using News.Web.Models;

namespace News.Data
{
    public static class SeedData
    {
        public static async Task<IHost> SeedDb(this IHost webHost)
        {
            using var scope = webHost.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<NewsDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                if (!await userManager.Users.AnyAsync())
                {
                    await userManager.SeedAdmin();

                }
                await context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return webHost;
        }

        

        public static async Task SeedAdmin(this UserManager<User> userManger)
        {
            if (await userManger.Users.AnyAsync())
            {
                return;
            }
            var user = new User();
            user.FullName = "م.أحمد بعلوشة";
            user.UserName = "abalousha4@gmail.com";
            user.Email = "abalousha4@gmail.com";
            user.EmailConfirmed = true;
            user.DOB = DateTime.Today;

            await userManger.CreateAsync(user, "Admin@2023");

        }
        

            }
        }
    


