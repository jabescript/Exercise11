namespace Exercise11API.Services;

public interface IStorageService
{
    //async Task<bool> UploadFileToAzureStorage(IFormFile file);
    Task<string> UploadFileToAzureStorage(IFormFile blob);
}
