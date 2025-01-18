using GcsRepository.Entities;

namespace GcsRepository.Interfaces
{
    public interface IRolRepository
    {
        Task <List<Rol>> Lista();
    }
}
