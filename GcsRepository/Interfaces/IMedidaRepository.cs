using GcsRepository.Entities;

namespace GcsRepository.Interfaces
{
    public interface IMedidaRepository
    {
        Task<List<Medida>> Lista();

    }
}
