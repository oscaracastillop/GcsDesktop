using GcsRepository.Entities;
using System.ComponentModel;

namespace GcsPresentation.ViewModels
{
    public class ProductoVM
    {
        public int IdProducto { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        [DisplayName("Precio Compra")]
        public string PrecioCompra { get; set; }
        [DisplayName("Precio Venta")]
        public string PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public int Activo { get; set; }
        public string Habilitado { get; set; }
    }
}
