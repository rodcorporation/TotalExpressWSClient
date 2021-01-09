using System;
using System.Xml;

namespace TotalExpressWSClient.RegistrarColeta
{
    internal class RegistrarColetaResponseBinding
    {
        private XmlDocument _xmlResponse;

        public RegistrarColetaResponseBinding(XmlDocument xmlResponse)
        {
            _xmlResponse = xmlResponse;
        }

        internal RegistrarColetaResponse GenerateObject()
        {
            var response = new RegistrarColetaResponse();

            // Start Parse

            response.CodRomaneio = _xmlResponse.SelectSingleNode("//CodRomaneio").InnerText;
            response.CodigoProc = Convert.ToInt32(_xmlResponse.SelectSingleNode("//CodigoProc").InnerText);

            // End Parse

            return response;
        }
    }
}
