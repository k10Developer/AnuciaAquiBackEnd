using System;
using System.Collections.Generic;
using System.Text;
using WebAnuncieAqui.Dominio.Dominios.Veiculos;
using WebAnuncieAqui.Dominio.Dominios.Veiculos.Repositorio;
using WebAnuncieAqui.Dominio.Dominios.Veiculos.Servicos;

namespace WebAnuncieAqui.Business.Servicos.Veiculos
{
    public class VeiculoServicos: IVeiculoServicos
    {
        private IVeiculoRepositorio _repositorio;
        public VeiculoServicos(IVeiculoRepositorio veiculoRepositorio)
        {
            _repositorio = veiculoRepositorio;
        }

        public void Alterar(Veiculo veiculo)
        {
            _repositorio.Alterar(veiculo);
        }

        public void Remover(int veiculoId)
        {
            _repositorio.Remover(veiculoId);
        }

        public void Salvar(Veiculo veiculo)
        {
            _repositorio.Salvar(veiculo);
        }
    }
}
