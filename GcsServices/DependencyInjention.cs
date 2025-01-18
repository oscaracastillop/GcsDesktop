using GcsServices.Implementation;
using GcsServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GcsServices
{
    public static class DependencyInjention
    {
        public static void RegisterServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IMedidaService, MedidaService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<INegocioService, NegocioService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ICorreoService, CorreoService>();

        }
    }
}
