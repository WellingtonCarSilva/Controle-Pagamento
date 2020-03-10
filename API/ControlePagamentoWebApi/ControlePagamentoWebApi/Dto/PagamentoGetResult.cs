using System;

namespace ControlePagamentoWebApi.Dto
{
    public class PagamentoGetResult
    {
        public Guid Id { get; set; }
        public double Valor { get; set; }
        public StatusPagamentoDto StatusPagamento { get; set; }
        public DateTimeOffset DataSolicitacao { get; set; }
        public DateTimeOffset? DataAprovacao { get; set; }
    }
}
