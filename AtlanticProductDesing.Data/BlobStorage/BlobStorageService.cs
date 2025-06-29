namespace AtlanticProductDesing.Infrastruture.BlobStorage
{
    //public class BlobStorageService : IBlobStorageService
    //{
    //    private readonly BlobServiceClient _blobServiceClient;


    //    public BlobStorageService(string sasUrl)
    //    {
    //        _blobServiceClient = new BlobServiceClient(new Uri(sasUrl));
    //    }

    //    public async Task<BlobDetail> UploadFileAsync(string containerName, string blobName, Stream fileStream)
    //    {
    //        var uniqueBlobName = $"{Guid.NewGuid()}_{blobName}";
    //        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
    //        var blobClient = containerClient.GetBlobClient(uniqueBlobName);
    //        await blobClient.UploadAsync(fileStream, true);

    //        // Crear y devolver los detalles del blob
    //        var blobDetails = new BlobDetail
    //        {
    //            ContainerName = containerName,
    //            BlobName = uniqueBlobName,
    //            BlobUrl = blobClient.Uri.ToString(),
    //            FileSize = fileStream.Length
    //        };

    //        return blobDetails;
    //    }

    //    public async Task<Stream> DownloadFileAsync(string containerName, string blobName)
    //    {
    //        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
    //        var blobClient = containerClient.GetBlobClient(blobName);
    //        var downloadInfo = await blobClient.DownloadAsync();
    //        return downloadInfo.Value.Content;
    //    }

    //    public async Task<Stream> DownloadFileByUrlAsync(string blobUrl)
    //    {
    //        var blobClient = new BlobClient(new Uri(blobUrl));
    //        var downloadInfo = await blobClient.DownloadAsync();
    //        return downloadInfo.Value.Content;
    //    }

    //    public async Task<IEnumerable<Stream>> DownloadFilesAsync(IEnumerable<string> blobUrls)
    //    {
    //        var tasks = new List<Task<Stream>>();

    //        foreach (var blobUrl in blobUrls)
    //        {
    //            tasks.Add(DownloadFileByUrlAsync(blobUrl));
    //        }

    //        return await Task.WhenAll(tasks);
    //    }

    //    public async Task<IEnumerable<Stream>> DownloadFilesAsync(string containerName, IEnumerable<string> filesName)
    //    {
    //        var tasks = new List<Task<Stream>>();

    //        foreach (var fileName in filesName)
    //        {
    //            tasks.Add(DownloadFileAsync(containerName, fileName));
    //        }

    //        return await Task.WhenAll(tasks);
    //    }
    //}
}
