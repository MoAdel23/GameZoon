
namespace GameZone.Services;

public class FileService : IFileService
{
    

    public async Task<string> SaveFileAsync(IFormFile file, string path)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        var filesPath = Path.Combine(path, fileName);


        using var stream = File.Create(filesPath);
        await file.CopyToAsync(stream);


        return fileName;
    }

    public void RemoveFile(string fileName, string path)
    {
        var filesPath = Path.Combine(path, fileName);

        File.Delete(filesPath);
    }
}
