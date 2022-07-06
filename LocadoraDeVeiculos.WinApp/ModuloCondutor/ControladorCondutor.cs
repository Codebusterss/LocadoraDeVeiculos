using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private readonly IRepositorioCondutor repositorioCondutor;
        private readonly ServicoCondutor servicoCondutor;
        private readonly RepositorioClienteEmBancoDeDados repositorioCliente;
        private TabelaCondutorControl tabelaCondutor;

        public ControladorCondutor(IRepositorioCondutor repositorioCondutor, ServicoCondutor servicoCondutor, RepositorioClienteEmBancoDeDados repositorioCliente)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.servicoCondutor = servicoCondutor;
           this.repositorioCliente = repositorioCliente;
        }

        public override void Inserir()
        {
            var condutores = repositorioCliente.SelecionarTodos();

            TelaCadastroCondutor tela = new TelaCadastroCondutor(condutores);
            tela.Condutor = new Condutor(); //condutor1 ver
            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarCondutores();
        }
        public override void Editar()
        {
            var condutores = repositorioCliente.SelecionarTodos();

             Condutor condutorSelecionado = ObtemCondutorSelecionado();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro.",
                "Edição de condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCondutor tela = new TelaCadastroCondutor(condutores);

            tela.Condutor = condutorSelecionado; //Ver condutor

            tela.GravarRegistro = servicoCondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutores();

        }
        public override void Excluir()
        {


            Condutor condutorSelecionado = ObtemCondutorSelecionado();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o condutor?",
               "Exclusão de Condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCondutor.Excluir(condutorSelecionado);
                CarregarCondutores();
            }
        }
        public override UserControl ObtemListagem()
        {
         
             tabelaCondutor = new TabelaCondutorControl();

            CarregarCondutores();

            return tabelaCondutor;
        }
        private Condutor ObtemCondutorSelecionado()
        {
            var ID = tabelaCondutor.ObtemCondutorSelecionado();

            return repositorioCondutor.SelecionarPorId(ID);
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCondutor();
        }


        private void CarregarCondutores()
        {
            List<Condutor> condutores = repositorioCondutor.SelecionarTodos();
            tabelaCondutor.AtualizarRegistros(condutores);
            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {condutores.Count} Condutores.");

        }

    }
}
