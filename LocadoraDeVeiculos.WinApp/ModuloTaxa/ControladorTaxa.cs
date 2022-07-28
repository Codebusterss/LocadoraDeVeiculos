using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {
        TabelaTaxaControl tabelataxa;
        private readonly IServicoTaxa servicoTaxa;

        public ControladorTaxa(IServicoTaxa servicoTaxa)
        {
            this.servicoTaxa = servicoTaxa;
        }
        public override void Inserir()
        {
            TelaCadastroTaxa tela = new TelaCadastroTaxa();
            tela.Taxa = new Taxa();

            tela.GravarRegistro = servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarTaxa();
            }
        }
        public override void Editar()
        {
            var id = tabelataxa.ObtemTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro.",
                    "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoTaxa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultado.Value;

            var tela = new TelaCadastroTaxa();

            tela.Taxa = taxaSelecionada;

            tela.GravarRegistro = servicoTaxa.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarTaxa();

        }
         public override void Excluir()
         {
            var id = tabelataxa.ObtemTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro.",
                    "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoTaxa.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a taxa?", "Exclusão de Taxa",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoTaxa.Excluir(taxaSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarTaxa();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTaxa();
        }

        private void CarregarTaxa()
        {
            var resultado = servicoTaxa.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Taxa> taxas = resultado.Value;
                tabelataxa.AtualizarRegistros(taxas);
                TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {taxas.Count} taxas.");
            }
            else if (resultado.IsFailed)
            {

                MessageBox.Show(resultado.Errors[0].Message, "Tela de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public override UserControl ObtemListagem()
        {
            tabelataxa = new TabelaTaxaControl();

            CarregarTaxa();

            return tabelataxa;
        }
    }
}
