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
            var item = encomenda(new EncomendaRegistrarColetaRequestBuilder()).GerarXml();

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
            #region Atributos
            
            // Dados da Coleta
            private int _tipoServico;
            private bool _comTipoServico;

            private int _tipoEntrega;
            private bool _comTipoEntrega;

            private decimal _peso;

            private int _volume;
            private bool _comVolume;

            private string _pedido;
            private bool _comPedido;

            private string _natureza;
            private bool _comNatureza;

            private int _isencaoIcms;
            private bool _comIsencaoIcms;

            // Dados do Destinatário
            private string _nomeDestinatario;
            private bool _comNomeDestinatario;

            private string _cpfCnpjDestinatario;
            private bool _comCpfCnpjDestinatario;

            private string _enderecoDestinatario;
            private bool _comEnderecoDestinatario;

            private string _numeroEnderecoDestinatario;
            private bool _comNumeroEnderecoDestinatario;

            private string _complementoEnderecoDestinatario;

            private string _bairroEnderecoDestinatario;
            private bool _comBairroEnderecoDestinatario;

            private string _cidadeEnderecoDestinatario;
            private bool _comCidadeEnderecoDestinatario;

            private string _ufEnderecoDestinatario;
            private bool _comUfEnderecoDestinatario;

            private string _cepEnderecoDestinatario;
            private bool _comCepEnderecoDestinatario;

            private string _emailDestinatario;
            private string _telefone1Destinatario;

            // Notas fiscais eletrônicas;
            private IList<string> _nfes;

            #endregion

            #region Construtores

            public EncomendaRegistrarColetaRequestBuilder()
            {
                _nfes = new List<string>();
            }

            #endregion

            #region Métodos

            public EncomendaRegistrarColetaRequestBuilder ComTipoServico(int tipoServico)
            {
                if (tipoServico < 1 || tipoServico > 7)
                    throw new TotalExpressWSClientException("O tipo de serviço deve estar entre 1 e 7. Qualquer dúvida, consulte o manual da Total Express.");

                _tipoServico = tipoServico;
                _comTipoServico = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComTipoEntrega(int tipoEntrega)
            {
                if (tipoEntrega < 0 || tipoEntrega > 2)
                    throw new TotalExpressWSClientException("O tipo de entrega deve estar entre 0 e 2. Qualquer dúvida, consulte o manual da Total Express.");

                _tipoEntrega = tipoEntrega;
                _comTipoEntrega = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComPeso(decimal peso)
            {
                _peso = peso;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComVolume(int volume)
            {
                if (volume <= 0)
                    throw new TotalExpressWSClientException("O volume deve ser maior que 0. Qualquer dúvida, consulte o manual da Total Express.");

                _volume = volume;
                _comVolume = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComPedido(string pedido)
            {
                _pedido = pedido;
                _comPedido = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComNatureza(string natureza)
            {
                _natureza = natureza;
                _comNatureza = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComIsencaoIcms(int isencaoIcms)
            {
                _isencaoIcms = isencaoIcms;
                _comIsencaoIcms = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComNomeDestinatario(string nomeDestinatario)
            {
                _nomeDestinatario = nomeDestinatario;
                _comNomeDestinatario = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComCpfCnpjDestinatario(string cpfCnpjDestinatario)
            {
                _cpfCnpjDestinatario = cpfCnpjDestinatario;
                _comCpfCnpjDestinatario = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComEnderecoDestinatario(string enderecoDestinatario)
            {
                _enderecoDestinatario = enderecoDestinatario;
                _comEnderecoDestinatario = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComNumeroEnderecoDestinatario(string numeroEnderecoDestinatario)
            {
                _numeroEnderecoDestinatario = numeroEnderecoDestinatario;
                _comNumeroEnderecoDestinatario = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComComplementoEnderecoDestinatario(string complementoEnderecoDestinatario)
            {
                _complementoEnderecoDestinatario = complementoEnderecoDestinatario;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComBairroEnderecoDestinatario(string bairroEnderecoDestinatario)
            {
                _bairroEnderecoDestinatario = bairroEnderecoDestinatario;
                _comBairroEnderecoDestinatario = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComCidadeEnderecoDestinatario(string cidadeEnderecoDestinatario)
            {
                _cidadeEnderecoDestinatario = cidadeEnderecoDestinatario;
                _comCidadeEnderecoDestinatario = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComUfEnderecoDestinatario(string ufEnderecoDestinatario)
            {
                _ufEnderecoDestinatario = ufEnderecoDestinatario;
                _comUfEnderecoDestinatario = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComCepEnderecoDestinatario(string cepEnderecoDestinatario)
            {
                _cepEnderecoDestinatario = cepEnderecoDestinatario;
                _comCepEnderecoDestinatario = true;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComEmailDestinatario(string emailDestinatario)
            {
                _emailDestinatario = emailDestinatario;

                return this;
            }

            public EncomendaRegistrarColetaRequestBuilder ComTelefone1Destinatario(string telefone1Destinatario)
            {
                _telefone1Destinatario = telefone1Destinatario;

                return this;
            }

            internal EncomendaRegistrarColetaRequestBuilder ComNotaFiscalEletronica(Func<NfeEncomendaRegistrarColetaRequestBuilder, NfeEncomendaRegistrarColetaRequestBuilder> nfe)
            {
                var item = nfe(new NfeEncomendaRegistrarColetaRequestBuilder()).GerarXml();

                _nfes.Add(item);

                return this;
            }

            internal string GerarXml()
            {
                var builder = new StringBuilder();

                // Validações
                if (!_comTipoServico)
                    throw new TotalExpressWSClientException("O tipo do serviço não foi informado");

                if (!_comTipoEntrega)
                    throw new TotalExpressWSClientException("O tipo de entrega não foi informado");

                if (!_comVolume)
                    throw new TotalExpressWSClientException("O volume não foi informado");

                if (!_comPedido)
                    throw new TotalExpressWSClientException("O número do pedido não foi informado");

                if (!_comNatureza)
                    throw new TotalExpressWSClientException("A natureza não foi informada");

                if (!_comIsencaoIcms)
                    throw new TotalExpressWSClientException("A isenção do ICMS não foi informada");

                if (!_comNomeDestinatario)
                    throw new TotalExpressWSClientException("O nome do destinatário não foi informado");

                if (!_comCpfCnpjDestinatario)
                    throw new TotalExpressWSClientException("O CPF/CNPJ do destinatário não foi informado");

                if (!_comEnderecoDestinatario)
                    throw new TotalExpressWSClientException("O endereço do destinatário não foi informado");

                if (!_comNumeroEnderecoDestinatario)
                    throw new TotalExpressWSClientException("O número do endereço do destinatário não foi informado");

                if (!_comBairroEnderecoDestinatario)
                    throw new TotalExpressWSClientException("O bairro do endereço do destinatário não foi informado");

                if (!_comCidadeEnderecoDestinatario)
                    throw new TotalExpressWSClientException("A cidade do endereço do destinatário não foi informada");

                if (!_comUfEnderecoDestinatario)
                    throw new TotalExpressWSClientException("O estado do endereço do destinatário não foi informado");

                if (!_comCepEnderecoDestinatario)
                    throw new TotalExpressWSClientException("O CEP do endereço do destinatário não foi informado");

                // Header
                builder.AppendLine(@"<item xsi:type=""ns2:Encomenda"">");

                // Body
                builder.AppendLine($@"<TipoServico xsi:type=""xsd:nonNegativeInteger"">{_tipoServico}</TipoServico>");
                builder.AppendLine($@"<TipoEntrega xsi:type=""xsd:nonNegativeInteger"">{_tipoEntrega}</TipoEntrega>");

                if (_peso != 0.0m)
                {
                    builder.AppendLine($@"<Peso xsi:type=""xsd:decimal"">{_peso}</Peso>");
                }

                builder.AppendLine($@"<Volumes xsi:type=""xsd:nonNegativeInteger"">{_volume}</Volumes>");
                builder.AppendLine($@"<CondFrete xsi:type=""xsd:string"">CIF</CondFrete>");
                builder.AppendLine($@"<Pedido xsi:type=""xsd:string"">{_pedido}</Pedido>");
                builder.AppendLine($@"<Natureza xsi:type=""xsd:string"">{_natureza}</Natureza>");
                builder.AppendLine($@"<IsencaoIcms xsi:type=""xsd:nonNegativeInteger"">{_isencaoIcms}</IsencaoIcms>");

                builder.AppendLine($@"<DestNome xsi:type=""xsd:string"">{_nomeDestinatario }</DestNome>");
                builder.AppendLine($@"<DestCpfCnpj xsi:type=""xsd:string"">{_cpfCnpjDestinatario}</DestCpfCnpj>");
                builder.AppendLine($@"<DestEnd xsi:type=""xsd:string"">{_enderecoDestinatario}</DestEnd>");
                builder.AppendLine($@"<DestEndNum xsi:type=""xsd:string"">{_numeroEnderecoDestinatario}</DestEndNum>");
                builder.AppendLine($@"<DestCompl xsi:type=""xsd:string"">{_complementoEnderecoDestinatario}</DestCompl>");
                builder.AppendLine($@"<DestBairro xsi:type=""xsd:string"">{_bairroEnderecoDestinatario}</DestBairro>");
                builder.AppendLine($@"<DestCidade xsi:type=""xsd:string"">{_cidadeEnderecoDestinatario}</DestCidade>");
                builder.AppendLine($@"<DestEstado xsi:type=""xsd:string"">{_ufEnderecoDestinatario}</DestEstado>");
                builder.AppendLine($@"<DestCep xsi:type=""xsd:nonNegativeInteger"">{_cepEnderecoDestinatario}</DestCep>");

                if (!string.IsNullOrWhiteSpace(_emailDestinatario))
                {
                    builder.AppendLine($@"<DestEmail xsi:type=""xsd: string"">{_emailDestinatario}</DestEmail>");
                }

                if (!string.IsNullOrWhiteSpace(_telefone1Destinatario))
                {
                    builder.AppendLine($@"<DestTelefone1 xsi:type=""xsd:nonNegativeInteger"">{_telefone1Destinatario}</DestTelefone1>");
                }

                builder.AppendLine(@"<DocFiscalNFe SOAP-ENC:arrayType=""ns2:NFe[1]"" xsi:type=""ns2:DocFiscalNFe"">");

                foreach (var nfe in _nfes)
                {
                    builder.AppendLine(nfe);
                }

                builder.AppendLine(@"</DocFiscalNFe>");

                // Footer
                builder.AppendLine(@"</item>");

                return builder.ToString();
            } 

            #endregion

            public class NfeEncomendaRegistrarColetaRequestBuilder
            {
                #region Atributos

                // Dados da Coleta
                private int _nfeNumero;
                private bool _comNfeNumero;

                private int _nfeSerie;
                private bool _comNfeSerie;

                private DateTime _nfeData;
                private bool _comNfeData;

                private decimal _nfeValorTotal;
                private bool _comNfeValorTotal;

                private decimal _nfeValorProduto;
                private bool _comNfeValorProduto;

                private string _nfeCfop;

                private string _nfeChaveAcesso;
                private bool _comNfeChaveAcesso;

                #endregion

                #region Métodos

                public NfeEncomendaRegistrarColetaRequestBuilder ComNfeNumero(int nfeNumero)
                {
                    _nfeNumero = nfeNumero;
                    _comNfeNumero = true;

                    return this;
                }

                public NfeEncomendaRegistrarColetaRequestBuilder ComNfeSerie(int nfeSerie)
                {
                    _nfeSerie = nfeSerie;
                    _comNfeSerie = true;

                    return this;
                }

                public NfeEncomendaRegistrarColetaRequestBuilder ComNfeData(DateTime nfeData)
                {
                    _nfeData = nfeData;
                    _comNfeData = true;

                    return this;
                }

                public NfeEncomendaRegistrarColetaRequestBuilder ComNfeValorTotal(decimal nfeValorTotal)
                {
                    _nfeValorTotal = nfeValorTotal;
                    _comNfeValorTotal = true;

                    return this;
                }

                public NfeEncomendaRegistrarColetaRequestBuilder ComNfeValorProduto(decimal nfeValorProduto)
                {
                    _nfeValorProduto = nfeValorProduto;
                    _comNfeValorProduto = true;

                    return this;
                }

                public NfeEncomendaRegistrarColetaRequestBuilder ComNfeCfop(string nfeCfop)
                {
                    _nfeCfop = nfeCfop;

                    return this;
                }

                public NfeEncomendaRegistrarColetaRequestBuilder ComNfeChaveAcesso(string nfeChaveAcesso)
                {
                    _nfeChaveAcesso = nfeChaveAcesso;
                    _comNfeChaveAcesso= true;

                    return this;
                }

                internal string GerarXml()
                {
                    var builder = new StringBuilder();

                    // Validações
                    if (!_comNfeNumero)
                        throw new TotalExpressWSClientException("O número da nota fiscal eletrônica não foi informado");

                    if (!_comNfeSerie)
                        throw new TotalExpressWSClientException("A série da nota fiscal eletrônica não foi informada");

                    if (!_comNfeData)
                        throw new TotalExpressWSClientException("A data da nota fiscal eletrônica não foi informada");

                    if (!_comNfeValorTotal)
                        throw new TotalExpressWSClientException("O valor total da nota fiscal eletrônica não foi informado");

                    if (!_comNfeValorProduto)
                        throw new TotalExpressWSClientException("O valor dos produtos da nota fiscal eletrônica não foi informado");

                    if (!_comNfeChaveAcesso)
                        throw new TotalExpressWSClientException("A chave de acesso da nota fiscal eletrônica não foi informada");

                    // Header
                    builder.AppendLine(@"<item xsi:type=""ns2:NFe"">");

                    // Body
                    builder.AppendLine($@"<NfeNumero xsi:type=""xsd:nonNegativeInteger"">{_nfeNumero}</NfeNumero>");
                    builder.AppendLine($@"<NfeSerie xsi:type=""xsd:nonNegativeInteger"">{_nfeSerie}</NfeSerie>");
                    builder.AppendLine($@"<NfeData xsi:type=""xsd:date"">{_nfeData:yyyy-MM-ddTHH:mm:ss}-03:00</NfeData>");
                    builder.AppendLine($@"<NfeValTotal xsi:type=""xsd:decimal"">{_nfeValorTotal}</NfeValTotal>");
                    builder.AppendLine($@"<NfeValProd xsi:type=""xsd:decimal"">{_nfeValorProduto}</NfeValProd>");

                    if (!string.IsNullOrWhiteSpace(_nfeCfop))
                    {
                        builder.AppendLine($@"<NfeCfop xsi:type=""xsd:nonNegativeInteger"">{_nfeCfop}</NfeCfop>");
                    }

                    builder.AppendLine($@"<NfeChave xsi:type=""xsd:string"">{_nfeChaveAcesso}</NfeChave>");

                    // Footer
                    builder.AppendLine(@"</item>");

                    return builder.ToString();
                }

                #endregion
            }
        }
    }
}
