using Azure.Data.Tables;
using DetailsDto;
using DotNetIot.Repository.TableStorage;
using Microsoft.AspNetCore.Mvc;
namespace MyCoreApi.TableStorageController;

[ApiController]
[Route("[controller]")]
public class TableController : ControllerBase
{
    [HttpPost("AddTable")]
      public async Task<string > AddTable(string tableName)
      {      
         await TableStorage.AddTable(tableName);
         return null;
      }

      [HttpPut("UpdateTable")]
      public async Task<Details> Updatetable(Details employee,string tableName)
      {
       var data= await TableStorage.Updatetable(employee,tableName);
         return data;
      }
      
        [HttpGet("GetTableData")]
      public async Task<Details> GetTableData(string tableName,string department,string id)
      {
        var data= await TableStorage.GetTableData(tableName,department,id);
        return data;
      }
        [HttpGet("GetTable")]
      public async Task<TableClient> GetTable(string tableName)
      {
        var data= await TableStorage.GetTable(tableName);
        return data;
      }
[HttpDelete("DeleteTableData")]
      public async Task DeleteTableData(string tableName,string department,string id)
      {
             await TableStorage.DeleteTableData(tableName,department,id);
             return;
      }
}
