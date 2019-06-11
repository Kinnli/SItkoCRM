using System.Threading.Tasks;

namespace SitkoCRM.Components.Storage
{
    public interface IStorage
    {
        Task<StorageItem> SaveFileAsync(byte[] file, string fileName, string path);
        Task<bool> DeleteFileAsync(string filePath);
    }
}
