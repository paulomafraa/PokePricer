using System;
using System.Drawing;

namespace PokePricer2._0
{
    partial class Form1 : System.Windows.Forms.Form
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.CheckBox chkLembrar;
        private System.Windows.Forms.Button btnExportar;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.chkLembrar = new System.Windows.Forms.CheckBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.executarPrice = new System.Windows.Forms.CheckBox();
            this.btnPrecificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(30, 30);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(36, 13);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login:";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(80, 27);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(200, 20);
            this.txtLogin.TabIndex = 1;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(30, 70);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 2;
            this.lblSenha.Text = "Senha:";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(80, 67);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(200, 20);
            this.txtSenha.TabIndex = 3;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // chkLembrar
            // 
            this.chkLembrar.AutoSize = true;
            this.chkLembrar.Location = new System.Drawing.Point(33, 120);
            this.chkLembrar.Name = "chkLembrar";
            this.chkLembrar.Size = new System.Drawing.Size(130, 17);
            this.chkLembrar.TabIndex = 4;
            this.chkLembrar.Text = "Lembrar login e senha";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(177, 163);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(103, 30);
            this.btnExportar.TabIndex = 5;
            this.btnExportar.Text = "Exportar Cartas";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // executarPrice
            // 
            this.executarPrice.AutoSize = true;
            this.executarPrice.Location = new System.Drawing.Point(177, 120);
            this.executarPrice.Name = "executarPrice";
            this.executarPrice.Size = new System.Drawing.Size(103, 17);
            this.executarPrice.TabIndex = 6;
            this.executarPrice.Text = "Converter Preço";
            this.executarPrice.UseVisualStyleBackColor = true;
            // 
            // btnPrecificar
            // 
            this.btnPrecificar.Location = new System.Drawing.Point(33, 163);
            this.btnPrecificar.Name = "btnPrecificar";
            this.btnPrecificar.Size = new System.Drawing.Size(103, 30);
            this.btnPrecificar.TabIndex = 7;
            this.btnPrecificar.Text = "Precificar";
            this.btnPrecificar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 222);
            this.Controls.Add(this.btnPrecificar);
            this.Controls.Add(this.executarPrice);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.chkLembrar);
            this.Controls.Add(this.btnExportar);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "PokePricer - Exportador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox executarPrice;
        private System.Windows.Forms.Button btnPrecificar;
    }
}