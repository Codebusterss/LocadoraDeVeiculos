namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    partial class TelaCadastroFuncionario
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxFuncionarioID = new System.Windows.Forms.TextBox();
            this.txtboxFuncionarioSenha = new System.Windows.Forms.TextBox();
            this.txtBoxFuncionarioLogin = new System.Windows.Forms.TextBox();
            this.btnCadastrarFuncionario = new System.Windows.Forms.Button();
            this.btnCancelarFuncionario = new System.Windows.Forms.Button();
            this.checkBoxFuncionarioAdmin = new System.Windows.Forms.CheckBox();
            this.dateTimeFuncionarioData = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data de admissão:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Senha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Login:";
            // 
            // txtBoxFuncionarioID
            // 
            this.txtBoxFuncionarioID.Location = new System.Drawing.Point(175, 45);
            this.txtBoxFuncionarioID.Name = "txtBoxFuncionarioID";
            this.txtBoxFuncionarioID.Size = new System.Drawing.Size(205, 31);
            this.txtBoxFuncionarioID.TabIndex = 4;
            // 
            // txtboxFuncionarioSenha
            // 
            this.txtboxFuncionarioSenha.Location = new System.Drawing.Point(175, 177);
            this.txtboxFuncionarioSenha.Name = "txtboxFuncionarioSenha";
            this.txtboxFuncionarioSenha.Size = new System.Drawing.Size(205, 31);
            this.txtboxFuncionarioSenha.TabIndex = 6;
            this.txtboxFuncionarioSenha.UseSystemPasswordChar = true;
            // 
            // txtBoxFuncionarioLogin
            // 
            this.txtBoxFuncionarioLogin.Location = new System.Drawing.Point(175, 107);
            this.txtBoxFuncionarioLogin.Name = "txtBoxFuncionarioLogin";
            this.txtBoxFuncionarioLogin.Size = new System.Drawing.Size(205, 31);
            this.txtBoxFuncionarioLogin.TabIndex = 7;
            // 
            // btnCadastrarFuncionario
            // 
            this.btnCadastrarFuncionario.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrarFuncionario.Location = new System.Drawing.Point(422, 337);
            this.btnCadastrarFuncionario.Name = "btnCadastrarFuncionario";
            this.btnCadastrarFuncionario.Size = new System.Drawing.Size(112, 34);
            this.btnCadastrarFuncionario.TabIndex = 8;
            this.btnCadastrarFuncionario.Text = "Cadastrar";
            this.btnCadastrarFuncionario.UseVisualStyleBackColor = true;
            this.btnCadastrarFuncionario.Click += new System.EventHandler(this.btnCadastrarFuncionario_Click);
            // 
            // btnCancelarFuncionario
            // 
            this.btnCancelarFuncionario.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarFuncionario.Location = new System.Drawing.Point(540, 337);
            this.btnCancelarFuncionario.Name = "btnCancelarFuncionario";
            this.btnCancelarFuncionario.Size = new System.Drawing.Size(112, 34);
            this.btnCancelarFuncionario.TabIndex = 9;
            this.btnCancelarFuncionario.Text = "Cancelar";
            this.btnCancelarFuncionario.UseVisualStyleBackColor = true;
            // 
            // checkBoxFuncionarioAdmin
            // 
            this.checkBoxFuncionarioAdmin.AutoSize = true;
            this.checkBoxFuncionarioAdmin.Location = new System.Drawing.Point(395, 109);
            this.checkBoxFuncionarioAdmin.Name = "checkBoxFuncionarioAdmin";
            this.checkBoxFuncionarioAdmin.Size = new System.Drawing.Size(91, 29);
            this.checkBoxFuncionarioAdmin.TabIndex = 10;
            this.checkBoxFuncionarioAdmin.Text = "Admin";
            this.checkBoxFuncionarioAdmin.UseVisualStyleBackColor = true;
            // 
            // dateTimeFuncionarioData
            // 
            this.dateTimeFuncionarioData.Location = new System.Drawing.Point(175, 251);
            this.dateTimeFuncionarioData.Name = "dateTimeFuncionarioData";
            this.dateTimeFuncionarioData.Size = new System.Drawing.Size(364, 31);
            this.dateTimeFuncionarioData.TabIndex = 11;
            // 
            // TelaCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 383);
            this.Controls.Add(this.dateTimeFuncionarioData);
            this.Controls.Add(this.checkBoxFuncionarioAdmin);
            this.Controls.Add(this.btnCancelarFuncionario);
            this.Controls.Add(this.btnCadastrarFuncionario);
            this.Controls.Add(this.txtBoxFuncionarioLogin);
            this.Controls.Add(this.txtboxFuncionarioSenha);
            this.Controls.Add(this.txtBoxFuncionarioID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TelaCadastroFuncionario";
            this.Text = "TelaCadastroFuncionario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtBoxFuncionarioID;
        private TextBox txtboxFuncionarioSenha;
        private TextBox txtBoxFuncionarioLogin;
        private Button btnCadastrarFuncionario;
        private Button btnCancelarFuncionario;
        private CheckBox checkBoxFuncionarioAdmin;
        private DateTimePicker dateTimeFuncionarioData;
    }
}