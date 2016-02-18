using PublishGSAClient.Clients;
using PublishGSAClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishGSAClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bPort_Click(object sender, EventArgs e)
        {
            FreePortClient freePortClient = new FreePortClient("http://localhost:8084");
            FreePort freePort = freePortClient.GetFreePort(new FreePort() { Project = this.textBox1.Text});
            lPort.Text = freePort.Port.ToString();
            textBox2.Text = freePort.Project;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Puertos libres:\n\r");

            FreePortClient freePortClient = new FreePortClient("http://localhost:8084");
            IEnumerable<FreePort> freePorts = freePortClient.GetFreePorts();
            foreach(FreePort freePort in freePorts)
            {
                sb.Append(freePort.ToString()).Append("\n\r");
            }

            MessageBox.Show(sb.ToString());
        }
    }
}
