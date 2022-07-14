﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private readonly IRepositorioCliente repositorioCliente;
        private TabelaClienteControl tabelaClienteControl;
        private readonly ServicoCliente servicoCliente;

        public ControladorCliente(IRepositorioCliente repositorioCliente, ServicoCliente servicoCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            TelaCadastroCliente tela = new TelaCadastroCliente();
            tela.Cliente = new Cliente();
            tela.GravarRegistro = servicoCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarClientes();
        }

        public override void Editar()
        {

            var id = tabelaClienteControl.ObtemClienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Cliente primeiro.",
                    "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCliente.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoSelecionado = resultado.Value;

            var tela = new TelaCadastroCliente();

            tela.Cliente = grupoSelecionado.Clone();

            tela.GravarRegistro = servicoCliente.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarClientes();

        }

        public override void Excluir()
        {
            var id = tabelaClienteControl.ObtemClienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Cliente primeiro.",
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCliente.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Cliente?", "Exclusão de Cliente",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCliente.Excluir(grupoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarClientes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCliente();
        }

        public override UserControl ObtemListagem()
        {
            tabelaClienteControl = new TabelaClienteControl();

            CarregarClientes();

            return tabelaClienteControl;
        }

        private void CarregarClientes()
        {
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();
            tabelaClienteControl.AtualizarRegistros(clientes);
            TelaMenuPrincipal.Instancia.AtualizarRodape($"Visualizando {clientes.Count} Clientes.");

        }

        private Cliente ObtemClienteSelecionado()
        {
            var id = tabelaClienteControl.ObtemClienteSelecionado();

            return repositorioCliente.SelecionarPorId(id);
        }

    }
}
