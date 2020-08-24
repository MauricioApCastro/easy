namespace WindowsFormsApp1
{
    partial class Aula5M2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aula5M2));
            this.btOuvir = new System.Windows.Forms.Button();
            this.btFalar = new System.Windows.Forms.Button();
            this.btEscrever = new System.Windows.Forms.Button();
            this.lbPagina = new System.Windows.Forms.Label();
            this.btProximo = new System.Windows.Forms.Button();
            this.textBoxAluno = new System.Windows.Forms.TextBox();
            this.txtEn = new System.Windows.Forms.Label();
            this.txtPt = new System.Windows.Forms.Label();
            this.timerFalar = new System.Windows.Forms.Timer(this.components);
            this.timerEscrever = new System.Windows.Forms.Timer(this.components);
            this.timerOuvir = new System.Windows.Forms.Timer(this.components);
            this.TimerMensagem = new System.Windows.Forms.Timer(this.components);
            this.lbAudio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGravando = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btOuvir
            // 
            this.btOuvir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOuvir.BackColor = System.Drawing.Color.Aqua;
            this.btOuvir.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOuvir.Location = new System.Drawing.Point(670, 9);
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
            this.btFalar.Location = new System.Drawing.Point(670, 115);
            this.btFalar.Name = "btFalar";
            this.btFalar.Size = new System.Drawing.Size(330, 83);
            this.btFalar.TabIndex = 23;
            this.btFalar.Text = "FALAR";
            this.btFalar.UseVisualStyleBackColor = false;
            this.btFalar.Click += new System.EventHandler(this.btFalar_Click_1);
            // 
            // btEscrever
            // 
            this.btEscrever.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEscrever.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btEscrever.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEscrever.Location = new System.Drawing.Point(670, 215);
            this.btEscrever.Name = "btEscrever";
            this.btEscrever.Size = new System.Drawing.Size(330, 83);
            this.btEscrever.TabIndex = 24;
            this.btEscrever.Text = "ESCREVER";
            this.btEscrever.UseVisualStyleBackColor = false;
            this.btEscrever.Click += new System.EventHandler(this.btEscrever_Click);
            // 
            // lbPagina
            // 
            this.lbPagina.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPagina.AutoSize = true;
            this.lbPagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPagina.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbPagina.Location = new System.Drawing.Point(873, 420);
            this.lbPagina.Name = "lbPagina";
            this.lbPagina.Size = new System.Drawing.Size(110, 120);
            this.lbPagina.TabIndex = 25;
            this.lbPagina.Text = "0";
            this.lbPagina.Click += new System.EventHandler(this.lbPagina_Click);
            // 
            // btProximo
            // 
            this.btProximo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btProximo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btProximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProximo.Location = new System.Drawing.Point(670, 316);
            this.btProximo.Name = "btProximo";
            this.btProximo.Size = new System.Drawing.Size(330, 83);
            this.btProximo.TabIndex = 26;
            this.btProximo.Text = "PRÓXIMO";
            this.btProximo.UseVisualStyleBackColor = false;
            this.btProximo.Click += new System.EventHandler(this.btProximo_Click);
            // 
            // textBoxAluno
            // 
            this.textBoxAluno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxAluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxAluno.Enabled = false;
            this.textBoxAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAluno.Location = new System.Drawing.Point(12, 570);
            this.textBoxAluno.MaxLength = 100;
            this.textBoxAluno.Multiline = true;
            this.textBoxAluno.Name = "textBoxAluno";
            this.textBoxAluno.Size = new System.Drawing.Size(880, 150);
            this.textBoxAluno.TabIndex = 27;
            this.textBoxAluno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAluno.Visible = false;
            this.textBoxAluno.TextChanged += new System.EventHandler(this.textBoxAluno_TextChanged);
            // 
            // txtEn
            // 
            this.txtEn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtEn.Location = new System.Drawing.Point(12, 420);
            this.txtEn.Name = "txtEn";
            this.txtEn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEn.Size = new System.Drawing.Size(880, 150);
            this.txtEn.TabIndex = 28;
            this.txtEn.Text = "leg. en";
            this.txtEn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtEn.UseCompatibleTextRendering = true;
            this.txtEn.Click += new System.EventHandler(this.txtEn_Click);
            // 
            // txtPt
            // 
            this.txtPt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPt.Font = new System.Drawing.Font("Microsoft Sans Serif", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPt.Location = new System.Drawing.Point(12, 570);
            this.txtPt.Name = "txtPt";
            this.txtPt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPt.Size = new System.Drawing.Size(880, 150);
            this.txtPt.TabIndex = 28;
            this.txtPt.Text = "leg.pt";
            this.txtPt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtPt.UseCompatibleTextRendering = true;
            this.txtPt.Click += new System.EventHandler(this.txtPt_Click);
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
            // lbAudio
            // 
            this.lbAudio.AutoSize = true;
            this.lbAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAudio.Location = new System.Drawing.Point(592, 338);
            this.lbAudio.Name = "lbAudio";
            this.lbAudio.Size = new System.Drawing.Size(59, 13);
            this.lbAudio.TabIndex = 32;
            this.lbAudio.Text = "texto audio";
            this.lbAudio.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(616, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // lblGravando
            // 
            this.lblGravando.AutoSize = true;
            this.lblGravando.Location = new System.Drawing.Point(603, 307);
            this.lblGravando.Name = "lblGravando";
            this.lblGravando.Size = new System.Drawing.Size(35, 13);
            this.lblGravando.TabIndex = 37;
            this.lblGravando.Text = "label2";
            this.lblGravando.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.what_s_you_name;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(564, 390);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(294, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(282, 390);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Aula5M2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.lblGravando);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAudio);
            this.Controls.Add(this.lbPagina);
            this.Controls.Add(this.txtEn);
            this.Controls.Add(this.btProximo);
            this.Controls.Add(this.btEscrever);
            this.Controls.Add(this.btFalar);
            this.Controls.Add(this.btOuvir);
            this.Controls.Add(this.textBoxAluno);
            this.Controls.Add(this.txtPt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Aula5M2";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Aula1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.Label txtPt;
        private System.Windows.Forms.Timer timerFalar;
        private System.Windows.Forms.Timer timerEscrever;
        private System.Windows.Forms.Timer timerOuvir;
        private System.Windows.Forms.Timer TimerMensagem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbAudio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblGravando;
    }
}