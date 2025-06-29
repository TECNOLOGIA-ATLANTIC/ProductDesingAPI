using AtlanticProductDesing.Application.Models;

namespace AtlanticProductDesing.Application.Contracts.Infrastructure
{
    public interface IFileSystemService
    {
        string GetFileName();
        string GetFileNameFull();
        FileBase64 LoadBase64ToModel(string base64, string? name = null);
        Task WriteBinaryFileAsync(string fileName, string ext, byte[] binary);
        Task WriteBinaryFileAsync(string fileName, string ext, string relativePath, byte[] binary);
        Task<Byte[]> ReadFileToBinaryData(string url);
        string GetFileNameFromDIrectory(string directory);
        string GenerateFileName(string baseNameFile);
        string FileToBase64(string filePath);
    }
}
