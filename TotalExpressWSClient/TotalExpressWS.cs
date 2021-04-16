using TotalExpressWSClient.CalculoFrete;
using TotalExpressWSClient.ObterTracking;
using TotalExpressWSClient.RegistrarColeta;

namespace TotalExpressWSClient
{
    public class TotalExpressWS : RequestBase
    {
        // Cálculo de Frete
        private readonly string _urlCalculoFrete = "https://edi.totalexpress.com.br/webservice_calculo_frete.php";
        private readonly string _soapActionCalculoFrete = "urn:simulaFrete#calcularFrete";

        // Registrar Coleta
        private readonly string _urlRegistrarColeta = "https://edi.totalexpress.com.br/webservice24.php?wsdl";
        private readonly string _soapActionRegistrarColeta = "urn:RegistraColeta#RegistraColeta";

        // Obter Tracking
        private readonly string _urlObterTracking = "https://edi.totalexpress.com.br/webservice24.php?wsdl";
        private readonly string _soapActionObterTracking = "urn:ObterTracking#ObterTracking";

        // Credenciais 
        private string _username;
        private string _password;

        public TotalExpressWS(string username,
                              string password)
        {
            _username = username;
            _password = password;
        }

        public CalcularFreteResponse CalcularFrete(CalcularFreteRequest request)
        {
            var builder = new CalcularFreteRequestBuilder();

            var xmlRequest = builder
                                .ComTipoServico(request.TipoServico)
                                .ComCepDestino(request.CepDestino)
                                .ComPeso(request.Peso)
                                .ComValorDeclarado(request.ValorDeclarado)
                                .ComTipoEntrega(request.TipoEntrega)
                                .GerarXml();

            var xmlResponse = MakeRequest(_username,
                                          _password,
                                          _urlCalculoFrete,
                                          _soapActionCalculoFrete,
                                          xmlRequest);

            return new CalcularFreteResponseBinding(xmlRequest, xmlResponse).GenerateObject();
        }

        public RegistrarColetaResponse RegistrarColeta(RegistrarColetaRequest request)
        {
            var builder = new RegistrarColetaRequestBuilder();

            foreach (var encomenda in request.Encomendas)
            {
                builder
                    .ComNovaEncomenda(b =>
                    {
                        b.ComTipoServico(encomenda.TipoServico)
                         .ComTipoEntrega(encomenda.TipoEntrega);

                        if (encomenda.Peso > 0)
                            b.ComPeso(encomenda.Peso);

                        b.ComVolume(encomenda.Volume)
                         .ComPedido(encomenda.Pedido)
                         .ComNatureza(encomenda.Natureza)
                         .ComIsencaoIcms(encomenda.IsencaoIcms)
                         .ComNomeDestinatario(encomenda.DestNome)
                         .ComCpfCnpjDestinatario(encomenda.DestCpfCnpj)
                         .ComEnderecoDestinatario(encomenda.DestEnd)
                         .ComNumeroEnderecoDestinatario(encomenda.DestEndNum)
                         .ComComplementoEnderecoDestinatario(encomenda.DestCompl)
                         .ComBairroEnderecoDestinatario(encomenda.DestBairro)
                         .ComCidadeEnderecoDestinatario(encomenda.DestCidade)
                         .ComUfEnderecoDestinatario(encomenda.DestEstado)
                         .ComCepEnderecoDestinatario(encomenda.DestCep);

                        if (!string.IsNullOrWhiteSpace(encomenda.DestEmail))
                            b.ComEmailDestinatario(encomenda.DestEmail);

                        if (!string.IsNullOrWhiteSpace(encomenda.DestTelefone1))
                            b.ComTelefone1Destinatario(encomenda.DestTelefone1);

                        foreach (var nfe in encomenda.DocumentosFiscaisNfe)
                        {
                            b.ComNotaFiscalEletronica(bNfe =>
                            {
                                bNfe.ComNfeNumero(nfe.NfeNumero)
                                    .ComNfeSerie(nfe.NfeSerie)
                                    .ComNfeData(nfe.NfeData)
                                    .ComNfeValorTotal(nfe.NfeValProd)
                                    .ComNfeValorProduto(nfe.NfeValTotal)
                                    .ComNfeCfop(nfe.NfeCfop)
                                    .ComNfeChaveAcesso(nfe.NfeChaveAcesso);

                                return bNfe;
                            });
                        }

                        return b;
                    });
            }

            var xmlRequest = builder
                                .GerarXml();

            var xmlResponse = MakeRequest(_username,
                                          _password,
                                          _urlRegistrarColeta,
                                          _soapActionRegistrarColeta,
                                          xmlRequest);

            return new RegistrarColetaResponseBinding(xmlRequest, xmlResponse).GenerateObject();
        }

        public ObterTrackingResponse ObterTracking(ObterTrackingRequest request)
        {
            var builder = new ObterTrackingRequestBuilder();

            var xmlRequest = builder
                                .ComDataConsulta(request.DataConsulta)
                                .GerarXml();

            var xmlResponse = MakeRequest(_username,
                                          _password,
                                          _urlObterTracking,
                                          _soapActionObterTracking,
                                          xmlRequest);

            return new ObterTrackingResponseBinding(xmlRequest, xmlResponse).GenerateObject();
        }
    }
}
