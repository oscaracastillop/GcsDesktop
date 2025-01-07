using GcsRepository.Entities;

namespace GcsServices.Interfaces
{
    public interface IMedidaService
    {
        Task<List<Medida>> Lista();
    }
}
