using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentPublishGSA
{
    public class GSAPublishingServer
    {
        
        public GSAPublishingServer()
        {
            start();
        }
        private IDisposable serverProcess;

        public void end()
        {
            LogFile.Log.Write("Ending web Server...");
            if (serverProcess != null)
                serverProcess.Dispose();
        }
        private void start()
        {
            int port = 8084;

            StartOptions options = new StartOptions(String.Format("http://+:{0}/", port))
            {
                ServerFactory = "Microsoft.Owin.Host.HttpListener"
            };
            //Console.WriteLine("Starting web Server...");

            try
            {
                LogFile.Log.Write("Starting web Server...");
                serverProcess = WebApp.Start<Startup>(options);

            }
            catch (Exception e) {
                LogFile.Log.Write(e.Message);
                LogFile.Log.Write(e.StackTrace);
            }
        }

        private void command(String cmd)
        {
            // netsh http show urlacl

            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("runas.exe", "/user:Administrator cmd /K " + cmd);
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = false;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = false;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }
        private void enableUrl(IList<string> urls, string user)
        {
            string cmdFormat = "netsh http add urlacl url={0} user={1}";
            foreach (String url in urls)
            {
                command(String.Format(cmdFormat, url, user));
            }
        }
        private void disableUrl(IList<string> urls)
        {
            string cmdFormat = "netsh http delete urlacl url={0}";
            foreach (String url in urls)
            {
                command(String.Format(cmdFormat, url));
            }
        }
    }
}
