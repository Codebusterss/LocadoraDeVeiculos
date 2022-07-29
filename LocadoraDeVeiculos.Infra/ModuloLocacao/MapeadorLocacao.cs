using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloLocacao
{
    public class MapeadorLocacao : MapeadorBase<Locacao>
    {
        RepositorioVeiculoEmBancoDeDados repositorioVeiculo = new RepositorioVeiculoEmBancoDeDados();
        RepositorioFuncionarioEmBancoDeDados repositorioFuncionario = new RepositorioFuncionarioEmBancoDeDados();
        RepositorioCondutorEmBancoDeDados repositorioCondutor = new RepositorioCondutorEmBancoDeDados();
        RepositorioClienteEmBancoDeDados repositorioCliente = new RepositorioClienteEmBancoDeDados();
        RepositorioPlanoDeCobrancaEmBancoDeDados repositorioPlano = new RepositorioPlanoDeCobrancaEmBancoDeDados();


        public override void ConfigurarParametros(Locacao locacao, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", locacao.ID);
            comando.Parameters.AddWithValue("VEICULOID", locacao.Veiculo.ID);
            comando.Parameters.AddWithValue("FUNCIONARIOID", locacao.Funcionario.ID);
            comando.Parameters.AddWithValue("CLIENTEID", locacao.Cliente.ID);
            comando.Parameters.AddWithValue("CONDUTORID", locacao.Condutor.ID);
            comando.Parameters.AddWithValue("PLANOID", locacao.Plano.ID);
            comando.Parameters.AddWithValue("DATALOCACAO", locacao.DataLocacao);
            comando.Parameters.AddWithValue("DATADEVOLUCAO", locacao.DataDevolucao);
            comando.Parameters.AddWithValue("STATUSLOCACAO", locacao.StatusLocacao);
            comando.Parameters.AddWithValue("SEGURO", locacao.Seguro);
            comando.Parameters.AddWithValue("VALOR", locacao.Valor);
        }



        public override Locacao ConverterRegistro(SqlDataReader leitorLocacao)
        {
            var id = Guid.Parse(leitorLocacao["ID"].ToString());
            var veiculoID = Guid.Parse(leitorLocacao["VEICULOID"].ToString());
            var funcionarioID = Guid.Parse(leitorLocacao["FUNCIONARIOID"].ToString());
            var clienteID = Guid.Parse(leitorLocacao["CLIENTEID"].ToString());
            var condutorID = Guid.Parse(leitorLocacao["CONDUTORID"].ToString());
            var planoID = Guid.Parse(leitorLocacao["PLANOID"].ToString());
            var dataLocacao = Convert.ToDateTime(leitorLocacao["DATALOCACAO"]);
            var dataDevolucao = Convert.ToDateTime(leitorLocacao["DATADEVOLUCAO"]);
            var statusLocacao = Convert.ToString(leitorLocacao["STATUSLOCACAO"]);
            var seguro = Convert.ToString(leitorLocacao["SEGURO"]);
            var valor = Convert.ToDouble(leitorLocacao["VALOR"]);
            
            Locacao locacao = new Locacao();
            locacao.ID = id;
            locacao.Veiculo = repositorioVeiculo.SelecionarPorId(veiculoID);
            locacao.Funcionario = repositorioFuncionario.SelecionarPorId(funcionarioID);
            locacao.Cliente = repositorioCliente.SelecionarPorId(clienteID);
            locacao.Condutor = repositorioCondutor.SelecionarPorId(condutorID);
            locacao.Plano = repositorioPlano.SelecionarPorId(planoID);
            locacao.DataLocacao = dataLocacao;
            locacao.DataDevolucao = dataDevolucao;
            locacao.StatusLocacao = statusLocacao;
            locacao.Seguro = seguro;
            locacao.Valor = valor;

            return locacao;
        }
    }
}
