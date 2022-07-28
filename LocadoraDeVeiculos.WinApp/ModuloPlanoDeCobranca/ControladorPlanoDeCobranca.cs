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
        private readonly IServicoGrupoDeVeiculo servicoGrupo;
        private TabelaPlanoControl tabelaPlanoControl;
        private readonly IServicoPlanoDeCobranca servicoPlano;

        public ControladorPlanoDeCobranca(IServicoPlanoDeCobranca servicoPlano, IServicoGrupoDeVeiculo servicoGrupo)
        {
            this.servicoPlano = servicoPlano;
            this.servicoGrupo = servicoGrupo;
        }

        public override void Inserir()
        {
            var grupos = servicoGrupo.SelecionarTodos();

            TelaCadastroPlano tela = new TelaCadastroPlano(grupos.Value);
            tela.Plano = new PlanoDeCobranca();
            tela.GravarRegistro = servicoPlano.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarPlanos();
        }

        public override void Editar()
        {
            var grupos = servicoGrupo.SelecionarTodos();
            var id = tabelaPlanoControl.ObtemPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro.",
                    "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlano.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoSelecionado = resultado.Value;

            var tela = new TelaCadastroPlano(grupos.Value);

            tela.Plano = planoSelecionado;

            tela.GravarRegistro = servicoPlano.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarPlanos();

        }

        public override void Excluir()
        {
            var id = tabelaPlanoControl.ObtemPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro.",
                    "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoPlano.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o plano de cobrança?", "Exclusão de Plano de Cobrança",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoPlano.Excluir(condutorSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarPlanos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {planos.Count} planos de cobrança.");
            }
            else if (resultado.IsFailed)
            {

                MessageBox.Show(resultado.Errors[0].Message, "Tela de Planos de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}