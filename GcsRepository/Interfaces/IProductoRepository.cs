﻿using GcsRepository.Entities;

namespace GcsRepository.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> Lista(string buscar = "");

        Task<string> Crear(Producto objeto);

        Task<string> Editar(Producto objeto);
    }
}
