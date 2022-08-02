using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Microsoft.AspNetCore.Mvc;
using DotNetIot.Repository.FileStorage;
namespace MyCoreApi.FileStorageController;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
      [HttpPost("CreateFile")]
      public async Task CreateFile(string fileName)
      {    
         await FileStorages.CreateFile(fileName);
      }
       [HttpPost("CreateDirectory")]
      public async Task CreateDirectory(string directoryName, string fileName)
      {    
         await FileStorages.CreateDirectory(directoryName,fileName);
      }
       [HttpPut("UploadFile")]
        public async Task UploadFile(IFormFile file,string directoryName, string fileShareName)
      {    
         await FileStorages.UploadFile(file,directoryName,fileShareName);
      }
      [HttpDelete("DeleteDirectory")]
      public  async Task DeleteDirectory(string directoryName,string fileShareName)
      {
        await FileStorages.DeleteDirectory(directoryName,fileShareName);
      }
      [HttpDelete("DeleteFile")]
      public async Task DeleteFile(string directoryName,string fileShareName,string fileName)
      {
        await FileStorages.DeleteFile(directoryName,fileShareName,fileName);
      }
      [HttpGet("GetAllFiles")]
      public async Task<List<string>> GetAllFiles(string directoryName,string fileShareName)
      {
        var data=   await FileStorages.GetAllFiles(directoryName,fileShareName);
        return data;
      }
   [HttpGet("DownloadFile")]
        public async Task DownloadFile(string directoryName,string fileShareName,string fileName)
         {
           await FileStorages.DownloadFile(directoryName,fileShareName,fileName);
        
         }
}