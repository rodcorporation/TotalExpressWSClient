using System;
using System.Collections.Generic;

namespace TotalExpressWSClient.ObterTracking
{
    public class ObterTrackingResponse
    {
        public string CodigoProc { get; set; }

        public string ResponseXml { get; set; }

        public IList<ArrayLoteRetornoObterTrackingResponse> ArrayLoteRetorno { get; set; }

        public ObterTrackingResponse()
        {
            ArrayLoteRetorno = new List<ArrayLoteRetornoObterTrackingResponse>();
        }
    }

    public class ArrayLoteRetornoObterTrackingResponse
    {
        public LoteRetornoObterTrackingResponse LoteRetorno { get; set; }

        public ArrayLoteRetornoObterTrackingResponse()
        {
            LoteRetorno = new LoteRetornoObterTrackingResponse();
        }
    }

    public class LoteRetornoObterTrackingResponse
    {
        public string CodRetorno { get; set; }

        public DateTime DataGeracao { get; set; }

        public IList<ArrayEncomendaRetornoObterTrackingResponse> ArrayEncomendaRetorno { get; set; }

        public LoteRetornoObterTrackingResponse()
        {
            ArrayEncomendaRetorno = new List<ArrayEncomendaRetornoObterTrackingResponse>();
        }
    }

    public class ArrayEncomendaRetornoObterTrackingResponse
    {
        public EncomendaRetornoObterTrackingResponse EncomendaRetorno { get; set; }

        public ArrayEncomendaRetornoObterTrackingResponse()
        {
            EncomendaRetorno = new EncomendaRetornoObterTrackingResponse();
        }
    }

    public class EncomendaRetornoObterTrackingResponse
    {
        public string AWB { get; set; }

        public string Pedido { get; set; }

        public string NotaFiscal { get; set; }

        public string NotaFiscalSerie { get; set; }

        public string IdCliente { get; set; }

        public string CodigoObjeto { get; set; }

        public IList<ArrayStatusTotalObterTrackingResponse> ArrayStatusTotal { get; set; }

        public IList<ArrayStatusEctObterTrackingResponse> ArrayStatusEct { get; set; }

        public EncomendaRetornoObterTrackingResponse()
        {
            ArrayStatusTotal = new List<ArrayStatusTotalObterTrackingResponse>();
            ArrayStatusEct = new List<ArrayStatusEctObterTrackingResponse>();
        }
    }

    public class ArrayStatusTotalObterTrackingResponse
    {
        public StatusTotalObterTrackingResponse StatusTotal { get; set; }

        public ArrayStatusTotalObterTrackingResponse()
        {
            StatusTotal = new StatusTotalObterTrackingResponse();
        }
    }

    public class StatusTotalObterTrackingResponse
    {
        public string CodStatus { get; set; }

        public string DescStatus { get; set; }

        public DateTime DataStatus { get; set; }
    }

    public class ArrayStatusEctObterTrackingResponse
    {
        public StatusEctObterTrackingResponse StatusEct { get; set; }

        public ArrayStatusEctObterTrackingResponse()
        {
            StatusEct = new StatusEctObterTrackingResponse();
        }
    }

    public class StatusEctObterTrackingResponse
    {
        public string EctTipo { get; set; }
        public string EctStatus { get; set; }
        public DateTime EctData { get; set; }
        public TimeSpan EctHora { get; set; }
        public string EctDescricao { get; set; }
        public string EctComentario { get; set; }
        public string EctLocal { get; set; }
        public string EctCodigo { get; set; }
        public string EctCidade { get; set; }
        public string EctUf { get; set; }
    }
}
