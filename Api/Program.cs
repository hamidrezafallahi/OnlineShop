
using Application.Commands.Blogs.Commands;
using Application.Commands.Brands;
using Application.Commands.Categories;
using Application.Commands.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Application.Common.Mappings; 
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);





            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // رجیستر کردن IApplicationDbContext



            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var provider = builder.Services.BuildServiceProvider();
            var mapper = provider.GetRequiredService<IMapper>();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();


            builder.Services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<AppDbContext>());
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly);
            });
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateBlogCommand).Assembly));
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly);
            });
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly));

            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateBrandCommandHandler).Assembly));

            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly));



            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}