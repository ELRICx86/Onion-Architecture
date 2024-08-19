using crud_postgresql.Dependency;
using crud_postgresql.Mappers;
using curd_postgresql.Application.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace crud_postgresql
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
            builder.Services.AddSwaggerGen();

            // Get the connection string from configuration
            string connectionString = builder.Configuration.GetConnectionString("TestConnection")!;

            var dbConnOptions = new DBConn { connectionString = connectionString };


            builder.Services.Configure<DBConn>(builder.Configuration.GetSection("ConnectionStrings"));

            
            builder.Services.AddSingleton(dbConnOptions);
            builder.Services.AddRepoDependency();
            builder.Services.AddAutoMapper(typeof(RequestMapper), typeof(ResponseMapper));
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
