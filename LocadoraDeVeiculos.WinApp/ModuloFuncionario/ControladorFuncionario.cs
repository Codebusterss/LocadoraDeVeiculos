using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using FluentResults;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private TabelaFuncionarioControl tabelaFuncionarioControl;
        private readonly IServicoFuncionario servicoFuncionario;

        public ControladorFuncionario(IServicoFuncionario servicoFuncionario)
        {
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            TelaCadastroFuncionario tela = new TelaCadastroFuncionario();
            tela.Funcionario = new Funcionario();
            tela.GravarRegistro = servicoFuncionario.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Editar()
        {
            var id = tabelaFuncionarioControl.ObtemFuncionarioSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro.",
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoFuncionario.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            var tela = new TelaCadastroFuncionario();

            tela.Funcionario = funcionarioSelecionado;

            tela.GravarRegistro = servicoFuncionario.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Excluir()
        {
            var id = tabelaFuncionarioControl.ObtemFuncionarioSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro.",
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoFuncionario.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o funcionário?", "Exclusão de Funcionário",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoFuncionario.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarFuncionarios();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var resultado = servicoFuncionario.SelecionarTodos();

            


            if(resultado.IsSuccess)
            {
                List<Funcionario> funcionarios = resultado.Value;
                tabelaFuncionarioControl.AtualizarRegistros(funcionarios);
                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionários.");
            }
            else if (resultado.IsFailed)
            {

                MessageBox.Show(resultado.Errors[0].Message, "Tela de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}
