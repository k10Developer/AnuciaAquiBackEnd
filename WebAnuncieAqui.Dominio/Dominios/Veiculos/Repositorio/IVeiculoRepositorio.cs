using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Veiculos.Repositorio
{
    public interface IVeiculoRepositorio
    {
        void Salvar(Veiculo veiculo);
        void Alterar(Veiculo veiculo);
        void Remover(int veiculoId);
        List<Veiculo> ObterTodos();
        Veiculo ObterPorId(int veiculoId);
    }
}
