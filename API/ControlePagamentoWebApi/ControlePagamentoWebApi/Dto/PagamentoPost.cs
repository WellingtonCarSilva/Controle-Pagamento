using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePagamentoWebApi.Dto
{
    public class PagamentoPost
    {
        public double Valor { get; set; }
        public FormaPagamentoDto FormaPagamento { get; set; }
        public CartaoDto Cartao { get; set; }
        public int QuantidadeParcelas { get; set; }
        public ICollection<Item> Itens { get; set; }
    }
}
