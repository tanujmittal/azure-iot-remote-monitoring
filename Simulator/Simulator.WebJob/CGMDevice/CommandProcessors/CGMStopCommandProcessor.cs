using System;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Applications.RemoteMonitoring.Simulator.WebJob.CGMDevice.Devices;
using Microsoft.Azure.Devices.Applications.RemoteMonitoring.Simulator.WebJob.SimulatorCore.CommandProcessors;
using Microsoft.Azure.Devices.Applications.RemoteMonitoring.Simulator.WebJob.SimulatorCore.Transport;

namespace Microsoft.Azure.Devices.Applications.RemoteMonitoring.Simulator.WebJob.CGMDevice.CommandProcessors
{
    /// <summary>
    /// Command processor to stop telemetry data
    /// </summary>
    public class CGMStopCommandProcessor : CommandProcessor
    {
        private const string STOP_TELEMETRY = "StopTelemetry";

        public CGMStopCommandProcessor(CBGMDevice device)
            : base(device)
        {

        }

        public override async Task<CommandProcessingResult> HandleCommandAsync(DeserializableCommand deserializableCommand)
        {
            if (deserializableCommand.CommandName == STOP_TELEMETRY)
            {
                try
                {
                    var device = Device as CBGMDevice;
                    device.StopTelemetryData();
                    return CommandProcessingResult.Success;
                }
                catch (Exception)
                {
                    return CommandProcessingResult.RetryLater;
                }
            }
            else if (NextCommandProcessor != null)
            {
                return await NextCommandProcessor.HandleCommandAsync(deserializableCommand);
            }

            return CommandProcessingResult.CannotComplete;
        }
    }
}
