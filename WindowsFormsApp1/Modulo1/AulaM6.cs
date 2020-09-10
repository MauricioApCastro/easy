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
    public partial class Aula6M1 : Form
    {
        //variáveis
        string frase = "teste";
        string legenda;
        string sd;//variável do áudio
        int contadorGeral, contadorCasos = 0, n, numeroVezes,num;
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






        public Aula6M1()
        {
            InitializeComponent();

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


        }
        private void btProximo_Click(object sender, EventArgs e)//casos

        {

            timerOuvir.Start();
            contadorGeral++;//cada vez que clica adiciona 1           
            var x = contadorGeral;
            var result = Convert.ToString(x);
            btOuvir.Enabled = true;
            btFalar.Enabled = true;
            btEscrever.Enabled = true;
            lbPagina.Text = result;
            timerOuvir.Enabled = true;
            lbPagina.Visible = true;
            lblGravando.Text = "";
            btFalar.Text = "Falar";
            btEscrever.Text = "Escrever";
            
            switch (contadorCasos)
                
            {
                case 0:
                    num = 0;

                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.ClientSize = new Size(510, 382);//tela inteira
                    pictureBox1.Image = Properties.Resources.apple; 
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 1:
                    num = 1;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.strswberry;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 2:
                    num = 2;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.banana;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;



                case 3:
                    num = 3;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.grape;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;



                case 4:
                    num = 4;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    
                    pictureBox1.Image = Properties.Resources.mango;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 5:
                    num = 5;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                   
                    pictureBox1.Image = Properties.Resources.orange;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;




                case 6:
                    num = 6;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.limon;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 7:
                    num = 7;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.pineapple;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;



                case 8:
                    num = 8;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.she_eats_strawberry;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 9:
                    num = 9;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.limon;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 10:
                    num = 10;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.he_eats_mango;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;



                case 11:
                    num = 11;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.pineapple;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 12:
                    num = 12;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.grape;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 13:
                    num = 13;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.she_eats_apple;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 14:
                    num = 14;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.he_eats_banana;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                
               case 15:
                    num = 15;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.ClientSize = new Size(255, 382);
                    pictureBox1.Image = Properties.Resources.she_eats_strawberry;
                    pictureBox2.Image = Properties.Resources.he_eats_banana;                  
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

               

                case 16:
                    num = 16;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox1.ClientSize = new Size(255, 382);
                    pictureBox1.Image = Properties.Resources.he_eats_grape;
                    pictureBox2.Image = Properties.Resources.she_eats_apple;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                





            }
            int quantidadeCasos = 16;
                    if (numeroVezes < 3)
                    {
                        if (contadorCasos <= quantidadeCasos - 1)
                        {
                            contadorCasos++;
                        }
                        else
                        {
                            contadorCasos = 0;
                            numeroVezes++;
                        }
                    }
                    else
                    {
                        this.Close();
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
                btFalar.Text = "Correto";
                btFalar.Font = new Font("Comic Sans MS", 48, (FontStyle.Bold & FontStyle.Italic), GraphicsUnit.Point);
            }
            if ((lbAudio.Text) != (txtEn.Text) && (lblGravando.Text.Equals("gravando")))
            {
                btFalar.Text = "REPETIR";

            }


        }

        private void btOuvir_Click(object sender, EventArgs e)
        {

            btOuvir.Font = new Font("Comic Sans MS", 48, (FontStyle.Bold & FontStyle.Italic), GraphicsUnit.Point);
            timerOuvir.Stop();
            timerFalar.Start();
            btFalar.Enabled = true;
            btFalar.Text = "Falar";

            {//audio
                System.Media.SoundPlayer Tocar = new System.Media.SoundPlayer();//ativa o áudio
                Tocar.SoundLocation = sd;
                Tocar.Load();
                Tocar.Play();

            }
        }

        private void timerFalar_Tick(object sender, EventArgs e)
        {
            n = n == 58 ? 48 : 58;
            btFalar.Font = new Font("Comic Sans MS", n, FontStyle.Bold & FontStyle.Italic, GraphicsUnit.Point);
        }

        private void timerEscrever_Tick(object sender, EventArgs e)
        {
            n = n == 58 ? 48 : 58;
            btEscrever.Font = new Font("Comic Sans MS", n, FontStyle.Bold & FontStyle.Italic, GraphicsUnit.Point);
        }

        private void timerOuvir_Tick(object sender, EventArgs e)
        {
            n = n == 58 ? 48 : 58;
            btOuvir.Font = new Font("Comic Sans MS", n, (FontStyle.Bold & FontStyle.Italic), GraphicsUnit.Point);
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


                btEscrever.Text = "Correto";

                timerEscrever.Stop();
                btProximo.Enabled = true;

            }
            else
            {
                btEscrever.Text = "Corrigir";
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
            btFalar.Text = "Falar";
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
                c = 0;
                btFalar.Text = "Correto";
                btFalar.Font = new Font("Comic Sans MS", 48, (FontStyle.Bold & FontStyle.Italic), GraphicsUnit.Point);

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblGravando_Click(object sender, EventArgs e)
        {

        }
    }
}
