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
        private IRepositorioTaxa repositorioTaxa;
        TabelaTaxaControl tabelataxa;
        private readonly ServicoTaxa servicoTaxa;

        public ControladorTaxa(IRepositorioTaxa repositorioTaxa, ServicoTaxa servicoTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
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
            Taxa taxaselecionada = ObtemTaxaSelecionada();
            if(taxaselecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro.", "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaCadastroTaxa tela = new TelaCadastroTaxa();
            tela.Taxa = taxaselecionada;
            tela.GravarRegistro = servicoTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if(resultado == DialogResult.OK)
            {
                CarregarTaxa();
            }
            
        }
         public override void Excluir()
         {
            Taxa taxaselecionada = ObtemTaxaSelecionada();

            if (taxaselecionada == null)
            {
                MessageBox.Show("Selecione um taxa primeiro.", "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
               "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(resultado == DialogResult.OK)
            {
                repositorioTaxa.Excluir(taxaselecionada);
                CarregarTaxa();
            }

        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTaxa();
        }
        private void CarregarTaxa()
        {
            List<Taxa> taxas = repositorioTaxa.SelecionarTodos();

            tabelataxa.AtualizarRegistros(taxas);
            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {taxas.Count} Taxas.");

        }
        public override UserControl ObtemListagem()
        {
            tabelataxa = new TabelaTaxaControl();

            CarregarTaxa();

            return tabelataxa;
        }

        private Taxa ObtemTaxaSelecionada()
        {
            var ID = tabelataxa.ObtemTaxaSelecionada();

            return repositorioTaxa.SelecionarPorId(ID);
        }
    }
}
