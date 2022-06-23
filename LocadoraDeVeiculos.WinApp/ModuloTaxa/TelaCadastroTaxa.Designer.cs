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
            this.txtTaxaDescricao = new System.Windows.Forms.ListBox();
            this.btnCadastrarTaxa = new System.Windows.Forms.Button();
            this.btnCancelarTaxa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(70, 35);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(34, 25);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID:";
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(48, 82);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(56, 25);
            this.labelValor.TabIndex = 1;
            this.labelValor.Text = "Valor:";
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(53, 137);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(51, 25);
            this.labelTipo.TabIndex = 2;
            this.labelTipo.Text = "Tipo:";
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(12, 200);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(92, 25);
            this.labelDescricao.TabIndex = 3;
            this.labelDescricao.Text = "Descrição:";
            // 
            // txtBoxTaxaID
            // 
            this.txtBoxTaxaID.Location = new System.Drawing.Point(119, 29);
            this.txtBoxTaxaID.Name = "txtBoxTaxaID";
            this.txtBoxTaxaID.Size = new System.Drawing.Size(165, 31);
            this.txtBoxTaxaID.TabIndex = 4;
            // 
            // txtBoxTaxaValor
            // 
            this.txtBoxTaxaValor.Location = new System.Drawing.Point(119, 79);
            this.txtBoxTaxaValor.Name = "txtBoxTaxaValor";
            this.txtBoxTaxaValor.Size = new System.Drawing.Size(165, 31);
            this.txtBoxTaxaValor.TabIndex = 5;
            // 
            // radioBtnFixoTaxa
            // 
            this.radioBtnFixoTaxa.AutoSize = true;
            this.radioBtnFixoTaxa.Location = new System.Drawing.Point(119, 137);
            this.radioBtnFixoTaxa.Name = "radioBtnFixoTaxa";
            this.radioBtnFixoTaxa.Size = new System.Drawing.Size(69, 29);
            this.radioBtnFixoTaxa.TabIndex = 8;
            this.radioBtnFixoTaxa.TabStop = true;
            this.radioBtnFixoTaxa.Text = "Fixo";
            this.radioBtnFixoTaxa.UseVisualStyleBackColor = true;
            // 
            // radioBtnDiarioTaxa
            // 
            this.radioBtnDiarioTaxa.AutoSize = true;
            this.radioBtnDiarioTaxa.Location = new System.Drawing.Point(200, 137);
            this.radioBtnDiarioTaxa.Name = "radioBtnDiarioTaxa";
            this.radioBtnDiarioTaxa.Size = new System.Drawing.Size(84, 29);
            this.radioBtnDiarioTaxa.TabIndex = 9;
            this.radioBtnDiarioTaxa.TabStop = true;
            this.radioBtnDiarioTaxa.Text = "Diário";
            this.radioBtnDiarioTaxa.UseVisualStyleBackColor = true;
            // 
            // txtTaxaDescricao
            // 
            this.txtTaxaDescricao.AccessibleDescription = "Ex: Cadeirinha de bebê";
            this.txtTaxaDescricao.FormattingEnabled = true;
            this.txtTaxaDescricao.ItemHeight = 25;
            this.txtTaxaDescricao.Location = new System.Drawing.Point(104, 200);
            this.txtTaxaDescricao.Name = "txtTaxaDescricao";
            this.txtTaxaDescricao.Size = new System.Drawing.Size(342, 129);
            this.txtTaxaDescricao.TabIndex = 10;
            // 
            // btnCadastrarTaxa
            // 
            this.btnCadastrarTaxa.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrarTaxa.Location = new System.Drawing.Point(236, 362);
            this.btnCadastrarTaxa.Name = "btnCadastrarTaxa";
            this.btnCadastrarTaxa.Size = new System.Drawing.Size(112, 34);
            this.btnCadastrarTaxa.TabIndex = 11;
            this.btnCadastrarTaxa.Text = "Cadastrar";
            this.btnCadastrarTaxa.UseVisualStyleBackColor = true;
            this.btnCadastrarTaxa.Click += new System.EventHandler(this.btnCadastrarTaxa_Click);
            // 
            // btnCancelarTaxa
            // 
            this.btnCancelarTaxa.AccessibleDescription = "a";
            this.btnCancelarTaxa.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarTaxa.Location = new System.Drawing.Point(365, 362);
            this.btnCancelarTaxa.Name = "btnCancelarTaxa";
            this.btnCancelarTaxa.Size = new System.Drawing.Size(112, 34);
            this.btnCancelarTaxa.TabIndex = 12;
            this.btnCancelarTaxa.Text = "Cancelar";
            this.btnCancelarTaxa.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroTaxa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 407);
            this.Controls.Add(this.btnCancelarTaxa);
            this.Controls.Add(this.btnCadastrarTaxa);
            this.Controls.Add(this.txtTaxaDescricao);
            this.Controls.Add(this.radioBtnDiarioTaxa);
            this.Controls.Add(this.radioBtnFixoTaxa);
            this.Controls.Add(this.txtBoxTaxaValor);
            this.Controls.Add(this.txtBoxTaxaID);
            this.Controls.Add(this.labelDescricao);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.labelValor);
            this.Controls.Add(this.labelID);
            this.Name = "TelaCadastroTaxa";
            this.Text = "TelaCadastroTaxa";
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
        private ListBox txtTaxaDescricao;
        private Button btnCadastrarTaxa;
        private Button btnCancelarTaxa;
    }
}