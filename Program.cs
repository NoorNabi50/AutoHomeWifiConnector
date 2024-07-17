using ManagedNativeWifi;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WiFiManager
{

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WiFiService wifiService = new WiFiService();
                wifiService.connectBestWifiNetwork();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}