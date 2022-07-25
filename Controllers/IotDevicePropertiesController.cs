using Microsoft.AspNetCore.Mvc;
using DotNetIot.Repository.IotDeviceProperties;
using Microsoft.Azure.Devices; 
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using PropertiesDto; 
namespace MyCoreApi.IotDeviceControllers;

[ApiController]
[Route("[controller]")]
public class IotDevicePropertiesControllers : ControllerBase
{
     [HttpPut("UpdateIotDeviceReportedProperties")]
      public async Task<string > UpdateIotDeviceReportedProperties(string deviceName,ReportedProperties properties)
      {
        
         await IotDeviceProperties.AddReportedPropertiesAsync(deviceName,properties);
         return null;
      }

      [HttpPut("UpdateIotDeviceDesiredProperties")]
      public async Task<string > UpdateIotDeviceDesiredProperties(string deviceName)
      {
        
         await IotDeviceProperties.DesiredPropertiesUpdate(deviceName);
         return null;
      }

 [HttpPut("UpdateIotDeviceTagProperties")]
      public async Task<string > UpdateIotDeviceTagProperties(string deviceName)
      {
        
         await IotDeviceProperties.UpdateDeviceTagProperties(deviceName);
         return null;
      }

       [HttpGet("GetIotDeviceProperties")]
         public async Task<Twin> GetIotDevice(string deviceName)
      {
        
          var device=await IotDeviceProperties.GetDevicePropertiesAsync(deviceName);
           return device;
      }
}