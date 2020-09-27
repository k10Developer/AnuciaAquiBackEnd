using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAnuncieAqui.Business.Servicos.Anuncios;
using WebAnuncieAqui.Dominio.Dominios.Anuncios.Servicos;
using WebAnuncieAqui.Dominio.Dominios.Vendas;
using WebAnuncieAqui.Dominio.Dominios.Vendas.Repositorio;
using WebAnuncieAqui.Dominio.Dominios.Vendas.Servicos;

namespace WebAnuncieAqui.API.Controllers.Vendas
{
    [Route("api/[controller]")]
    public class VendaController : Controller
    {
        private IVendaServicos _servicos;
        private IVendaRepositorio _repositorio;
        private IAnuncioServicos _anuncioService;

        public VendaController(IVendaServicos vendaServicos, IVendaRepositorio vendaRepositorio, IAnuncioServicos anuncioServicos)
        {
            _repositorio = vendaRepositorio;
            _servicos = vendaServicos;
            _anuncioService = anuncioServicos;
        }

        [HttpGet]
        [Route("v1/Vendas/{id}")]
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
        [Route("v1/Vendas/{dataInicio}/{dataFim}")]
        public async Task<IActionResult> ObterPorId(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                return Ok(_repositorio.ObterVendasPorPeriodo(dataInicio, dataFim));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/Vendas")]
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
        [Route("v1/Vendas/Anuncio/{id}")]
        public async Task<IActionResult> ObterTodos(int id)
        {
            try
            {
                return Ok(_repositorio.ObterPorAnuncioId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("v1/Vendas/{id}")]
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
        [Route("v1/Vendas")]
        public async Task<IActionResult> Salvar([FromBody] Venda venda)
        {
            try
            {
                venda.DataDeVenda();
                _anuncioService.FinalizarAnuncio(venda.AnuncioId);
                _servicos.Salvar(venda);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return Ok(new { error = "Operação realizada com sucesso." });
            }
        }

        [HttpPut]
        [Route("v1/Vendas")]
        public async Task<IActionResult> Alterar([FromBody] Venda venda)
        {
            try
            {
                _servicos.Alterar(venda);
                return Ok(new { message = "Operação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
