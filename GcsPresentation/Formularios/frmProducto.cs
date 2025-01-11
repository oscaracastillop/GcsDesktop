using GcsPresentation.Utilidades;
using GcsPresentation.Utilidades.Objetos;
using GcsPresentation.ViewModels;
using GcsRepository.Entities;
using GcsServices.Interfaces;
using System.Data;

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
            textBoxPrecioCompraNuevo.ValidarNumero();
            textBoxPrecioCompraEditar.ValidarNumero();
            textBoxPrecioVentaNuevo.ValidarNumero();
            textBoxPrecioVentaEditar.ValidarNumero();
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
            MostrarTap(tabNuevo.Name);
            comboBoxCategoriaNuevo.SelectedIndex = 0;
            textBoxCodigoNuevo.Text = "";
            textBoxDescripcionNuevo.Text = "";
            textBoxPrecioCompraNuevo.Text = "";
            textBoxPrecioVentaNuevo.Text = "";
            textBoxCantidadNuevo.Value = 0;
            comboBoxCategoriaNuevo.Select();
            //tabControlMain.SelectedTab = tabControlMain.TabPages[tabNuevo.Name];            
        }

        private void btnVolverNuevo_Click(object sender, EventArgs e)
        {
            MostrarTap(tabLista.Name);
        }

        private async void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            if (textBoxCodigoNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el código");
                return;
            }

            if (textBoxDescripcionNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar la descripción");
                return;
            }

            if (textBoxPrecioCompraNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el Precio de Compra");
                return;
            }

            if (textBoxPrecioVentaNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el Precio de Venta");
                return;
            }

            if (textBoxCantidadNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar la Cantidad");
                return;
            }

            decimal preciocompra = 0;
            decimal precioventa = 0;

            if (!decimal.TryParse(textBoxPrecioCompraNuevo.Text, out preciocompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                textBoxPrecioCompraNuevo.Select();
                return;
            }

            if (!decimal.TryParse(textBoxPrecioVentaNuevo.Text, out precioventa))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                textBoxPrecioVentaNuevo.Select();
                return;
            }

            var objeto = new Producto
            {
                RefCategoria = new Categoria { IdCategoria = ((OpcionCombo)comboBoxCategoriaNuevo.SelectedItem!).Valor },
                Codigo = textBoxCodigoNuevo.Text.Trim(),
                Descripcion = textBoxDescripcionNuevo.Text.Trim(),
                PrecioCompra = preciocompra,
                PrecioVenta = precioventa,
                Cantidad = Convert.ToInt32(textBoxCantidadNuevo.Value)
            };

            var respuesta = await _productoService.Crear(objeto);

            if (respuesta != "")
            {
                MessageBox.Show(respuesta);
            }
            else
            {
                await MostrarProductos();
                MostrarTap(tabLista.Name);
            }
        }

        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewProductos.Columns[e.ColumnIndex].Name == "ColumnaAccion")
            {
                var productoSeleccionado = (ProductoVM)dataGridViewProductos.CurrentRow.DataBoundItem;

                comboBoxCategoriaEditar.EstablecerValor(productoSeleccionado.IdCategoria);
                textBoxCodigoEditar.Text = productoSeleccionado.Codigo;
                textBoxDescripcionEditar.Text = productoSeleccionado.Descripcion;
                textBoxPrecioCompraEditar.Text = productoSeleccionado.PrecioCompra;
                textBoxPrecioVentaEditar.Text = productoSeleccionado.PrecioVenta;
                textBoxCantidadEditar.Value = productoSeleccionado.Cantidad;
                comboBoxHabilitado.EstablecerValor(productoSeleccionado.Activo);

                MostrarTap(tabEditar.Name);
                comboBoxCategoriaEditar.Select();
            }
        }

        private void btnVolverEditar_Click(object sender, EventArgs e)
        {
            MostrarTap(tabLista.Name);
        }

        private async void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            if (textBoxCodigoEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el código");
                return;
            }

            if (textBoxDescripcionEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar la descripción");
                return;
            }

            if (textBoxPrecioCompraEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el Precio de Compra");
                return;
            }

            if (textBoxPrecioVentaEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el Precio de Venta");
                return;
            }

            if (textBoxCantidadEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar la Cantidad");
                return;
            }

            decimal preciocompra = 0;
            decimal precioventa = 0;

            if (!decimal.TryParse(textBoxPrecioCompraEditar.Text, out preciocompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                textBoxPrecioCompraEditar.Select();
                return;
            }

            if (!decimal.TryParse(textBoxPrecioVentaEditar.Text, out precioventa))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                textBoxPrecioVentaEditar.Select();
                return;
            }

            var productoSeleccionado = (ProductoVM)dataGridViewProductos.CurrentRow.DataBoundItem;

            var objeto = new Producto
            {
                IdProducto = productoSeleccionado.IdProducto,
                RefCategoria = new Categoria { IdCategoria = ((OpcionCombo)comboBoxCategoriaEditar.SelectedItem!).Valor },
                Codigo = textBoxCodigoEditar.Text.Trim(),
                Descripcion = textBoxDescripcionEditar.Text.Trim(),
                PrecioCompra = preciocompra,
                PrecioVenta = precioventa,
                Cantidad = Convert.ToInt32(textBoxCantidadEditar.Value),
                Activo = ((OpcionCombo)comboBoxHabilitado.SelectedItem!).Valor            
            };

            var respuesta = await _productoService.Editar(objeto);

            if (respuesta != "")
            {
                MessageBox.Show(respuesta);
            }
            else
            {
                await MostrarProductos();
                MostrarTap(tabLista.Name);
            }
        }
    }
}
