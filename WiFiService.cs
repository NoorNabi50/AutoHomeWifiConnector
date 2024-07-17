using ManagedNativeWifi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WiFiManager
{
    internal class WiFiService
    {

        
        private AvailableNetworkPack getBestAvailableNetwork() {
            var availabeNetworks = NativeWifi.EnumerateAvailableNetworks();
            if(!availabeNetworks.Any())
            {
                throw new Exception("No wifi Network Available");
            }
            return availabeNetworks.Where(network => !string.IsNullOrEmpty(network.ProfileName)).
                                    OrderByDescending(network => network.SignalQuality).
                                    FirstOrDefault();
        }

        private bool connectBestNetwork()
        {
            AvailableNetworkPack bestNetwork = getBestAvailableNetwork();
            bool isConnected = NativeWifi.ConnectNetwork(
                      bestNetwork.Interface.Id,
                      bestNetwork.ProfileName,
                      bestNetwork.BssType,
                      null);
            return isConnected;
        }

        public void connectBestWifiNetwork()
        {
            connectBestNetwork();
            Console.WriteLine("Wifi with best signal Connected");
        }

    }
}
