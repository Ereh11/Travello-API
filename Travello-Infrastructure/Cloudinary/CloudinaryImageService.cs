using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Cloudinary;

public class CloudinaryImageService : IImageRepository
{
    private readonly ICloudinary _cloudinary;

    public CloudinaryImageService(IOptions<CloudinarySettings> options)
    {
        var settings = options.Value;
        var account = new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret);
        _cloudinary = new CloudinaryDotNet.Cloudinary(account); // Fixed: Fully qualify the Cloudinary class
    }

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        await using var stream = file.OpenReadStream();
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream),
            Folder = "my_project_images"
        };

        var result = await _cloudinary.UploadAsync(uploadParams);

        if (result.StatusCode == System.Net.HttpStatusCode.OK)
            return result.SecureUrl.ToString();

        throw new Exception("Image upload failed.");
    }
}
