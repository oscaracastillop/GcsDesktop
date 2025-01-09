using GcsRepository.DB;
using GcsRepository.Implementation;
using GcsRepository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GcsRepository
{
    public static class DependencyInjection
    {
        public static void RegisterRepositoryDependencies(this IServiceCollection services)
        {
            services.AddSingleton<Conexion>();
            services.AddTransient<IMedidaRepository, MedidaRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
        }
    }
}
