using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAnuncieAqui.Dominio.Dominios.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Repositorios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Servicos;

namespace WebAnuncieAqui.API.Controllers.Modelos
{
    [Route("api/[controller]")]
    public class ModeloController : Controller
    {
        private IModeloServicos _servicos;
        private IModeloRepositorio _repositorio;

        public ModeloController(IModeloServicos modeloServicos, IModeloRepositorio modeloRepositorio)
        {
            _repositorio = modeloRepositorio;
            _servicos = modeloServicos;
        }

        [HttpGet]
        [Route("v1/Modelos/{id}")]
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
        [Route("v1/Modelos/Marca/{id}")]
        public async Task<IActionResult> ObterPorMarcaId(int id)
        {
            try
            {
                return Ok(_repositorio.ObterTodosPorMarca(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/Modelos")]
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
        [Route("v1/Modelos/{id}")]
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
        [Route("v1/Modelos")]
        public async Task<IActionResult> Salvar([FromBody]Modelo Modelo)
        {
            try
            {
                _servicos.Salvar(Modelo);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        [Route("v1/Modelos")]
        public async Task<IActionResult> Alterar([FromBody]Modelo Modelo)
        {
            try
            {
                _servicos.Alterar(Modelo);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
