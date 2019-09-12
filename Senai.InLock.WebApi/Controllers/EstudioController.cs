using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    //[Produces("application/json")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        EstudiosRepository estudiosRepository = new EstudiosRepository();

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(estudiosRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]

        public IActionResult Cadastrar(Estudios estudios)
        {
            estudiosRepository.Cadastrar(estudios);
            return Ok();
        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            Estudios estudioBuscado = estudiosRepository.BuscarPorId(id);
            return Ok(estudioBuscado);
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            estudiosRepository.Deletar(id);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(Estudios estudios, int id)
        {
            estudios.IdEstudio = id;
            estudiosRepository.Atualizar(estudios);
            return Ok();
        }
    }
}