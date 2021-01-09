using System.Text;
using System.Xml;

namespace TotalExpressWSClient.CalculoFrete
{
    internal class CalcularFreteRequestBuilder
    {
        #region Atributos

        private string _tipoServico;
        private bool _comTipoServico;

        private string _cepDestino;
        private bool _comCepDestino;

        private decimal _peso;
        private bool _comPeso;

        private decimal _valorDeclarado;
        private bool _comValorDeclarado;

        private short _tipoEntrega;
        private bool _comTipoEntrega;

        #endregion

        #region Construtores

        internal CalcularFreteRequestBuilder()
        {
            _comTipoServico = false;
            _comCepDestino = false;
            _comPeso = false;
            _comValorDeclarado = false;
            _comTipoEntrega = false;
        }

        #endregion

        #region Métodos

        internal CalcularFreteRequestBuilder ComTipoServico(string tipoServico)
        {
            _tipoServico = tipoServico;
            _comTipoServico = true;

            return this;
        }

        internal CalcularFreteRequestBuilder ComCepDestino(string cepDestino)
        {
            _cepDestino = cepDestino;
            _comCepDestino = true;

            return this;
        }

        internal CalcularFreteRequestBuilder ComPeso(decimal peso)
        {
            _peso = peso;
            _comPeso = true;

            return this;
        }

        internal CalcularFreteRequestBuilder ComValorDeclarado(decimal valorDeclarado)
        {
            _valorDeclarado = valorDeclarado;
            _comValorDeclarado = true;

            return this;
        }

        internal CalcularFreteRequestBuilder ComTipoEntrega(short tipoEntrega)
        {
            _tipoEntrega = tipoEntrega;
            _comTipoEntrega = true;

            return this;
        }

        internal XmlDocument GerarXml()
        {
            // Validações

            if (!_comTipoServico)
                throw new TotalExpressWSClientException("O tipo de serviço não foi informado");

            if (!_comCepDestino)
                throw new TotalExpressWSClientException("O cep de desitno não foi informado");

            if (!_comPeso)
                throw new TotalExpressWSClientException("O peso não foi informado");

            if (_valorDeclarado <= 0)
                throw new TotalExpressWSClientException("O valor declarado não foi informado");

            if (!_comTipoEntrega)
                throw new TotalExpressWSClientException("O tipo de entrega não foi informado");

            // Construindo o objeto
            var builder = new StringBuilder();

            builder.AppendLine(@"<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:calcularFrete"">");
            builder.AppendLine(@"<soapenv:Header/>");
            builder.AppendLine(@"<soapenv:Body>");
            builder.AppendLine(@"<urn:calcularFrete soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">");
            builder.AppendLine(@"<calcularFreteRequest xsi:type=""web:calcularFreteRequest"" xmlns:web=""http://edi.totalexpress.com.br/soap/webservice_calculo_frete.total"">");

            // Inicia a montagem aqui;

            /// Tipo de Serviço
            builder.AppendLine($@"<TipoServico xsi:type=""xsd:string"">{_tipoServico}</TipoServico>");

            /// Cep de Destino
            builder.AppendLine($@"<CepDestino xsi:type=""xsd:nonNegativeInteger"">{_cepDestino}</CepDestino>");

            /// Peso
            builder.AppendLine($@"<Peso xsi:type=""xsd:string"">{_peso}</Peso>");

            /// Valor Declarado
            builder.AppendLine($@"<ValorDeclarado xsi:type=""xsd:string"">{_valorDeclarado}</ValorDeclarado>");

            /// Tipo de Entrega
            builder.AppendLine($@"<TipoEntrega xsi:type=""xsd:nonNegativeInteger"">{_tipoEntrega}</TipoEntrega>");

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
