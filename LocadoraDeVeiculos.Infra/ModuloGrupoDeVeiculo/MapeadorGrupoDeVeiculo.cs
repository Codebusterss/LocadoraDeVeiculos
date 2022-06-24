using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos
{
    public class MapeadorGrupoDeVeiculo : MapeadorBase<GrupoDeVeiculo>
    {
        public override void ConfigurarParametros(GrupoDeVeiculo grupoDeVeiculo, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", grupoDeVeiculo.ID);
            comando.Parameters.AddWithValue("NOME", grupoDeVeiculo.Nome);
        }

        public override GrupoDeVeiculo ConverterRegistro(SqlDataReader leitorGrupoDeVeiculo)
        {
            var id = Convert.ToInt32(leitorGrupoDeVeiculo["ID"]);
            var nome = Convert.ToString(leitorGrupoDeVeiculo["NOME"]);

            GrupoDeVeiculo grupoDeVeiculo = new GrupoDeVeiculo();
            grupoDeVeiculo.ID = id;
            grupoDeVeiculo.Nome = nome;

            return grupoDeVeiculo;
        }
    }
}
