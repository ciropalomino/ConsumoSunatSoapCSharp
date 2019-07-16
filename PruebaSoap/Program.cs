using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSoap
{
    class Program
    {
        static void Main(string[] args)
        {

            //SOAP soap = new SOAP();
            //soap.Execute();

            WS.billServiceClient client = new WS.billServiceClient();
            client.ClientCredentials.UserName.UserName = "";
            client.ClientCredentials.UserName.UserName = "";
            try {
                var res = client.getStatus("20100030838", "01", "FOL1", 0247510);
            }
            catch (Exception err) {

                Console.WriteLine(err.Message);

            }
        }
    }
}
