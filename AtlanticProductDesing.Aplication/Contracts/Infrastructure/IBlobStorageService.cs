namespace AtlanticProductDesing.Application.Contracts.Infrastructure
{
    public interface IBlobStorageService
    {
        //Task<BlobDetail> UploadFileAsync(string containerName, string blobName, Stream fileStream);
        Task<Stream> DownloadFileAsync(string containerName, string blobName);

        Task<Stream> DownloadFileByUrlAsync(string blobUrl);

        Task<IEnumerable<Stream>> DownloadFilesAsync(IEnumerable<string> blobUrls);

        Task<IEnumerable<Stream>> DownloadFilesAsync(string containerName, IEnumerable<string> filesName);

    }
}
