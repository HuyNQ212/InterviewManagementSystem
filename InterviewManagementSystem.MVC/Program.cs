using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Implement;
using InterviewManagementSystem.MVC.Models;

namespace InterviewManagementSystem.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            builder.Services.AddScoped<InterviewManagementContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
            builder.Services.AddScoped<IOfferRepository, OfferRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "candidate-name",
            //    pattern: "{candidateName}",
            //    defaults: new {controller = "Candidates", action = "Details"});



            //app.MapControllerRoute(
            //    name: "detail-candidate",
            //    pattern: "{controller=Candidates}/{action=Details}/{id}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Use(async (context, next) =>
            {
                // Các middleware ở trước invoke sẽ chạy khi request đến
                await next.Invoke();
                // Các middleware ở sau invoke sẽ chayk hi response được trả về
            });

            app.Run();
        }
    }
}