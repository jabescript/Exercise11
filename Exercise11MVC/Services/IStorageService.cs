namespace Exercise11MVC.Services;

public interface IStorageService
{
    //async Task<bool> UploadFileToAzureStorage(IFormFile file);
    Task<string> UploadFile(Stream filesStream, string filename);

    string UploadFileToAzureStorage(IFormFile blob);
}
