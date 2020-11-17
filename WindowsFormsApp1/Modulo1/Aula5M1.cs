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
    public partial class Aula5M1 : Form
    {
        //variáveis
        string frase = "teste";
        string legenda;
        string sd;//variável do áudio
        int contadorGeral, contadorCasos = 0, n, numeroVezes, num;
        int i;
        int c;
        // variaveis para voz
        static CultureInfo ci = new CultureInfo("en-US");// linguagem utilizada
        static SpeechRecognitionEngine reconhecedor; // reconhecedor de voz
        SpeechSynthesizer resposta = new SpeechSynthesizer();// sintetizador de voz

        //Arrays
        public String[] listaAudio =
        {
          "audio//pie.wav",
"audio//hot dog.wav",
"audio//hanburguer.wav",
"audio//corn flakes.wav",
"audio//cake.wav",
"audio//ice cream.wav",
"audio//snack.wav",
"audio//french fries.wav",
"audio//I eat pie and you eat hot dog.wav",
"audio//You eat ice cream and I eat cake.wav",
"audio//I eat snacks and you eat french fries.wav",
"audio//I eat cornflakes and you eat bread.wav",
"audio//You eat cake and I eat hamburger.wav",
"audio//I eat salad and you eat egg.wav",
"audio//You eat barbecue and I eat fish.wav",
"audio//I eat rice and beans.wav",
"audio//I eat pancake and you milk.wav",
"audio//You drink coffee and I eat bacon.wav",
"audio//I eat chicken and you eat sausage.wav",
"audio//I drink coconut water and you drink tea.wav",
"audio//I drink chocolate and eat cake.wav",
"audio//I eat salad and drink lemonade.wav",
        };
        public String[] listaIngles =
        {
            "pie",
"hot dog",
"hamburger",
"corn flakes",
"cake",
"ice cream",
"snack",
"French fries",
"I eat pie and you eat hot dog",
"You eat ice cream and I eat cake",
"I eat snacks and you eat french fries",
"I eat cornflakes and you eat bread",
"You eat cake and I eat hamburger",
"I eat salad and you eat egg",
"You eat barbecue and I eat fish",
"I eat rice and beans",
"I eat pancake and you milk",
"You drink coffee and I eat bacon",
"I eat chicken and you eat sausage",
"I drink coconut water and you drink tea",
"I drink chocolate and eat cake",
"I eat salad and drink lemonade",

        };
        public String[] listaPortugues =
{
         "torta",
"cachorro quente",
"hamburguer",
"flocos de milho",
"bolo",
"sorvete",
"salgadinho",
"batatas fritas",
"Eu como torta e você come cachorro quente",
"Você toma sorvete e eu como bolo",
"Eu como salgadinho e você come batata frita",
"Eu como sucrilhos e você come pão",
"Você come bolo e eu como hamburguer",
"Eu como salada e você come ovo",
"Você come churrasco e eu como peixe",
"Eu como arroz e feijão",
"Eu como panqueca e você leite",
"Você bebe café e eu como bacon",
"Eu como frango e você come linguiça",
"Eu bebo água de coco e você bebe chá",
"Eu bebo achocolatado e como bolo",
"Eu como salada e bebo limonda",

        };







        public Aula5M1()
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
                    pictureBox1.Image = Properties.Resources.pie;
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
                    pictureBox1.Image = Properties.Resources.hot_dog;
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
                    pictureBox1.Image = Properties.Resources.hambuger;
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
                    pictureBox1.Image = Properties.Resources.corn_flakes;
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
                    pictureBox1.Image = Properties.Resources.cake;
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
                    pictureBox1.Image = Properties.Resources.ice_cream;
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
                    pictureBox1.Image = Properties.Resources.snacks;
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
                    pictureBox1.Image = Properties.Resources.french_fries;
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
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);//metade da tela
                    pictureBox1.Image = Properties.Resources.i_eat_pie;
                    pictureBox2.Image = Properties.Resources.i_eat_hot_dog;
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
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);//metade da tela
                    pictureBox1.Image = Properties.Resources.i_eat_ice_cream;
                    pictureBox2.Image = Properties.Resources.i_eat_cake;
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
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);//metade da tela
                    pictureBox1.Image = Properties.Resources.i_eats_snacks;
                    pictureBox2.Image = Properties.Resources.i_eat_french_fries;
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
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);//metade da tela
                    pictureBox1.Image = Properties.Resources.i_eat_corn_flakes;
                    pictureBox2.Image = Properties.Resources.i_eat_bread;
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
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);//metade da tela
                    pictureBox1.Image = Properties.Resources.i_eat_cake;
                    pictureBox2.Image = Properties.Resources.i_eat_hamburger;
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
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);//metade da tela
                    pictureBox1.Image = Properties.Resources.i_eat_salad;
                    pictureBox2.Image = Properties.Resources.i_eat_egg;
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
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);//metade da tela
                    pictureBox1.Image = Properties.Resources.i_eat_barbecue;
                    pictureBox2.Image = Properties.Resources.i_eat_fish;
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
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);
                    pictureBox1.Image = Properties.Resources.i_eats_rice;
                    pictureBox2.Image = Properties.Resources.i_eat_beam;
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
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);
                    pictureBox1.Image = Properties.Resources.i_eat_pancake;
                    pictureBox2.Image = Properties.Resources.I_drink_milk;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 17:
                    num = 17;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);
                    pictureBox1.Image = Properties.Resources.I_drink_coffee;
                    pictureBox2.Image = Properties.Resources.i_eat_bacon;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 18:
                    num = 18;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);
                    pictureBox1.Image = Properties.Resources.i_eat_chicken;
                    pictureBox2.Image = Properties.Resources.i_eat_sausage;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;



                case 19:
                    num = 19;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);
                    pictureBox1.Image = Properties.Resources.coconut_water;
                    pictureBox2.Image = Properties.Resources.I_drink_tea
                        ;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 20:
                    num = 20;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);
                    pictureBox1.Image = Properties.Resources.ACHOCOLATADO;
                    pictureBox2.Image = Properties.Resources.i_eat_cake;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 21:
                    num = 21;
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                     btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                    pictureBox1.ClientSize = new Size(255, 382);
                    pictureBox1.Image = Properties.Resources.salad;
                    pictureBox2.Image = Properties.Resources.LIMONADA;
                    sd = listaAudio[num];//audio
                    txtPt.Text = listaPortugues[num];//legenda 
                    txtEn.Text = listaIngles[num];//legenda inglês

                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;








            }
            int quantidadeCasos = 21;
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

                textBoxAluno.Visible = false;
                btOuvir.Enabled = false;
                btEscrever.Enabled = false;
                btFalar.Enabled = false;
                lbPagina.Enabled = false;
                //btProximo.Enabled = false;
                pictureBox1.ClientSize = new Size(510, 382);//tela inteira
                pictureBox1.Image = Properties.Resources.congratulation;
                txtPt.Text = "";//legenda 
                txtEn.Text = "Parabéns!!!. Agora faça os exercícios da apostila";//legenda inglês
                System.Media.SoundPlayer Tocar = new System.Media.SoundPlayer();//ativa o áudio
                sd = "audio//congratulations.wav";
                Tocar.SoundLocation = sd;
                Tocar.Load();
                Tocar.Play();
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
            btFalar.Text = "Falando";
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
