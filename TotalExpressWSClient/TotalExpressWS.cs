using System;
using System.Linq;
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

            return new CalcularFreteResponseBinding(xmlResponse).GenerateObject();
        }

        public RegistrarColetaResponse RegistrarColeta(RegistrarColetaRequest request)
        {
            var builder = new RegistrarColetaRequestBuilder();

            foreach (var encomenda in request.Encomendas)
            {
                request.Encomendas.Where(p => p.DestNome == "");
                builder
                    .ComNovaEncomenda(b => b.ComTipoServico("1"));
            }

            var xmlRequest = builder                                
                                .GerarXml();

            var xmlResponse = MakeRequest(_username,
                                          _password,
                                          _urlRegistrarColeta,
                                          _soapActionRegistrarColeta,
                                          xmlRequest);

            return new RegistrarColetaResponseBinding(xmlResponse).GenerateObject();
        }
        
        public ObterTrackingResponse ObterTracking(ObterTrackingRequest request)
        {
            var builder = new ObterTrackingRequestBuilder();

            var xmlRequest = builder
                                .GerarXml();

            var xmlResponse = MakeRequest(_username,
                                          _password, 
                                          _urlObterTracking,
                                          _soapActionObterTracking,
                                          xmlRequest);

            return new ObterTrackingResponseBinding(xmlResponse).GenerateObject();
        }
    }
}
