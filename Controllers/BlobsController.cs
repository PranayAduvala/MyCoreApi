using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using DotNetIot.Repository.BlobStorage;
namespace MyCoreApi.IotDeviceControllers;

[ApiController]
[Route("[controller]")]
public class BlobsController : ControllerBase
{
     [HttpPost("AddBlob")]
      public async Task<string > AddBlob(string blobName)
      {
        
         await BlobStorage.CreateBlob(blobName);
         return null;
      }

       [HttpDelete("DeleteBlob")]
      public async Task<string > DeleteBlob(string blobName)
      {
        
         await BlobStorage.DeleteBlob(blobName);
         return null;
      }

        [HttpPut("DeleteBlobContent")]
      public async Task<string > DeleteBlobContent(string blobName,string file)
      {
        
         await BlobStorage.DeleteBlobContent(blobName,file);
         return null;
      }

 [HttpPut("UpdateBlobContent")]
      public async Task<BlobProperties> UpdateBlobContent(string blobName,string file)
      {
         await BlobStorage.UpdateBlobContent(blobName,file);
         return null;
      }

 [HttpGet("GetBlobContent")]
  public async Task<BlobProperties> GetBlobContent(string blobName,string file)
      {
       var data=  await BlobStorage.getBlobContent(blobName,file);
         return data;
      }

 [HttpGet("GetBlob")]
      public async Task<List<string>> GetBlob(string blobName,string file)
      {
         var data=  await BlobStorage.GetBlob(blobName,file);
         return data;
      }
       [HttpGet("DownloadBlobContent")]
      public async  Task<BlobProperties> DownloadBlob(string blobName,string file)
      {
         var data=  await BlobStorage.DownloadBlob(blobName,file);
         return data;
      }

}