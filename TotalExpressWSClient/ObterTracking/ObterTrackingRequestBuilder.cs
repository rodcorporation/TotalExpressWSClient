using System;
using System.Text;
using System.Xml;

namespace TotalExpressWSClient.ObterTracking
{
    internal class ObterTrackingRequestBuilder
    {
        #region Atributos

        private DateTime? _dataConsulta;

        #endregion

        #region Construtores

        internal ObterTrackingRequestBuilder() { }

        #endregion

        #region Métodos

        internal ObterTrackingRequestBuilder ComDataConsulta(DateTime dataConsulta)
        {
            _dataConsulta = dataConsulta;

            return this;
        }

        internal XmlDocument GerarXml()
        {
            // Validações

            // Construindo o objeto
            var builder = new StringBuilder();

            builder.AppendLine(@"<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:ObterTracking"">");
            builder.AppendLine(@"<soapenv:Header/>");
            builder.AppendLine(@"<soapenv:Body>");
            builder.AppendLine(@"<urn:ObterTracking soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">");
            builder.AppendLine(@"<ObterTrackingRequest xsi:type=""web:ObterTrackingRequest"" xmlns:web=""http://edi.totalexpress.com.br/soap/webservice_v24.total"">");

            // Inicia a montagem aqui;

            if (_dataConsulta.HasValue)
            {
                builder.AppendLine($@"<DataConsulta xsi:type=""xsd:date"">{_dataConsulta:yyyyMMdd}</DataConsulta>");
            }

            // Fim da montagem aqui;

            builder.AppendLine(@"</ObterTrackingRequest>");
            builder.AppendLine(@"</urn:ObterTracking>");
            builder.AppendLine(@"</soapenv:Body>");
            builder.AppendLine(@"</soapenv:Envelope>");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(builder.ToString());

            return xmlDoc;
        }

        #endregion
    }
}
