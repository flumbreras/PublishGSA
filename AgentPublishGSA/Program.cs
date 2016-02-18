using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Diagnostics;

namespace AgentPublishGSA
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            service();            
        }

        private static void program()
        {
            GSAPublishingServer server = new GSAPublishingServer();
            try
            {
                Process.Start("http://localhost:8084/gsa/FreePort/");
            }
            catch (Exception)
            {
            }
            Console.WriteLine("Server running at {0} - press Enter to quit. ", "http://localhost:8084");

            Console.ReadLine();
            server.end();
        }

        private static void service()
        {
            LogFile.Log.Write("Instantiating Windows Service.");
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new AgentGSAService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
