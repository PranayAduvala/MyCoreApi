using System;  
using System.Threading.Tasks;  
using Microsoft.Azure.Devices; 
using Microsoft.Azure.Devices.Client;
using PropertiesDto;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;

namespace DotNetIot.Repository.IotDeviceProperties
{
public class IotDeviceProperties
{

      private static string connectionString = "HostName=NxTIoTTraining.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=RlHaCMxWGXDfNA+0BPe7b8WPjOnS+7B7EUAfBQSMOzg=";
   
     public  static RegistryManager registryManager =RegistryManager.CreateFromConnectionString(connectionString);
     public static  DeviceClient client=null;
     public static string myDeviceConnection="HostName=NxTIoTTraining.azure-devices.net;DeviceId=NewTestPranay;SharedAccessKey=Xn4rFtt1TXdr251jaflUdppnApL7c9GhIfAjjCmTDZY=";

     public static  async Task AddReportedPropertiesAsync(string deviceName,ReportedProperties properties)
     {
            if(string.IsNullOrEmpty(deviceName))
            {
                throw new ArgumentNullException("ValidDeviceNamePlease");
            }
            else
            {
              client=DeviceClient.CreateFromConnectionString(myDeviceConnection,Microsoft.Azure.Devices.Client.TransportType.Mqtt);
              TwinCollection reportedProperties, connectivity;
              reportedProperties=new TwinCollection();
              connectivity= new TwinCollection();
              connectivity["type"]="cellular";
              reportedProperties["connectivity"]=connectivity;
              reportedProperties["temparature"]=properties.temperature;
              reportedProperties["pressure"]=properties.pressure;
              reportedProperties["drift"]=properties.drift;
              reportedProperties["accuracy"]=properties.accuracy;
              reportedProperties["supplyVoltageLevel"]=properties.supplyVoltageLevel;
              reportedProperties["fullScale"]=properties.fullScale;
              reportedProperties["frequency"]=properties.frequency;
              reportedProperties["resolution"]=properties.resolution;
              reportedProperties["sensorType"]=properties.sensorType;
              reportedProperties["DateTimeLastAppLaunch"]=properties.dateTimeLastAppLaunch;
              await client.UpdateReportedPropertiesAsync(reportedProperties);
              return;
            }
     }

     public static async Task DesiredPropertiesUpdate(string deviceName)
     {
             client=DeviceClient.CreateFromConnectionString(myDeviceConnection,Microsoft.Azure.Devices.Client.TransportType.Mqtt);
            var device=await registryManager.GetTwinAsync(deviceName);
            TwinCollection desiredProperties, telemetryconfig;
            desiredProperties= new TwinCollection();
            telemetryconfig =new TwinCollection();
            telemetryconfig["frequency"]="5Hz";
            desiredProperties["telemetryconfig"]=telemetryconfig;
            device.Properties.Desired["telemetryconfig"]=telemetryconfig;
            await registryManager.UpdateTwinAsync(device.DeviceId,device,device.ETag);
            return;
     }

     public static async Task<Twin> GetDevicePropertiesAsync(string deviceName)
     {
        var device=await registryManager.GetTwinAsync(deviceName);
        return device;
     }

     public static async Task UpdateDeviceTagProperties(string deviceName)
     {
          if(string.IsNullOrEmpty(deviceName))
            {
                throw new ArgumentNullException("ValidDeviceNamePlease");
            }
            else
            {
              var twin= await registryManager.GetTwinAsync(deviceName);
              var patchData=
              @"{
                tags:{
                  location:{
                       region:'Canada',
                       plant:'IOTPro'
                  }
                }
                }";

                client=DeviceClient.CreateFromConnectionString(myDeviceConnection,Microsoft.Azure.Devices.Client.TransportType.Mqtt);
              TwinCollection  connectivity;
              connectivity= new TwinCollection();
              connectivity["type"]="cellular";
              await registryManager.UpdateTwinAsync(twin.DeviceId,patchData,twin.ETag);          
              return;
            }
     }
 
 }

}