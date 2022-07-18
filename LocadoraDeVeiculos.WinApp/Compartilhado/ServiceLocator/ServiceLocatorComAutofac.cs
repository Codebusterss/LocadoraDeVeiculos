using Autofac;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloTaxa;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorComAutofac : IServiceLocator
    {
        private readonly IContainer container;

        public ServiceLocatorComAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RepositorioClienteEmBancoDeDados>().As<IRepositorioCliente>();
            builder.RegisterType<ServicoCliente>().As<IServicoCliente>();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioGrupoDeVeiculosEmBancoDeDados>().As<IRepositorioGrupoDeVeiculo>();
            builder.RegisterType<ServicoGrupoDeVeiculo>().As<IServicoGrupoDeVeiculo>();
            builder.RegisterType<ControladorGrupoDeVeiculo>().AsSelf();

            builder.RegisterType<RepositorioFuncionarioEmBancoDeDados>().As<IRepositorioFuncionario>();
            builder.RegisterType<ServicoFuncionario>().As<IServicoFuncionario>();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<RepositorioCondutorEmBancoDeDados>().As<IRepositorioCondutor>();
            builder.RegisterType<ServicoCondutor>().As<IServicoCondutor>();
            builder.RegisterType<ControladorCondutor>().AsSelf();

            builder.RegisterType<RepositorioTaxaEmBancoDeDados>().As<IRepositorioTaxa>();
            builder.RegisterType<ServicoTaxa>().As<IServicoTaxa>();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            builder.RegisterType<RepositorioVeiculoEmBancoDeDados>().As<IRepositorioVeiculo>();
            builder.RegisterType<ServicoVeiculo>().As<IServicoVeiculo>();
            builder.RegisterType<ControladorVeiculos>().AsSelf();

            builder.RegisterType<RepositorioPlanoDeCobrancaEmBancoDeDados>().As<IRepositorioPlanoDeCobranca>();
            builder.RegisterType<ServicoPlanoDeCobranca>().As<IServicoPlanoDeCobranca>();
            builder.RegisterType<ControladorPlanoDeCobranca>().AsSelf();

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
