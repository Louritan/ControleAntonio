using System;

namespace ControleAntonio.Domain
{
    public class ContaDeLuz
    {
        public long NumeroLeitura { get; set; }
        public DateTime DataLeitura { get; set; }
        public DateTime DataPagamento { get; set; }
        public double KWGastoMes { get; set; }
        public double Valor { get; set; }
        public double MediaConsumo { get; set; }

        public ContaDeLuz(long numeroLeitura, DateTime dataLeitura, DateTime dataPagamento, double kwGastoMes, double valor, double mediaConsumo)
        {
            NumeroLeitura = numeroLeitura;
            DataLeitura = dataLeitura;
            DataPagamento = dataPagamento;
            KWGastoMes = kwGastoMes;
            Valor = valor;
            MediaConsumo = mediaConsumo;
        }

        public override string ToString()
        {
            return $"Número da leitura: {NumeroLeitura} - Data da leitura: {DataLeitura.ToShortDateString()} - Data do pagamento: {DataPagamento.ToShortDateString()} - KW gasto no mês: {KWGastoMes} - Valor: {Valor} - Média de Consumo: {MediaConsumo}";
        }
    }
}