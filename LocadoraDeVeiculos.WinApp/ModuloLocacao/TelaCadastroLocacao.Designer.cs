namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    partial class TelaCadastroLocacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBoxCliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBoxCondutor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbBoxVeiculo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimeDataLocacao = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBoxPlanoCobranca = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxKMveiculo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimeDataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxValorTotal = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.rdBtnIndividual = new System.Windows.Forms.RadioButton();
            this.rdBtnTotal = new System.Windows.Forms.RadioButton();
            this.rdBtnTerceiros = new System.Windows.Forms.RadioButton();
            this.lstBoxTaxa = new System.Windows.Forms.ListBox();
            this.btnAddTaxa = new System.Windows.Forms.Button();
            this.cbBoxTaxas = new System.Windows.Forms.ComboBox();
            this.cbBoxFuncionarios = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funcionário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // cbBoxCliente
            // 
            this.cbBoxCliente.FormattingEnabled = true;
            this.cbBoxCliente.Location = new System.Drawing.Point(139, 58);
            this.cbBoxCliente.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxCliente.Name = "cbBoxCliente";
            this.cbBoxCliente.Size = new System.Drawing.Size(138, 23);
            this.cbBoxCliente.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Condutor:";
            // 
            // cbBoxCondutor
            // 
            this.cbBoxCondutor.FormattingEnabled = true;
            this.cbBoxCondutor.Location = new System.Drawing.Point(473, 25);
            this.cbBoxCondutor.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxCondutor.Name = "cbBoxCondutor";
            this.cbBoxCondutor.Size = new System.Drawing.Size(155, 23);
            this.cbBoxCondutor.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Veículo:";
            // 
            // cbBoxVeiculo
            // 
            this.cbBoxVeiculo.FormattingEnabled = true;
            this.cbBoxVeiculo.Location = new System.Drawing.Point(140, 99);
            this.cbBoxVeiculo.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxVeiculo.Name = "cbBoxVeiculo";
            this.cbBoxVeiculo.Size = new System.Drawing.Size(138, 23);
            this.cbBoxVeiculo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 142);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Data de Locação:";
            // 
            // dateTimeDataLocacao
            // 
            this.dateTimeDataLocacao.Location = new System.Drawing.Point(140, 139);
            this.dateTimeDataLocacao.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeDataLocacao.Name = "dateTimeDataLocacao";
            this.dateTimeDataLocacao.Size = new System.Drawing.Size(186, 23);
            this.dateTimeDataLocacao.TabIndex = 11;
            this.dateTimeDataLocacao.ValueChanged += new System.EventHandler(this.dateTimeDataLocacao_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(354, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Plano de Cobrança:";
            // 
            // cbBoxPlanoCobranca
            // 
            this.cbBoxPlanoCobranca.FormattingEnabled = true;
            this.cbBoxPlanoCobranca.Location = new System.Drawing.Point(473, 61);
            this.cbBoxPlanoCobranca.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxPlanoCobranca.Name = "cbBoxPlanoCobranca";
            this.cbBoxPlanoCobranca.Size = new System.Drawing.Size(155, 23);
            this.cbBoxPlanoCobranca.TabIndex = 13;
            this.cbBoxPlanoCobranca.SelectedIndexChanged += new System.EventHandler(this.cbBoxPlanoCobranca_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(354, 103);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Quantidade de KM:";
            // 
            // txtBoxKMveiculo
            // 
            this.txtBoxKMveiculo.Enabled = false;
            this.txtBoxKMveiculo.Location = new System.Drawing.Point(473, 100);
            this.txtBoxKMveiculo.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxKMveiculo.Name = "txtBoxKMveiculo";
            this.txtBoxKMveiculo.Size = new System.Drawing.Size(155, 23);
            this.txtBoxKMveiculo.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(352, 139);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Data de Devolução:";
            // 
            // dateTimeDataDevolucao
            // 
            this.dateTimeDataDevolucao.Location = new System.Drawing.Point(473, 139);
            this.dateTimeDataDevolucao.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeDataDevolucao.Name = "dateTimeDataDevolucao";
            this.dateTimeDataDevolucao.Size = new System.Drawing.Size(186, 23);
            this.dateTimeDataDevolucao.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(88, 173);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 18);
            this.label10.TabIndex = 18;
            this.label10.Text = "Taxas:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(405, 173);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 18);
            this.label11.TabIndex = 25;
            this.label11.Text = "Seguro:";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirmar.Location = new System.Drawing.Point(487, 345);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(84, 29);
            this.btnConfirmar.TabIndex = 29;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(575, 345);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 29);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 316);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "Valor total previsto:";
            // 
            // txtBoxValorTotal
            // 
            this.txtBoxValorTotal.Location = new System.Drawing.Point(140, 313);
            this.txtBoxValorTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxValorTotal.Name = "txtBoxValorTotal";
            this.txtBoxValorTotal.Size = new System.Drawing.Size(186, 23);
            this.txtBoxValorTotal.TabIndex = 32;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(330, 312);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(114, 23);
            this.btnCalcular.TabIndex = 33;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // rdBtnIndividual
            // 
            this.rdBtnIndividual.AutoSize = true;
            this.rdBtnIndividual.Location = new System.Drawing.Point(461, 172);
            this.rdBtnIndividual.Name = "rdBtnIndividual";
            this.rdBtnIndividual.Size = new System.Drawing.Size(77, 19);
            this.rdBtnIndividual.TabIndex = 34;
            this.rdBtnIndividual.TabStop = true;
            this.rdBtnIndividual.Text = "Individual";
            this.rdBtnIndividual.UseVisualStyleBackColor = true;
            // 
            // rdBtnTotal
            // 
            this.rdBtnTotal.AutoSize = true;
            this.rdBtnTotal.Location = new System.Drawing.Point(461, 197);
            this.rdBtnTotal.Name = "rdBtnTotal";
            this.rdBtnTotal.Size = new System.Drawing.Size(50, 19);
            this.rdBtnTotal.TabIndex = 35;
            this.rdBtnTotal.TabStop = true;
            this.rdBtnTotal.Text = "Total";
            this.rdBtnTotal.UseVisualStyleBackColor = true;
            // 
            // rdBtnTerceiros
            // 
            this.rdBtnTerceiros.AutoSize = true;
            this.rdBtnTerceiros.Location = new System.Drawing.Point(461, 222);
            this.rdBtnTerceiros.Name = "rdBtnTerceiros";
            this.rdBtnTerceiros.Size = new System.Drawing.Size(71, 19);
            this.rdBtnTerceiros.TabIndex = 36;
            this.rdBtnTerceiros.TabStop = true;
            this.rdBtnTerceiros.Text = "Terceiros";
            this.rdBtnTerceiros.UseVisualStyleBackColor = true;
            // 
            // lstBoxTaxa
            // 
            this.lstBoxTaxa.FormattingEnabled = true;
            this.lstBoxTaxa.ItemHeight = 15;
            this.lstBoxTaxa.Location = new System.Drawing.Point(139, 202);
            this.lstBoxTaxa.Name = "lstBoxTaxa";
            this.lstBoxTaxa.Size = new System.Drawing.Size(186, 94);
            this.lstBoxTaxa.TabIndex = 37;
            // 
            // btnAddTaxa
            // 
            this.btnAddTaxa.Enabled = false;
            this.btnAddTaxa.Location = new System.Drawing.Point(287, 174);
            this.btnAddTaxa.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddTaxa.Name = "btnAddTaxa";
            this.btnAddTaxa.Size = new System.Drawing.Size(70, 23);
            this.btnAddTaxa.TabIndex = 38;
            this.btnAddTaxa.Text = "Adicionar";
            this.btnAddTaxa.UseVisualStyleBackColor = true;
            this.btnAddTaxa.Click += new System.EventHandler(this.btnAddTaxa_Click);
            // 
            // cbBoxTaxas
            // 
            this.cbBoxTaxas.FormattingEnabled = true;
            this.cbBoxTaxas.Location = new System.Drawing.Point(140, 174);
            this.cbBoxTaxas.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxTaxas.Name = "cbBoxTaxas";
            this.cbBoxTaxas.Size = new System.Drawing.Size(138, 23);
            this.cbBoxTaxas.TabIndex = 39;
            this.cbBoxTaxas.SelectedIndexChanged += new System.EventHandler(this.cbBoxTaxas_SelectedIndexChanged);
            // 
            // cbBoxFuncionarios
            // 
            this.cbBoxFuncionarios.FormattingEnabled = true;
            this.cbBoxFuncionarios.Location = new System.Drawing.Point(137, 20);
            this.cbBoxFuncionarios.Margin = new System.Windows.Forms.Padding(2);
            this.cbBoxFuncionarios.Name = "cbBoxFuncionarios";
            this.cbBoxFuncionarios.Size = new System.Drawing.Size(141, 23);
            this.cbBoxFuncionarios.TabIndex = 40;
            // 
            // TelaCadastroLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 385);
            this.Controls.Add(this.cbBoxFuncionarios);
            this.Controls.Add(this.cbBoxTaxas);
            this.Controls.Add(this.btnAddTaxa);
            this.Controls.Add(this.lstBoxTaxa);
            this.Controls.Add(this.rdBtnTerceiros);
            this.Controls.Add(this.rdBtnTotal);
            this.Controls.Add(this.rdBtnIndividual);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtBoxValorTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimeDataDevolucao);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBoxKMveiculo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbBoxPlanoCobranca);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimeDataLocacao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbBoxVeiculo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbBoxCondutor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbBoxCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "TelaCadastroLocacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Locação";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroLocacao_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroLocacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbBoxCliente;
        private Label label4;
        private ComboBox cbBoxCondutor;
        private Label label5;
        private ComboBox cbBoxVeiculo;
        private Label label6;
        private DateTimePicker dateTimeDataLocacao;
        private Label label7;
        private ComboBox cbBoxPlanoCobranca;
        private Label label8;
        private TextBox txtBoxKMveiculo;
        private Label label9;
        private DateTimePicker dateTimeDataDevolucao;
        private Label label10;
        private Label label11;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Label label3;
        private TextBox txtBoxValorTotal;
        private Button btnCalcular;
        private RadioButton rdBtnIndividual;
        private RadioButton rdBtnTotal;
        private RadioButton rdBtnTerceiros;
        private ListBox lstBoxTaxa;
        private Button btnAddTaxa;
        private ComboBox cbBoxTaxas;
        private ComboBox cbBoxFuncionarios;
    }
}