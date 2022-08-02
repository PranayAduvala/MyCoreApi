using System.Text;
using Microsoft.Azure.Devices; 
using Microsoft.Azure.Devices.Client;
using PropertiesDto;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;
namespace DotNetIot.Repository.SendTelemetryMessages
{
public class SendTelemetryMessages
{

      private static string connectionString = "HostName=NxTIoTTraining.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=RlHaCMxWGXDfNA+0BPe7b8WPjOnS+7B7EUAfBQSMOzg=";
   
     public  static RegistryManager registryManager ;
     public static  DeviceClient client=null;
     public static string myDeviceConnection="HostName=NxTIoTTraining.azure-devices.net;DeviceId=NewTestPranay;SharedAccessKey=Xn4rFtt1TXdr251jaflUdppnApL7c9GhIfAjjCmTDZY=";

     public static async Task SendMessage(string deviceName)
     {
        try{
        registryManager =RegistryManager.CreateFromConnectionString(connectionString);
        var device= await registryManager.GetTwinAsync(deviceName);
        ReportedProperties properties=new ReportedProperties();
        TwinCollection reportedProp;
        reportedProp=device.Properties.Reported;
         client=DeviceClient.CreateFromConnectionString(myDeviceConnection,Microsoft.Azure.Devices.Client.TransportType.Mqtt);
       while(true)
       {
        var telemetry=new{
            temperature=reportedProp["temparature"],
            pressure=reportedProp["pressure"],
            drift=reportedProp["drift"],
            accuracy=reportedProp["accuracy"],
            supplyVoltageLevel=reportedProp["supplyVoltageLevel"],
            fullScale=reportedProp["fullScale"],
            frequency=reportedProp["frequency"],
            resolution=reportedProp["resolution"],
            sensorType=reportedProp["sensorType"]
        };
        var telemetryString=JsonConvert.SerializeObject(telemetry);
        var message=new  Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(telemetryString));
        await client.SendEventAsync(message);
        Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, telemetryString);

        await Task.Delay(1000);
       }
       
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
     }


}

}