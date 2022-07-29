using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.ORM.Compartilhado;
using LocadoraDeVeiculos.ORM.ModuloCliente;
using LocadoraDeVeiculos.ORM.ModuloCondutor;
using LocadoraDeVeiculos.ORM.ModuloFuncionario;
using LocadoraDeVeiculos.ORM.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.ORM.ModuloLocacao;
using LocadoraDeVeiculos.ORM.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.ORM.ModuloTaxa;
using LocadoraDeVeiculos.ORM.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.WinApp.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public class ServiceLocatorManual : IServiceLocator
    {
        private Dictionary<string, ControladorBase> controladores;
        Funcionario funcionarioLogado = new Funcionario();

        public ServiceLocatorManual()
        {
            controladores = new Dictionary<string, ControladorBase>();

            ConfigurarControladores();
        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }

        private void ConfigurarControladores()
        {
            var configuracao = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("ConfiguracaoAplicacao.json")
                 .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var contextoDadosOrm = new LocadoraDeVeiculosDbContext(connectionString);

            var repositorioFuncionario = new RepositorioFuncionarioORM (contextoDadosOrm);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, contextoDadosOrm);
            controladores.Add("ControladorFuncionario", new ControladorFuncionario(servicoFuncionario));
       
            var repositorioTaxa = new RepositorioTaxaORM(contextoDadosOrm);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa, contextoDadosOrm);
            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxa));

            var repositorioCliente = new RepositorioClienteORM(contextoDadosOrm);
            var servicoCliente = new ServicoCliente(repositorioCliente, contextoDadosOrm);
            controladores.Add("ControladorCliente", new ControladorCliente(servicoCliente));

            var repositorioCondutor = new RepositorioCondutorORM(contextoDadosOrm);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor, contextoDadosOrm);
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCondutor, servicoCliente));

            var repositorioGrupo = new RepositorioGrupoORM(contextoDadosOrm);
            var servicoGrupo = new ServicoGrupoDeVeiculo(repositorioGrupo, contextoDadosOrm);
            controladores.Add("ControladorGrupoDeVeiculo", new ControladorGrupoDeVeiculo(servicoGrupo));
            
            
            var repositorioPlano = new RepositorioPlanoORM(contextoDadosOrm);
            var servicoPlano = new ServicoPlanoDeCobranca(repositorioPlano, contextoDadosOrm);
            controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(servicoPlano, servicoGrupo));

            var repositorioVeiculo = new RepositorioVeiculoORM(contextoDadosOrm);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo, contextoDadosOrm);
            controladores.Add("ControladorVeiculos", new ControladorVeiculos(servicoVeiculo, servicoGrupo));

            var repositorioLocacao = new RepositorioLocacaoORM(contextoDadosOrm);
            var servicoLocacao = new ServicoLocacao(repositorioLocacao, contextoDadosOrm);
            controladores.Add("ControladorLocacao", new ControladorLocacao(servicoLocacao, servicoCliente, servicoTaxa, servicoCondutor, servicoVeiculo, servicoPlano, servicoFuncionario));

        }
    }
}
