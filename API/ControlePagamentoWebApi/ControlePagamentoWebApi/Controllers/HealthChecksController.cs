using Microsoft.AspNetCore.Mvc;
using System;

namespace ControlePagamentoWebApi.Controllers
{
    public class HealthChecksController : Controller
    {
        public const string RoutePath = "/healthz";

        [HttpGet(RoutePath)]
        public IActionResult Healthz()
        {
            return Ok(DateTimeOffset.Now);
        }
    }
}