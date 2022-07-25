using Microsoft.AspNetCore.Mvc;
using DotNetIot.Repository.IotDeviceProperties;
using Microsoft.Azure.Devices; 
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using DotNetIot.Repository.SendTelemetryMessages; 
namespace MyCoreApi.IotDeviceControllers;

[ApiController]
[Route("[controller]")]
public class TelemetryController : ControllerBase
{

 [HttpPost("SendTelemetryMessage")]
      public async Task<string> SendMessage(string deviceName)
      { 
      await SendTelemetryMessages.SendMessage(deviceName);
      return null;
      }

}