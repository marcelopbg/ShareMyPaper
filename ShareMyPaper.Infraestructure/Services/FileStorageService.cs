using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShareMyPaper.Application.Interfaces.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ShareMyPaper.Infraestructure.Services;
public class FileStorageService : IFileStorageService
{
    private readonly IConfiguration _configuration;
    public FileStorageService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Stream> GetFile(string documentId)
    {
        var containerName = "documents";
        var blobClient = new BlobContainerClient(_configuration["AzureStorage"], containerName).GetBlobClient(documentId);
        var response = await blobClient.DownloadStreamingAsync();
        return response.Value.Content;

    }

    public async Task<string> UploadFileToStorage(IFormFile file)
    {
        var containerName = "documents";
        BlobContainerClient containerClient = new(_configuration["AzureStorage"], containerName);

        using var stream = file.OpenReadStream();
        var fileName = Guid.NewGuid().ToString();
        await containerClient.UploadBlobAsync(fileName, stream);
        return fileName;
    }
}
