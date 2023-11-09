using Microsoft.EntityFrameworkCore;
using UserManagement.Repositories;

namespace UserManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Database context DI

            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; User ID=sa; Password={dbPassword}; TrustServerCertificate=true";
            builder.Services.AddDbContext<UserDbContext>(opt => opt.UseSqlServer(connectionString));

            var app = builder.Build();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}