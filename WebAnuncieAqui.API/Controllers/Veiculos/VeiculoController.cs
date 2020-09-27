using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAnuncieAqui.Dominio.Dominios.Veiculos;
using WebAnuncieAqui.Dominio.Dominios.Veiculos.Repositorio;
using WebAnuncieAqui.Dominio.Dominios.Veiculos.Servicos;

namespace WebAnuncieAqui.API.Controllers.Veiculos
{
    [Route("api/[controller]")]
    public class VeiculoController : Controller
    {
        private IVeiculoServicos _servicos;
        private IVeiculoRepositorio _repositorio;

        public VeiculoController(IVeiculoServicos veiculoServicos, IVeiculoRepositorio veiculoRepositorio)
        {
            _repositorio = veiculoRepositorio;
            _servicos = veiculoServicos;
        }

        [HttpGet]
        [Route("v1/Veiculos/{id}")]
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
        [Route("v1/Veiculos")]
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

        [HttpGet]
        [Route("v1/Veiculos/SemVinculo")]
        public async Task<IActionResult> ObterTodosSemVinculo()
        {
            try
            {
                return Ok(_repositorio.ObterVeiculosSemVinculos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("v1/Veiculos/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                _servicos.Remover(id);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost]
        [Route("v1/Veiculos")]
        public async Task<IActionResult> Salvar([FromBody]Veiculo Veiculo)
        {
            try
            {
                _servicos.Salvar(Veiculo);
                return Ok(new { message = "Operação realizada com sucesso."});
            }
            catch (Exception ex)
            {
                return BadRequest(new {error =  ex.Message });
            }
        }

        [HttpPut]
        [Route("v1/Veiculos")]
        public async Task<IActionResult> Alterar([FromBody]Veiculo Veiculo)
        {
            try
            {
                _servicos.Alterar(Veiculo);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
