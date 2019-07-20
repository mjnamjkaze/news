using Microsoft.AspNetCore.Builder;
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
                if (context.Posts.Any())
                {
                    return;
                }
                var news = DummyData.GetNews().ToArray();
                context.Posts.AddRange(news);
                context.SaveChanges();

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
    }
}
