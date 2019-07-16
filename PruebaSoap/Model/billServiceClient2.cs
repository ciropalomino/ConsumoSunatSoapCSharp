using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace PruebaSoap
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "BillConsultServicePortBinding", Namespace = "http://service.ws.consulta.comppago.electronico.registro.servicio2.sunat.gob.pe/")]
    public partial class billConsultService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback getStatusCdrOperationCompleted;

        private System.Threading.SendOrPostCallback getStatusOperationCompleted;

        /// <remarks/>
        public billConsultService()
        {
            this.Url = "https://www.sunat.gob.pe:443/ol-it-wsconscpegem/billConsultService";
        }

        /// <remarks/>
        public event getStatusCdrCompletedEventHandler getStatusCdrCompleted;

        /// <remarks/>
        public event getStatusCompletedEventHandler getStatusCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:getStatusCdr", RequestNamespace = "http://service.sunat.gob.pe", ResponseNamespace = "http://service.sunat.gob.pe", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("statusCdr", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public statusResponse getStatusCdr([System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string rucComprobante, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string tipoComprobante, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string serieComprobante, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] int numeroComprobante, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] [System.Xml.Serialization.XmlIgnoreAttribute()] bool numeroComprobanteSpecified)
        {
            object[] results = this.Invoke("getStatusCdr", new object[] {
                    rucComprobante,
                    tipoComprobante,
                    serieComprobante,
                    numeroComprobante,
                    numeroComprobanteSpecified});
            return ((statusResponse)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BegingetStatusCdr(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante, bool numeroComprobanteSpecified, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("getStatusCdr", new object[] {
                    rucComprobante,
                    tipoComprobante,
                    serieComprobante,
                    numeroComprobante,
                    numeroComprobanteSpecified}, callback, asyncState);
        }

        /// <remarks/>
        public statusResponse EndgetStatusCdr(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((statusResponse)(results[0]));
        }

        /// <remarks/>
        public void getStatusCdrAsync(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante, bool numeroComprobanteSpecified)
        {
            this.getStatusCdrAsync(rucComprobante, tipoComprobante, serieComprobante, numeroComprobante, numeroComprobanteSpecified, null);
        }

        /// <remarks/>
        public void getStatusCdrAsync(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante, bool numeroComprobanteSpecified, object userState)
        {
            if ((this.getStatusCdrOperationCompleted == null))
            {
                this.getStatusCdrOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetStatusCdrOperationCompleted);
            }
            this.InvokeAsync("getStatusCdr", new object[] {
                    rucComprobante,
                    tipoComprobante,
                    serieComprobante,
                    numeroComprobante,
                    numeroComprobanteSpecified}, this.getStatusCdrOperationCompleted, userState);
        }

        private void OngetStatusCdrOperationCompleted(object arg)
        {
            if ((this.getStatusCdrCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getStatusCdrCompleted(this, new getStatusCdrCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:getStatus", RequestNamespace = "http://service.sunat.gob.pe", ResponseNamespace = "http://service.sunat.gob.pe", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("status", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public statusResponse getStatus([System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string rucComprobante, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string tipoComprobante, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string serieComprobante, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] int numeroComprobante, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] [System.Xml.Serialization.XmlIgnoreAttribute()] bool numeroComprobanteSpecified)
        {
            object[] results = this.Invoke("getStatus", new object[] {
                    rucComprobante,
                    tipoComprobante,
                    serieComprobante,
                    numeroComprobante,
                    numeroComprobanteSpecified});
            return ((statusResponse)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BegingetStatus(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante, bool numeroComprobanteSpecified, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("getStatus", new object[] {
                    rucComprobante,
                    tipoComprobante,
                    serieComprobante,
                    numeroComprobante,
                    numeroComprobanteSpecified}, callback, asyncState);
        }

        /// <remarks/>
        public statusResponse EndgetStatus(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((statusResponse)(results[0]));
        }

        /// <remarks/>
        public void getStatusAsync(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante, bool numeroComprobanteSpecified)
        {
            this.getStatusAsync(rucComprobante, tipoComprobante, serieComprobante, numeroComprobante, numeroComprobanteSpecified, null);
        }

        /// <remarks/>
        public void getStatusAsync(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante, bool numeroComprobanteSpecified, object userState)
        {
            if ((this.getStatusOperationCompleted == null))
            {
                this.getStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetStatusOperationCompleted);
            }
            this.InvokeAsync("getStatus", new object[] {
                    rucComprobante,
                    tipoComprobante,
                    serieComprobante,
                    numeroComprobante,
                    numeroComprobanteSpecified}, this.getStatusOperationCompleted, userState);
        }

        private void OngetStatusOperationCompleted(object arg)
        {
            if ((this.getStatusCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getStatusCompleted(this, new getStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.sunat.gob.pe")]
    public partial class statusResponse
    {

        private byte[] contentField;

        private string statusCodeField;

        private string statusMessageField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
        public byte[] content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string statusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string statusMessage
        {
            get
            {
                return this.statusMessageField;
            }
            set
            {
                this.statusMessageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void getStatusCdrCompletedEventHandler(object sender, getStatusCdrCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getStatusCdrCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal getStatusCdrCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public statusResponse Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((statusResponse)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void getStatusCompletedEventHandler(object sender, getStatusCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal getStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public statusResponse Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((statusResponse)(this.results[0]));
            }
        }
    }

}
