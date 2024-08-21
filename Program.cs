
using Microsoft.EntityFrameworkCore;
using NextBlueGen_API.Data;

namespace NextBlueGen_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Instanciate WebApplication
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container (Custom additions)
            builder.Services.AddDbContext<ScoreboardContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext") ?? throw new InvalidOperationException("Missing or invalid database-connectionstring")));
            #endregion

            #region Default pipeline setup
            builder.Services.AddControllers();
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
            #endregion
        }
    }
}
