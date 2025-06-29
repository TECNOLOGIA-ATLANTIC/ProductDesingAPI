using AtlanticProductDesing.Application.Contracts.Infrastructure;
using AtlanticProductDesing.Application.Extensions;
using AtlanticProductDesing.Application.Models;
using Microsoft.Extensions.Hosting;
using NLog;

namespace AtlanticProductDesing.Infrastruture.Services
{
    public class FileSystemService : IFileSystemService
    {
        private readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IHostEnvironment _environment;

        private string DirectoryFile = Path.Combine("Assets", "Image");
        private Byte[]? FileByte;

        private string FileNameFull;
        private FileBase64 model;

        public FileSystemService(IHostEnvironment environment)
        {
            _environment = environment;
            FileByte = null;
            model = new FileBase64();

        }

        public void Flush()
        {
            FileByte = null;
            model = new FileBase64();
        }

        public string GetFileName()
        {
            return Path.GetRandomFileName().Split(".")[0];
        }

        public string GenerateFileName(string baseNameFile)
        {
            return $"{baseNameFile.Truncate(20, "")}{DateTime.Now:yyyyMMddHHmmsss}";
        }

        public string GetFileNameFull()
        {
            return model.Path;
        }

        public FileBase64 LoadBase64ToModel(string base64, string? name = null)
        {
            string[]? filePart = base64.Split("base64,");
            string[]? extensionPart = filePart[0].Split(";");
            string? extension;
            if (name is not null)
                extension = name.Split(".")[name.Split(".").Length - 1];
            else
                extension = extensionPart[0].Split("/")[1];
            model = new()
            {
                Ext = extension,
                Uri = filePart[0],
                Data = filePart[1]
            };

            return model;
        }


        public async Task WriteBinaryFileAsync(string fileName, string ext, string relativePath, byte[] binary)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                fileName = GetFileName();
            }
            string dirfile = Path.Combine(_environment.ContentRootPath, DirectoryFile);
            if (!String.IsNullOrEmpty(relativePath))
            {
                dirfile = Path.Combine(dirfile, relativePath);
                relativePath = Path.Combine(DirectoryFile, relativePath);
            }

            if (binary == null) return;

            if (!Directory.Exists(dirfile)) Directory.CreateDirectory(dirfile);

            model.Path = SetPath(relativePath, fileName, ext);

            await using FileStream fs = File.Create(model.Path);
            foreach (byte b in binary)
            {
                fs.WriteByte(b);
            }

        }

        private string SetPath(string dirfile, string fileName, string ext)
        {
            int repeatFile = 1;

            string path = Path.Combine(dirfile, $"{fileName}.{ext}");
            string fullPath = Path.Combine(_environment.ContentRootPath, path);
            while (File.Exists(fullPath))
            {
                path = Path.Combine(dirfile, $"{fileName}-{repeatFile}.{ext}");
                repeatFile++;
                fullPath = Path.Combine(_environment.ContentRootPath, path);

            }
            return path;

        }

        public async Task WriteBinaryFileAsync(string fileName, string ext, byte[] binary)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                fileName = GetFileName();
            }
            string dirfile = Path.Combine(_environment.ContentRootPath, DirectoryFile);

            model.Path = SetPath(DirectoryFile, fileName, ext);

            if (binary == null) return;

            if (!Directory.Exists(dirfile)) Directory.CreateDirectory(dirfile);
            await using FileStream fs = File.Create(model.Path);
            foreach (byte b in binary)
            {
                fs.WriteByte(b);
            }

        }


        public async Task<Byte[]> ReadFileToBinaryData(string fileName)
        {
            FileByte = null;
            string dirfile = Path.Combine(_environment.ContentRootPath, fileName);
            await using (FileStream fr = new(dirfile, FileMode.Open))
            {
                using BinaryReader br = new(fr);
                FileByte = br.ReadBytes((int)fr.Length);
            }
            return FileByte;
        }

        public string GetFileNameFromDIrectory(string directory)
        {
            return Path.GetFileName(directory);
        }

        public string FileToBase64(string filePath)
        {
            Byte[] bytes = File.ReadAllBytes(filePath);
            string fileOut = Convert.ToBase64String(bytes);
            return fileOut;
        }

    }
}
