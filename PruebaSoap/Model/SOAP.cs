using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PruebaSoap
{
    class SOAP
    {

        public SOAP()
        {

        }

        public void CallWebService()
        {
            var _url = @"https://e-factura.sunat.gob.pe/ol-it-wsconscpegem/billConsultService";
            var _action = @"urn:getStatus";
            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);


            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                    rd.Close();
                }
                Console.WriteLine(soapResult);
                Console.ReadKey();
            }
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = WebRequest.CreateHttp(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            webRequest.UserAgent = ".NET Framework Test Client";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(@"<soapenv:Envelope
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
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
