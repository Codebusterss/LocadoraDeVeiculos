﻿namespace LocadoraDeVeiculos.WinApp
{
    partial class TelaMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaMenuPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposDeVeículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planosDeCobrançaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condutoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnInserir = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.locaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panelRegistros.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenu
            // 
            this.cadastrosToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.gruposDeVeículosToolStripMenuItem,
            this.funcionáriosToolStripMenuItem,
            this.taxasToolStripMenuItem,
            this.planosDeCobrançaToolStripMenuItem,
            this.condutoresToolStripMenuItem,
            this.veículosToolStripMenuItem,
            this.locaçõesToolStripMenuItem});
            this.cadastrosToolStripMenu.Name = "cadastrosToolStripMenu";
            this.cadastrosToolStripMenu.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenu.Text = "Cadastros";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // gruposDeVeículosToolStripMenuItem
            // 
            this.gruposDeVeículosToolStripMenuItem.Name = "gruposDeVeículosToolStripMenuItem";
            this.gruposDeVeículosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.gruposDeVeículosToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.gruposDeVeículosToolStripMenuItem.Text = "Grupos de Veículos";
            this.gruposDeVeículosToolStripMenuItem.Click += new System.EventHandler(this.gruposDeVeículosToolStripMenuItem_Click);
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            this.funcionáriosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.funcionáriosToolStripMenuItem.Text = "Funcionários";
            this.funcionáriosToolStripMenuItem.Click += new System.EventHandler(this.funcionáriosToolStripMenuItem_Click);
            // 
            // taxasToolStripMenuItem
            // 
            this.taxasToolStripMenuItem.Name = "taxasToolStripMenuItem";
            this.taxasToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.taxasToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.taxasToolStripMenuItem.Text = "Taxas";
            this.taxasToolStripMenuItem.Click += new System.EventHandler(this.taxasToolStripMenuItem_Click);
            // 
            // planosDeCobrançaToolStripMenuItem
            // 
            this.planosDeCobrançaToolStripMenuItem.Name = "planosDeCobrançaToolStripMenuItem";
            this.planosDeCobrançaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.planosDeCobrançaToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.planosDeCobrançaToolStripMenuItem.Text = "Planos de Cobrança";
            this.planosDeCobrançaToolStripMenuItem.Click += new System.EventHandler(this.planosDeCobrançaToolStripMenuItem_Click);
            // 
            // condutoresToolStripMenuItem
            // 
            this.condutoresToolStripMenuItem.Name = "condutoresToolStripMenuItem";
            this.condutoresToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.condutoresToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.condutoresToolStripMenuItem.Text = "Condutores";
            this.condutoresToolStripMenuItem.Click += new System.EventHandler(this.condutoresToolStripMenuItem_Click);
            // 
            // veículosToolStripMenuItem
            // 
            this.veículosToolStripMenuItem.Name = "veículosToolStripMenuItem";
            this.veículosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.veículosToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.veículosToolStripMenuItem.Text = "Veículos";
            this.veículosToolStripMenuItem.Click += new System.EventHandler(this.veículosToolStripMenuItem_Click);
            // 
            // panelRegistros
            // 
            this.panelRegistros.BackColor = System.Drawing.SystemColors.Control;
            this.panelRegistros.Controls.Add(this.lblTitulo);
            this.panelRegistros.Location = new System.Drawing.Point(0, 80);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(800, 345);
            this.panelRegistros.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(540, 347);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(220, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Locadora de Veículos";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInserir,
            this.btnEditar,
            this.btnExcluir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(800, 53);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            this.btnInserir.AutoSize = false;
            this.btnInserir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInserir.Image = ((System.Drawing.Image)(resources.GetObject("btnInserir.Image")));
            this.btnInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(50, 50);
            this.btnInserir.Text = "Inserir";
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = false;
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(50, 50);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = false;
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(50, 50);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusRodape});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusRodape
            // 
            this.lblStatusRodape.Name = "lblStatusRodape";
            this.lblStatusRodape.Size = new System.Drawing.Size(52, 17);
            this.lblStatusRodape.Text = "[rodape]";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // locaçõesToolStripMenuItem
            // 
            this.locaçõesToolStripMenuItem.Name = "locaçõesToolStripMenuItem";
            this.locaçõesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.locaçõesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.locaçõesToolStripMenuItem.Text = "Locações";
            this.locaçõesToolStripMenuItem.Click += new System.EventHandler(this.locaçõesToolStripMenuItem_Click);
            // 
            // TelaMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "TelaMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locadora de Veículos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TelaMenuPrincipal_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelRegistros.ResumeLayout(false);
            this.panelRegistros.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosToolStripMenu;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem gruposDeVeículosToolStripMenuItem;
        private ToolStripMenuItem funcionáriosToolStripMenuItem;
        private ToolStripMenuItem taxasToolStripMenuItem;
        private Panel panelRegistros;
        private Label lblTitulo;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatusRodape;
        private ToolStrip toolStrip1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripMenuItem planosDeCobrançaToolStripMenuItem;
        private ToolStripMenuItem condutoresToolStripMenuItem;
        private ToolStripMenuItem veículosToolStripMenuItem;
        private ToolStripMenuItem locaçõesToolStripMenuItem;
    }
}