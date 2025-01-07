using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GcsRepository.DB
{
    public class Conexion
    {
        private readonly IConfiguration _configuracion;
        private readonly string _cadenaSql;

        public Conexion(IConfiguration configuracion)
        {
            _configuracion = configuracion;
            _cadenaSql = _configuracion.GetConnectionString("CadenaSql")!;
        }

        public SqlConnection ObtenerSQLConexion()
        {
            return new SqlConnection(_cadenaSql);
        }
    }
}
