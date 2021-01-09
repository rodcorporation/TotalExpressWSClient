using System;
using System.Xml;

namespace TotalExpressWSClient.CalculoFrete
{
    internal class CalcularFreteResponseBinding
    {
        private XmlDocument _xmlResponse;

        public CalcularFreteResponseBinding(XmlDocument xmlResponse)
        {
            _xmlResponse = xmlResponse;
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

            return response;
        }
    }
}
