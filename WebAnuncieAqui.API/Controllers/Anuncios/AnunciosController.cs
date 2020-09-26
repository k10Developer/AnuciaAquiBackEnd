using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Servicos;

namespace WebAnuncieAqui.API.Controllers.Anuncios
{
    [Route("api/[controller]")]
    public class AnuncioController : Controller
    {
        private IAnuncioServicos _servicos;
        private IAnuncioRepositorio _repositorio;

        public AnuncioController(IAnuncioServicos anuncioServicos, IAnuncioRepositorio anuncioRepositorio )
        {
            _repositorio = anuncioRepositorio;
            _servicos = anuncioServicos;
        }

        [HttpGet]
        [Route("v1/anuncios/{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                return Ok(_repositorio.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/anuncios")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                return Ok(_repositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("v1/anuncios/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                _servicos.Remover(id);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("v1/anuncios")]
        public async Task<IActionResult> Salvar([FromBody] Anuncio anuncio)
        {
            try
            {
                anuncio.DataCriacao();
                _servicos.Salvar(anuncio);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("v1/anuncios")]
        public async Task<IActionResult> Alterar([FromBody]Anuncio anuncio)
        {
            try
            {                
                _servicos.Alterar(anuncio);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
