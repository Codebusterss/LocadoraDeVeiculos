using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Compartilhado;

namespace LocadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario funcionario, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", funcionario.ID);
            comando.Parameters.AddWithValue("LOGIN", funcionario.Login);
        }

        public override void ConfigurarParametros(Funcionario registro, SqlCommand comando)
        {
            throw new NotImplementedException();
        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorFuncionario)
        {
            var id = Convert.ToInt32(leitorFuncionario["ID"]);
            var nome = Convert.ToString(leitorFuncionario["NOME"]);

            Funcionario funcionario = new Funcionario();
            funcionario.ID = id;
            funcionario.Nome = nome;

            return grupoDeVeiculo;
        }
    }
}
