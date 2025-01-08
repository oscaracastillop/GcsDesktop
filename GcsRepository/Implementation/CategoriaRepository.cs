﻿using GcsRepository.DB;
using GcsRepository.Entities;
using GcsRepository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GcsRepository.Implementation
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly Conexion _conexion;

        public CategoriaRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<List<Categoria>> Lista(string buscar = "")
        {
            List<Categoria> lista = new List<Categoria>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaCategoria", con);
                cmd.Parameters.AddWithValue("@Buscar", buscar);
                cmd.CommandType = CommandType.StoredProcedure;
                
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {

                        lista.Add(new Categoria
                        {
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                            Nombre = dr["Nombre"].ToString()!,
                            Activo = Convert.ToInt32(dr["Activo"]),
                            RefMedida = new Medida
                            {
                                IdMedida = Convert.ToInt32(dr["IdMedida"]),
                                Nombre = dr["NombreMedida"].ToString()!,
                            }
                        });
                    }
                }
            }
            return lista;
        }
        public async Task<string> Crear(Categoria objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_crearCategoria", con);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@IdMedida", objeto.RefMedida.IdMedida);
                cmd.Parameters.Add("@MsjError",SqlDbType.VarChar,100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@MsjError"].Value)!;
                }
                catch (Exception)
                {
                    respuesta = "Error(rp): No se pudo procesar";
                }
                
            }
            return respuesta;
        }

        public async Task<string> Editar(Categoria objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_editarCategoria", con);
                cmd.Parameters.AddWithValue("@IdCategoria", objeto.IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@IdMedida", objeto.RefMedida.IdMedida);
                cmd.Parameters.AddWithValue("@Activo", objeto.Activo);
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Input;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@MsjError"].Value)!;
                }
                catch (Exception)
                {
                    respuesta = "Error(rp): No se pudo procesar";
                }

            }
            return respuesta;
        }
    }
}
