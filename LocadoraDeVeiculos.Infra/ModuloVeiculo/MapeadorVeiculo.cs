using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupo = new RepositorioGrupoDeVeiculosEmBancoDeDados();
        public override void ConfigurarParametros(Veiculo registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.ID);
            comando.Parameters.AddWithValue("GRUPO_ID", registro.GrupoDeVeiculo.ID);
            comando.Parameters.AddWithValue("MODELO", registro.Modelo);
            comando.Parameters.AddWithValue("MARCA", registro.Marca);
            comando.Parameters.AddWithValue("ANO", registro.Ano);
            comando.Parameters.AddWithValue("COR", registro.Cor);
            comando.Parameters.AddWithValue("PLACA", registro.Placa);
            comando.Parameters.AddWithValue("KMPERCORRIDO", registro.KmPercorrido);
            comando.Parameters.AddWithValue("TIPODECOMBUSTIVEL", registro.TipoCombustivel);
            comando.Parameters.AddWithValue("CAPACIDADEDOTANQUE", registro.CapacidadeDoTanque);
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorVeiculo)
        {
            var id = Guid.Parse(leitorVeiculo["ID"].ToString());
            var grupoDeVeiculo = Guid.Parse(leitorVeiculo["GRUPO_ID"].ToString());
            var modelo = Convert.ToString(leitorVeiculo["MODELO"]);
            var marca = Convert.ToString(leitorVeiculo["MARCA"]);
            var placa = Convert.ToString(leitorVeiculo["PLACA"]);
            var cor = Convert.ToString(leitorVeiculo["COR"]);
            var capacidadeDoTanque = Convert.ToDouble(leitorVeiculo["CAPACIDADEDOTANQUE"]);
            var kmPercorrido = Convert.ToDouble(leitorVeiculo["KMPERCORRIDO"]);
            var ano = Convert.ToInt32(leitorVeiculo["ANO"]);
            var tipoCombustivel = Convert.ToString(leitorVeiculo["TIPODECOMBUSTIVEL"]);

            Veiculo veiculo = new Veiculo();
            veiculo.ID = id;
            veiculo.GrupoDeVeiculo = repositorioGrupo.SelecionarPorId(grupoDeVeiculo);
            veiculo.Modelo = modelo;
            veiculo.Marca = marca;
            veiculo.Ano = ano;
            veiculo.Cor = cor;
            veiculo.Placa = placa;
            veiculo.KmPercorrido = kmPercorrido;
            veiculo.TipoCombustivel = tipoCombustivel;
            veiculo.CapacidadeDoTanque = capacidadeDoTanque;
            return veiculo;
        }
    }
}
