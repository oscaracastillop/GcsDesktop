using GcsRepository.DB;
using GcsRepository.Entities;
using GcsRepository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GcsRepository.Implementation
{
    public class NegocioRepository :INegocioRepository
    {
        private readonly Conexion _conexion;
        public NegocioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<Negocio> Obtener()
        {
            Negocio objeto = new Negocio();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_obtenerNegocio", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        objeto = new Negocio()
                        {
                            RazonSocial = dr["RazonSocial"].ToString()!,
                            RUC = dr["RUC"].ToString()!,
                            Direccion = dr["Direccion"].ToString()!,
                            Celular = dr["Celular"].ToString()!,
                            Correo = dr["Correo"].ToString()!,
                            SimboloMoneda = dr["SimboloMoneda"].ToString()!,
                            NombreLogo = dr["NombreLogo"].ToString()!,
                            UrlLogo = dr["UrlLogo"].ToString()!,
                        };
                    }
                }
            }
            return objeto;
        }

        public async Task Editar(Negocio objeto)
        {
            //string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_editarNegocio", con);
                cmd.Parameters.AddWithValue("@RazonSocial", objeto.RazonSocial);
                cmd.Parameters.AddWithValue("@RUC", objeto.RUC);
                cmd.Parameters.AddWithValue("@Direccion", objeto.Direccion);
                cmd.Parameters.AddWithValue("@Celular", objeto.Celular);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@SimboloMoneda", objeto.SimboloMoneda);
                cmd.Parameters.AddWithValue("@NombreLogo", objeto.NombreLogo);
                cmd.Parameters.AddWithValue("@UrlLogo", objeto.UrlLogo);
                //cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    //respuesta = Convert.ToString(cmd.Parameters["@MsjError"].Value)!;
                }
                catch (Exception)
                {
                    throw;
                    //respuesta = "Error(rp): No se pudo procesar";
                }

            }
            //return respuesta;
        }
        
    }
}
