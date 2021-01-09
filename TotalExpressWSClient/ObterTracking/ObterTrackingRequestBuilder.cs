using System.Text;
using System.Xml;

namespace TotalExpressWSClient.ObterTracking
{
    internal class ObterTrackingRequestBuilder
    {
        #region Construtores

        internal ObterTrackingRequestBuilder() { }

        #endregion

        #region Métodos

        internal XmlDocument GerarXml()
        {
            // Validações

            // Construindo o objeto
            var builder = new StringBuilder();

            builder.AppendLine(@"<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:calcularFrete"">");
            builder.AppendLine(@"<soapenv:Header/>");
            builder.AppendLine(@"<soapenv:Body>");
            builder.AppendLine(@"<urn:calcularFrete soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">");
            builder.AppendLine(@"<calcularFreteRequest xsi:type=""web:calcularFreteRequest"" xmlns:web=""http://edi.totalexpress.com.br/soap/webservice_calculo_frete.total"">");

            // Inicia a montagem aqui;

            // Fim da montagem aqui;

            builder.AppendLine(@"</calcularFreteRequest>");
            builder.AppendLine(@"</urn:calcularFrete>");
            builder.AppendLine(@"</soapenv:Body>");
            builder.AppendLine(@"</soapenv:Envelope>");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(builder.ToString());

            return xmlDoc;
        }

        #endregion
    }
}
