using System;
using System.Xml;

namespace TotalExpressWSClient.CalculoFrete
{
    internal class CalcularFreteResponseBinding
    {
        private XmlDocument _xmlResponse;
        private XmlDocument _xmlRequest;

        public CalcularFreteResponseBinding(XmlDocument xmlRequest,
                                            XmlDocument xmlResponse)
        {
            _xmlResponse = xmlResponse;
            _xmlRequest = xmlRequest;
        }

        internal CalcularFreteResponse GenerateObject()
        {
            var response = new CalcularFreteResponse();

            // Start Parse

            if (_xmlResponse.SelectSingleNode("//ErroConsultaFrete") == null)
            {
                response.CodigoProc = Convert.ToInt16(_xmlResponse.SelectSingleNode("//CodigoProc").InnerText);
                response.DadosFrete.Prazo = Convert.ToInt32(_xmlResponse.SelectSingleNode("//Prazo").InnerText);
                response.DadosFrete.ValorServico = Convert.ToDecimal(_xmlResponse.SelectSingleNode("//ValorServico").InnerText);
            }
            else
            {
                var texto = _xmlResponse.SelectSingleNode("//ErroConsultaFrete").InnerText;
            }

            // End Parse

            // Adding XML Response
            response.ResponseXml = _xmlResponse.OuterXml;
            response.RequestXml = _xmlRequest.OuterXml;

            return response;
        }
    }
}
