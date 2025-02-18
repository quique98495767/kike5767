﻿using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Comunicaciones
            services.AddScoped<IDetallesImagenesComunicacion, DetallesImagenesComunicacion>();
            services.AddScoped<IImagenesComunicacion, ImagenesComunicacion>();
            services.AddScoped<ILocalidadesComunicacion, LocalidadesComunicacion>();
            services.AddScoped<ILocalizacionesComunicacion, LocalizacionesComunicacion>();
            services.AddScoped<IPersonasComunicacion, PersonasComunicacion>();
            services.AddScoped<IUbicacionesComunicacion, UbicacionesComunicacion>();
            // Presentaciones
            services.AddScoped<IDetallesImagenesPresentacion, DetallesImagenesPresentacion>();
            services.AddScoped<IImagenesPresentacion, ImagenesPresentacion>();
            services.AddScoped<ILocalidadesPresentacion, LocalidadesPresentacion>();
            services.AddScoped<ILocalizacionesPresentacion, LocalizacionesPresentacion>();
            services.AddScoped<IPersonasPresentacion, PersonasPresentacion>();
            services.AddScoped<IUbicacionesPresentacion, UbicacionesPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}