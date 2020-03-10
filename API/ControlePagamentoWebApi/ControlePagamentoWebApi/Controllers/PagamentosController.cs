using ControlePagamentoWebApi.Dto;
using ControlePagamentoWebApi.ExemploSwagger;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
//using Swashbuckle.AspNetCore.Examples;
//using Swashbuckle.AspNetCore.Filters;
using System;

namespace ControlePagamentoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        /// <summary>
        /// Retorna os dados do pagamento do id passado por parâmetro
        /// </summary>
        /// <param name="id">Identificador do pagamento</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PagamentoGetResult), 200)]
        [SwaggerResponse(200, Type = typeof(PagamentoGetResult))]
        [SwaggerResponseExample(200, typeof(PagamentoGetExemplo))]
        public IActionResult ObtemPagamento(Guid id)
        {
            PagamentoGetResult pagamentoDto = new PagamentoGetResult
            {
                Id = Guid.NewGuid(),
                DataSolicitacao = DateTimeOffset.Now,
                DataAprovacao = null,
                StatusPagamento = StatusPagamentoDto.Processando,
                Valor = 1234.12
            };

            return Ok(pagamentoDto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PagamentoPostResult), 200)]
        [SwaggerResponse(200, Type = typeof(PagamentoPostResult))]
        [SwaggerResponseExample(200, typeof(PagamentoPostExemplo))]
        public IActionResult RealizaPagamento(PagamentoPost pagamentoPost)
        {
            PagamentoPostResult pagamentoDto = new PagamentoPostResult
            {
                Id = Guid.NewGuid(),
                DataSolicitacao = DateTimeOffset.Now,
                DataAprovacao = null,
                StatusPagamento = StatusPagamentoDto.Pago,
                Valor = pagamentoPost.Valor
            };

            return Ok(pagamentoDto);
        }
    }
}