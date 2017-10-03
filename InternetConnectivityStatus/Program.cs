namespace InternetConnectivityStatus
{
    using System;
    using System.Threading.Tasks;
    using Windows.Networking.Connectivity;

    /// <summary>
    /// The Program Class, defines entry point of application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var consoleForegroundColor = Console.ForegroundColor;
            DateTime startTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{startTime}-INFO-Determining Internet Connectivity Status.");
            Program.DetermineInternetConnectivityStatus();
            DateTime endTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{endTime}-INFO-Completed Determining Internet Connectivity Status. Total Time (ms): {(endTime - startTime).TotalMilliseconds}");
            Console.ForegroundColor = consoleForegroundColor;
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }


        /// <summary>
        /// Determine Internet Connectivity Status
        /// </summary>
        private static void DetermineInternetConnectivityStatus()
        {
            try
            {
                var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
                if (connectionProfile == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{DateTime.Now}-WARNING-Not able to find Internet connection profile to check status.");
                    return;
                }

                var connectivityStatus = connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{DateTime.Now}-INFO-Internet connection status determined as: ");
                Console.ForegroundColor = connectivityStatus ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"{(connectivityStatus ? "Connected" : "Disconnected")}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now}-ERROR-Error on determining Internet connectivity status, Details: {ex}");
            }
        }
    }
}
