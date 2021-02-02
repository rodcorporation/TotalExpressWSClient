using System.Xml;

namespace TotalExpressWSClient.ObterTracking
{
    internal class ObterTrackingResponseBinding
    {
        private XmlDocument _xmlResponse;
        private XmlDocument _xmlRequest;

        public ObterTrackingResponseBinding(XmlDocument xmlRequest,
                                            XmlDocument xmlResponse)
        {
            _xmlResponse = xmlResponse;
            _xmlRequest = xmlRequest;
        }

        internal ObterTrackingResponse GenerateObject()
        {
            var response = new ObterTrackingResponse();

            // Start Parse

            response.CodigoProc = _xmlResponse.SelectSingleNode("//CodigoProc").InnerText;

            // End Parse

            // Adding XML Response
            response.ResponseXml = _xmlResponse.OuterXml;
            response.RequestXml = _xmlRequest.OuterXml;

            return response;
        }
    }
}
