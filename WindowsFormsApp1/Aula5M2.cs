﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using Microsoft.Speech.Recognition;
using System.Globalization;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Aula5M2 : Form
    {
        //variáveis
        string frase = "teste";
        string legenda;
        string sd;//variável do áudio
        int num;
        int i;
        int c;
        // variaveis para voz
        static CultureInfo ci = new CultureInfo("en-US");// linguagem utilizada
        static SpeechRecognitionEngine reconhecedor; // reconhecedor de voz
        SpeechSynthesizer resposta = new SpeechSynthesizer();// sintetizador de voz

        //Arrays
        public String[] listaAudio =
        {
            

        };
        public String[] listaIngles =
        {
         
        };
        public String[] listaPortugues =
{
         
        };



        public Aula5M2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Init();


        }
        public void Gramatica()
        {
            try
            {
                reconhecedor = new SpeechRecognitionEngine(ci);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao integrar lingua escolhida:" + ex.Message);
            }

            // criacao da gramatica simples que o programa vai entender
            // usando um objeto Choices
            var gramatica = new Choices();
            gramatica.Add(listaIngles); // inclui a gramatica criada
            // cria o construtor gramatical
            // e passa o objeto criado com as palavras
            var gb = new GrammarBuilder();
            gb.Append(gramatica);
            // cria a instancia e carrega a engine de reconhecimento
            // passando a gramatica construida anteriomente
            try
            {
                var g = new Grammar(gb);

                try
                {
                    // carrega o arquivo de gramatica
                    reconhecedor.RequestRecognizerUpdate();
                    reconhecedor.LoadGrammarAsync(g);

                    // registra a voz como mecanismo de entrada para o evento de reconhecimento

                    reconhecedor.SpeechRecognized += Sre_Reconhecimento;


                    reconhecedor.SetInputToDefaultAudioDevice(); // microfone padrao
                    resposta.SetOutputToDefaultAudioDevice(); // auto falante padrao
                    reconhecedor.RecognizeAsync(RecognizeMode.Multiple); // multiplo reconheciment
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO ao criar reconhecedor: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO ao criar a gramática: " + ex.Message);
            }
        }
        public void Init()
        {
            resposta.Volume = 100; // controla volume de saida
            resposta.Rate = 2; // velocidade de fala
            Gramatica(); // inicialização da gramatica
        }


        private void Aula1_Load(object sender, EventArgs e)
        {
            //case 0


            btEscrever.Enabled = false;
            btFalar.Enabled = false;
             btProximo.Enabled = false;

            pictureBox1.Image = Properties.Resources.I_dislike_to_drink_coffee;
            sd = listaAudio[0];//audio
            txtPt.Text = listaPortugues[0];//legenda 
            txtEn.Text = listaIngles[0];//legenda inglês

            timerFalar.Stop();
            timerEscrever.Stop();
            textBoxAluno.Focus();

        }
        private void btProximo_Click(object sender, EventArgs e)//casos

        {
            timerOuvir.Start();
            num++;
            c = 0;
            int silvinha = num;
            var x = num;

            var result = Convert.ToString(x);
            lbPagina.Text = result;
            timerOuvir.Enabled = true;
            lblGravando.Text = "";
            btFalar.Text = "FALAR";
            btEscrever.Text = "ESCREVER";

            switch (silvinha)

            {

               







            }
        }
        void Sre_Reconhecimento(object sender, SpeechRecognizedEventArgs e)
        {
            i++;

            frase = e.Result.Text;
            legenda = txtEn.Text;
            lbAudio.Text = frase;




            if ((lbAudio.Text) == (txtEn.Text) && (lblGravando.Text.Equals("gravando")))
            {


                textBoxAluno.Enabled = true;
                timerFalar.Stop();
                timerEscrever.Start();
                timerOuvir.Stop();
                textBoxAluno.Visible = true;

                textBoxAluno.Select();
                btEscrever.Enabled = true;
                TimerMensagem.Stop();
                btFalar.BackColor = Color.Aqua;
                btFalar.Text = "CORRETO";

            }
            if ((lbAudio.Text) != (txtEn.Text) && (lblGravando.Text.Equals("gravando")))
            {
                btFalar.Text = "REPETIR";

            }


        }

        private void btOuvir_Click(object sender, EventArgs e)
        {



            timerOuvir.Stop();
            btOuvir.BackColor = Color.Aqua;
            timerFalar.Start();
            btFalar.Enabled = true;
            btFalar.Text = "FALAR";

            {//audio
                System.Media.SoundPlayer Tocar = new System.Media.SoundPlayer();//ativa o áudio
                Tocar.SoundLocation = sd;
                Tocar.Load();
                Tocar.Play();

            }
        }

        private void timerFalar_Tick(object sender, EventArgs e)
        {
            btFalar.BackColor = btFalar.BackColor == Color.Red ? Color.Aqua : Color.Red;
        }

        private void timerEscrever_Tick(object sender, EventArgs e)
        {
            btEscrever.BackColor = btEscrever.BackColor == Color.Red ? Color.Aqua : Color.Red;
        }

        private void timerOuvir_Tick(object sender, EventArgs e)
        {
            btOuvir.BackColor = btOuvir.BackColor == Color.Red ? Color.Aqua : Color.Red;
        }

        private void TimerMensagem_Tick(object sender, EventArgs e)
        {

        }

        private void btFalar_Click(object sender, EventArgs e)
        {



            if (lbAudio.Text.Equals(txtEn.Text))
            {


                textBoxAluno.Enabled = true;
                timerFalar.Stop();
                timerEscrever.Start();
                timerOuvir.Stop();
                textBoxAluno.Visible = true;
                textBoxAluno.Select();
                btEscrever.Enabled = true;
                TimerMensagem.Stop();
                btFalar.BackColor = Color.Aqua;
                c = 0;
            }
            else
            {
                var result = Convert.ToString(c);
                c++;

                if (c > 3)
                {


                    textBoxAluno.Enabled = true;
                    timerFalar.Stop();
                    timerEscrever.Start();
                    timerOuvir.Stop();
                    textBoxAluno.Visible = true;
                    textBoxAluno.Select();
                    btEscrever.Enabled = true;
                    TimerMensagem.Stop();
                    btFalar.BackColor = Color.Aqua;

                    c = 0;
                }
                else
                {

                }






            }










        }

        private void btEscrever_Click(object sender, EventArgs e)
        {

            if (txtEn.Text.Equals(textBoxAluno.Text.TrimEnd()))
            {


                btEscrever.Text = "CORRETO";
                btEscrever.BackColor = Color.Aqua;
                timerEscrever.Stop();
                btProximo.Enabled = true;
                btEscrever.Enabled = false;
                TimerMensagem.Enabled = false;
            }
            else
            {
                TimerMensagem.Start();

                btEscrever.Text = "REPETIR";

                btProximo.Enabled = false;

            }
        }

        private void txtEn_Click(object sender, EventArgs e)
        {

        }

        private void Tela_Click(object sender, EventArgs e)
        {

        }




        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBoxAluno_TextChanged(object sender, EventArgs e)
        {
            textBoxAluno.Focus();
        }

        private void axWindowsMediaPlayer1_Enter_2(object sender, EventArgs e)
        {

        }

        private void txtPt_Click(object sender, EventArgs e)
        {

        }

        private void lbPagina_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btFalar_Click_1(object sender, EventArgs e)
        {

            c++;
            lbAudio.Text = "";
            btFalar.Text = "FALANDO";
            lblGravando.Text = "gravando";
            if (c > 3)
            {

                textBoxAluno.Enabled = true;
                timerFalar.Stop();
                timerEscrever.Start();
                timerOuvir.Stop();
                textBoxAluno.Visible = true;

                textBoxAluno.Select();
                btEscrever.Enabled = true;
                TimerMensagem.Stop();
                btFalar.BackColor = Color.Aqua;
                btFalar.Text = "CORRETO";
                c = 0;
            }

        }
    }
}