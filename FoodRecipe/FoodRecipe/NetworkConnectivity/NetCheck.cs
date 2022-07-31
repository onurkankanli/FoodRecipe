using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipe.NetworkConnectivity
{
    public class NetworkInfo
    {
        static void OnNetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
                Console.WriteLine("Network has become available");
            }
            else
            {
                Console.WriteLine("Network has become unavailable");
            }
        }
    }
}
