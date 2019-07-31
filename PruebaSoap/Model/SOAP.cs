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
using System.Xml.Linq;

namespace PruebaSoap
{
    class SOAP
    {

        public SOAP()
        {

        }

        public void CallWebService(Comprobante item)
        {
            var _url = @"https://e-factura.sunat.gob.pe/ol-it-wsconscpegem/billConsultService";
            var _action = @"urn:getStatus";
            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(item);
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
               
                XElement xelement = XElement.Parse(soapResult);
                item.respuetas = xelement.Value;
                Console.WriteLine(xelement.Value);
                
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

        private static XmlDocument CreateSoapEnvelope(Comprobante item)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();

            String sXML = @"<soapenv:Envelope
	                                        xmlns:ser=""http://service.sunat.gob.pe""
                                            xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                                            xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" >
	                                        <soapenv:Header>
		                                        <wsse:Security>
			                                        <wsse:UsernameToken>
				                                        <wsse:Username>@@Username</wsse:Username>
				                                        <wsse:Password>@@Password</wsse:Password>
			                                        </wsse:UsernameToken>
		                                        </wsse:Security>
	                                        </soapenv:Header>
	                                        <soapenv:Body>
		                                        <ser:getStatus>
			                                        <!--Optional:-->
			                                        <rucComprobante>@@rucComprobante</rucComprobante>
			                                        <!--Optional:-->
			                                        <tipoComprobante>@tipoComprobante</tipoComprobante>
			                                        <!--Optional:-->
			                                        <serieComprobante>@serieComprobante</serieComprobante>
			                                        <!--Optional:-->
			                                        <numeroComprobante>@numeroComprobante</numeroComprobante>
		                                        </ser:getStatus>
	                                        </soapenv:Body>
                                        </soapenv:Envelope>";

            sXML = sXML.Replace("@@Username", item.username);
            sXML = sXML.Replace("@@Password", item.password);
            sXML = sXML.Replace("@@rucComprobante", item.rucComprobante);

            sXML = sXML.Replace("@tipoComprobante"  ,item.tipoComprobante);
            sXML = sXML.Replace("@serieComprobante" , item.serieComprobante);
            sXML = sXML.Replace("@numeroComprobante", item.numeroComprobante);


            soapEnvelopeDocument.LoadXml(sXML);
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
