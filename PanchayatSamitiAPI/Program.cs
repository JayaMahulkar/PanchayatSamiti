
using Microsoft.EntityFrameworkCore;
using PanchayatSamitiAPI.Services;
using PanchayatSamitiAPI.Services.IServices;

namespace PanchayatSamitiAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // register DbContext and repositories/services
            builder.Services.AddDbContext<DataLayer.Models.PanchayatSamitiContext>(options =>
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            builder.Services.AddScoped(typeof(DataLayer.Repository.IRepository<>), typeof(DataLayer.Repository.Repository<>));
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<ISubDepartmentService, SubDepartmentService>();
            builder.Services.AddScoped<IBankecheTapshilService, BankecheTapshilService>();
            builder.Services.AddScoped<IRelationService, RelationService>();
            builder.Services.AddScoped<IVetanAyogService, VetanAyogService>();
            builder.Services.AddScoped<IKhatePramukhService, KhatePramukhService>();
            builder.Services.AddScoped<IKharchacheShirshService, KharchacheShirshService>();
            builder.Services.AddScoped<IKaryalayaPramukhService, KaryalayaPramukhService>();
            builder.Services.AddScoped<IDesignationService, DesignationService>();
            builder.Services.AddScoped<IBankService, BankService>();
            builder.Services.AddScoped<IRetirementOfficeService, RetirementOfficeService>();
            builder.Services.AddScoped<IVetanShreneeService, VetanShreneeService>();            
            builder.Services.AddScoped<IAdhiSuchanaService, AdhiSuchanaService>();
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
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
