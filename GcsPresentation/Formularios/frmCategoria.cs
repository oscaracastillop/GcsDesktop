using GcsPresentation.Utilidades;
using GcsPresentation.Utilidades.Objetos;
using GcsPresentation.ViewModels;
using GcsRepository.Entities;
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

    public partial class frmCategoria : Form
    {
        private readonly IMedidaService _medidaService;
        private readonly ICategoriaService _categoriaService;

        public frmCategoria(IMedidaService medidaService, ICategoriaService categoriaService)
        {
            InitializeComponent();
            _categoriaService = categoriaService;
            _medidaService = medidaService;
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

        private async Task MostrarCategorias(string buscar = "")
        {
            var listaCategorias = await _categoriaService.Lista(buscar);

            var listaVM = listaCategorias.Select(item => new CategoriaVM
            {
                IdCategoria = item.IdCategoria,
                Nombre = item.Nombre,
                IdMedida = item.RefMedida.IdMedida,
                Medida = item.RefMedida.Nombre,
                Activo = item.Activo,
                Habilitado = item.Activo == 1 ? "Si" : "No"
            }).ToList();

            dataGridViewCategorias.DataSource = listaVM;

            dataGridViewCategorias.Columns["IdCategoria"].Visible = false;
            dataGridViewCategorias.Columns["IdMedida"].Visible = false;
            dataGridViewCategorias.Columns["Activo"].Visible = false;
        }

        private async void frmCategoria_Load(object sender, EventArgs e)
        {
            MostrarTap(tabLista.Name);

            dataGridViewCategorias.ImplementarConfiguracion("Editar");
            dataGridViewCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            await MostrarCategorias();

            OpcionCombo[] itemsHabilitado = new OpcionCombo[] {
                new OpcionCombo {Texto = "Si", Valor = 1 },
                new OpcionCombo {Texto = "No", Valor = 0 }
            };

            var listaMedida = await _medidaService.Lista();
            var items = listaMedida.Select(item => new OpcionCombo
            {
                Texto = item.Nombre,
                Valor = item.IdMedida
            }).ToArray();

            comboBoxMedidaNuevo.InsertarItems(items);
            comboBoxMedidaEditar.InsertarItems(items);

            comboBoxHabilitado.InsertarItems(itemsHabilitado);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await MostrarCategorias(textBoxBuscar.Text);
        }

        private void btnNuevoLista_Click(object sender, EventArgs e)
        {
            textBoxNombreNuevo.Text = "";
            comboBoxMedidaNuevo.SelectedIndex = 0;
            textBoxNombreNuevo.Select();
            tabControlMain.SelectedTab = tabControlMain.TabPages[tabNuevo.Name];

            MostrarTap(tabNuevo.Name);
        }

        private void btnVolverNuevo_Click(object sender, EventArgs e)
        {
            MostrarTap(tabLista.Name);
        }

        private void btnVolverEditar_Click(object sender, EventArgs e)
        {
            MostrarTap(tabLista.Name);
        }

        private async void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            if (textBoxNombreNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar el nombre");
                return;
            }

            var item = (OpcionCombo)comboBoxMedidaNuevo.SelectedItem!;
            var objeto = new Categoria
            {
                Nombre = textBoxNombreNuevo.Text.Trim(),
                RefMedida = new Medida {IdMedida = item.Valor }
            };

            var respuesta = await _categoriaService.Crear(objeto);

            if (respuesta != "") {
                MessageBox.Show(respuesta);
            }
            else
            {
                await MostrarCategorias();
                MostrarTap(tabLista.Name);
            }
        }
    }
}
