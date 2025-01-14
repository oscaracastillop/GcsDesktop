using GcsServices.Recursos.Cloudinary;

namespace GcsServices.Interfaces
{
    public interface ICloudinaryService
    {
        Task<CloudinaryResponse> SubirImagen(string nombreImagen, Stream formatoImagen);
        Task<bool> EliminarImagen(string publicid);
    }
}
