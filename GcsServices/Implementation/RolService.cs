using GcsRepository.Entities;
using GcsRepository.Implementation;
using GcsRepository.Interfaces;
using GcsServices.Interfaces;

namespace GcsServices.Implementation
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }
        public async Task<List<Rol>> Lista()
        {
            return await _rolRepository.Lista();
        }
    }
}
