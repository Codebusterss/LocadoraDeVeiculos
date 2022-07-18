namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    partial class TelaCadastroTaxa
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
            this.labelID = new System.Windows.Forms.Label();
            this.labelValor = new System.Windows.Forms.Label();
            this.labelTipo = new System.Windows.Forms.Label();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.txtBoxTaxaID = new System.Windows.Forms.TextBox();
            this.txtBoxTaxaValor = new System.Windows.Forms.TextBox();
            this.radioBtnFixoTaxa = new System.Windows.Forms.RadioButton();
            this.radioBtnDiarioTaxa = new System.Windows.Forms.RadioButton();
            this.btnCadastrarTaxa = new System.Windows.Forms.Button();
            this.btnCancelarTaxa = new System.Windows.Forms.Button();
            this.txtTaxaDescricao = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(49, 21);
            this.labelID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 15);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID:";
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(34, 49);
            this.labelValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(36, 15);
            this.labelValor.TabIndex = 1;
            this.labelValor.Text = "Valor:";
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(37, 82);
            this.labelTipo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(33, 15);
            this.labelTipo.TabIndex = 2;
            this.labelTipo.Text = "Tipo:";
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(8, 120);
            this.labelDescricao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(61, 15);
            this.labelDescricao.TabIndex = 3;
            this.labelDescricao.Text = "Descrição:";
            // 
            // txtBoxTaxaID
            // 
            this.txtBoxTaxaID.Enabled = false;
            this.txtBoxTaxaID.Location = new System.Drawing.Point(83, 17);
            this.txtBoxTaxaID.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxTaxaID.Name = "txtBoxTaxaID";
            this.txtBoxTaxaID.Size = new System.Drawing.Size(47, 23);
            this.txtBoxTaxaID.TabIndex = 4;
            // 
            // txtBoxTaxaValor
            // 
            this.txtBoxTaxaValor.Location = new System.Drawing.Point(83, 47);
            this.txtBoxTaxaValor.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxTaxaValor.Name = "txtBoxTaxaValor";
            this.txtBoxTaxaValor.Size = new System.Drawing.Size(117, 23);
            this.txtBoxTaxaValor.TabIndex = 5;
            // 
            // radioBtnFixoTaxa
            // 
            this.radioBtnFixoTaxa.AutoSize = true;
            this.radioBtnFixoTaxa.Location = new System.Drawing.Point(83, 82);
            this.radioBtnFixoTaxa.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnFixoTaxa.Name = "radioBtnFixoTaxa";
            this.radioBtnFixoTaxa.Size = new System.Drawing.Size(47, 19);
            this.radioBtnFixoTaxa.TabIndex = 8;
            this.radioBtnFixoTaxa.TabStop = true;
            this.radioBtnFixoTaxa.Text = "Fixo";
            this.radioBtnFixoTaxa.UseVisualStyleBackColor = true;
            // 
            // radioBtnDiarioTaxa
            // 
            this.radioBtnDiarioTaxa.AutoSize = true;
            this.radioBtnDiarioTaxa.Location = new System.Drawing.Point(140, 82);
            this.radioBtnDiarioTaxa.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnDiarioTaxa.Name = "radioBtnDiarioTaxa";
            this.radioBtnDiarioTaxa.Size = new System.Drawing.Size(56, 19);
            this.radioBtnDiarioTaxa.TabIndex = 9;
            this.radioBtnDiarioTaxa.TabStop = true;
            this.radioBtnDiarioTaxa.Text = "Diário";
            this.radioBtnDiarioTaxa.UseVisualStyleBackColor = true;
            // 
            // btnCadastrarTaxa
            // 
            this.btnCadastrarTaxa.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrarTaxa.Location = new System.Drawing.Point(165, 217);
            this.btnCadastrarTaxa.Margin = new System.Windows.Forms.Padding(2);
            this.btnCadastrarTaxa.Name = "btnCadastrarTaxa";
            this.btnCadastrarTaxa.Size = new System.Drawing.Size(78, 24);
            this.btnCadastrarTaxa.TabIndex = 11;
            this.btnCadastrarTaxa.Text = "Cadastrar";
            this.btnCadastrarTaxa.UseVisualStyleBackColor = true;
            this.btnCadastrarTaxa.Click += new System.EventHandler(this.btnCadastrarTaxa_Click);
            // 
            // btnCancelarTaxa
            // 
            this.btnCancelarTaxa.AccessibleDescription = "a";
            this.btnCancelarTaxa.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarTaxa.Location = new System.Drawing.Point(256, 217);
            this.btnCancelarTaxa.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarTaxa.Name = "btnCancelarTaxa";
            this.btnCancelarTaxa.Size = new System.Drawing.Size(78, 24);
            this.btnCancelarTaxa.TabIndex = 12;
            this.btnCancelarTaxa.Text = "Cancelar";
            this.btnCancelarTaxa.UseVisualStyleBackColor = true;
            // 
            // txtTaxaDescricao
            // 
            this.txtTaxaDescricao.Location = new System.Drawing.Point(73, 117);
            this.txtTaxaDescricao.Margin = new System.Windows.Forms.Padding(2);
            this.txtTaxaDescricao.Multiline = true;
            this.txtTaxaDescricao.Name = "txtTaxaDescricao";
            this.txtTaxaDescricao.Size = new System.Drawing.Size(248, 85);
            this.txtTaxaDescricao.TabIndex = 13;
            // 
            // TelaCadastroTaxa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 252);
            this.Controls.Add(this.txtTaxaDescricao);
            this.Controls.Add(this.btnCancelarTaxa);
            this.Controls.Add(this.btnCadastrarTaxa);
            this.Controls.Add(this.radioBtnDiarioTaxa);
            this.Controls.Add(this.radioBtnFixoTaxa);
            this.Controls.Add(this.txtBoxTaxaValor);
            this.Controls.Add(this.txtBoxTaxaID);
            this.Controls.Add(this.labelDescricao);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.labelValor);
            this.Controls.Add(this.labelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "TelaCadastroTaxa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Taxas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroTaxa_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroTaxa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelID;
        private Label labelValor;
        private Label labelTipo;
        private Label labelDescricao;
        private TextBox txtBoxTaxaID;
        private TextBox txtBoxTaxaValor;
        private RadioButton radioBtnFixoTaxa;
        private RadioButton radioBtnDiarioTaxa;
        private Button btnCadastrarTaxa;
        private Button btnCancelarTaxa;
        private TextBox txtTaxaDescricao;
    }
}