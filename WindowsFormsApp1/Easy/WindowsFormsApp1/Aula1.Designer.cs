﻿namespace WindowsFormsApp1
{
    partial class Aula1
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
            this.components = new System.ComponentModel.Container();
            this.btOuvir = new System.Windows.Forms.Button();
            this.btFalar = new System.Windows.Forms.Button();
            this.btEscrever = new System.Windows.Forms.Button();
            this.lbPagina = new System.Windows.Forms.Label();
            this.btProximo = new System.Windows.Forms.Button();
            this.textBoxAluno = new System.Windows.Forms.TextBox();
            this.txtEn = new System.Windows.Forms.Label();
            this.lbProfessor = new System.Windows.Forms.Label();
            this.txtPt = new System.Windows.Forms.Label();
            this.timerFalar = new System.Windows.Forms.Timer(this.components);
            this.timerEscrever = new System.Windows.Forms.Timer(this.components);
            this.timerOuvir = new System.Windows.Forms.Timer(this.components);
            this.TimerMensagem = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbAudio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btOuvir
            // 
            this.btOuvir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOuvir.BackColor = System.Drawing.Color.Aqua;
            this.btOuvir.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOuvir.Location = new System.Drawing.Point(876, 9);
            this.btOuvir.Name = "btOuvir";
            this.btOuvir.Size = new System.Drawing.Size(330, 83);
            this.btOuvir.TabIndex = 1;
            this.btOuvir.Text = "OUVIR";
            this.btOuvir.UseVisualStyleBackColor = false;
            this.btOuvir.Click += new System.EventHandler(this.btOuvir_Click);
            // 
            // btFalar
            // 
            this.btFalar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFalar.BackColor = System.Drawing.Color.Aqua;
            this.btFalar.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFalar.Location = new System.Drawing.Point(876, 136);
            this.btFalar.Name = "btFalar";
            this.btFalar.Size = new System.Drawing.Size(330, 83);
            this.btFalar.TabIndex = 23;
            this.btFalar.Text = "FALAR";
            this.btFalar.UseVisualStyleBackColor = false;
            this.btFalar.Click += new System.EventHandler(this.btFalar_Click);
            // 
            // btEscrever
            // 
            this.btEscrever.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEscrever.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btEscrever.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEscrever.Location = new System.Drawing.Point(876, 261);
            this.btEscrever.Name = "btEscrever";
            this.btEscrever.Size = new System.Drawing.Size(330, 83);
            this.btEscrever.TabIndex = 24;
            this.btEscrever.Text = "ESCREVER";
            this.btEscrever.UseVisualStyleBackColor = false;
            this.btEscrever.Click += new System.EventHandler(this.btEscrever_Click);
            // 
            // lbPagina
            // 
            this.lbPagina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPagina.AutoSize = true;
            this.lbPagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 84.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPagina.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbPagina.Location = new System.Drawing.Point(1084, 490);
            this.lbPagina.Name = "lbPagina";
            this.lbPagina.Size = new System.Drawing.Size(118, 128);
            this.lbPagina.TabIndex = 25;
            this.lbPagina.Text = "0";
            // 
            // btProximo
            // 
            this.btProximo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btProximo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btProximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProximo.Location = new System.Drawing.Point(876, 390);
            this.btProximo.Name = "btProximo";
            this.btProximo.Size = new System.Drawing.Size(330, 83);
            this.btProximo.TabIndex = 26;
            this.btProximo.Text = "PRÓXIMO";
            this.btProximo.UseVisualStyleBackColor = false;
            this.btProximo.Click += new System.EventHandler(this.btProximo_Click);
            // 
            // textBoxAluno
            // 
            this.textBoxAluno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAluno.Enabled = false;
            this.textBoxAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold);
            this.textBoxAluno.Location = new System.Drawing.Point(32, 744);
            this.textBoxAluno.Name = "textBoxAluno";
            this.textBoxAluno.Size = new System.Drawing.Size(1170, 98);
            this.textBoxAluno.TabIndex = 27;
            this.textBoxAluno.Visible = false;
            this.textBoxAluno.TextChanged += new System.EventHandler(this.textBoxAluno_TextChanged);
            // 
            // txtEn
            // 
            this.txtEn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEn.AutoSize = true;
            this.txtEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtEn.Location = new System.Drawing.Point(16, 619);
            this.txtEn.Name = "txtEn";
            this.txtEn.Size = new System.Drawing.Size(282, 91);
            this.txtEn.TabIndex = 28;
            this.txtEn.Text = "leg. en";
            this.txtEn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtEn.Click += new System.EventHandler(this.txtEn_Click);
            // 
            // lbProfessor
            // 
            this.lbProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbProfessor.AutoSize = true;
            this.lbProfessor.BackColor = System.Drawing.Color.White;
            this.lbProfessor.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold);
            this.lbProfessor.Location = new System.Drawing.Point(43, 506);
            this.lbProfessor.Name = "lbProfessor";
            this.lbProfessor.Size = new System.Drawing.Size(452, 91);
            this.lbProfessor.TabIndex = 29;
            this.lbProfessor.Text = "lbProfessor";
            this.lbProfessor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbProfessor.Click += new System.EventHandler(this.lbProfessor_Click);
            // 
            // txtPt
            // 
            this.txtPt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPt.AutoSize = true;
            this.txtPt.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPt.Location = new System.Drawing.Point(16, 744);
            this.txtPt.Name = "txtPt";
            this.txtPt.Size = new System.Drawing.Size(238, 91);
            this.txtPt.TabIndex = 30;
            this.txtPt.Text = "leg.pt";
            // 
            // timerFalar
            // 
            this.timerFalar.Enabled = true;
            this.timerFalar.Interval = 1000;
            this.timerFalar.Tick += new System.EventHandler(this.timerFalar_Tick);
            // 
            // timerEscrever
            // 
            this.timerEscrever.Enabled = true;
            this.timerEscrever.Interval = 1000;
            this.timerEscrever.Tick += new System.EventHandler(this.timerEscrever_Tick);
            // 
            // timerOuvir
            // 
            this.timerOuvir.Enabled = true;
            this.timerOuvir.Interval = 1000;
            this.timerOuvir.Tick += new System.EventHandler(this.timerOuvir_Tick);
            // 
            // TimerMensagem
            // 
            this.TimerMensagem.Interval = 1000;
            this.TimerMensagem.Tick += new System.EventHandler(this.TimerMensagem_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.I_drink;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(827, 604);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // lbAudio
            // 
            this.lbAudio.AutoSize = true;
            this.lbAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAudio.Location = new System.Drawing.Point(893, 506);
            this.lbAudio.Name = "lbAudio";
            this.lbAudio.Size = new System.Drawing.Size(259, 55);
            this.lbAudio.TabIndex = 32;
            this.lbAudio.Text = "texto audio";
            this.lbAudio.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(903, 583);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // Aula1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1214, 989);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbProfessor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbAudio);
            this.Controls.Add(this.lbPagina);
            this.Controls.Add(this.textBoxAluno);
            this.Controls.Add(this.txtPt);
            this.Controls.Add(this.txtEn);
            this.Controls.Add(this.btProximo);
            this.Controls.Add(this.btEscrever);
            this.Controls.Add(this.btFalar);
            this.Controls.Add(this.btOuvir);
            this.Name = "Aula1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Aula1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOuvir;
        private System.Windows.Forms.Button btFalar;
        private System.Windows.Forms.Button btEscrever;
        private System.Windows.Forms.Label lbPagina;
        private System.Windows.Forms.Button btProximo;
        private System.Windows.Forms.TextBox textBoxAluno;
        private System.Windows.Forms.Label txtEn;
        private System.Windows.Forms.Label lbProfessor;
        private System.Windows.Forms.Label txtPt;
        private System.Windows.Forms.Timer timerFalar;
        private System.Windows.Forms.Timer timerEscrever;
        private System.Windows.Forms.Timer timerOuvir;
        private System.Windows.Forms.Timer TimerMensagem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbAudio;
        private System.Windows.Forms.Label label1;
    }
}