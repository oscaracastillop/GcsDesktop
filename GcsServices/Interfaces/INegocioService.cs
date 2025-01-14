using GcsRepository.Entities;

namespace GcsServices.Interfaces
{
    public interface INegocioService
    {
        Task<Negocio> Obtener();
        Task Editar(Negocio objeto);
    }
}
