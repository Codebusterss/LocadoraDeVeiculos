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
            comando.Parameters.AddWithValue("ID", condutor.ID);
            comando.Parameters.AddWithValue("CLIENTE_ID", condutor.Cliente.ID); //puxa cliente
            comando.Parameters.AddWithValue("NOME", condutor.Nome);
            comando.Parameters.AddWithValue("CNH", condutor.CNH);
            comando.Parameters.AddWithValue("CPF", condutor.CPF);
            comando.Parameters.AddWithValue("VALIDADECNH", condutor.ValidadeCNH);
            comando.Parameters.AddWithValue("ENDERECO", condutor.Endereco);
            comando.Parameters.AddWithValue("EMAIL", condutor.Email);
            comando.Parameters.AddWithValue("TELEFONE", condutor.Telefone);
            

            if (condutor.CondutorCliente == true)
            {
                comando.Parameters.AddWithValue("CONDUTORCLIENTE", 1);
            }
            else
            {
                comando.Parameters.AddWithValue("CONDUTORCLIENTE", 0);
            }

        }

        public override Condutor ConverterRegistro(SqlDataReader leitorCondutor)
        {
            var id = Guid.Parse(leitorCondutor["ID"].ToString());
            var clienteCond = Guid.Parse(leitorCondutor["CLIENTE_ID"].ToString());
            var nome = Convert.ToString(leitorCondutor["NOME"]);
            var cnh = Convert.ToString(leitorCondutor["CNH"]);
            var cpf = Convert.ToString(leitorCondutor["CPF"]);
            var validadecnh = Convert.ToDateTime(leitorCondutor["VALIDADECNH"]);
            var endereco = Convert.ToString(leitorCondutor["ENDERECO"]);
            var email = Convert.ToString(leitorCondutor["EMAIL"]);
            var telefone = Convert.ToString(leitorCondutor["TELEFONE"]);
            var condutorcliente = Convert.ToBoolean(leitorCondutor["CONDUTORCLIENTE"]);
          

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
            condutor.CondutorCliente = condutorcliente;


            return condutor;
        }
    }
}
