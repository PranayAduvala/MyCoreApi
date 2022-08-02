using Azure.Data.Tables;
using DetailsDto;

namespace DotNetIot.Repository.TableStorage
{

        public class TableStorage
        {
              static string connectionString="DefaultEndpointsProtocol=https;AccountName=simulationdevicedata;AccountKey=Bd7hAg/1GZ5B824iPKpdWtDxkVlELJ71I90kkYZcckYR3zRilKf8Jk9dCGmpx/SZhEJbbCS1bWop1ThPDtwqFg==;EndpointSuffix=core.windows.net";
   
            public static async Task AddTable(string tableName)
            {
                  var data=new TableServiceClient(connectionString);
                  var client= data.GetTableClient(tableName);
                  await client.CreateIfNotExistsAsync();
            }

            public static async Task<Details> Updatetable(Details employee,string tableName)
            {
                    var data=new TableServiceClient(connectionString);
                  var client= data.GetTableClient(tableName);
                  await client.UpsertEntityAsync(employee);
                  return employee;
            }
            public static async Task<Details> GetTableData(string tableName,string department,string id)
            {
                  var data=new TableServiceClient(connectionString);
                  var client= data.GetTableClient(tableName);
                  var tableData=await client.GetEntityAsync<Details>(department,id);
                  return tableData;
            }
            public static async Task<TableClient> GetTable(string tableName)
            {
                 var data=new TableServiceClient(connectionString);
                  var client= data.GetTableClient(tableName);
                  return client;
            }

             public static async Task DeleteTableData(string tableName,string department,string id)
            {
                var data=new TableServiceClient(connectionString);
                  var client= data.GetTableClient(tableName);
                  await client.DeleteEntityAsync(department,id);
                  return;
            }
        }

}