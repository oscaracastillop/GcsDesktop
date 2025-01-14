using GcsRepository.Entities;

namespace GcsRepository.Interfaces
{
    public interface INegocioRepository
    {
        Task<Negocio> Obtener();
        Task Editar(Negocio objeto);
    }
}
