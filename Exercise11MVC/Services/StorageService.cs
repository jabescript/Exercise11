using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Exercise11MVC.Services;

public class StorageService : IStorageService
{
    private readonly string _fullUri;
    private readonly CloudBlobContainer _container;
    private readonly string _storageConnectionString;
    private readonly string _storageContainerName;

    public StorageService(IConfiguration configuration)
    {
        _storageConnectionString = configuration.GetValue<string>("BlobConnectionString");
        _storageContainerName = configuration.GetValue<string>("BlobContainerName");
    }

    public static bool IsImage(IFormFile file)
    {
        if (file.ContentType.Contains("image"))
        {
            return true;
        }

        string[] formats = [".jpg", ".png", ".gif", ".jpeg"];

        return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<string> UploadFile(Stream fileStream, string fileName)
    {
        var blobBlock = _container.GetBlockBlobReference(fileName);
        await blobBlock.UploadFromStreamAsync(fileStream);

        string link = _fullUri + fileName;
        return blobBlock.Uri.AbsoluteUri;
    }

    public string UploadFileToAzureStorage(IFormFile blob)
    {

        BlobContainerClient container = new(_storageConnectionString, _storageContainerName);
        BlobClient client = container.GetBlobClient(blob.FileName);

        using MemoryStream fileUploadStream = new();
        blob.CopyTo(fileUploadStream);
        fileUploadStream.Position = 0;

        client.Upload(fileUploadStream, new BlobUploadOptions()
        {
            HttpHeaders = new BlobHttpHeaders
            {
                ContentType = "image/bitmap"
            }
        }, cancellationToken: default);

        return client.Uri.AbsoluteUri;
    }

}

    //public async Task<string> UploadFileToAzureStorage(IFormFile blob)
    //{
    //    BlobContainerClient containerClient = new(_storageConnectionString, _storageContainerName);

    //    await containerClient.CreateIfNotExistsAsync();

    //    try
    //    {
    //        // Get a reference to the blob just uploaded from the API in a container from configuration settings
    //        BlobClient client = containerClient.GetBlobClient(blob.FileName);

    //        await using (Stream? data = blob.OpenReadStream())
    //        {
    //            // Upload the file async
    //            await client.UploadAsync(data);
    //        }

    //        return client.Uri.ToString();
    //    }
    //    catch (Exception ex)
    //    {
    //        return ex.Message;
    //    }
    //}


