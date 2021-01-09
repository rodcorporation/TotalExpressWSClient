using System;
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
            throw new NotImplementedException();
        }
    }
}
