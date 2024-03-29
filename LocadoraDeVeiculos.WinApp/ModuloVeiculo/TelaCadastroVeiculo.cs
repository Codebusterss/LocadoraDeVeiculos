﻿using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        private Veiculo veiculo;
        ValidadorRegex validador = new ValidadorRegex();
        public string caminhoFoto = "";

        public TelaCadastroVeiculo(List<GrupoDeVeiculo> grupos)
        {
            InitializeComponent();
            CarregarGrupos(grupos);
            CarregarCombutivel();
        }

        public Func<Veiculo, Result<Veiculo>> GravarRegistro { get; set; }

        public Veiculo Veiculo
        {
            get
            {
                return veiculo;
            }
            set
            {
                veiculo = value;
                txtBoxId.Text = veiculo.ID.ToString();
                cbBoxGrupoDeVeiculos.SelectedItem = veiculo.GrupoDeVeiculo;
                txtBoxModelo.Text = veiculo.Modelo;
                txtBoxMarca.Text = veiculo.Marca;
                txtBoxPlaca.Text = veiculo.Placa;
                txtBoxAno.Text = veiculo.Ano.ToString();
                txtBoxCor.Text = veiculo.Cor;
                txtBoxCapTanque.Text = veiculo.CapacidadeDoTanque.ToString();
                txtBoxKMPercorrido.Text = veiculo.KmPercorrido.ToString();
                cbBoxCombustivel.SelectedItem = veiculo.TipoCombustivel;
                if (veiculo.Foto != null)
                    CarregarImagem();
            }
        }

        #region Botoes

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string kmPercorridoReplace = txtBoxKMPercorrido.Text.Replace(",", ".");
            string capTanqueReplace = txtBoxCapTanque.Text.Replace(",", ".");

            if (!validador.ApenasNumerosInteirosOuDecimais(kmPercorridoReplace) || !validador.ApenasNumerosInteirosOuDecimais(capTanqueReplace))
            {
                TelaMenuPrincipal.Instancia.AtualizarRodape("Insira apenas números válidos nos campos de Quilometragem e Capacidade.");
                DialogResult = DialogResult.None;
                return;
            }

            veiculo.GrupoDeVeiculo = (GrupoDeVeiculo)cbBoxGrupoDeVeiculos.SelectedItem;
            veiculo.Marca = txtBoxMarca.Text;
            veiculo.Modelo = txtBoxModelo.Text;
            veiculo.Placa = txtBoxPlaca.Text;
            veiculo.Ano = Convert.ToInt32(txtBoxAno.Text);
            veiculo.Cor = txtBoxCor.Text;
            veiculo.CapacidadeDoTanque = Convert.ToDouble(txtBoxCapTanque.Text);
            veiculo.KmPercorrido = Convert.ToDouble(txtBoxKMPercorrido.Text);
            veiculo.TipoCombustivel = cbBoxCombustivel.SelectedItem.ToString();

            if (caminhoFoto != "")
                veiculo.Foto = GetFoto(caminhoFoto);

            var resultadoValidacao = GravarRegistro(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                      "Cadastro de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipal.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void btnSelecionarImagem_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "|*.jpg; *.jpeg; *.png; *.jfif;";
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                caminhoFoto = openFile.FileName;
            }

            if (caminhoFoto != "")
            {
                caixaImagem.Load(caminhoFoto);
            }
        }

        #endregion  

        #region Rodape

        private void TelaCadastroVeiculo_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroVeiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipal.Instancia.AtualizarRodape("");
        }

        #endregion

        #region Metodos

        private void CarregarGrupos(List<GrupoDeVeiculo> grupos)
        {
            cbBoxGrupoDeVeiculos.Items.Clear();

            foreach (var grupo in grupos)
            {
                cbBoxGrupoDeVeiculos.Items.Add(grupo);
            }
        }

        private void CarregarCombutivel()
        {
            cbBoxCombustivel.Items.Clear();
            cbBoxCombustivel.Items.Add("Gasolina");
            cbBoxCombustivel.Items.Add("Etanol");
            cbBoxCombustivel.Items.Add("Diesel");
        }

        private byte[] GetFoto(string caminhoFoto)
        {
            byte[] imagem;
            using (var stream = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    imagem = reader.ReadBytes((int)stream.Length);
                }
            }

            return imagem;
        }

        private void CarregarImagem()
        {
            using (var img = new MemoryStream(veiculo.Foto))
            {
                caixaImagem.Image = Image.FromStream(img);
            }
        }

        #endregion
    }
}
