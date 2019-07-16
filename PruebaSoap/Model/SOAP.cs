using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PruebaSoap
{
    class SOAP
    {

        public SOAP() {

        }

        /// <summary>
        /// Execute a Soap WebService call
        /// </summary>
        public void Execute()
        {
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<soapenv:Envelope
	                                        xmlns:ser=""http://service.sunat.gob.pe""
                                            xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                                            xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" >
	                                        <soapenv:Header>
		                                        <wsse:Security>
			                                        <wsse:UsernameToken>
				                                        <wsse:Username></wsse:Username>
				                                        <wsse:Password></wsse:Password>
			                                        </wsse:UsernameToken>
		                                        </wsse:Security>
	                                        </soapenv:Header>
	                                        <soapenv:Body>
		                                        <ser:getStatus>
			                                        <!--Optional:-->
			                                        <rucComprobante>20100030838</rucComprobante>
			                                        <!--Optional:-->
			                                        <tipoComprobante>01</tipoComprobante>
			                                        <!--Optional:-->
			                                        <serieComprobante>FOL1</serieComprobante>
			                                        <!--Optional:-->
			                                        <numeroComprobante>0247510</numeroComprobante>
		                                        </ser:getStatus>
	                                        </soapenv:Body>
                                        </soapenv:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Console.WriteLine(soapResult);
                }
            }
        }

        /// <summary>
        /// Create a soap webrequest to [Url]
        /// </summary>
        /// <returns></returns>
        public HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://www.sunat.gob.pe:443/ol-it-wsconscpegem/billConsultService");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

    }
}
