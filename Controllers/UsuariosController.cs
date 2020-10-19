using OpticaApi.Models;
using OpticaApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OpticaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get() =>
            _usuarioService.Get();

        [HttpGet("{correo}/{contrasenia}")]
        public ActionResult<Usuario> Get(string correo, string contrasenia)
        {
            var usuariosAux = _usuarioService.Get();
            var existe = false;

            foreach (var usuarioActual in usuariosAux)
            {
                if (usuarioActual.correo == correo)
                {
                    if (BCrypt.Net.BCrypt.Verify(contrasenia, usuarioActual.contrasenia))
                    {
                        existe = true;
                    }
                }
            }

            if (existe)
            {
                return Content(correo);
            }
            else
            {
                return Content("error");
            }
        }

        [HttpPost]
        public ActionResult<Usuario> Create(Usuario usuario)
        {
            var usuariosAux = _usuarioService.Get();
            var existe = false;

            foreach (var usuarioActual in usuariosAux)
            {
                if (usuarioActual.correo == usuario.correo)
                {
                    existe = true;
                }
            }

            if (existe)
            {
                return Content("Ya existe");
            }
            else
            {
                usuario.contrasenia = BCrypt.Net.BCrypt.HashPassword(usuario.contrasenia, 12);
                _usuarioService.Create(usuario);

                return Content("Creado");
            }
        }
    }
}