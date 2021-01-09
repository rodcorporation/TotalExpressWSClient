using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TotalExpressWSClient.RegistrarColeta
{
    internal class RegistrarColetaRequestBuilder
    {
        #region Atributos

        private IList<string> _encomendas;

        #endregion

        #region Construtores

        internal RegistrarColetaRequestBuilder() 
        {
            _encomendas = new List<string>();
        }

        #endregion

        #region Métodos

        internal RegistrarColetaRequestBuilder ComNovaEncomenda(Func<EncomendaRegistrarColetaRequestBuilder, EncomendaRegistrarColetaRequestBuilder> encomenda)
        {
            var item = encomenda(new EncomendaRegistrarColetaRequestBuilder()).GerarTrechoXml();

            _encomendas.Add(item);

            return this;
        }

        internal XmlDocument GerarXml()
        {
            // Validações

            // Construindo o objeto
            var builder = new StringBuilder();

            builder.AppendLine(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ns1=""urn:RegistraColeta"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:ns2=""http://edi.totalexpress.com.br/soap/webservice_v24.total"" xmlns:SOAP-ENC=""http://schemas.xmlsoap.org/soap/encoding/"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">");
            builder.AppendLine(@"<SOAP-ENV:Body>");
            builder.AppendLine(@"<ns1:RegistraColeta>");

            builder.AppendLine(@"<RegistraColetaRequest xsi:type=""ns2:RegistraColetaRequest"">");

            // Inicia a montagem aqui;

            builder.AppendLine(@"<CodRemessa xsi:type=""xsd:string"">ReenvioNF7</CodRemessa>");

            builder.AppendLine(@"<Encomendas SOAP-ENC:arrayType=""ns2:Encomenda[1]"" xsi:type=""ns2:Encomendas"">");

            foreach (var encomenda in _encomendas)
            {
                builder.AppendLine(encomenda);
            }

            builder.AppendLine(@"</Encomendas>");

            // Entre as encomendas
            // builder.AppendLine(@" < CondFrete xsi:type=""xsd:string"">CIF</CondFrete>");

            // Fim da montagem aqui;

            builder.AppendLine(@"</RegistraColetaRequest>");
            builder.AppendLine(@"</ns1:RegistraColeta>");
            builder.AppendLine(@"</SOAP-ENV:Body>");
            builder.AppendLine(@"</SOAP-ENV:Envelope>");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(builder.ToString());

            return xmlDoc;
        }

        #endregion

        public class EncomendaRegistrarColetaRequestBuilder
        {
            private string _tipoServico = "";
            private string _tipoEntrega = "";
            private string _peso = "";
            private string _volume = "";
            private string _pedido = "";
            private string _natureza = "";
            private string _isencaoIcms = "";

            public EncomendaRegistrarColetaRequestBuilder ComTipoServico(string tipoServico)
            {
                _tipoServico = tipoServico;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComTipoEntrega(string tipoEntrega)
            {
                _tipoEntrega = tipoEntrega;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComPeso(string peso)
            {
                _peso = peso;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComVolume(string volume)
            {
                _volume = volume;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComPedido(string pedido)
            {
                _pedido = pedido;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComNatureza(string natureza)
            {
                _natureza = natureza;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComIsencaoIcms(string isencaoIcms)
            {
                _isencaoIcms = isencaoIcms;

                return this;
            }

            internal string GerarTrechoXml()
            {
                var builder = new StringBuilder();

                // Header
                builder.AppendLine(@"<item xsi:type=""ns2:Encomenda"">");

                // Body
                builder.AppendLine($@"<TipoServico xsi:type=""xsd:nonNegativeInteger"">{_tipoServico}</TipoServico>");
                builder.AppendLine($@"<TipoEntrega xsi:type=""xsd:nonNegativeInteger"">{_tipoEntrega}</TipoEntrega>");
                builder.AppendLine($@"<Peso xsi:type=""xsd:decimal"">{_peso}</Peso>");
                builder.AppendLine($@"<Volumes xsi:type=""xsd:nonNegativeInteger"">{_volume}</Volumes>");
                builder.AppendLine($@"<CondFrete xsi:type=""xsd:string"">CIF</CondFrete>");
                builder.AppendLine($@"<Pedido xsi:type=""xsd:string"">{_pedido}</Pedido>");
                builder.AppendLine($@"<Natureza xsi:type=""xsd:string"">{_natureza}</Natureza>");
                builder.AppendLine($@"<IsencaoIcms xsi:type=""xsd:nonNegativeInteger"">{_isencaoIcms}</IsencaoIcms>");

                builder.AppendLine($@"<DestNome xsi:type=""xsd:string"">VEM PRA MESA JOGOS LTDA</DestNome>");
                builder.AppendLine($@"<DestCpfCnpj xsi:type=""xsd:string"">19371777000271</DestCpfCnpj>");
                builder.AppendLine($@"<DestEnd xsi:type=""xsd:string"">PRAÇA AMARO MARINHO</DestEnd>");
                builder.AppendLine($@"<DestEndNum xsi:type=""xsd:string"">7</DestEndNum>");
                builder.AppendLine($@"<DestCompl xsi:type=""xsd:string""></DestCompl>");
                builder.AppendLine($@"<DestBairro xsi:type=""xsd:string"">LAGOA NOVA</DestBairro>");
                builder.AppendLine($@"<DestCidade xsi:type=""xsd:string"">Natal</DestCidade>");
                builder.AppendLine($@"<DestEstado xsi:type=""xsd:string"">RN</DestEstado>");
                builder.AppendLine($@"<DestCep xsi:type=""xsd:nonNegativeInteger"">59056580</DestCep>");
                builder.AppendLine($@"<DestTelefone1 xsi:type=""xsd:nonNegativeInteger"">0</DestTelefone1>");

                // Footer
                builder.AppendLine(@"</item>");

                return builder.ToString();
            }
        }
    }
}
