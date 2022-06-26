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
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxNome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxSalario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 252);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data de admissão:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Senha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Login:";
            // 
            // txtBoxFuncionarioID
            // 
            this.txtBoxFuncionarioID.Enabled = false;
            this.txtBoxFuncionarioID.Location = new System.Drawing.Point(122, 27);
            this.txtBoxFuncionarioID.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxFuncionarioID.Name = "txtBoxFuncionarioID";
            this.txtBoxFuncionarioID.Size = new System.Drawing.Size(45, 23);
            this.txtBoxFuncionarioID.TabIndex = 4;
            // 
            // txtboxFuncionarioSenha
            // 
            this.txtboxFuncionarioSenha.Location = new System.Drawing.Point(122, 140);
            this.txtboxFuncionarioSenha.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxFuncionarioSenha.Name = "txtboxFuncionarioSenha";
            this.txtboxFuncionarioSenha.Size = new System.Drawing.Size(145, 23);
            this.txtboxFuncionarioSenha.TabIndex = 6;
            this.txtboxFuncionarioSenha.UseSystemPasswordChar = true;
            // 
            // txtBoxFuncionarioLogin
            // 
            this.txtBoxFuncionarioLogin.Location = new System.Drawing.Point(122, 103);
            this.txtBoxFuncionarioLogin.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxFuncionarioLogin.Name = "txtBoxFuncionarioLogin";
            this.txtBoxFuncionarioLogin.Size = new System.Drawing.Size(145, 23);
            this.txtBoxFuncionarioLogin.TabIndex = 7;
            // 
            // btnCadastrarFuncionario
            // 
            this.btnCadastrarFuncionario.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrarFuncionario.Location = new System.Drawing.Point(268, 341);
            this.btnCadastrarFuncionario.Margin = new System.Windows.Forms.Padding(2);
            this.btnCadastrarFuncionario.Name = "btnCadastrarFuncionario";
            this.btnCadastrarFuncionario.Size = new System.Drawing.Size(78, 27);
            this.btnCadastrarFuncionario.TabIndex = 8;
            this.btnCadastrarFuncionario.Text = "Cadastrar";
            this.btnCadastrarFuncionario.UseVisualStyleBackColor = true;
            this.btnCadastrarFuncionario.Click += new System.EventHandler(this.btnCadastrarFuncionario_Click);
            // 
            // btnCancelarFuncionario
            // 
            this.btnCancelarFuncionario.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarFuncionario.Location = new System.Drawing.Point(350, 341);
            this.btnCancelarFuncionario.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarFuncionario.Name = "btnCancelarFuncionario";
            this.btnCancelarFuncionario.Size = new System.Drawing.Size(78, 27);
            this.btnCancelarFuncionario.TabIndex = 9;
            this.btnCancelarFuncionario.Text = "Cancelar";
            this.btnCancelarFuncionario.UseVisualStyleBackColor = true;
            // 
            // checkBoxFuncionarioAdmin
            // 
            this.checkBoxFuncionarioAdmin.AutoSize = true;
            this.checkBoxFuncionarioAdmin.Location = new System.Drawing.Point(122, 178);
            this.checkBoxFuncionarioAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxFuncionarioAdmin.Name = "checkBoxFuncionarioAdmin";
            this.checkBoxFuncionarioAdmin.Size = new System.Drawing.Size(62, 19);
            this.checkBoxFuncionarioAdmin.TabIndex = 10;
            this.checkBoxFuncionarioAdmin.Text = "Admin";
            this.checkBoxFuncionarioAdmin.UseVisualStyleBackColor = true;
            // 
            // dateTimeFuncionarioData
            // 
            this.dateTimeFuncionarioData.Location = new System.Drawing.Point(122, 246);
            this.dateTimeFuncionarioData.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeFuncionarioData.Name = "dateTimeFuncionarioData";
            this.dateTimeFuncionarioData.Size = new System.Drawing.Size(256, 23);
            this.dateTimeFuncionarioData.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nome:";
            // 
            // txtBoxNome
            // 
            this.txtBoxNome.Location = new System.Drawing.Point(122, 66);
            this.txtBoxNome.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxNome.Name = "txtBoxNome";
            this.txtBoxNome.Size = new System.Drawing.Size(145, 23);
            this.txtBoxNome.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 212);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Salário:";
            // 
            // txtBoxSalario
            // 
            this.txtBoxSalario.Location = new System.Drawing.Point(122, 209);
            this.txtBoxSalario.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxSalario.Name = "txtBoxSalario";
            this.txtBoxSalario.Size = new System.Drawing.Size(145, 23);
            this.txtBoxSalario.TabIndex = 16;
            // 
            // TelaCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 379);
            this.Controls.Add(this.txtBoxSalario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxNome);
            this.Controls.Add(this.label5);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "TelaCadastroFuncionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Funcionários";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroFuncionario_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroFuncionario_Load);
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
        private Label label5;
        private TextBox txtBoxNome;
        private Label label6;
        private TextBox txtBoxSalario;
    }
}