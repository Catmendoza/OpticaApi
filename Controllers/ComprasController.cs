using OpticaApi.Models;
using OpticaApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OpticaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly CompraService _compraService;

        public CompraController(CompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public ActionResult<List<Compra>> Get() =>
            _compraService.Get();

        [HttpGet("{id}")]
        public ActionResult<Compra> Get(string id)
        {
            var compraAuxiliar = _compraService.Get();
            var lista = new List<Compra>();

            foreach (var compra in compraAuxiliar)
            {
                if (compra.id_usuario == id)
                {
                    lista.Add(compra);
                }
            }

            return Ok(lista);
        }

        [HttpPost]
        public ActionResult<Compra> Create(Compra compra)
        {
            _compraService.Create(compra);

            return Content("Creado");
        }
    }
}