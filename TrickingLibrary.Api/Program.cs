using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrickingLibrary.Data;
using TrickingLibrary.Models;

namespace TrickingLibrary.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

                if (env.IsDevelopment())
                {
                    ctx.Difficulties.Add(new Difficulty{Id = "easy", Name = "Easy", Descrption = "Easy Desc"});
                    ctx.Difficulties.Add(new Difficulty{Id = "hard", Name = "Hard", Descrption = "Hard Desc"});
                    ctx.Difficulties.Add(new Difficulty{Id = "medium", Name = "Medium", Descrption = "Medium Desc"});

                    ctx.Categories.Add(new Category{Id = "kick", Name = "Kick", Descrption = "Kick Desc"});
                    ctx.Categories.Add(new Category{Id = "flip", Name = "Flip", Descrption = "Flip Desc"});
                    ctx.Categories.Add(new Category{Id = "transition", Name = "Transition", Descrption = "Transition Desc"});
                    ctx.SaveChanges();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}