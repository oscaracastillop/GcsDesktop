using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using GcsServices.Interfaces;
using GcsServices.Recursos.Cloudinary;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace GcsServices.Implementation
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly IConfiguration _configuration;
        private Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            _configuration = configuration;
            var CloudName = _configuration["Cloudinary:CloudName"];
            var ApiKey = _configuration["Cloudinary:ApiKey"];
            var ApiSecret = _configuration["Cloudinary:ApiSecret"];

            _cloudinary = new Cloudinary(new Account(CloudName, ApiKey, ApiSecret));

        }
        public async Task<CloudinaryResponse> SubirImagen(string nombreImagen, Stream formatoImagen)
        {
            var cloudinaryResponse = new CloudinaryResponse();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(nombreImagen, formatoImagen),
                AssetFolder = "GcsImagesNegocio"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if(uploadResult.StatusCode == HttpStatusCode.OK)
            {
                cloudinaryResponse.PublicId = uploadResult.PublicId;
                cloudinaryResponse.SecureUrl = uploadResult.SecureUrl.ToString();
            }
            else
            {
                cloudinaryResponse.PublicId = "";
            }
            return cloudinaryResponse;
        }
        public async Task<bool> EliminarImagen(string publicid)
        {
            var deleteParams = new DeletionParams(publicid);
            var deleteResult = await _cloudinary.DestroyAsync(deleteParams);

            if (deleteResult.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }        
    }
}
