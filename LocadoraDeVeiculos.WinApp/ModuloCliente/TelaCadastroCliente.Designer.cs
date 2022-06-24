namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    partial class TelaCadastroCliente
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
            this.label3 = new System.Windows.Forms.Label();
            this.rdBtnCPF = new System.Windows.Forms.RadioButton();
            this.rdBtnCNPJ = new System.Windows.Forms.RadioButton();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.txtBoxNome = new System.Windows.Forms.TextBox();
            this.txtBoxCPFCNPJ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxEmail = new System.Windows.Forms.TextBox();
            this.txtBoxTelefone = new System.Windows.Forms.TextBox();
            this.txtBoxEndereco = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email:";
            // 
            // rdBtnCPF
            // 
            this.rdBtnCPF.AutoSize = true;
            this.rdBtnCPF.Location = new System.Drawing.Point(20, 106);
            this.rdBtnCPF.Name = "rdBtnCPF";
            this.rdBtnCPF.Size = new System.Drawing.Size(46, 19);
            this.rdBtnCPF.TabIndex = 3;
            this.rdBtnCPF.TabStop = true;
            this.rdBtnCPF.Text = "CPF";
            this.rdBtnCPF.UseVisualStyleBackColor = true;
            this.rdBtnCPF.CheckedChanged += new System.EventHandler(this.rdBtnCPF_CheckedChanged);
            // 
            // rdBtnCNPJ
            // 
            this.rdBtnCNPJ.AutoSize = true;
            this.rdBtnCNPJ.Location = new System.Drawing.Point(20, 131);
            this.rdBtnCNPJ.Name = "rdBtnCNPJ";
            this.rdBtnCNPJ.Size = new System.Drawing.Size(52, 19);
            this.rdBtnCNPJ.TabIndex = 4;
            this.rdBtnCNPJ.TabStop = true;
            this.rdBtnCNPJ.Text = "CNPJ";
            this.rdBtnCNPJ.UseVisualStyleBackColor = true;
            this.rdBtnCNPJ.CheckedChanged += new System.EventHandler(this.rdBtnCNPJ_CheckedChanged);
            // 
            // txtBoxID
            // 
            this.txtBoxID.Enabled = false;
            this.txtBoxID.Location = new System.Drawing.Point(56, 24);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(50, 23);
            this.txtBoxID.TabIndex = 5;
            // 
            // txtBoxNome
            // 
            this.txtBoxNome.Location = new System.Drawing.Point(56, 63);
            this.txtBoxNome.Name = "txtBoxNome";
            this.txtBoxNome.Size = new System.Drawing.Size(179, 23);
            this.txtBoxNome.TabIndex = 6;
            // 
            // txtBoxCPFCNPJ
            // 
            this.txtBoxCPFCNPJ.Enabled = false;
            this.txtBoxCPFCNPJ.Location = new System.Drawing.Point(78, 115);
            this.txtBoxCPFCNPJ.Name = "txtBoxCPFCNPJ";
            this.txtBoxCPFCNPJ.Size = new System.Drawing.Size(166, 23);
            this.txtBoxCPFCNPJ.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Telefone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Endereço:";
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.Location = new System.Drawing.Point(56, 173);
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.Size = new System.Drawing.Size(166, 23);
            this.txtBoxEmail.TabIndex = 10;
            // 
            // txtBoxTelefone
            // 
            this.txtBoxTelefone.Location = new System.Drawing.Point(72, 209);
            this.txtBoxTelefone.Name = "txtBoxTelefone";
            this.txtBoxTelefone.Size = new System.Drawing.Size(150, 23);
            this.txtBoxTelefone.TabIndex = 11;
            // 
            // txtBoxEndereco
            // 
            this.txtBoxEndereco.Location = new System.Drawing.Point(72, 244);
            this.txtBoxEndereco.Name = "txtBoxEndereco";
            this.txtBoxEndereco.Size = new System.Drawing.Size(202, 23);
            this.txtBoxEndereco.TabIndex = 12;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdicionar.Location = new System.Drawing.Point(160, 302);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 13;
            this.btnAdicionar.Text = "Cadastrar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(241, 302);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 337);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.txtBoxEndereco);
            this.Controls.Add(this.txtBoxTelefone);
            this.Controls.Add(this.txtBoxEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxCPFCNPJ);
            this.Controls.Add(this.txtBoxNome);
            this.Controls.Add(this.txtBoxID);
            this.Controls.Add(this.rdBtnCNPJ);
            this.Controls.Add(this.rdBtnCPF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TelaCadastroCliente";
            this.Text = "Cadastro de Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroCliente_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private RadioButton rdBtnCPF;
        private RadioButton rdBtnCNPJ;
        private TextBox txtBoxID;
        private TextBox txtBoxNome;
        private TextBox txtBoxCPFCNPJ;
        private Label label4;
        private Label label5;
        private TextBox txtBoxEmail;
        private TextBox txtBoxTelefone;
        private TextBox txtBoxEndereco;
        private Button btnAdicionar;
        private Button btnCancelar;
    }
}