using System.Collections;
using System.Collections.Generic;
using System.Net;
using Open.Nat;

namespace NBlockchain.Interfaces
{
    public interface IProvideUpnpDevice
    {
        IPAddress GetExternalIp();
        void CreateMapping(int internalPort, int externalPort, string mappingIdentifier);
        IEnumerable<Mapping> GetAllMappings();
    }

    public class OpenNatUpnpProvider : IProvideUpnpDevice
    {
        private readonly NatDevice _device;

        public OpenNatUpnpProvider()
        {
            //var devicetask = new NatDiscoverer().DiscoverDeviceAsync();
            //devicetask.Wait();
            //_device = devicetask.Result;
        }
        public IPAddress GetExternalIp()
        {
            //var ipTask = _device.GetExternalIPAsync();
            //ipTask.Wait();
            return new IPAddress(new byte[] { 127, 0, 0, 1 }); //ipTask.Result;
        }

        public void CreateMapping(int internalPort, int externalPort, string mappingIdentifier)
        {
            _device.CreatePortMapAsync(new Mapping(Protocol.Tcp, internalPort, externalPort, mappingIdentifier));
        }

        public IEnumerable<Mapping> GetAllMappings()
        {
            //var mappingsTask = _device.GetAllMappingsAsync();
            //mappingsTask.Wait();
            return new List<Mapping>() { new Mapping(Protocol.Tcp, new IPAddress(new byte[] { 192, 168, 195, 91 }), 27017, 49151, 5000, "My Currency") };
        }
    }
}