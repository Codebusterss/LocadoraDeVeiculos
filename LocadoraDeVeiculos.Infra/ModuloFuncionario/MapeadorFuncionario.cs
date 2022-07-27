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
            comando.Parameters.AddWithValue("NOME", funcionario.Nome);
            comando.Parameters.AddWithValue("LOGIN", funcionario.Login);
            comando.Parameters.AddWithValue("SENHA", funcionario.Senha);
            comando.Parameters.AddWithValue("SALARIO", funcionario.Salario);
            comando.Parameters.AddWithValue("DATAADMISSAO", funcionario.DataAdmissao);
            comando.Parameters.AddWithValue("ADMIN", funcionario.Admin);
        }

       

        public override Funcionario ConverterRegistro(SqlDataReader leitorFuncionario)
        {
            var id = Guid.Parse(leitorFuncionario["ID"].ToString());
            var nome = Convert.ToString(leitorFuncionario["NOME"]);
            var login = Convert.ToString(leitorFuncionario["LOGIN"]);
            var senha = Convert.ToString(leitorFuncionario["SENHA"]);
            var salario = Convert.ToSingle(leitorFuncionario["SALARIO"]);
            var dataAdmissao = Convert.ToDateTime(leitorFuncionario["DATAADMISSAO"]);
            var admin = Convert.ToBoolean(leitorFuncionario["ADMIN"]);
           

            Funcionario funcionario = new Funcionario();
            funcionario.ID = id;
            funcionario.Nome = nome;
            funcionario.Login = login;
            funcionario.Senha = senha;
            funcionario.Salario = salario;
            funcionario.DataAdmissao = dataAdmissao;
            funcionario.Admin = admin;

            return funcionario;
        }
    }
}
