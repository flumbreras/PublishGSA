using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishGSAClient.Models
{
    public class FreePort
    {
        public Int32 Port { get; set; }
        public String Project { get; set; }

        public override string ToString()
        {
            return string.Format("Port: {0}, Project:{1}", Port, Project);
        }
    }
}
