namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    partial class TelaCadastroPlano
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
            this.lblGrupo = new System.Windows.Forms.Label();
            this.cbBoxGrupos = new System.Windows.Forms.ComboBox();
            this.tabControlPlanos = new System.Windows.Forms.TabControl();
            this.tabDiario = new System.Windows.Forms.TabPage();
            this.txtBoxDiarioValorKM = new System.Windows.Forms.TextBox();
            this.txtBoxDiarioValorDia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabLivre = new System.Windows.Forms.TabPage();
            this.txtBoxLivreValorDia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControlado = new System.Windows.Forms.TabPage();
            this.txtBoxControladoValorKM = new System.Windows.Forms.TextBox();
            this.txtBoxControladoValorDia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxControladoLimiteKM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabControlPlanos.SuspendLayout();
            this.tabDiario.SuspendLayout();
            this.tabLivre.SuspendLayout();
            this.tabControlado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGrupo.Location = new System.Drawing.Point(21, 23);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(50, 20);
            this.lblGrupo.TabIndex = 0;
            this.lblGrupo.Text = "Grupo";
            // 
            // cbBoxGrupos
            // 
            this.cbBoxGrupos.FormattingEnabled = true;
            this.cbBoxGrupos.Location = new System.Drawing.Point(21, 46);
            this.cbBoxGrupos.Name = "cbBoxGrupos";
            this.cbBoxGrupos.Size = new System.Drawing.Size(172, 23);
            this.cbBoxGrupos.TabIndex = 1;
            this.cbBoxGrupos.SelectedIndexChanged += new System.EventHandler(this.cbBoxGrupos_SelectedIndexChanged);
            // 
            // tabControlPlanos
            // 
            this.tabControlPlanos.Controls.Add(this.tabDiario);
            this.tabControlPlanos.Controls.Add(this.tabLivre);
            this.tabControlPlanos.Controls.Add(this.tabControlado);
            this.tabControlPlanos.Enabled = false;
            this.tabControlPlanos.Location = new System.Drawing.Point(21, 98);
            this.tabControlPlanos.Name = "tabControlPlanos";
            this.tabControlPlanos.SelectedIndex = 0;
            this.tabControlPlanos.Size = new System.Drawing.Size(306, 241);
            this.tabControlPlanos.TabIndex = 2;
            // 
            // tabDiario
            // 
            this.tabDiario.Controls.Add(this.txtBoxDiarioValorKM);
            this.tabDiario.Controls.Add(this.txtBoxDiarioValorDia);
            this.tabDiario.Controls.Add(this.label2);
            this.tabDiario.Controls.Add(this.label1);
            this.tabDiario.Location = new System.Drawing.Point(4, 24);
            this.tabDiario.Name = "tabDiario";
            this.tabDiario.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiario.Size = new System.Drawing.Size(319, 268);
            this.tabDiario.TabIndex = 0;
            this.tabDiario.Text = "Diário";
            this.tabDiario.UseVisualStyleBackColor = true;
            // 
            // txtBoxDiarioValorKM
            // 
            this.txtBoxDiarioValorKM.Location = new System.Drawing.Point(8, 100);
            this.txtBoxDiarioValorKM.Name = "txtBoxDiarioValorKM";
            this.txtBoxDiarioValorKM.Size = new System.Drawing.Size(239, 23);
            this.txtBoxDiarioValorKM.TabIndex = 3;
            // 
            // txtBoxDiarioValorDia
            // 
            this.txtBoxDiarioValorDia.Location = new System.Drawing.Point(8, 39);
            this.txtBoxDiarioValorDia.Name = "txtBoxDiarioValorDia";
            this.txtBoxDiarioValorDia.Size = new System.Drawing.Size(239, 23);
            this.txtBoxDiarioValorDia.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor Por KM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor Diário";
            // 
            // tabLivre
            // 
            this.tabLivre.Controls.Add(this.txtBoxLivreValorDia);
            this.tabLivre.Controls.Add(this.label4);
            this.tabLivre.Location = new System.Drawing.Point(4, 24);
            this.tabLivre.Name = "tabLivre";
            this.tabLivre.Padding = new System.Windows.Forms.Padding(3);
            this.tabLivre.Size = new System.Drawing.Size(319, 268);
            this.tabLivre.TabIndex = 1;
            this.tabLivre.Text = "Livre";
            this.tabLivre.UseVisualStyleBackColor = true;
            // 
            // txtBoxLivreValorDia
            // 
            this.txtBoxLivreValorDia.Location = new System.Drawing.Point(6, 39);
            this.txtBoxLivreValorDia.Name = "txtBoxLivreValorDia";
            this.txtBoxLivreValorDia.Size = new System.Drawing.Size(239, 23);
            this.txtBoxLivreValorDia.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Valor Diário";
            // 
            // tabControlado
            // 
            this.tabControlado.Controls.Add(this.txtBoxControladoLimiteKM);
            this.tabControlado.Controls.Add(this.label6);
            this.tabControlado.Controls.Add(this.txtBoxControladoValorKM);
            this.tabControlado.Controls.Add(this.txtBoxControladoValorDia);
            this.tabControlado.Controls.Add(this.label3);
            this.tabControlado.Controls.Add(this.label5);
            this.tabControlado.Location = new System.Drawing.Point(4, 24);
            this.tabControlado.Name = "tabControlado";
            this.tabControlado.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlado.Size = new System.Drawing.Size(298, 213);
            this.tabControlado.TabIndex = 2;
            this.tabControlado.Text = "Controlado";
            this.tabControlado.UseVisualStyleBackColor = true;
            // 
            // txtBoxControladoValorKM
            // 
            this.txtBoxControladoValorKM.Location = new System.Drawing.Point(6, 101);
            this.txtBoxControladoValorKM.Name = "txtBoxControladoValorKM";
            this.txtBoxControladoValorKM.Size = new System.Drawing.Size(239, 23);
            this.txtBoxControladoValorKM.TabIndex = 7;
            // 
            // txtBoxControladoValorDia
            // 
            this.txtBoxControladoValorDia.Location = new System.Drawing.Point(6, 40);
            this.txtBoxControladoValorDia.Name = "txtBoxControladoValorDia";
            this.txtBoxControladoValorDia.Size = new System.Drawing.Size(239, 23);
            this.txtBoxControladoValorDia.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Valor Por KM";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valor Diário";
            // 
            // txtBoxControladoLimiteKM
            // 
            this.txtBoxControladoLimiteKM.Location = new System.Drawing.Point(6, 164);
            this.txtBoxControladoLimiteKM.Name = "txtBoxControladoLimiteKM";
            this.txtBoxControladoLimiteKM.Size = new System.Drawing.Size(239, 23);
            this.txtBoxControladoLimiteKM.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Limite de Quilometragem";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirmar.Location = new System.Drawing.Point(189, 371);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(270, 371);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 410);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.tabControlPlanos);
            this.Controls.Add(this.cbBoxGrupos);
            this.Controls.Add(this.lblGrupo);
            this.Name = "TelaCadastroPlano";
            this.Text = "Cadastro de Plano de Cobrança";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroPlano_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroPlano_Load);
            this.tabControlPlanos.ResumeLayout(false);
            this.tabDiario.ResumeLayout(false);
            this.tabDiario.PerformLayout();
            this.tabLivre.ResumeLayout(false);
            this.tabLivre.PerformLayout();
            this.tabControlado.ResumeLayout(false);
            this.tabControlado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblGrupo;
        private ComboBox cbBoxGrupos;
        private TabControl tabControlPlanos;
        private TabPage tabDiario;
        private TextBox txtBoxDiarioValorKM;
        private TextBox txtBoxDiarioValorDia;
        private Label label2;
        private Label label1;
        private TabPage tabLivre;
        private TextBox txtBoxLivreValorDia;
        private Label label4;
        private TabPage tabControlado;
        private TextBox txtBoxControladoLimiteKM;
        private Label label6;
        private TextBox txtBoxControladoValorKM;
        private TextBox txtBoxControladoValorDia;
        private Label label3;
        private Label label5;
        private Button btnConfirmar;
        private Button btnCancelar;
    }
}