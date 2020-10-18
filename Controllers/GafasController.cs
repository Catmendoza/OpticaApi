using OpticaApi.Models;
using OpticaApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OpticaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GafasController : ControllerBase
    {
        private readonly GafaService _gafaService;

        public GafasController(GafaService gafaService)
        {
            _gafaService = gafaService;
        }

        [HttpGet]
        public ActionResult<List<Gafa>> Get() =>
            _gafaService.Get();

        [HttpGet("{id}")]
        public ActionResult<Gafa> Get(string id)
        {
            var gafaAuxiliar = _gafaService.Get(id);

            if (gafaAuxiliar == null)
            {
                return NotFound();
            }
            else
            {
                return gafaAuxiliar;
            }
        }

        [HttpPost]
        public ActionResult<Gafa> Create(Gafa gafa)
        {
            _gafaService.Create(gafa);

            return Content("Creado");
        }


    }
}