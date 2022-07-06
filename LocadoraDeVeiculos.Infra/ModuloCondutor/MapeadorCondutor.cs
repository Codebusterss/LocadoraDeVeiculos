using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
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
        RepositorioClienteEmBancoDeDados repositorioCliente = new RepositorioClienteEmBancoDeDados();
        public override void ConfigurarParametros(Condutor condutor, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("CONDUTOR_ID", condutor.ID);
            comando.Parameters.AddWithValue("CLIENTE_COND", condutor.Cliente.ID); //puxa cliente
            comando.Parameters.AddWithValue("CONDUTOR_NOME", condutor.Nome);
            comando.Parameters.AddWithValue("CONDUTOR_CNH", condutor.CNH);
            comando.Parameters.AddWithValue("CONDUTOR_CPF", condutor.CPF);
            comando.Parameters.AddWithValue("CONDUTOR_CNH", condutor.ValidadeCNH);
            comando.Parameters.AddWithValue("CONDUTOR_ENDERECO", condutor.Endereco);
            comando.Parameters.AddWithValue("CONDUTOR_EMAIL", condutor.Email);
            comando.Parameters.AddWithValue("CONDUTOR_TELEFONE", condutor.Telefone);
            comando.Parameters.AddWithValue("CONDUTOR_CLIENTE ", condutor.ClienteCondutor);

           

        }

        public override Condutor ConverterRegistro(SqlDataReader leitorCondutor)
        {
            var id = Convert.ToInt32(leitorCondutor["CONDUTOR_ID"]);
            var clienteCond = Convert.ToInt32(leitorCondutor["CLIENTE_COND"]);
            var nome = Convert.ToString(leitorCondutor["CONDUTOR_NOME"]);
            var cnh = Convert.ToString(leitorCondutor["CONDUTOR_CNH"]);
            var cpf = Convert.ToString(leitorCondutor["CONDUTOR_CPF"]);
            var validadecnh = Convert.ToDateTime(leitorCondutor["CONDUTOR_ValidadeCNH"]);
            var endereco = Convert.ToString(leitorCondutor["CONDUTOR_ENDERECO"]);
            var email = Convert.ToString(leitorCondutor["CONDUTOR_EMAIL"]);
            var telefone = Convert.ToString(leitorCondutor["CONDUTOR_TELEFONE"]);
            var clientecondutor = Convert.ToBoolean(leitorCondutor["CONDUTOR_CLIENTECONDUTOR"]);
          

            Condutor condutor = new Condutor();
            condutor.ID = id;
            condutor.Cliente = repositorioCliente.SelecionarPorId(clienteCond);
            condutor.Nome = nome;
            condutor.CNH = cnh;
            condutor.CPF = cpf;
            condutor.ValidadeCNH = validadecnh;
            condutor.Endereco = endereco;
            condutor.Email = email;
            condutor.Telefone = telefone;
            condutor.ClienteCondutor = clientecondutor;


            condutor.Cliente = new MapeadorCliente().ConverterRegistro(leitorCondutor);


            return condutor;
        }
    }
}
