using System;
using System.Collections.Generic;
using System.Xml;

namespace TotalExpressWSClient.ObterTracking
{
    internal class ObterTrackingResponseBinding
    {
        private XmlDocument _xmlResponse;
        private XmlDocument _xmlRequest;

        public ObterTrackingResponseBinding(XmlDocument xmlRequest,
                                            XmlDocument xmlResponse)
        {
            _xmlResponse = xmlResponse;
            _xmlRequest = xmlRequest;
        }

        internal ObterTrackingResponse GenerateObject()
        {
            var response = new ObterTrackingResponse();

            // Start Parse

            response.CodigoProc = _xmlResponse.SelectSingleNode("//CodigoProc").InnerText;

            var nodes = _xmlResponse.SelectSingleNode("//ArrayLoteRetorno").ChildNodes;

            foreach (XmlNode node in nodes)
            {
                var item = new ArrayLoteRetornoObterTrackingResponse()
                {
                    LoteRetorno = new LoteRetornoObterTrackingResponse()
                    {
                        CodRetorno = node.SelectSingleNode("CodRetorno").InnerText,
                        DataGeracao = Convert.ToDateTime(node.SelectSingleNode("DataGeracao").InnerText)
                    }
                };

                foreach (XmlNode encomenda in node.SelectSingleNode("ArrayEncomendaRetorno").ChildNodes)
                {
                    var encomendaItem = new EncomendaRetornoObterTrackingResponse();

                    encomendaItem.AWB = encomenda.SelectSingleNode("Awb").InnerText;
                    encomendaItem.Pedido = encomenda.SelectSingleNode("Pedido").InnerText;
                    encomendaItem.NotaFiscal = encomenda.SelectSingleNode("NotaFiscal").InnerText;
                    encomendaItem.NotaFiscalSerie = encomenda.SelectSingleNode("SerieNotaFiscal").InnerText;
                    encomendaItem.IdCliente = encomenda.SelectSingleNode("IdCliente").InnerText;
                    encomendaItem.CodigoObjeto = encomenda.SelectSingleNode("CodigoObjeto").InnerText;

                    foreach(XmlNode status in encomenda.SelectSingleNode("ArrayStatusTotal").ChildNodes)
                    {
                        var statusItem = new StatusTotalObterTrackingResponse()
                        {
                            CodStatus = status.SelectSingleNode("CodStatus").InnerText,
                            DescStatus = status.SelectSingleNode("DescStatus").InnerText,
                            DataStatus = Convert.ToDateTime(status.SelectSingleNode("DataStatus").InnerText)
                        };

                        encomendaItem.ArrayStatusTotal.Add(new ArrayStatusTotalObterTrackingResponse()
                        {
                             StatusTotal = statusItem
                        });
                    }

                    item.LoteRetorno.ArrayEncomendaRetorno.Add(new ArrayEncomendaRetornoObterTrackingResponse()
                    {
                        EncomendaRetorno = encomendaItem
                    });
                }

                response.ArrayLoteRetorno.Add(item);
            }

            // End Parse

            // Adding XML Response
            response.ResponseXml = _xmlResponse.OuterXml;
            response.RequestXml = _xmlRequest.OuterXml;

            return response;
        }
    }
}
