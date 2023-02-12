using Microsoft.EntityFrameworkCore;
using Portal_ELIPBVC.Domain;
using Portal_ELIPBVC.Domain.Repositories;
using Portal_ELIPBVC.Services.Ensaios;
using Portal_ELIPBVC.Services.Eventos;
using Portal_ELIPBVC.Services.Membros;
using Portal_ELIPBVC.Services.Songs;

namespace Portal_ELIPBVC
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IEnsaioRepository, EnsaioRepository>();
            services.AddScoped<IMembroRepository, MembroRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEnsaioService, EnsaioService>();
            services.AddScoped<IMembroService, MembroService>();
            services.AddScoped<ISongService, SongService>();

            services.AddControllers();
            services.AddSwaggerGen();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();



            //Configuration DBContext
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("LocalConnection");
                options.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    mySqlOptions =>
                        mySqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null));
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseStaticFiles();

            app.UseAuthentication();
            //app.UseIdentityServer();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}