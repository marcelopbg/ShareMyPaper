using Microsoft.AspNetCore.Http;

namespace ShareMyPaper.Application.Interfaces.Services;
public interface IFileStorageService
{
    public Task<Stream> GetFile(string documentId);
    public Task<string> UploadFileToStorage(IFormFile file);
}
