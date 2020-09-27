using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAnuciaAqui.Infra;
using WebAnuncieAqui.Dominio.Dominios.Veiculos;
using WebAnuncieAqui.Dominio.Dominios.Veiculos.Repositorio;
using WebAnuncieAqui.Infra.Helpers;

namespace WebAnuncieAqui.Infra.Repositorios.Veiculos
{
    public class VeiculosRepositorio : IVeiculoRepositorio
    {
        private WebAnuncieAquiContext _webAnuncieAquiContext;

        public VeiculosRepositorio(WebAnuncieAquiContext webAnuncieAquiContext)
        {
            _webAnuncieAquiContext = webAnuncieAquiContext;
        }
        public void Alterar(Veiculo veiculo)
        {
            _webAnuncieAquiContext.Entry<Veiculo>(veiculo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _webAnuncieAquiContext.SaveChanges();
        }

        public Veiculo ObterPorId(int veiculoId)
        {
            return _webAnuncieAquiContext.Veiculos.Where(c => c.Id == veiculoId && c.Ativo).FirstOrDefault();
        }

        public List<Veiculo> ObterTodos()
        {
            return _webAnuncieAquiContext.Veiculos.Where(c => c.Ativo).ToList();
        }

        public List<Veiculo> ObterVeiculosSemVinculos()
        {
            var sql = $@"
                   select [V].* from [Veiculo] as [V]
                           left join [Anuncio] as [A] on [A].[VeiculoId] = [V].[Id]
                           where [V].[Ativo] and([A].[Id] is null or [A].[Ativo] = {false})
                      ".TSQLToAnsi();
            var result = _webAnuncieAquiContext.Veiculos.FromSqlRaw<Veiculo>(sql).ToList();
            return result;
        }

        public void Remover(int veiculoId)
        {
            var veiculo = ObterPorId(veiculoId);
            veiculo.Ativo = false;
            Alterar(veiculo);
        }

        public void Salvar(Veiculo veiculo)
        {
            _webAnuncieAquiContext.Veiculos.Add(veiculo);
            _webAnuncieAquiContext.SaveChanges();
        }
    }
}
