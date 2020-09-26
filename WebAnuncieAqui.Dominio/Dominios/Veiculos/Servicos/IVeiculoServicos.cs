using System;
using System.Collections.Generic;
using System.Text;

namespace WebAnuncieAqui.Dominio.Dominios.Veiculos.Servicos
{
    public interface IVeiculoServicos
    {
        void Salvar(Veiculo veiculo);
        void Alterar(Veiculo veiculo);
        void Remover(int veiculoId);
    }
}
