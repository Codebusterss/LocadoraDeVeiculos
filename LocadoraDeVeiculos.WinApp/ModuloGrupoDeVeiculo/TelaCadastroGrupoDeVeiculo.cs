﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo
{
    public partial class TelaCadastroGrupoDeVeiculo : Form
    {
        private GrupoDeVeiculo grupoDeVeiculo;
        ValidadorRegex validador = new ValidadorRegex();

        public TelaCadastroGrupoDeVeiculo()
        {
            InitializeComponent();
        }
        public Func<GrupoDeVeiculo, Result<GrupoDeVeiculo>> GravarRegistro { get; set; }

        public GrupoDeVeiculo GrupoDeVeiculo
        {
            get
            {
                return grupoDeVeiculo;
            }
            set
            {
                grupoDeVeiculo = value;
                txtBoxNomeDoGrupo.Text = grupoDeVeiculo.Nome;
                txtBoxID.Text = grupoDeVeiculo.ID.ToString();
            }
        }

        #region Botoes

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            grupoDeVeiculo.Nome = txtBoxNomeDoGrupo.Text;

            var resultadoValidacao = GravarRegistro(grupoDeVeiculo);
            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                      "Cadastro de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }

        }

        #endregion

        #region Rodape

        private void TelaCadastroGrupoDeVeiculo_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroGrupoDeVeiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        #endregion
    }
}
