using GcsRepository.Entities;

namespace GcsServices.Interfaces
{
    public interface IRolService
    {
        Task<List<Rol>> Lista();
    }
}
