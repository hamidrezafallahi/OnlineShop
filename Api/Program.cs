using Application.Commands.Blogs.Commands;
using Application.Commands.Blogs.Queries;
using Application.Commands.Brands;
using Application.Commands.Categories.Commands;
using Application.Commands.Products;
using Application.Common.Mappings;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Persistence;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // رجیستر کردن IApplicationDbContext
            builder.Services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<AppDbContext>());

            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            // رجیستر کردن MediatR به صورت یکجا
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(CreateUserCommandHandler).Assembly,
                    typeof(CreateBlogCommand).Assembly,
                    typeof(CreateCategoryCommandHandler).Assembly,
                    typeof(CreateBrandCommandHandler).Assembly,
                    typeof(CreateProductCommandHandler).Assembly
                );
            });

            // رجیستر کردن AutoMapper با اسمبلی مشخص
            builder.Services.AddAutoMapper(
                typeof(UserMappingProfile).Assembly,
                typeof(BlogMappingProfile).Assembly,
                typeof(CategoryMappingProfile).Assembly,
                typeof(BrandMappingProfile).Assembly


                );

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
