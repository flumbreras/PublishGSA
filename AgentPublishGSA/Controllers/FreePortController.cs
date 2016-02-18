using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Add these usings:
using System.Web.Http;
using System.Net.Http;
using AgentPublishGSA.Models;
using System.Collections;

namespace AgentPublishGSA.Controllers
{
    public class FreePortController : ApiController
    {
        private static ServiceViewer serviceViewer = new ServiceViewer(8080, 8090);

        public FreePort[] Get()
        {
            IList<FreePort> freePorts = new List<FreePort>();
            IEnumerable<Int32> ports = serviceViewer.getFreePorts();
            foreach(Int32 port in ports)
            {
                freePorts.Add( new FreePort { Port = port, Project = "list" });
            }
            LogFile.Log.Write(String.Format("Get()={0} free ports.", freePorts.Count));
            return freePorts.ToArray<FreePort>();
        }


        public FreePort Get(String param)
        {
            FreePort result = null;
            int port = 0;
            if (param == "next")
            {
                port = serviceViewer.nextFreePort();
                result = new FreePort { Port = port, Project = "test" };
            }

            LogFile.Log.Write(String.Format("Get(\"{0}\")={1}.", param, port));
            return result;
        }


        public FreePort Post(FreePort freePort)
        {
            int port = serviceViewer.nextFreePort();
            LogFile.Log.Write(String.Format("Post(\"{0}\")={1}.", freePort.Project, port));
            return new FreePort { Port = port, Project = freePort.Project };
        }

        public IHttpActionResult Put(FreePort company)
        {
            // NO IMPLEMENTED

            LogFile.Log.Write("Put()");
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            // NO IMPLEMENTED
            LogFile.Log.Write("Delete()");
            return Ok();
        }
    }
}
