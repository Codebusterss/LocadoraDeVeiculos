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

        public ControladorCondutor(IRepositorioCondutor repositorioCondutor, ServicoCondutor servicoCondutor, IRepositorioCliente repositorioCliente)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.servicoCondutor = servicoCondutor;
           this.repositorioCliente = repositorioCliente;
        }

        public override void Inserir()
        {
            var clientes = repositorioCliente.SelecionarTodos();
            var tela = new TelaCadastroCondutor(clientes);
            TelaCadastroCondutor tela = new TelaCadastroCondutor();
            tela.Condutor = new Condutor();
            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarCondutores();
        }
        public override void Editar()
        {
            Condutor clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro.",
                "Edição de condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCondutor tela = new TelaCadastroCondutor();

            tela.Condutor = clienteSelecionado;

            tela.GravarRegistro = servicoCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();

        }
        private Condutor ObtemClienteSelecionado()
        {
            var id = tabelaCondutorControl.ObtemClienteSelecionado();

            return repositorioCondutor.SelecionarPorId(id);
        }

        private void CarregarCondutores()
        {
            List<Condutor> condutores = repositorioCondutor.SelecionarTodos();
            tabelaCondutorControl.AtualizarRegistros(condutores);
            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {condutores.Count} Condutores.");

        }

    }
}
