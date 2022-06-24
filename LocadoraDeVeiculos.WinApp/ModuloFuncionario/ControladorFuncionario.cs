using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private readonly RepositorioFuncionarioEmBancoDeDados repositorioFuncionario;
        private TabelaFuncionarioControl tabelaFuncionarioControl;

        public ControladorFuncionario(RepositorioFuncionarioEmBancoDeDados repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public override void Inserir()
        {
            TelaCadastroFuncionario tela = new TelaCadastroFuncionario();
            tela.Funcionario = new Funcionario();
            tela.GravarRegistro = repositorioFuncionario.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Editar()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                "Edição de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroFuncionario tela = new TelaCadastroFuncionario();

            tela.Funcionario = funcionarioSelecionado;

            tela.GravarRegistro = repositorioFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();

        }

        public override void Excluir()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                "Exclusão de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o funcionário?",
                "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioFuncionario.Excluir(funcionarioSelecionado);
                CarregarFuncionarios();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolboxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            tabelaFuncionarioControl = new TabelaFuncionarioControl();

            CarregarFuncionarios();

            return tabelaFuncionarioControl;
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

            tabelaFuncionarioControl.AtualizarRegistros(funcionarios);
            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando Funcionários");

        }

        private Funcionario ObtemFuncionarSelecionado()
        {
            var id = tabelaFuncionarioControl.ObtemGrupoDeVeiculoSelecionado();

            return repositorioFuncionario.SelecionarPorId(id);
        }

    }
}
