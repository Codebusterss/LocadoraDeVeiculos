using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
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
        private TabelaCondutorControl tabelaCondutorControl;
        private readonly ServicoCondutor servicoCondutor;
        private readonly IRepositorioCliente repositorioCliente;
        private TabelaCondutorControl tabelaCondutor;

        public ControladorCondutor(IRepositorioCondutor repositorioCondutor, ServicoCondutor servicoCondutor, IRepositorioCliente repositorioCliente)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.servicoCondutor = servicoCondutor;
           this.repositorioCliente = repositorioCliente;
        }

        public override void Inserir()
        {
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            var tela = new TelaCadastroCondutor(clientes);

            tela.Condutor = new Condutor();

            tela.GravarRegistro = repositorioCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }
        public override void Editar()
        {
            var id = tabelaCondutor.ObtemIDCondutorSelecionado();

            Condutor materiaSelecionada = repositorioCondutor.SelecionarPorId(id);

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma materia primeiro",
                "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Cliente> condutor = repositorioCliente.SelecionarTodos();

            var tela = new TelaCadastroCondutor(condutor);

            tela.Condutor = materiaSelecionada.Clone();

            tela.GravarRegistro = repositorioCondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }

        }
        public override void Excluir()
        {
            var id = tabelaCondutor.ObtemIDCondutorSelecionado();

            Condutor condutorSelecionado = repositorioCondutor.SelecionarPorId(id);

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
            if (tabelaCondutor == null)
                tabelaCondutor = new TabelaCondutorControl();

            CarregarCondutores();

            return tabelaCondutor;
        }
        private Condutor ObtemClienteSelecionado()
        {
            var id = tabelaCondutorControl.ObtemClienteSelecionado();

            return repositorioCondutor.SelecionarPorId(id);
        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCondutor();
        }


        private void CarregarCondutores()
        {
            List<Condutor> condutores = repositorioCondutor.SelecionarTodos();
            tabelaCondutorControl.AtualizarRegistros(condutores);
            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {condutores.Count} Condutores.");

        }

    }
}
