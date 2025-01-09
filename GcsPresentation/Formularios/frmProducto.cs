using GcsPresentation.Utilidades.Objetos;
using GcsPresentation.Utilidades;
using GcsPresentation.ViewModels;
using GcsServices.Implementation;
using GcsServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GcsPresentation.Formularios
{
    public partial class frmProducto : Form
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;

        public frmProducto(IProductoService productoService, ICategoriaService categoriaService)
        {
            InitializeComponent();
            _productoService = productoService;
            _categoriaService = categoriaService;
        }
        public void MostrarTap(string tabName)
        {
            var TabsMenu = new TabPage[] { tabLista, tabNuevo, tabEditar };

            foreach (var tab in TabsMenu)
            {
                if (tab.Name != tabName)
                {
                    tab.Parent = null;
                }
                else
                {
                    tab.Parent = tabControlMain;
                }
            }
        }
        private async Task MostrarProductos(string buscar = "")
        {
            var listaproductos = await _productoService.Lista(buscar);

            var listaVM = listaproductos.Select(item => new ProductoVM
            {
                IdProducto = item.IdProducto,
                Codigo = item.Codigo,
                Descripcion = item.Descripcion,
                IdCategoria = item.RefCategoria.IdCategoria,
                Categoria = item.RefCategoria.Nombre,
                PrecioCompra = item.PrecioCompra.ToString("0.00"),
                PrecioVenta = item.PrecioVenta.ToString("0.00"),
                Cantidad = item.Cantidad,
                Activo = item.Activo,
                Habilitado = item.Activo == 1 ? "Si" : "No"
            }).ToList();

            dataGridViewProductos.DataSource = listaVM;

            dataGridViewProductos.Columns["IdProducto"].Visible = false;
            dataGridViewProductos.Columns["IdCategoria"].Visible = false;
            dataGridViewProductos.Columns["Activo"].Visible = false;
            dataGridViewProductos.Columns["Descripcion"].Width = 200;
        }

        private async void frmProducto_Load(object sender, EventArgs e)
        {
            MostrarTap(tabLista.Name);

            dataGridViewProductos.ImplementarConfiguracion("Editar");
            //dataGridViewProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            await MostrarProductos();

            OpcionCombo[] itemsHabilitado = new OpcionCombo[] {
                new OpcionCombo {Texto = "Si", Valor = 1 },
                new OpcionCombo {Texto = "No", Valor = 0 }
            };

            var listaCategoria = await _categoriaService.Lista();
            var items = listaCategoria
                .Where(item => item.Activo == 1)
                .Select(item => new OpcionCombo { Texto = item.Nombre, Valor = item.IdCategoria })
                .ToArray();

            comboBoxCategoriaNuevo.InsertarItems(items);
            comboBoxCategoriaEditar.InsertarItems(items);

            comboBoxHabilitado.InsertarItems(itemsHabilitado);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await MostrarProductos(textBoxBuscar.Text);
        }

        private void btnNuevoLista_Click(object sender, EventArgs e)
        {
            comboBoxCategoriaNuevo.SelectedIndex = 0;
            textBoxCodigoNuevo.Text = "";
            textBoxDescripcionNuevo.Text = "";
            textBoxPrecioCompraNuevo.Text = "";
            textBoxPrecioVentaNuevo.Text = "";
            textBoxCantidadNuevo.Value = 0;
            comboBoxCategoriaNuevo.Select();
            //tabControlMain.SelectedTab = tabControlMain.TabPages[tabNuevo.Name];

            MostrarTap(tabNuevo.Name);
        }

        private void btnVolverNuevo_Click(object sender, EventArgs e)
        {
            MostrarTap(tabLista.Name);
        }
    }
}
