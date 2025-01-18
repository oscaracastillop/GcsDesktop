﻿using GcsRepository.DB;
using GcsRepository.Entities;
using GcsRepository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GcsRepository.Implementation
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Conexion _conexion;

        public UsuarioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<List<Usuario>> Lista(string buscar = "")
        {
            List<Usuario> lista = new List<Usuario>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaUsuario", con);
                cmd.Parameters.AddWithValue("@Buscar", buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {

                        lista.Add(new Usuario
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            RefRol = new Rol
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Nombre = dr["Nombre"].ToString()!,
                            },
                            NombreCompleto = dr["NombreCompleto"].ToString()!,
                            Correo = dr["Correo"].ToString()!,
                            NombreUsuario = dr["NombreUsuario"].ToString()!,
                            Activo = Convert.ToInt32(dr["Activo"]),                            
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<string> Crear(Usuario objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_crearUsuario", con);
                cmd.Parameters.AddWithValue("@IdRol", objeto.RefRol.IdRol);
                cmd.Parameters.AddWithValue("@NombreCompleto", objeto.NombreCompleto);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@NombreUsuario", objeto.NombreUsuario);
                cmd.Parameters.AddWithValue("@Clave", objeto.Clave);
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
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

        public async Task<string> Editar(Usuario objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_editarUsuario", con);
                cmd.Parameters.AddWithValue("@IdUsuario", objeto.IdUsuario);
                cmd.Parameters.AddWithValue("@IdRol", objeto.RefRol.IdRol);
                cmd.Parameters.AddWithValue("@NombreCompleto", objeto.NombreCompleto);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@NombreUsuario", objeto.NombreUsuario);
                cmd.Parameters.AddWithValue("@Activo", objeto.Activo);
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
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
