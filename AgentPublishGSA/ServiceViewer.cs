using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;

namespace AgentPublishGSA
{
    public class ServiceViewer
    {
        private bool[] status;
        private bool[] Status
        {
            get
            {
                if (status == null)
                {
                    status = new bool[65536];
                }
                return status;
            }
        }
        private Socket socket;

        private int low;
        private int high;
        private int lastFreePort;

        public ServiceViewer(int low, int high)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Unspecified);
            this.low = (low < 0 ? 0 : low);
            lastFreePort = low;
            this.high = (high > Status.Length - 1 ? Status.Length - 1 : high);
        }
        public IEnumerable<Int32> getFreePorts()
        {
            IList<Int32> freePorts = new List<Int32>();
            CheckServices();
            bool[] busyPorts = Status;
            low = (low < 0 ? 0 : low);
            high = (high > Status.Length - 1 ? Status.Length - 1 : high);
            for (int port = low; port < high; port++)
            {
                if (!busyPorts[port])
                {
                    freePorts.Add(port);
                }
            }
            return freePorts.ToArray<Int32>();
        }

        private bool isOpenEnabled(int port)
        {
            // TODO:
            return true;
        }

        public int nextFreePort()
        {
            int result = -1;
            CheckServices();
            lastFreePort++;
            if (lastFreePort > high)
            {
                lastFreePort = low;
            }
            for (int port = lastFreePort; port <= high; port++)
            {
                if (!Status[port])
                {
                    result = port;
                    break;
                }
            }
            if (result == -1)
            {
                for (int port = low; port <= high; port++)
                {
                    if (!Status[port])
                    {
                        result = port;
                        break;
                    }
                }
            }
            lastFreePort = result;
            return result;
        }

        public void CheckServices()
        {
            bool[] busyPorts = loadBusyPorts();
            bool[] antBusyPorts = Status;
            low = (low < 0 ? 0 : low);
            high = (high > Status.Length - 1 ? Status.Length - 1:high);
            for (int port = low;port< high; port++)
            {
                if (busyPorts[port] && !antBusyPorts[port])
                {
                    LogFile.Log.Write(String.Format("LocalPort {0} Openned.", port));
                    antBusyPorts[port] = busyPorts[port];
                }
                else if(!busyPorts[port] && antBusyPorts[port])
                {
                    LogFile.Log.Write(String.Format("LocalPort {0} Closed.", port));
                    antBusyPorts[port] = busyPorts[port];
                }
            }
            status = busyPorts;
        }

        private bool[] loadBusyPorts()
        {
            bool[] busyPorts = new bool[65536];
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
            {
                busyPorts[tcpi.LocalEndPoint.Port] = true;
                //log.Write(String.Format("LocalPort {0}, Address {1}, RemotePort {2}, Status {3}", tcpi.LocalEndPoint.Port, tcpi.LocalEndPoint.Address, tcpi.RemoteEndPoint.Port, tcpi.State));
            }
            IPEndPoint[] iptcp = ipGlobalProperties.GetActiveTcpListeners();

            foreach (IPEndPoint tcpi in iptcp)
            {
                busyPorts[tcpi.Port] = true;
                //log.Write(String.Format("LocalPort {0}, Address {1}, TCP, Listening", tcpi.Port, tcpi.Address));
            }
            IPEndPoint[] ipudp = ipGlobalProperties.GetActiveUdpListeners();

            foreach (IPEndPoint tcpi in ipudp)
            {
                busyPorts[tcpi.Port] = true;
                //log.Write(String.Format("LocalPort {0}, Address {1}, UDP, Listening", tcpi.Port, tcpi.Address));
            }
            return busyPorts;
        }
    }
}
