using Microsoft.AspNetCore.Mvc;
using System;

namespace ControlePagamentoWebApi.Controllers
{
    public class HealthChecksController : Controller
    {
        public const string RoutePath = "api/v1/healthz";

        /// <summary>
        /// Retorna o status da aplicação
        /// </summary>asd asdasd
        /// <returns>O status de funcionamento da API</returns>
        /// <response code="200">Reotrno caso a API esteja OK</response>
        /// <response code="500">Reotrno caso a API esteja com problemas</response>
        [HttpGet(RoutePath)]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult Healthz()
        {
            return Ok(DateTimeOffset.Now);
        }
    }
}