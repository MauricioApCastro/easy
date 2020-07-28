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
    public partial class Aula6 : Form
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
     "audio//Apple.wav",
"audio//Strawberry.wav",
"audio//banana.wav",
"audio//grape.wav",
"audio//mango.wav",
"audio//orange.wav",
"audio//lemon.wav",
"audio//pineapple.wav",
"audio//She eats strawberry.wav",
"audio//He eats lemon.wav",
"audio//He eats mango.wav",
"audio//He eats pineapple.wav",
"audio//He eats grape.wav",
"audio//She eats apple.wav",
"audio//He eats banana.wav",
"audio//She eats strawberry and he eats banana.wav",
"audio//He eats grape and she eats apple.wav",
        };
        public String[] listaIngles =
        {
            "Apple",
"Strawberry",
"banana",
"grape",
"mango",
"orange",
"lemon",
"pineapple",
"She eats strawberry",
"He eats lemon",
"He eats mango",
"He eats pineapple",
"He eats grape",
"She eats apple",
"He eats banana",
"She eats strawberry and he eats banana",
"He eats grape and she eats apple",

        };
        public String[] listaPortugues =
{"maçã",
"morango",
"banana",
"uva",
"manga",
"laranja",
"limão",
"abacaxi",
"Ela come morango",
"Ele come limão",
"Ele come manga",
"Ele come abacaxi",
"Ele come uva",
"Ela come maça",
"Ele come banana",
"Ela come morango e ele come banana",
"Ele come uva e ela come maçã",


        };



        public Aula6()
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

            pictureBox1.Image = Properties.Resources.apple1;
            sd = listaAudio[0];//audio
            txtPt.Text = listaPortugues[0];//legenda 
            txtEn.Text = listaIngles[0];//legenda inglês
            lbProfessor.Text = "";
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
            lbProfessor.Text = "";
            var result = Convert.ToString(x);
            lbPagina.Text = result;
            timerOuvir.Enabled = true;
            lblGravando.Text = "";
            btFalar.Text = "FALAR";
            btEscrever.Text = "ESCREVER";

            switch (silvinha)

            {

                case 1:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                   btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.strswberry;
                    sd = listaAudio[1];//audio
                    txtPt.Text = listaPortugues[1];//legenda 
                    txtEn.Text = listaIngles[1];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 2:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                   btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.banana;
                    sd = listaAudio[2];//audio
                    txtPt.Text = listaPortugues[2];//legenda 
                    txtEn.Text = listaIngles[2];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;




                case 3:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                   btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.grape;
                    sd = listaAudio[3];//audio
                    txtPt.Text = listaPortugues[3];//legenda 
                    txtEn.Text = listaIngles[3];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 4:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.mango;
                    sd = listaAudio[4];//audio
                    txtPt.Text = listaPortugues[4];//legenda 
                    txtEn.Text = listaIngles[4];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 5:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                  btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.orange;
                    sd = listaAudio[5];//audio
                    txtPt.Text = listaPortugues[5];//legenda 
                    txtEn.Text = listaIngles[5];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 6:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.limon;
                    sd = listaAudio[6];//audio
                    txtPt.Text = listaPortugues[6];//legenda 
                    txtEn.Text = listaIngles[6];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 7:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                   btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.pineapple;
                    sd = listaAudio[7];//audio
                    txtPt.Text = listaPortugues[7];//legenda 
                    txtEn.Text = listaIngles[7];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 8:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.she_eats_strawberry;
                    sd = listaAudio[8];//audio
                    txtPt.Text = listaPortugues[8];//legenda 
                    txtEn.Text = listaIngles[8];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;



                case 9:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                   btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.limon;
                    sd = listaAudio[9];//audio
                    txtPt.Text = listaPortugues[9];//legenda 
                    txtEn.Text = listaIngles[9];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 10:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.he_eats_mango;
                    sd = listaAudio[10];//audio
                    txtPt.Text = listaPortugues[10];//legenda 
                    txtEn.Text = listaIngles[10];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 11:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.she_eats_pineapple;
                    sd = listaAudio[11];//audio
                    txtPt.Text = listaPortugues[11];//legenda 
                    txtEn.Text = listaIngles[11];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 12:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.he_eats_grape;
                    sd = listaAudio[12];//audio
                    txtPt.Text = listaPortugues[12];//legenda 
                    txtEn.Text = listaIngles[12];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 13:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.she_eats_apple;
                    sd = listaAudio[13];//audio
                    txtPt.Text = listaPortugues[13];//legenda 
                    txtEn.Text = listaIngles[13];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 14:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.he_eats_banana;
                    sd = listaAudio[14];//audio
                    txtPt.Text = listaPortugues[14];//legenda 
                    txtEn.Text = listaIngles[14];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 15:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                   btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(408, 275);//metade da tela
                    pictureBox1.Image = Properties.Resources.she_eats_strawberry;
                    pictureBox2.Image = Properties.Resources.he_eats_banana;
                    sd = listaAudio[15];//audio
                    txtPt.Text = listaPortugues[15];//legenda 
                    txtEn.Text = listaIngles[15];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 16:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(408, 275);//metade da tela
                    pictureBox1.Image = Properties.Resources.he_eats_grape;
                    pictureBox2.Image = Properties.Resources.she_eats_apple;
                    sd = listaAudio[16];//audio
                    txtPt.Text = listaPortugues[16];//legenda 
                    txtEn.Text = listaIngles[16];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 17:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.ClientSize = new Size(816, 550);//tela inteira
                    pictureBox1.Image = Properties.Resources.apple1;
                    sd = listaAudio[0];//audio
                    txtPt.Text = listaPortugues[0];//legenda 
                    txtEn.Text = listaIngles[0];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 18:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.strswberry;
                    sd = listaAudio[1];//audio
                    txtPt.Text = listaPortugues[1];//legenda 
                    txtEn.Text = listaIngles[1];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 19:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.banana;
                    sd = listaAudio[2];//audio
                    txtPt.Text = listaPortugues[2];//legenda 
                    txtEn.Text = listaIngles[2];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;




                case 20:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                  btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.grape;
                    sd = listaAudio[3];//audio
                    txtPt.Text = listaPortugues[3];//legenda 
                    txtEn.Text = listaIngles[3];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 21:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.mango;
                    sd = listaAudio[4];//audio
                    txtPt.Text = listaPortugues[4];//legenda 
                    txtEn.Text = listaIngles[4];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 22:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                   btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.orange;
                    sd = listaAudio[5];//audio
                    txtPt.Text = listaPortugues[5];//legenda 
                    txtEn.Text = listaIngles[5];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 23:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.limon;
                    sd = listaAudio[6];//audio
                    txtPt.Text = listaPortugues[6];//legenda 
                    txtEn.Text = listaIngles[6];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 24:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.pineapple;
                    sd = listaAudio[7];//audio
                    txtPt.Text = listaPortugues[7];//legenda 
                    txtEn.Text = listaIngles[7];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 25:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.she_eats_strawberry;
                    sd = listaAudio[8];//audio
                    txtPt.Text = listaPortugues[8];//legenda 
                    txtEn.Text = listaIngles[8];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;



                case 26:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.limon;
                    sd = listaAudio[9];//audio
                    txtPt.Text = listaPortugues[9];//legenda 
                    txtEn.Text = listaIngles[9];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 27:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.he_eats_mango;
                    sd = listaAudio[10];//audio
                    txtPt.Text = listaPortugues[10];//legenda 
                    txtEn.Text = listaIngles[10];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 28:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.she_eats_pineapple;
                    sd = listaAudio[11];//audio
                    txtPt.Text = listaPortugues[11];//legenda 
                    txtEn.Text = listaIngles[11];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 29:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.he_eats_grape;
                    sd = listaAudio[12];//audio
                    txtPt.Text = listaPortugues[12];//legenda 
                    txtEn.Text = listaIngles[12];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 30:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.she_eats_apple;
                    sd = listaAudio[13];//audio
                    txtPt.Text = listaPortugues[13];//legenda 
                    txtEn.Text = listaIngles[13];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 31:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.he_eats_banana;
                    sd = listaAudio[14];//audio
                    txtPt.Text = listaPortugues[14];//legenda 
                    txtEn.Text = listaIngles[14];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 32:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(408, 275);//metade da tela
                    pictureBox1.Image = Properties.Resources.she_eats_strawberry;
                    pictureBox2.Image = Properties.Resources.he_eats_banana;
                    sd = listaAudio[15];//audio
                    txtPt.Text = listaPortugues[15];//legenda 
                    txtEn.Text = listaIngles[15];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 33:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(408, 275);//metade da tela
                    pictureBox1.Image = Properties.Resources.he_eats_grape;
                    pictureBox2.Image = Properties.Resources.she_eats_apple;
                    sd = listaAudio[16];//audio
                    txtPt.Text = listaPortugues[16];//legenda 
                    txtEn.Text = listaIngles[16];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 34:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.ClientSize = new Size(816, 550);//tela inteira
                    pictureBox1.Image = Properties.Resources.apple1;
                    sd = listaAudio[0];//audio
                    txtPt.Text = listaPortugues[0];//legenda 
                    txtEn.Text = listaIngles[0];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 35:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.strswberry;
                    sd = listaAudio[1];//audio
                    txtPt.Text = listaPortugues[1];//legenda 
                    txtEn.Text = listaIngles[1];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 36:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.banana;
                    sd = listaAudio[2];//audio
                    txtPt.Text = listaPortugues[2];//legenda 
                    txtEn.Text = listaIngles[2];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;




                case 37:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.grape;
                    sd = listaAudio[3];//audio
                    txtPt.Text = listaPortugues[3];//legenda 
                    txtEn.Text = listaIngles[3];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 38:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.mango;
                    sd = listaAudio[4];//audio
                    txtPt.Text = listaPortugues[4];//legenda 
                    txtEn.Text = listaIngles[4];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 39:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.orange;
                    sd = listaAudio[5];//audio
                    txtPt.Text = listaPortugues[5];//legenda 
                    txtEn.Text = listaIngles[5];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 40:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.limon;
                    sd = listaAudio[6];//audio
                    txtPt.Text = listaPortugues[6];//legenda 
                    txtEn.Text = listaIngles[6];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 41:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.pineapple;
                    sd = listaAudio[7];//audio
                    txtPt.Text = listaPortugues[7];//legenda 
                    txtEn.Text = listaIngles[7];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 42:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.she_eats_strawberry;
                    sd = listaAudio[8];//audio
                    txtPt.Text = listaPortugues[8];//legenda 
                    txtEn.Text = listaIngles[8];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;



                case 43:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.limon;
                    sd = listaAudio[9];//audio
                    txtPt.Text = listaPortugues[9];//legenda 
                    txtEn.Text = listaIngles[9];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 44:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.he_eats_mango;
                    sd = listaAudio[10];//audio
                    txtPt.Text = listaPortugues[10];//legenda 
                    txtEn.Text = listaIngles[10];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 45:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.she_eats_pineapple;
                    sd = listaAudio[11];//audio
                    txtPt.Text = listaPortugues[11];//legenda 
                    txtEn.Text = listaIngles[11];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 46:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.he_eats_grape;
                    sd = listaAudio[12];//audio
                    txtPt.Text = listaPortugues[12];//legenda 
                    txtEn.Text = listaIngles[12];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 47:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.she_eats_apple;
                    sd = listaAudio[13];//audio
                    txtPt.Text = listaPortugues[13];//legenda 
                    txtEn.Text = listaIngles[13];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 48:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.he_eats_banana;
                    sd = listaAudio[14];//audio
                    txtPt.Text = listaPortugues[14];//legenda 
                    txtEn.Text = listaIngles[14];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 49:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(408, 275);//metade da tela
                    pictureBox1.Image = Properties.Resources.she_eats_strawberry;
                    pictureBox2.Image = Properties.Resources.he_eats_banana;
                    sd = listaAudio[15];//audio
                    txtPt.Text = listaPortugues[15];//legenda 
                    txtEn.Text = listaIngles[15];//legenda inglês
                    lbProfessor.Text = "";
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 50:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(408, 275);//metade da tela
                    pictureBox1.Image = Properties.Resources.he_eats_grape;
                    pictureBox2.Image = Properties.Resources.she_eats_apple;
                    sd = listaAudio[16];//audio
                    txtPt.Text = listaPortugues[16];//legenda 
                    txtEn.Text = listaIngles[16];//legenda inglês
                    lbProfessor.Text = "";
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
            lbProfessor.Text = "";
            frase = e.Result.Text;
            legenda = txtEn.Text;
            lbAudio.Text = frase;




            if ((lbAudio.Text) == (txtEn.Text) && (lblGravando.Text.Equals("gravando")))
            {

                lbProfessor.Visible = true;
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


            lbProfessor.Text = "";
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
            lbProfessor.ForeColor = lbProfessor.ForeColor == Color.Red ? Color.White : Color.Red;
        }

        private void btFalar_Click(object sender, EventArgs e)
        {



            if (lbAudio.Text.Equals(txtEn.Text))
            {

                lbProfessor.Visible = true;
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

                    lbProfessor.Visible = true;
                    textBoxAluno.Enabled = true;
                    timerFalar.Stop();
                    timerEscrever.Start();
                    timerOuvir.Stop();
                    textBoxAluno.Visible = true;
                    textBoxAluno.Select();
                    btEscrever.Enabled = true;
                    TimerMensagem.Stop();
                    btFalar.BackColor = Color.Aqua;
                    lbProfessor.Enabled = false;
                    c = 0;
                }
                else
                {
                    lbProfessor.Text = "Fale novamente!!!";
                }






            }










        }

        private void btEscrever_Click(object sender, EventArgs e)
        {

            if (txtEn.Text.Equals(textBoxAluno.Text.TrimEnd()))
            {

                lbProfessor.ForeColor = Color.Green;
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
                lbProfessor.ForeColor = Color.Red;
                btEscrever.Text = "REPETIR";

                btProximo.Enabled = false;

            }
        }

        private void lbProfessor_Click(object sender, EventArgs e)
        {

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
                lbProfessor.Visible = true;
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
