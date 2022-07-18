namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculo
{
    partial class TelaCadastroGrupoDeVeiculo
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
            this.lblID = new System.Windows.Forms.Label();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.lblNomeDoGrupo = new System.Windows.Forms.Label();
            this.txtBoxNomeDoGrupo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 24);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 15);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // txtBoxID
            // 
            this.txtBoxID.Enabled = false;
            this.txtBoxID.Location = new System.Drawing.Point(39, 21);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.ReadOnly = true;
            this.txtBoxID.Size = new System.Drawing.Size(48, 23);
            this.txtBoxID.TabIndex = 1;
            // 
            // lblNomeDoGrupo
            // 
            this.lblNomeDoGrupo.AutoSize = true;
            this.lblNomeDoGrupo.Location = new System.Drawing.Point(12, 56);
            this.lblNomeDoGrupo.Name = "lblNomeDoGrupo";
            this.lblNomeDoGrupo.Size = new System.Drawing.Size(96, 15);
            this.lblNomeDoGrupo.TabIndex = 2;
            this.lblNomeDoGrupo.Text = "Nome do Grupo:";
            // 
            // txtBoxNomeDoGrupo
            // 
            this.txtBoxNomeDoGrupo.Location = new System.Drawing.Point(114, 53);
            this.txtBoxNomeDoGrupo.Name = "txtBoxNomeDoGrupo";
            this.txtBoxNomeDoGrupo.Size = new System.Drawing.Size(130, 23);
            this.txtBoxNomeDoGrupo.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(274, 102);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(193, 102);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 5;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // TelaCadastroGrupoDeVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 135);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtBoxNomeDoGrupo);
            this.Controls.Add(this.lblNomeDoGrupo);
            this.Controls.Add(this.txtBoxID);
            this.Controls.Add(this.lblID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TelaCadastroGrupoDeVeiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Grupo de Veículos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroGrupoDeVeiculo_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroGrupoDeVeiculo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblID;
        private TextBox txtBoxID;
        private Label lblNomeDoGrupo;
        private TextBox txtBoxNomeDoGrupo;
        private Button btnCancelar;
        private Button btnCadastrar;
    }
}