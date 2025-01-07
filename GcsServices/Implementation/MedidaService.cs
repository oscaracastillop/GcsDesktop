using GcsRepository.Entities;
using GcsRepository.Interfaces;
using GcsServices.Interfaces;

namespace GcsServices.Implementation
{
    public class MedidaService : IMedidaService
    {
        private readonly IMedidaRepository _medidaRepository;
        public MedidaService(IMedidaRepository medidaRepository)
        {
            _medidaRepository = medidaRepository;
        }
        public async Task<List<Medida>> Lista()
        {
           return await _medidaRepository.Lista();
        }
    }
}
