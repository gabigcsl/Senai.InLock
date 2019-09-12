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
    [Produces("application/json")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        JogoRepository jogoRepository = new JogoRepository();

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(jogoRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]

        public IActionResult Cadastrar(Jogos jogos)
        {
            jogoRepository.Cadastrar(jogos);
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            jogoRepository.Deletar(id);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(Jogos jogos, int id)
        {
            jogos.IdJogos = id;
            jogoRepository.Atualizar(jogos);
            return Ok();
        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            Jogos JogoBuscado = jogoRepository.BuscarPorId(id);
            return Ok(JogoBuscado);
        }
    }
}