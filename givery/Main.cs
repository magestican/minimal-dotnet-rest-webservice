using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text.RegularExpressions;
using System.Web;

namespace givery
{
    public class Program
    {

        static void Main(string[] args)
        {
            ServiceHost svcHost = null;
            try
            {
                string port = " ";
                Regex regex = new Regex("^[0-9]+$");

                while (!regex.IsMatch(port))
                {
                    Console.WriteLine("Type the port address were you want to host the service (type 80 for default aka plain localhost)");
                    port = Console.ReadLine();
                }
                //Base Address for StudentService
                Uri httpBaseAddress = new Uri("http://localhost:" + port + "/api");

                //Instantiate ServiceHost
                svcHost = new ServiceHost(typeof(givery.api),
                    httpBaseAddress);



                //Open
                svcHost.Open();
                Console.WriteLine("Service is live now at : {0}", httpBaseAddress);
             
            }
            catch (Exception eX)
            {
                svcHost = null;
                Console.WriteLine("Service can not be started \n\nError Message [" + eX.Message + "]");
                Console.Read();
            } if (svcHost != null)
            {
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
                svcHost.Close();
                svcHost = null;
            }
        }
    }
}