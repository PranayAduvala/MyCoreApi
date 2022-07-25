using Microsoft.AspNetCore.Mvc;
using IotTest;
using Microsoft.Azure.Devices;  
namespace MyCoreApi.IotDeviceControllers;

[ApiController]
[Route("[controller]")]
public class IotDeviceControllers : ControllerBase
{
 
   [HttpPost("AddIotDevice")]
      public async Task<string> AddDevice(string deviceName)
      { 
      await IotDevice.AddDeviceAsync(deviceName);
      return null;
      }

   [HttpGet("GetIotDevice")]
         public async Task<Device> GetIotDevice(string deviceName)
      {
           Device device;
           device=await IotDevice.GetDeviceAsync(deviceName);
           return device;
      }

      [HttpDelete("DeleteIotDevice")]
      public async Task<string > DeleteIotDevice(string deviceName)
      {
        
          await IotDevice.DeleteDeviceAsync(deviceName);
         return null;
      }

       [HttpPut("UpdateIotDevice")]
      public async Task<Device > UpdateDeviceProperties(string deviceName)
      {
        Device device;
       device=   await IotDevice.UpdateDeviceAsync(deviceName);
         return device;
      }

}