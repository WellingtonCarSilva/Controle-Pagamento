using ControlePagamentoWebApi.Dto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControlePagamentoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PagamentoDto), 200)]
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

        [HttpPost]
        [ProducesResponseType(typeof(PagamentoDto), 200)]
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