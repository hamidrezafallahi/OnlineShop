
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
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // رجیستر کردن IApplicationDbContext
            builder.Services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<AppDbContext>());
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly);
            });
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(OnlineShop.Application.Blogs.Commands.CreateBlogCommand).Assembly));
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly);
            });
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





//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using OnlineShop.Application.Blogs.Commands;
//using OnlineShop.Application.Blogs.Dtos;
//using OnlineShop.Application.Common.Interfaces;
//using OnlineShop.Core.Domains.Entities;
//using OnlineShop.Infrastructure;


//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddInfrastructure(builder.Configuration);

//// Add services to the container.
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssembly(typeof(OnlineShop.Application.Blogs.Commands.CreateBlogCommand).Assembly));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseHttpsRedirection();








////using (var scope = app.Services.CreateScope())
////{
////    var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

////    // چک کن ببینی یوزری با این ایمیل هست یا نه
////    var existingUser = context.Users.FirstOrDefault(u => u.Email == "test@example.com");
////    if (existingUser == null)
////    {
////        var user = new User
////        {
////            Id = Guid.NewGuid(),
////            FullName = "تست یوزر",
////            Email = "test@example.com",
////            PhoneNumber = "09123456789"
////        };

////        var hasher = new PasswordHasher<User>();
////        user.PasswordHash = hasher.HashPassword(user, "Pa$$w0rd123");

////        context.Users.Add(user);
////        await context.SaveChangesAsync(CancellationToken.None);

////        Console.WriteLine("✅ یوزر تستی ساخته شد.");
////    }
////    else
////    {
////        Console.WriteLine("ℹ️ یوزر از قبل وجود دارد.");
////    }
////}






















//using (var scope = app.Services.CreateScope())
//{
//    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

//    var command = new CreateBlogCommand
//    {
//        BlogDto = new CreateBlogDto
//        {
//            Title = "اولین بلاگ",
//            Slug = "test",
//            Content = "محتوای تست",
//            ThumbnailUrl = "https://example.com/image.jpg"
//        },
//        AuthorId = Guid.Parse("645C1BEA-B196-4F65-ACF7-5A29955F470A")
//    };

//    var resultId = await mediator.Send(command);
//    Console.WriteLine("Blog created with ID: " + resultId);
//}







//app.Run();using MediatR;
//using Microsoft.AspNetCore.Identity;
//using OnlineShop.Application.Blogs.Commands;
//using OnlineShop.Application.Blogs.Dtos;
//using OnlineShop.Application.Common.Interfaces;
//using OnlineShop.Core.Domains.Entities;
//using OnlineShop.Infrastructure;


//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddInfrastructure(builder.Configuration);

//// Add services to the container.
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssembly(typeof(OnlineShop.Application.Blogs.Commands.CreateBlogCommand).Assembly));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseHttpsRedirection();








////using (var scope = app.Services.CreateScope())
////{
////    var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

////    // چک کن ببینی یوزری با این ایمیل هست یا نه
////    var existingUser = context.Users.FirstOrDefault(u => u.Email == "test@example.com");
////    if (existingUser == null)
////    {
////        var user = new User
////        {
////            Id = Guid.NewGuid(),
////            FullName = "تست یوزر",
////            Email = "test@example.com",
////            PhoneNumber = "09123456789"
////        };

////        var hasher = new PasswordHasher<User>();
////        user.PasswordHash = hasher.HashPassword(user, "Pa$$w0rd123");

////        context.Users.Add(user);
////        await context.SaveChangesAsync(CancellationToken.None);

////        Console.WriteLine("✅ یوزر تستی ساخته شد.");
////    }
////    else
////    {
////        Console.WriteLine("ℹ️ یوزر از قبل وجود دارد.");
////    }
////}






















//using (var scope = app.Services.CreateScope())
//{
//    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

//    var command = new CreateBlogCommand
//    {
//        BlogDto = new CreateBlogDto
//        {
//            Title = "اولین بلاگ",
//            Slug = "test",
//            Content = "محتوای تست",
//            ThumbnailUrl = "https://example.com/image.jpg"
//        },
//        AuthorId = Guid.Parse("645C1BEA-B196-4F65-ACF7-5A29955F470A")
//    };

//    var resultId = await mediator.Send(command);
//    Console.WriteLine("Blog created with ID: " + resultId);
//}







//app.Run();