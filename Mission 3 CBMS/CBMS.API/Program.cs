using CBMS.BLL.Services.CustomerService;
using CBMS.BLL.Services.HallService;
using CBMS.BLL.Services.MovieService;
using CBMS.BLL.Services.TicketService;
using CBMS.DAL;
using CBMS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CBMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ITicketRepositry, TicketRepository>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IHallRepository, HallRepository>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IHallService, HallService>();

            var app = builder.Build();

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
