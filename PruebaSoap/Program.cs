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
            List<Comprobante> lista = new List<Comprobante>();



            string originPath = Directory.GetCurrentDirectory();

            string filePath = Directory.GetFiles(originPath, "documentos.csv")[0];//@"D:\documentos.csv";
            string credencialesPath = Directory.GetFiles(originPath, "credenciales.csv")[0];//@"D:\documentos.csv";
            string fileResponsePath = originPath + "//" + "responseConsult.txt";

            string line, user, pass, ruc;

            char[] charSeparators = new char[] { ';' };
            string[] creden = null;
            string[] datos;

            if (File.Exists(credencialesPath))
            {
                StreamReader fileC = null;

                fileC = new StreamReader(credencialesPath);
                creden = fileC.ReadLine().Split(charSeparators, StringSplitOptions.None);
            }

            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    while ((line = file.ReadLine()) != null)
                    {
                        datos = line.Split(charSeparators, StringSplitOptions.None);
                        lista.Add(new Comprobante(creden[0], creden[1], creden[2], datos[0], datos[1], datos[2]));
                    }
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }


            foreach (Comprobante item in lista)
            {
                try
                {
                    SOAP soap = new SOAP();
                    soap.CallWebService(item);
                }
                catch (WebException err)
                {

                    Console.WriteLine(err.Message);
                    Console.ReadKey();

                }
                catch (Exception err)
                {

                    Console.WriteLine(err.Message);
                    Console.ReadKey();
                }
            }

            using (TextWriter writer = File.CreateText(fileResponsePath))
            {
                foreach (Comprobante item in lista)
                {

                    writer.WriteLine("01- "+item.serieComprobante + "-" + item.numeroComprobante 
                                     + "\t" + item.respuetas.Substring(0,4) 
                                     + "\t"+ item.respuetas.Substring(item.respuetas.IndexOf("El comprobante"), item.respuetas.Length - item.respuetas.IndexOf("El comprobante")));
                }
            }

            Console.ReadKey();
        }
    }
}
