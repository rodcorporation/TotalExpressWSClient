using System.Xml;

namespace TotalExpressWSClient.ObterTracking
{
    internal class ObterTrackingResponseBinding
    {
        private XmlDocument _xmlResponse;

        public ObterTrackingResponseBinding(XmlDocument xmlResponse)
        {
            _xmlResponse = xmlResponse;
        }

        internal ObterTrackingResponse GenerateObject()
        {
            var response = new ObterTrackingResponse();

            // Start Parse

            response.CodigoProc = _xmlResponse.SelectSingleNode("//CodigoProc").InnerText;

            // End Parse

            return response;
        }
    }
}
