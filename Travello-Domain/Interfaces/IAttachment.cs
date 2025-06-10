using Microsoft.AspNetCore.Http;

namespace Travello_Domain.Interfaces;

public interface IAttachment
{
    Task<string> UploadAsync(IFormFile file);

}
