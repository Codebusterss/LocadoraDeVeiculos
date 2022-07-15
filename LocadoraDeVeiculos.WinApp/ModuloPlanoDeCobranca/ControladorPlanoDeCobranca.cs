using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculo;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private readonly RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupoDeVeiculos;
        private TabelaPlanoControl tabelaPlanoControl;
        private readonly ServicoPlanoDeCobranca servicoPlano;

        public ControladorPlanoDeCobranca(ServicoPlanoDeCobranca servicoPlano, RepositorioGrupoDeVeiculosEmBancoDeDados repositorioGrupoDeVeiculos)
        {
            this.servicoPlano = servicoPlano;
            this.repositorioGrupoDeVeiculos = repositorioGrupoDeVeiculos;
        }

        public override void Inserir()
        {
            var grupos = repositorioGrupoDeVeiculos.SelecionarTodos();

            TelaCadastroPlano tela = new TelaCadastroPlano(grupos);
            tela.Plano = new PlanoDeCobranca();
            tela.GravarRegistro = servicoPlano.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarPlanos();
        }

        public override void Editar()
        {
            var grupos = repositorioGrupoDeVeiculos.SelecionarTodos();
            var id = tabelaPlanoControl.ObtemPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano de cobranca primeiro",
                    "Edição de Plano de Cobranca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlano.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Plano de Cobranca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoSelecionado = resultado.Value;

            var tela = new TelaCadastroPlano(grupos);

            tela.Plano = planoSelecionado.Clone();

            tela.GravarRegistro = servicoPlano.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarPlanos();

        }

        public override void Excluir()
        {
            var id = tabelaPlanoControl.ObtemPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano de cobranca primeiro.",
                    "Exclusão de Plano de Cobranca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoPlano.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Plano de Cobranca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o plano de cobranca?", "Exclusão de Plano de Cobranca",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoPlano.Excluir(condutorSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarPlanos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Plano de Cobranca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolboxPlanoDeCobranca();
        }

        public override UserControl ObtemListagem()
        {
            tabelaPlanoControl = new TabelaPlanoControl();

            CarregarPlanos();

            return tabelaPlanoControl;
        }

        private void CarregarPlanos()
        {
            var resultado = servicoPlano.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<PlanoDeCobranca> planos = resultado.Value;
                tabelaPlanoControl.AtualizarRegistros(planos);
                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {planos.Count} Planos de Cobranca.");
            }
            else if (resultado.IsFailed)
            {

                MessageBox.Show(resultado.Errors[0].Message, "Tela de Planos de Cobranca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}