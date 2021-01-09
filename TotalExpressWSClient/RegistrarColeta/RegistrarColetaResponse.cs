using System.Collections.Generic;

namespace TotalExpressWSClient.RegistrarColeta
{
    public class RegistrarColetaResponse
    {
        public string CodRomaneio { get; set; }

        public int ItensProcessados { get; set; }

        public int ItensRejeitados { get; set; }

        public List<ErrosIndividuais> ErrosIndividuais { get; set; }

        public int CodigoProc { get; set; }

        public string NumProtocolo { get; set; }

        public RegistrarColetaResponse()
        {
            ErrosIndividuais = new List<ErrosIndividuais>();
        }
    }

    public class ErrosIndividuais
    {
        public string Pedido { get; set; }

        public int CodigoErro { get; set; }

        public string DescricaoErro { get; set; }
    }
}
