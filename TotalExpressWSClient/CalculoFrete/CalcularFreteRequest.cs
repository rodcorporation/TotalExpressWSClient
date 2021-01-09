namespace TotalExpressWSClient.CalculoFrete
{
    public class CalcularFreteRequest
    {
        public string TipoServico { get; set; }

        public string CepDestino { get; set; }

        public decimal Peso { get; set; }

        public decimal ValorDeclarado { get; set; }

        public short TipoEntrega { get; set; }

        public bool ServicoCOD { get; set; }

        public int Altura { get; set; }

        public int Largura { get; set; }

        public int Profundidade { get; set; }
    }
}
