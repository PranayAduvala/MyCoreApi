using System;  
using System.Threading.Tasks;  
using Microsoft.Azure.Devices;  
using Microsoft.Azure.Devices.Common.Exceptions;

namespace IotTest
{
    public class IotDevice
    {
        public  static RegistryManager registryManager;
      private static string connectionString = "HostName=NxTIoTTraining.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=RlHaCMxWGXDfNA+0BPe7b8WPjOnS+7B7EUAfBQSMOzg=";
        public static async Task AddDeviceAsync(string deviceName)
        {
              if(string.IsNullOrEmpty(deviceName))
              {
              throw new ArgumentNullException("deviceNamePlease");
              }
              Device device;
              registryManager=RegistryManager.CreateFromConnectionString(connectionString);
              device=await registryManager.AddDeviceAsync(new Device(deviceName));
              return  ;
        }

        public static async Task<Device> GetDeviceAsync(string deviceId)
        {
             Device device;
             registryManager= RegistryManager.CreateFromConnectionString(connectionString);
             device= await registryManager.GetDeviceAsync(deviceId);
             return device; 
        }

        public static async Task DeleteDeviceAsync(string deviceId)
        {
          
             registryManager= RegistryManager.CreateFromConnectionString(connectionString);
              await registryManager.RemoveDeviceAsync(deviceId);
        }


        public static async Task<Device> UpdateDeviceAsync(string deviceId)
        {
          if(string.IsNullOrEmpty(deviceId))
              {
              throw new ArgumentNullException("deviceNamePlease");
              }

              Device device=new Device(deviceId);
              registryManager= RegistryManager.CreateFromConnectionString(connectionString);
              device=await registryManager.GetDeviceAsync(deviceId);
              device.StatusReason="UpdatedSuccessfully";
              device=await registryManager.UpdateDeviceAsync(device);
              return device;
        }

    }
}

