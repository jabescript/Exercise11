using Azure.Storage.Blobs;

namespace Exercise11API.Services;

public class StorageService : IStorageService
{
    private readonly string _storageConnectionString;
    private readonly string _storageContainerName;
    private readonly ILogger _logger;

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

    public async Task<string> UploadFileToAzureStorage(IFormFile blob)
    {
        BlobContainerClient containerClient = new(_storageConnectionString, _storageContainerName);

        await containerClient.CreateIfNotExistsAsync();

        try
        {
            // Get a reference to the blob just uploaded from the API in a container from configuration settings
            BlobClient client = containerClient.GetBlobClient(blob.FileName);

            await using (Stream? data = blob.OpenReadStream())
            {
                // Upload the file async
                await client.UploadAsync(data);
            }

            return client.Uri.AbsoluteUri;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
