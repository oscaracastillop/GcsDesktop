﻿using GcsRepository.Entities;
using GcsRepository.Implementation;
using GcsRepository.Interfaces;
using GcsServices.Interfaces;

namespace GcsServices.Implementation
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<List<Producto>> Lista(string buscar = "")
        {
            return await _productoRepository.Lista(buscar);
        }

        public async Task<string> Crear(Producto objeto)
        {
            return await _productoRepository.Crear(objeto);
        }

        public async Task<string> Editar(Producto objeto)
        {
            return await _productoRepository.Editar(objeto);
        }

        
    }
}
