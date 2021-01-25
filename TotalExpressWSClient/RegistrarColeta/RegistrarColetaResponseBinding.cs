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

            response.CodigoProc = Convert.ToInt32(_xmlResponse.SelectSingleNode("//CodigoProc").InnerText);
            response.ItensProcessados = Convert.ToInt32(_xmlResponse.SelectSingleNode("//ItensProcessados").InnerText);
            response.ItensRejeitados = Convert.ToInt32(_xmlResponse.SelectSingleNode("//ItensRejeitados").InnerText);

            // Erros Individuais

            var errosIndividuaisNodes = _xmlResponse.SelectNodes("//ErrosIndividuais");

            foreach (XmlNode node in errosIndividuaisNodes)
            {
                var item = new ErrosIndividuais();

                item.Pedido = node.SelectSingleNode("//Pedido").InnerText;
                item.CodigoErro = Convert.ToInt32(node.SelectSingleNode("//CodigoErro").InnerText);
                item.DescricaoErro = node.SelectSingleNode("//DescricaoErro").InnerText;

                response.ErrosIndividuais.Add(item);
            }

            // End Parse

            // Adding XML Response
            response.ResponseXml = _xmlResponse.OuterXml;

            return response;
        }
    }
}
