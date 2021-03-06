﻿using System;
using System.Collections.Generic;

namespace TotalExpressWSClient.RegistrarColeta
{
    public class RegistrarColetaRequest
    {
        public string CodRemessa { get; set; }

        public List<EncomendaRegistrarColetaRequest> Encomendas { get; set; }

        public RegistrarColetaRequest()
        {
            Encomendas = new List<EncomendaRegistrarColetaRequest>();
        }
    }

    public class EncomendaRegistrarColetaRequest
    {
        public int TipoServico { get; set; }
        public int TipoEntrega { get; set; }
        public decimal Peso { get; set; }
        public int Volume { get; set; }
        public string CondFrete { get; set; }
        public string Pedido { get; set; }
        public string Natureza { get; set; }
        public int IsencaoIcms { get; set; }
        public string DestNome { get; set; }
        public string DestCpfCnpj { get; set; }
        public string DestEnd { get; set; }
        public string DestEndNum { get; set; }
        public string DestCompl { get; set; }
        public string DestBairro { get; set; }
        public string DestCidade { get; set; }
        public string DestEstado { get; set; }
        public string DestCep { get; set; }
        public string DestEmail { get; set; }
        public string DestTelefone1 { get; set; }
        public List<DocumentoFiscalNfeRegistrarColetaRequest> DocumentosFiscaisNfe { get; set; }

        public EncomendaRegistrarColetaRequest()
        {
            DocumentosFiscaisNfe = new List<DocumentoFiscalNfeRegistrarColetaRequest>();
        }
    }

    public class DocumentoFiscalNfeRegistrarColetaRequest
    {
        public int NfeNumero { get; set; }
        public int NfeSerie { get; set; }
        public DateTime NfeData { get; set; }
        public decimal NfeValTotal { get; set; }
        public decimal NfeValProd { get; set; }
        public string NfeCfop { get; set; }
        public string NfeChaveAcesso { get; set; }
    }
}
