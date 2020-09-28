using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Servicos;

namespace WebAnuncieAqui.API.Controllers.Marcas
{
    [Route("api/[controller]")]
    public class MarcaController : Controller
    {
        private IMarcaServicos _servicos;
        private IMarcaRepositorio _repositorio;

        public MarcaController(IMarcaServicos marcaServicos, IMarcaRepositorio marcaRepositorio)
        {
            _repositorio = marcaRepositorio;
            _servicos = marcaServicos;
        }

        [HttpGet]
        [Route("v1/Marcas/{id}")]
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
        [Route("v1/Marcas")]
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
        [Route("v1/Marcas/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                if (_repositorio.VinculadoAAlgumCarro(id))
                    throw new Exception("Marca não pode ser removida, pois possui vinculo com um carro.");
                _servicos.Remover(id);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("v1/Marcas")]
        public async Task<IActionResult> Salvar([FromBody]Marca Marca)
        {
            try
            {
                _servicos.Salvar(Marca);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        [Route("v1/Marcas")]
        public async Task<IActionResult> Alterar([FromBody] Marca Marca)
        {
            try
            {
                _servicos.Alterar(Marca);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
