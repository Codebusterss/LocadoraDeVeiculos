using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCondutor
{
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        public override void ConfigurarParametros(Condutor condutor, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", condutor.ID);
            comando.Parameters.AddWithValue("NOME", condutor.Nome);
            comando.Parameters.AddWithValue("CNH", condutor.CNH);
            comando.Parameters.AddWithValue("CPF", condutor.CPF);
            comando.Parameters.AddWithValue("CNH", condutor.ValidadeCNH);
            comando.Parameters.AddWithValue("ENDERECO", condutor.Endereco);
            comando.Parameters.AddWithValue("EMAIL", condutor.Email);
            comando.Parameters.AddWithValue("TELEFONE", condutor.Telefone);

           

        }

        public override Condutor ConverterRegistro(SqlDataReader leitorCliente)
        {
            var id = Convert.ToInt32(leitorCliente["ID"]);
            var nome = Convert.ToString(leitorCliente["NOME"]);
            var cnh = Convert.ToString(leitorCliente["CNH"]);
            var cpf = Convert.ToString(leitorCliente["CPF"]);
            var validadecnh = Convert.ToString(leitorCliente["ValidadeCNH"]);
            var endereco = Convert.ToString(leitorCliente["ENDERECO"]);
            var email = Convert.ToString(leitorCliente["EMAIL"]);
            var telefone = Convert.ToString(leitorCliente["TELEFONE"]);
            var pessoaFisica = Convert.ToBoolean(leitorCliente["TIPOCLIENTE"]);

            Condutor condutor = new Condutor();
            condutor.ID = id;
            condutor.Nome = nome;
            condutor.CNH = cnh;
            condutor.CPF = cpf;
            condutor.ValidadeCNH = validadecnh;
            condutor.Endereco = endereco;
            condutor.Email = email;
            condutor.Telefone = telefone;
            condutor.PessoaFisica = pessoaFisica;


            return condutor;
        }
    }
}
