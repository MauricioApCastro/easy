using System;
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
    public partial class Aula3M2 : Form
    {
        //variáveis
        int numero;
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
"audio//red.wav",
"audio//blue.wav",
"audio//green.wav",
"audio//yellow.wav",
"audio//black.wav",
"audio//White.wav",
"audio//Brown.wav",
"audio//rose.wav",
"audio//purple.wav",
"audio//orange.wav",
"audio//light red.wav",
"audio//dark yellow.wav",
"audio//light brown.wav",
"audio//light orange.wav",
"audio//dark pink.wav",
"audio//light purple.wav",
"audio//dark orange.wav",
"audio//dark brown.wav",

"audio//light green.wav",
"audio//light blue.wav",
"audio//Dark purple.wav",
"audio//dark blue.wav",
"audio//dark green.wav",
"audio//two red apples.wav",
"audio//yellow banana.wav",
"audio//ten pink cakes.wav",

        };
        public String[] listaIngles =
        {
"red",
"blue",
"green",
"yellow",
"black",
"White",
"Brown",
"rose",
"purple",
"orange",
"light red",
"dark yellow",
"light brown",
"light orange",
"dark pink",
"light purple",
"dark orange",
"dark brown",

"light green",
"light blue",
"Dark purple",
"dark blue",
"dark green",
"two red apples",
"yellow banana",
"ten pink cakes",

        };
        public String[] listaPortugues =
{

            "vermelho",
"azul ",
"verde",
"amarelo",
"preto",
"branco",
"marrom",
"rosa",
"roxo",
"laranja",
"vermelho claro",
"amarelo escuro",
"marrom claro",
"laranja claro",
"rosa escuro",
"roxo claro",
"laranja escuro",
"marrom escuro",

"verde claro",
"azul claro",
"roxo escuro",
"azul escuro",
"verde escuro",
"duas maças vermelhas",
"banana amarela",
"dez bolos rosa",
        };



        public Aula3M2()
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

            numero = 0;
            btEscrever.Enabled = false;
            btFalar.Enabled = false;
            btProximo.Enabled = false;
            pictureBox1.Image = Properties.Resources.red;
            sd = listaAudio[numero];//audio
            txtPt.Text = listaPortugues[numero];//legenda 
            txtEn.Text = listaIngles[numero];//legenda inglês
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
                case 1:
                    numero = 1;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.blue;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 2:
                    numero = 2;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.green;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 3:
                    numero = 3;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.yellow;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 4:
                    numero = 4;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.black;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 5:
                    numero = 5;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.white;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 6:
                    numero = 6;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.marrom;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 7:
                    numero = 7;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.pink;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 8:
                    numero = 8;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.purple;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 9:
                    numero = 9;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.orange1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 10:
                    numero = 10;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.light_red;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 11:
                    numero = 11;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_yellow;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 12:
                    numero = 12;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_brown1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 13:
                    numero = 13;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_orange1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 14:
                    numero = 14;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_pink1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 15:
                    numero = 15;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_purple;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 16:
                    numero = 16;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_orange1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 17:
                    numero = 17;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_brown1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 18:
                    numero = 18;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.light_green1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 19:
                    numero = 19;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.light_blue;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 20:
                    numero = 20;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_purple;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 21:
                    numero = 21;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_blue;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 22:
                    numero = 22;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_green1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 23:
                    numero = 23;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.red;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 24:
                    numero = 1;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.blue;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 25:
                    numero = 2;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.green;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 26:
                    numero = 3;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.yellow;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 27:
                    numero = 4;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.black;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 28:
                    numero = 5;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.white;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 29:
                    numero = 6;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.marrom;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 30:
                    numero = 7;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.pink;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 31:
                    numero = 8;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.purple;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 32:
                    numero = 9;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.orange1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 33:
                    numero = 10;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.light_red;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 34:
                    numero = 11;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_yellow;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 35:
                    numero = 12;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_brown1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 36:
                    numero = 13;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_orange1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 37:
                    numero = 14;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_pink1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 38:
                    numero = 15;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_purple;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 39:
                    numero = 16;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_orange1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 40:
                    numero = 17;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_brown1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 41:
                    numero = 18;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.light_green1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 42:
                    numero = 19;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.light_blue;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 43:
                    numero = 20;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_purple;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 44:
                    numero = 21;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_blue;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 45:
                    numero = 22;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_green1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 46:
                    numero = 23;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.red;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 47:
                    numero = 1;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.blue;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 48:
                    numero = 2;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.green;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 49:
                    numero = 3;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.yellow;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 50:
                    numero = 4;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.black;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 51:
                    numero = 5;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.white;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 52:
                    numero = 6;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.marrom;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 53:
                    numero = 7;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.pink;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 54:
                    numero = 8;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.purple;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 55:
                    numero = 9;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.orange1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 56:
                    numero = 10;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.light_red;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 57:
                    numero = 11;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_yellow;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 58:
                    numero = 12;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_brown1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 59:
                    numero = 13;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_orange1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 60:
                    numero = 14;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_pink1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 61:
                    numero = 15;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_purple;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 62:
                    numero = 16;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_orange1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 63:
                    numero = 17;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_brown1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 64:
                    numero = 18;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.light_green1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 65:
                    numero = 19;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.light_blue;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 66:
                    numero = 20;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_purple;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 67:
                    numero = 21;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_blue;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 68:
                    numero = 22;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.dark_green1;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 69:
                    numero = 23;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.red;
                    sd = listaAudio[numero];//audio
                    txtPt.Text = listaPortugues[numero];//legenda 
                    txtEn.Text = listaIngles[numero];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    this.Close();
                    break;



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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
