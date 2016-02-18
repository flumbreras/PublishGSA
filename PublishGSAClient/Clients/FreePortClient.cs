using PublishGSAClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishGSAClient.Clients
{
    class FreePortClient
    {
        string _hostUri;

        public FreePortClient(string hostUri)
        {
            _hostUri = hostUri;
        }


        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(_hostUri), "/gsa/FreePort/");
            return client;
        }


        public IEnumerable<FreePort> GetFreePorts()
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.GetAsync(client.BaseAddress).Result;
            }
            var result = response.Content.ReadAsAsync<IEnumerable<FreePort>>().Result;
            return result;
        }

        public FreePort GetNextPort()
        {
            HttpResponseMessage response = null;
            using (var client = CreateClient())
            {
                try {
                    response = client.GetAsync(new Uri(client.BaseAddress.AbsoluteUri + "next")).Result;
                }
                catch (AggregateException ex)
                {
                    String msg = String.Format("Cannot connect with server {0} \n\r\t{1}", client.BaseAddress.AbsoluteUri, ex.Message);
                    MessageBox.Show(msg);
                }
            }
            //var a = response.Content.ReadAsStringAsync().Result;
            var result = response.Content.ReadAsAsync<FreePort>().Result;
            return result;
        }

        public FreePort GetFreePort(FreePort freePort)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.PostAsJsonAsync(client.BaseAddress, freePort).Result;
            }
            var result = response.Content.ReadAsAsync<FreePort>().Result;
            return result;
        }

    }
}
