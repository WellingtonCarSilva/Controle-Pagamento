using ControlePagamentoWebApi.Dto;
using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(typeof(PagamentoDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult ObtemPagamento(Guid id)
        {
            PagamentoDto pagamentoDto = new PagamentoDto
            {
                Id = Guid.NewGuid(),
                DataSolicitacao = DateTimeOffset.Now,
                DataAprovacao = null,
                StatusPagamento = StatusPagamentoDto.Processando,
                Valor = 1234.12
            };

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
        [ProducesResponseType(typeof(PagamentoDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult RealizaPagamento(PagamentoPost pagamentoPost)
        {
            PagamentoDto pagamentoDto = new PagamentoDto
            {
                Id = Guid.NewGuid(),
                DataSolicitacao = DateTimeOffset.Now,
                DataAprovacao = null,
                StatusPagamento = StatusPagamentoDto.Processando,
                Valor = pagamentoPost.Valor
            };

            return Ok(pagamentoDto);
        }
    }
}