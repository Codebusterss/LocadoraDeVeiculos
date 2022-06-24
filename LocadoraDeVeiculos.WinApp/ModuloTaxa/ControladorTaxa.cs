using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {
        private RepositorioTaxaEmBancoDeDados repositorioTaxa;
        TabelaTaxaControl tabelataxa;

        public ControladorTaxa(RepositorioTaxaEmBancoDeDados repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }
        public override void Inserir()
        {
            TelaCadastroTaxa tela = new TelaCadastroTaxa();
            tela.Taxa = new Taxa();

            tela.GravarRegistro = repositorioTaxa.Inserir;

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
                MessageBox.Show("Selecione uma taxa primeiro", "Edição de taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaCadastroTaxa tela = new TelaCadastroTaxa();
            tela.Taxa = taxaselecionada;
            tela.GravarRegistro = repositorioTaxa.Editar;

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
                MessageBox.Show("Selecione um taxa primeiro", "Exclusão de taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a disciplina?",
               "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

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
            List<Taxa> disciplinas = repositorioTaxa.SelecionarTodos();

            tabelataxa.AtualizarRegistros(disciplinas);
            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando Taxa");

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
