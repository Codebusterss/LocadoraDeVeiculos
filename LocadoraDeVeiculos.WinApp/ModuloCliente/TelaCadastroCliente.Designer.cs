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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxEmail = new System.Windows.Forms.TextBox();
            this.txtBoxEndereco = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtBoxCPFCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.txtBoxCNH = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 311);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email:";
            // 
            // rdBtnCPF
            // 
            this.rdBtnCPF.AutoSize = true;
            this.rdBtnCPF.Location = new System.Drawing.Point(14, 182);
            this.rdBtnCPF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdBtnCPF.Name = "rdBtnCPF";
            this.rdBtnCPF.Size = new System.Drawing.Size(67, 29);
            this.rdBtnCPF.TabIndex = 3;
            this.rdBtnCPF.TabStop = true;
            this.rdBtnCPF.Text = "CPF";
            this.rdBtnCPF.UseVisualStyleBackColor = true;
            this.rdBtnCPF.CheckedChanged += new System.EventHandler(this.rdBtnCPF_CheckedChanged);
            // 
            // rdBtnCNPJ
            // 
            this.rdBtnCNPJ.AutoSize = true;
            this.rdBtnCNPJ.Location = new System.Drawing.Point(89, 182);
            this.rdBtnCNPJ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdBtnCNPJ.Name = "rdBtnCNPJ";
            this.rdBtnCNPJ.Size = new System.Drawing.Size(76, 29);
            this.rdBtnCNPJ.TabIndex = 4;
            this.rdBtnCNPJ.TabStop = true;
            this.rdBtnCNPJ.Text = "CNPJ";
            this.rdBtnCNPJ.UseVisualStyleBackColor = true;
            this.rdBtnCNPJ.CheckedChanged += new System.EventHandler(this.rdBtnCNPJ_CheckedChanged);
            // 
            // txtBoxID
            // 
            this.txtBoxID.Enabled = false;
            this.txtBoxID.Location = new System.Drawing.Point(173, 60);
            this.txtBoxID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(70, 31);
            this.txtBoxID.TabIndex = 1;
            // 
            // txtBoxNome
            // 
            this.txtBoxNome.Location = new System.Drawing.Point(173, 118);
            this.txtBoxNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxNome.Name = "txtBoxNome";
            this.txtBoxNome.Size = new System.Drawing.Size(293, 31);
            this.txtBoxNome.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 371);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Telefone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 439);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Endereço:";
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.Location = new System.Drawing.Point(173, 305);
            this.txtBoxEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.PlaceholderText = "email@provedor.com";
            this.txtBoxEmail.Size = new System.Drawing.Size(235, 31);
            this.txtBoxEmail.TabIndex = 7;
            // 
            // txtBoxEndereco
            // 
            this.txtBoxEndereco.Location = new System.Drawing.Point(173, 433);
            this.txtBoxEndereco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxEndereco.Name = "txtBoxEndereco";
            this.txtBoxEndereco.Size = new System.Drawing.Size(293, 31);
            this.txtBoxEndereco.TabIndex = 9;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdicionar.Location = new System.Drawing.Point(334, 505);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(107, 38);
            this.btnAdicionar.TabIndex = 10;
            this.btnAdicionar.Text = "Cadastrar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(449, 505);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 38);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 246);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "CNH:";
            // 
            // txtBoxTelefone
            // 
            this.txtBoxTelefone.Location = new System.Drawing.Point(173, 368);
            this.txtBoxTelefone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxTelefone.Mask = "(00)00000-0000";
            this.txtBoxTelefone.Name = "txtBoxTelefone";
            this.txtBoxTelefone.Size = new System.Drawing.Size(235, 31);
            this.txtBoxTelefone.TabIndex = 8;
            // 
            // txtBoxCPFCNPJ
            // 
            this.txtBoxCPFCNPJ.Location = new System.Drawing.Point(173, 182);
            this.txtBoxCPFCNPJ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxCPFCNPJ.Name = "txtBoxCPFCNPJ";
            this.txtBoxCPFCNPJ.Size = new System.Drawing.Size(235, 31);
            this.txtBoxCPFCNPJ.TabIndex = 16;
            // 
            // txtBoxCNH
            // 
            this.txtBoxCNH.Location = new System.Drawing.Point(173, 243);
            this.txtBoxCNH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxCNH.Name = "txtBoxCNH";
            this.txtBoxCNH.Size = new System.Drawing.Size(235, 31);
            this.txtBoxCNH.TabIndex = 17;
            // 
            // TelaCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 549);
            this.Controls.Add(this.txtBoxCNH);
            this.Controls.Add(this.txtBoxCPFCNPJ);
            this.Controls.Add(this.txtBoxTelefone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.txtBoxEndereco);
            this.Controls.Add(this.txtBoxEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxNome);
            this.Controls.Add(this.txtBoxID);
            this.Controls.Add(this.rdBtnCNPJ);
            this.Controls.Add(this.rdBtnCPF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "TelaCadastroCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private Label label4;
        private Label label5;
        private TextBox txtBoxEmail;
        private TextBox txtBoxEndereco;
        private Button btnAdicionar;
        private Button btnCancelar;
        private Label label6;
        private MaskedTextBox txtBoxTelefone;
        private MaskedTextBox txtBoxCPFCNPJ;
        private MaskedTextBox txtBoxCNH;
    }
}