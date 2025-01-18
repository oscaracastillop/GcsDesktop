using GcsRepository.Entities;
using GcsServices.Interfaces;
using GcsServices.Recursos.Cloudinary;

namespace GcsPresentation.Formularios
{
    public partial class frmNegocio : Form
    {
        private readonly INegocioService _negocioService;
        private readonly ICloudinaryService _cloudinaryService;
        OpenFileDialog _openFileDialog = new OpenFileDialog();
        Negocio _negocio = new Negocio();

        public frmNegocio(INegocioService negocioService, ICloudinaryService cloudinaryService)
        {
            InitializeComponent();
            _negocioService = negocioService;
            _cloudinaryService = cloudinaryService;
        }

        private async void frmNegocio_Load(object sender, EventArgs e)
        {
            _openFileDialog.Filter = "Escoger imagen (*.JPG;*.PNG) | *.jpg; *.png";
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;

            _negocio = await _negocioService.Obtener();

            textBoxRazonSocial.Text = _negocio.RazonSocial;
            textBoxRuc.Text = _negocio.RUC;
            textBoxDireccion.Text = _negocio.Direccion;
            textBoxCelular.Text = _negocio.Celular;
            textBoxCorreo.Text = _negocio.Correo;
            textBoxSimboloMoneda.Text = _negocio.SimboloMoneda;
            if (_negocio.UrlLogo != "")
            {
                pictureBoxLogo.ImageLocation = _negocio.UrlLogo;
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _openFileDialog.OpenFile();
                pictureBoxLogo.Image = Image.FromFile(_openFileDialog.FileName);

                textBoxRutaImagen.Text = _openFileDialog.FileName;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            //GcsImagesNegocio

            CloudinaryResponse cloudinaryResponse = new CloudinaryResponse();   
            Negocio objeto = new Negocio();

            if (_openFileDialog.FileName != "")
            {
                cloudinaryResponse = await _cloudinaryService.SubirImagen(_openFileDialog.SafeFileName, _openFileDialog.OpenFile());

                if (cloudinaryResponse.PublicId != "")
                {
                    if (_negocio.NombreLogo != "")
                    
                    await _cloudinaryService.EliminarImagen(_negocio.NombreLogo);

                    objeto.NombreLogo = cloudinaryResponse.PublicId;
                    objeto.UrlLogo = cloudinaryResponse.SecureUrl;

                    _negocio.NombreLogo = cloudinaryResponse.PublicId;
                    _negocio.UrlLogo = cloudinaryResponse.SecureUrl;

                }
            }
            else
            {
                objeto.NombreLogo = _negocio.NombreLogo;
                objeto.UrlLogo = _negocio.UrlLogo;
            }

            objeto.RazonSocial = textBoxRazonSocial.Text;
            objeto.RUC = textBoxRuc.Text;
            objeto.Direccion = textBoxDireccion.Text;
            objeto.Celular = textBoxCelular.Text;
            objeto.Correo = textBoxCorreo.Text;
            objeto.SimboloMoneda = textBoxSimboloMoneda.Text;

            await _negocioService.Editar(objeto);
            MessageBox.Show("La información fue Actualizada");

            textBoxRutaImagen.Text = "";
            //_openFileDialog.FileName = "";
            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "Escoger imagen (*.JPG;*.PNG) | *.jpg; *.png";
        }
    }
}
