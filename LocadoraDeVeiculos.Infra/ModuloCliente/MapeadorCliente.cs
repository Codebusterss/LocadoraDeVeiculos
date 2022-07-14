using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente cliente, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", cliente.ID);
            comando.Parameters.AddWithValue("NOME", cliente.Nome);
            comando.Parameters.AddWithValue("CNPJ", cliente.CNPJ);
            comando.Parameters.AddWithValue("CPF", cliente.CPF);
           
            comando.Parameters.AddWithValue("ENDERECO", cliente.Endereco);
            comando.Parameters.AddWithValue("EMAIL", cliente.Email);
            comando.Parameters.AddWithValue("TELEFONE", cliente.Telefone);

            if(cliente.PessoaFisica == true)
            {
                comando.Parameters.AddWithValue("TIPOCLIENTE", 1);
            }
            else
            {
                comando.Parameters.AddWithValue("TIPOCLIENTE", 0);
            }

        }

        public override Cliente ConverterRegistro(SqlDataReader leitorCliente)
        {
            var id = Guid.Parse(leitorCliente["ID"].ToString());
            var nome = Convert.ToString(leitorCliente["NOME"]);
            var cnpj = Convert.ToString(leitorCliente["CNPJ"]);
            var cpf = Convert.ToString(leitorCliente["CPF"]);
           
            var endereco = Convert.ToString(leitorCliente["ENDERECO"]);
            var email = Convert.ToString(leitorCliente["EMAIL"]);
            var telefone = Convert.ToString(leitorCliente["TELEFONE"]);
            var pessoaFisica = Convert.ToBoolean(leitorCliente["TIPOCLIENTE"]);

            Cliente cliente = new Cliente();
            cliente.ID = id;
            cliente.Nome = nome;
            cliente.CNPJ = cnpj;
            cliente.CPF = cpf;
            
            cliente.Endereco = endereco;
            cliente.Email = email;
            cliente.Telefone = telefone;
            cliente.PessoaFisica = pessoaFisica;


            return cliente;
        }
    }
}
