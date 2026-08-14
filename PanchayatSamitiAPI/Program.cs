
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
            builder.Services.AddDbContext<DataLayer.Models.PanchayatSamitiContext>();
            builder.Services.AddScoped(typeof(DataLayer.Repository.IRepository<>), typeof(DataLayer.Repository.Repository<>));
            builder.Services.AddScoped<IDepartmentService,Services.DepartmentService>();
            builder.Services.AddScoped<ISubDepartmentService, Services.SubDepartmentService>();
            builder.Services.AddScoped<IBankecheTapshilService, Services.BankecheTapshilService>();
            builder.Services.AddScoped<IRelationService, Services.RelationService>();
            builder.Services.AddScoped<IVetanAyogService, Services.VetanAyogService>();
            builder.Services.AddScoped<IKhatePramukhService, Services.KhatePramukhService>();
            builder.Services.AddScoped<IKharchacheShirshService, Services.KharchacheShirshService>();
            builder.Services.AddScoped<IKaryalayaPramukhService, Services.KaryalayaPramukhService>();
            builder.Services.AddScoped<IDesignationService, Services.DesignationService>();
            builder.Services.AddScoped<IBankService, Services.BankService>();
            builder.Services.AddScoped<IRetirementOfficeService, Services.RetirementOfficeService>();
            builder.Services.AddScoped<IVetanShreneeService, Services.VetanShreneeService>();

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

            }

            );

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
