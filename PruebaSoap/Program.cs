using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSoap
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SOAP soap = new SOAP();
                soap.CallWebService();
            }
            catch (WebException err)
            {

                Console.WriteLine(err.Message);
                Console.ReadKey();

            }
            catch (Exception err) {

                Console.WriteLine(err.Message);
                Console.ReadKey();
            }
        }
    }
}
