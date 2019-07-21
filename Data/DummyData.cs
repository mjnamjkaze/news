using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();
                if (!context.Posts.Any())
                {
                    var news = DummyData.GetNews().ToArray();
                    context.Posts.AddRange(news);
                    context.SaveChanges();
                }

                if (!context.Roles.Any())
                {
                    var roles = DummyData.GetRoles().ToArray();
                    context.Roles.AddRange(roles);
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    var users = DummyData.GetUsers().ToArray();
                    context.Users.AddRange(users);
                    context.SaveChanges();

                    var userRoles = DummyData.GetUserRoles(context).ToArray();
                    context.UserRoles.AddRange(userRoles);
                    context.SaveChanges();
                }
            }
        }

        private static List<Post> GetNews()
        {
            return new List<Post>() {

                    new Post(){
                          Content ="Hello World"
                    }
            };
        }

        private static List<IdentityRole> GetRoles()
        {
            return new List<IdentityRole>() {

                    new IdentityRole(){
                          Name ="admin",
                          NormalizedName ="admin"
                    },
                     new IdentityRole(){
                          Name ="editor",
                          NormalizedName ="editor"
                    },
                    new IdentityRole(){
                          Name ="audience",
                          NormalizedName ="audience"
                    },
            };
        }

        private static List<Author> GetUsers()
        {
            return new List<Author>() {

                    new Author(){
                          Name ="NamVH",
                          Email ="mjnamjkaze@gmail.com",
                          UserName ="admin",
                    },
                     new Author(){
                          Name ="Gosei Nam",
                          Email ="vo.hai.nam@gosei.com.vn",
                          UserName ="editor"
                    },
                    new Author(){
                          Name ="audience",
                          Email ="vo.hai.nam@gosei.com.vn",
                          UserName ="audience"
                    },
            };
        }


        private static List<IdentityUserRole<string>> GetUserRoles(ApplicationDbContext context)
        {
            return new List<IdentityUserRole<string>>() {

                    new IdentityUserRole<string>(){
                        UserId = context.Users.Where(x=>x.UserName=="admin").FirstOrDefault().Id,
                        RoleId  = context.Roles.Where(x=>x.Name=="admin").FirstOrDefault().Id,
                    },
                     new IdentityUserRole<string>(){
                        UserId = context.Users.Where(x=>x.UserName=="editor").FirstOrDefault().Id,
                        RoleId  = context.Roles.Where(x=>x.Name=="editor").FirstOrDefault().Id,
                    },
                    new IdentityUserRole<string>(){
                        UserId = context.Users.Where(x=>x.UserName=="audience").FirstOrDefault().Id,
                        RoleId  = context.Roles.Where(x=>x.Name=="audience").FirstOrDefault().Id,
                    },
            };
        }
    }
}
