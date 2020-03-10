using ControlePagamentoWebApi.Dto;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace ControlePagamentoWebApi.ExemploSwagger
{
    public class PagamentoGetExemplo : IExamplesProvider<PagamentoGetResult>
    {
        public PagamentoGetResult GetExamples()
        {
            return new PagamentoGetResult
            {
                Id = Guid.NewGuid(),
                DataSolicitacao = DateTimeOffset.Now,
                DataAprovacao = null,
                StatusPagamento = StatusPagamentoDto.Processando,
                Valor = 1234.12
            };
        }
    }

    public class PagamentoPostExemplo : IExamplesProvider<PagamentoPostResult>
    {
        public PagamentoPostResult GetExamples()
        {
            return new PagamentoPostResult
            {
                Id = Guid.NewGuid(),
                DataSolicitacao = DateTimeOffset.Now.AddDays(-1),
                DataAprovacao = DateTimeOffset.Now.AddHours(-20),
                StatusPagamento = StatusPagamentoDto.Pago,
                Valor = 1234.12
            };
        }
    }
}