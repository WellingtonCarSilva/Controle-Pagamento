using ControlePagamentoWebApi.Dto;
using ControlePagamentoWebApi.ExemploSwagger;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace ControlePagamentoWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        /// <summary>
        /// Obtem informações relacionadas a um pagamento especifico
        /// </summary>
        /// <param name="id">ID do pagamento</param>
        /// <returns>Pagamento solicitado</returns>
        /// <response code="200">Caso o pagamento seja bem sucedido</response>
        /// <response code="400">Caso o pagamento não seja encontrado</response>
        /// <response code="500">Caso ocorra um erro desconhecido</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PagamentoGetResult), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        [SwaggerResponse(200, Type = typeof(PagamentoGetResult))]
        [SwaggerResponseExample(200, typeof(PagamentoGetExemplo))]
        public IActionResult ObtemPagamento(Guid id)
        {
            PagamentoGetResult pagamentoDto = new PagamentoGetResult
            {
                Id = id,
                DataSolicitacao = Mock.DataSolicitacao,
                DataAprovacao = null,
                StatusPagamento = Mock.StatusPagamento,
                Valor = Mock.Valor
            };

            if (pagamentoDto.DataSolicitacao.AddSeconds(30) < DateTimeOffset.Now)
            {
                pagamentoDto.DataAprovacao = DateTimeOffset.Now;
                pagamentoDto.StatusPagamento = StatusPagamentoDto.Pago;
            }

            return Ok(pagamentoDto);
        }

        /// <summary>
        /// Realiza o cadastro de um pagamento
        /// </summary>
        /// <param name="pagamentoPost">Estrutura de pagamento</param>
        /// <returns>Pagamento realizado</returns>
        /// <response code="200">Caso o pagamento seja bem sucedido</response>
        /// <response code="400">Caso ocorra um erro conhecido no processamento</response>
        /// <response code="500">Caso ocorra um erro desconhecido</response>
        [HttpPost]
        [ProducesResponseType(typeof(PagamentoPostResult), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        [SwaggerResponse(200, Type = typeof(PagamentoPostResult))]
        [SwaggerResponseExample(200, typeof(PagamentoPostExemplo))]
        public IActionResult RealizaPagamento([FromBody]PagamentoPost pagamentoPost)
        {
            var pagamentoPostResult = new PagamentoPostResult
            {
                Id = Guid.NewGuid(),
                DataSolicitacao = DateTimeOffset.Now,
                DataAprovacao = null,
                StatusPagamento = StatusPagamentoDto.Processando,
                Valor = pagamentoPost.Valor
            };

            Mock.Id = Guid.NewGuid();
            Mock.DataSolicitacao = DateTimeOffset.Now;
            Mock.DataAprovacao = null;
            Mock.StatusPagamento = StatusPagamentoDto.Processando;
            Mock.Valor = pagamentoPost.Valor;

            return Ok(pagamentoPostResult);
        }
    }

    public static class Mock
    {
        public static Guid Id { get; set; }
        public static double Valor { get; set; }
        public static StatusPagamentoDto StatusPagamento { get; set; }
        public static DateTimeOffset DataSolicitacao { get; set; }
        public static DateTimeOffset? DataAprovacao { get; set; }
    }
}