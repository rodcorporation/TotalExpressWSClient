﻿namespace TotalExpressWSClient.CalculoFrete
{
    public class CalcularFreteResponse
    {
        public short CodigoProc { get; set; }

        public DadosFrete DadosFrete { get; set; }

        public string ErroConsultaFrete { get; set; }

        public CalcularFreteResponse()
        {
            DadosFrete = new DadosFrete();
        }
    }

    public class DadosFrete
    {
        public int Prazo { get; set; }

        public decimal ValorServico { get; set; }
    }
}