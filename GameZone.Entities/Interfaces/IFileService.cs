



namespace GameZone.Entities.Interfaces;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file , string path );
    void RemoveFile(string fileName , string path );
}
