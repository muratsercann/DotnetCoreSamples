using Microsoft.EntityFrameworkCore;
using JWTAuthentication;
using JWTAuthentication.Data;
using Microsoft.AspNetCore;
using JWTAuthentication.Services;

internal class Program
{
    private static void Main(string[] args)
    {


        var builder = WebApplication.CreateBuilder(args);

        var conStr = builder.Configuration.GetConnectionString("SqliteDataContext");
        builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlite(conStr));

        CreateWebHostBuilder(args).Build();//bunun WebApplication.CreateBuilder(args) 'dan sonra olmasý lazým

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddScoped<IUserService, UserService>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>();
}