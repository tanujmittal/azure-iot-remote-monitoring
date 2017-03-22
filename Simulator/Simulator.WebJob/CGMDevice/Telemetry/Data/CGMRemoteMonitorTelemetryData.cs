namespace Microsoft.Azure.Devices.Applications.RemoteMonitoring.Simulator.WebJob.CGMDevice.Telemetry.Data
{
    public class CGMRemoteMonitorTelemetryData
    {
        public string DeviceId { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double? ExternalTemperature { get; set; }
    }
}
