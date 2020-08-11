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
    public partial class Aula5 : Form
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



        public Aula5()
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

            pictureBox1.Image = Properties.Resources.pie;
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

                case 1:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                   btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.hot_dog;
                    sd = listaAudio[1];//audio
                    txtPt.Text = listaPortugues[1];//legenda 
                    txtEn.Text = listaIngles[1];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.hambuger;
                    sd = listaAudio[2];//audio
                    txtPt.Text = listaPortugues[2];//legenda 
                    txtEn.Text = listaIngles[2];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.corn_flakes;
                    sd = listaAudio[3];//audio
                    txtPt.Text = listaPortugues[3];//legenda 
                    txtEn.Text = listaIngles[3];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.cake;
                    sd = listaAudio[4];//audio
                    txtPt.Text = listaPortugues[4];//legenda 
                    txtEn.Text = listaIngles[4];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.ice_cream;
                    sd = listaAudio[5];//audio
                    txtPt.Text = listaPortugues[5];//legenda 
                    txtEn.Text = listaIngles[5];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.snacks;
                    sd = listaAudio[6];//audio
                    txtPt.Text = listaPortugues[6];//legenda 
                    txtEn.Text = listaIngles[6];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.french_fries;
                    sd = listaAudio[7];//audio
                    txtPt.Text = listaPortugues[7];//legenda 
                    txtEn.Text = listaIngles[7];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_pie;
                    pictureBox2.Image = Properties.Resources.i_eat_hot_dog;
                    sd = listaAudio[8];//audio
                    txtPt.Text = listaPortugues[8];//legenda 
                    txtEn.Text = listaIngles[8];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.ice_cream;
                    pictureBox2.Image = Properties.Resources.cake;
                    sd = listaAudio[9];//audio
                    txtPt.Text = listaPortugues[9];//legenda 
                    txtEn.Text = listaIngles[9];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.snacks;
                    pictureBox2.Image = Properties.Resources.i_eat_french_fries;
                    sd = listaAudio[10];//audio
                    txtPt.Text = listaPortugues[10];//legenda 
                    txtEn.Text = listaIngles[10];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.corn_flakes;
                    pictureBox2.Image = Properties.Resources.i_eat_bread;
                    sd = listaAudio[11];//audio
                    txtPt.Text = listaPortugues[11];//legenda 
                    txtEn.Text = listaIngles[11];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_cake;
                    pictureBox2.Image = Properties.Resources.hambuger;
                    sd = listaAudio[12];//audio
                    txtPt.Text = listaPortugues[12];//legenda 
                    txtEn.Text = listaIngles[12];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.salad;
                    pictureBox2.Image = Properties.Resources.i_eat_egg;
                    sd = listaAudio[13];//audio
                    txtPt.Text = listaPortugues[13];//legenda 
                    txtEn.Text = listaIngles[13];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_barbecue;
                    pictureBox2.Image = Properties.Resources.i_eat_fish;
                    sd = listaAudio[14];//audio
                    txtPt.Text = listaPortugues[14];//legenda 
                    txtEn.Text = listaIngles[14];//legenda inglês
                 
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
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.rice;
                    pictureBox2.Image = Properties.Resources.i_eat_beam;
                    sd = listaAudio[15];//audio
                    txtPt.Text = listaPortugues[15];//legenda 
                    txtEn.Text = listaIngles[15];//legenda inglês
                 
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
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_pancake;
                    pictureBox2.Image = Properties.Resources.I_drink_milk;
                    sd = listaAudio[16];//audio
                    txtPt.Text = listaPortugues[16];//legenda 
                    txtEn.Text = listaIngles[16];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.I_drink_coffee;
                    pictureBox2.Image = Properties.Resources.i_eat_bacon;
                    sd = listaAudio[17];//audio
                    txtPt.Text = listaPortugues[17];//legenda 
                    txtEn.Text = listaIngles[17];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_chicken;
                    pictureBox2.Image = Properties.Resources.i_eat_sausage;
                    sd = listaAudio[18];//audio
                    txtPt.Text = listaPortugues[18];//legenda 
                    txtEn.Text = listaIngles[18];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.coconut_water;
                    pictureBox2.Image = Properties.Resources.I_drink_tea;
                    sd = listaAudio[19];//audio
                    txtPt.Text = listaPortugues[19];//legenda 
                    txtEn.Text = listaIngles[19];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.ACHOCOLATADO;
                    pictureBox2.Image = Properties.Resources.i_eat_cake;
                    sd = listaAudio[20];//audio
                    txtPt.Text = listaPortugues[20];//legenda 
                    txtEn.Text = listaIngles[20];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.salad;
                    pictureBox2.Image = Properties.Resources.she_drinks_lemonade;
                    sd = listaAudio[21];//audio
                    txtPt.Text = listaPortugues[21];//legenda 
                    txtEn.Text = listaIngles[21];//legenda inglês
                 
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
 pictureBox1.ClientSize = new Size(564,390) ;//tela inteira
                    pictureBox1.Image = Properties.Resources.hot_dog;
                    sd = listaAudio[1];//audio
                    txtPt.Text = listaPortugues[1];//legenda 
                    txtEn.Text = listaIngles[1];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.hot_dog;
                    sd = listaAudio[1];//audio
                    txtPt.Text = listaPortugues[1];//legenda 
                    txtEn.Text = listaIngles[1];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.hambuger;
                    sd = listaAudio[2];//audio
                    txtPt.Text = listaPortugues[2];//legenda 
                    txtEn.Text = listaIngles[2];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.corn_flakes;
                    sd = listaAudio[3];//audio
                    txtPt.Text = listaPortugues[3];//legenda 
                    txtEn.Text = listaIngles[3];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.cake;
                    sd = listaAudio[4];//audio
                    txtPt.Text = listaPortugues[4];//legenda 
                    txtEn.Text = listaIngles[4];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.ice_cream;
                    sd = listaAudio[5];//audio
                    txtPt.Text = listaPortugues[5];//legenda 
                    txtEn.Text = listaIngles[5];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.snacks;
                    sd = listaAudio[6];//audio
                    txtPt.Text = listaPortugues[6];//legenda 
                    txtEn.Text = listaIngles[6];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.french_fries;
                    sd = listaAudio[7];//audio
                    txtPt.Text = listaPortugues[7];//legenda 
                    txtEn.Text = listaIngles[7];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_pie;
                    pictureBox2.Image = Properties.Resources.i_eat_hot_dog;
                    sd = listaAudio[8];//audio
                    txtPt.Text = listaPortugues[8];//legenda 
                    txtEn.Text = listaIngles[8];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.ice_cream;
                    pictureBox2.Image = Properties.Resources.cake;
                    sd = listaAudio[9];//audio
                    txtPt.Text = listaPortugues[9];//legenda 
                    txtEn.Text = listaIngles[9];//legenda inglês
                 
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
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.snacks;
                    pictureBox2.Image = Properties.Resources.i_eat_french_fries;
                    sd = listaAudio[10];//audio
                    txtPt.Text = listaPortugues[10];//legenda 
                    txtEn.Text = listaIngles[10];//legenda inglês
                 
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
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.corn_flakes;
                    pictureBox2.Image = Properties.Resources.i_eat_bread;
                    sd = listaAudio[11];//audio
                    txtPt.Text = listaPortugues[11];//legenda 
                    txtEn.Text = listaIngles[11];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_cake;
                    pictureBox2.Image = Properties.Resources.hambuger;
                    sd = listaAudio[12];//audio
                    txtPt.Text = listaPortugues[12];//legenda 
                    txtEn.Text = listaIngles[12];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.salad;
                    pictureBox2.Image = Properties.Resources.i_eat_egg;
                    sd = listaAudio[13];//audio
                    txtPt.Text = listaPortugues[13];//legenda 
                    txtEn.Text = listaIngles[13];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_barbecue;
                    pictureBox2.Image = Properties.Resources.i_eat_fish;
                    sd = listaAudio[14];//audio
                    txtPt.Text = listaPortugues[14];//legenda 
                    txtEn.Text = listaIngles[14];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.rice;
                    pictureBox2.Image = Properties.Resources.i_eat_beam;
                    sd = listaAudio[15];//audio
                    txtPt.Text = listaPortugues[15];//legenda 
                    txtEn.Text = listaIngles[15];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_pancake;
                    pictureBox2.Image = Properties.Resources.I_drink_milk;
                    sd = listaAudio[16];//audio
                    txtPt.Text = listaPortugues[16];//legenda 
                    txtEn.Text = listaIngles[16];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.I_drink_coffee;
                    pictureBox2.Image = Properties.Resources.i_eat_bacon;
                    sd = listaAudio[17];//audio
                    txtPt.Text = listaPortugues[17];//legenda 
                    txtEn.Text = listaIngles[17];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_chicken;
                    pictureBox2.Image = Properties.Resources.i_eat_sausage;
                    sd = listaAudio[18];//audio
                    txtPt.Text = listaPortugues[18];//legenda 
                    txtEn.Text = listaIngles[18];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.coconut_water;
                    pictureBox2.Image = Properties.Resources.I_drink_tea;
                    sd = listaAudio[19];//audio
                    txtPt.Text = listaPortugues[19];//legenda 
                    txtEn.Text = listaIngles[19];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.ACHOCOLATADO;
                    pictureBox2.Image = Properties.Resources.i_eat_cake;
                    sd = listaAudio[20];//audio
                    txtPt.Text = listaPortugues[20];//legenda 
                    txtEn.Text = listaIngles[20];//legenda inglês
                 
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
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.salad;
                    pictureBox2.Image = Properties.Resources.she_drinks_lemonade;
                    sd = listaAudio[21];//audio
                    txtPt.Text = listaPortugues[21];//legenda 
                    txtEn.Text = listaIngles[21];//legenda inglês
                 
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
 pictureBox1.ClientSize = new Size(564,390) ;//tela inteira
                    pictureBox1.Image = Properties.Resources.hot_dog;
                    sd = listaAudio[1];//audio
                    txtPt.Text = listaPortugues[1];//legenda 
                    txtEn.Text = listaIngles[1];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.hot_dog;
                    sd = listaAudio[1];//audio
                    txtPt.Text = listaPortugues[1];//legenda 
                    txtEn.Text = listaIngles[1];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.hambuger;
                    sd = listaAudio[2];//audio
                    txtPt.Text = listaPortugues[2];//legenda 
                    txtEn.Text = listaIngles[2];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.corn_flakes;
                    sd = listaAudio[3];//audio
                    txtPt.Text = listaPortugues[3];//legenda 
                    txtEn.Text = listaIngles[3];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.cake;
                    sd = listaAudio[4];//audio
                    txtPt.Text = listaPortugues[4];//legenda 
                    txtEn.Text = listaIngles[4];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.ice_cream;
                    sd = listaAudio[5];//audio
                    txtPt.Text = listaPortugues[5];//legenda 
                    txtEn.Text = listaIngles[5];//legenda inglês
                 
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
                    pictureBox1.Image = Properties.Resources.snacks;
                    sd = listaAudio[6];//audio
                    txtPt.Text = listaPortugues[6];//legenda 
                    txtEn.Text = listaIngles[6];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 51:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox1.Image = Properties.Resources.french_fries;
                    sd = listaAudio[7];//audio
                    txtPt.Text = listaPortugues[7];//legenda 
                    txtEn.Text = listaIngles[7];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 52:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_pie;
                    pictureBox2.Image = Properties.Resources.i_eat_hot_dog;
                    sd = listaAudio[8];//audio
                    txtPt.Text = listaPortugues[8];//legenda 
                    txtEn.Text = listaIngles[8];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 53:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.ice_cream;
                    pictureBox2.Image = Properties.Resources.cake;
                    sd = listaAudio[9];//audio
                    txtPt.Text = listaPortugues[9];//legenda 
                    txtEn.Text = listaIngles[9];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 54:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.snacks;
                    pictureBox2.Image = Properties.Resources.i_eat_french_fries;
                    sd = listaAudio[10];//audio
                    txtPt.Text = listaPortugues[10];//legenda 
                    txtEn.Text = listaIngles[10];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 55:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.corn_flakes;
                    pictureBox2.Image = Properties.Resources.i_eat_bread;
                    sd = listaAudio[11];//audio
                    txtPt.Text = listaPortugues[11];//legenda 
                    txtEn.Text = listaIngles[11];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 56:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_cake;
                    pictureBox2.Image = Properties.Resources.hambuger;
                    sd = listaAudio[12];//audio
                    txtPt.Text = listaPortugues[12];//legenda 
                    txtEn.Text = listaIngles[12];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 57:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.salad;
                    pictureBox2.Image = Properties.Resources.i_eat_egg;
                    sd = listaAudio[13];//audio
                    txtPt.Text = listaPortugues[13];//legenda 
                    txtEn.Text = listaIngles[13];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 58:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_barbecue;
                    pictureBox2.Image = Properties.Resources.i_eat_fish;
                    sd = listaAudio[14];//audio
                    txtPt.Text = listaPortugues[14];//legenda 
                    txtEn.Text = listaIngles[14];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;




                case 59:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.rice;
                    pictureBox2.Image = Properties.Resources.i_eat_beam;
                    sd = listaAudio[15];//audio
                    txtPt.Text = listaPortugues[15];//legenda 
                    txtEn.Text = listaIngles[15];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 60:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_pancake;
                    pictureBox2.Image = Properties.Resources.I_drink_milk;
                    sd = listaAudio[16];//audio
                    txtPt.Text = listaPortugues[16];//legenda 
                    txtEn.Text = listaIngles[16];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 61:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.I_drink_coffee;
                    pictureBox2.Image = Properties.Resources.i_eat_bacon;
                    sd = listaAudio[17];//audio
                    txtPt.Text = listaPortugues[17];//legenda 
                    txtEn.Text = listaIngles[17];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;

                case 62:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.i_eat_chicken;
                    pictureBox2.Image = Properties.Resources.i_eat_sausage;
                    sd = listaAudio[18];//audio
                    txtPt.Text = listaPortugues[18];//legenda 
                    txtEn.Text = listaIngles[18];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 63:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.coconut_water;
                    pictureBox2.Image = Properties.Resources.I_drink_tea;
                    sd = listaAudio[19];//audio
                    txtPt.Text = listaPortugues[19];//legenda 
                    txtEn.Text = listaIngles[19];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 64:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.ACHOCOLATADO;
                    pictureBox2.Image = Properties.Resources.i_eat_cake;
                    sd = listaAudio[20];//audio
                    txtPt.Text = listaPortugues[20];//legenda 
                    txtEn.Text = listaIngles[20];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;


                case 65:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
                    pictureBox2.Visible = true;
                     pictureBox1.ClientSize = new Size(282,390) ;
                    pictureBox1.Image = Properties.Resources.salad;
                    pictureBox2.Image = Properties.Resources.she_drinks_lemonade;
                    sd = listaAudio[21];//audio
                    txtPt.Text = listaPortugues[21];//legenda 
                    txtEn.Text = listaIngles[21];//legenda inglês
                 
                    timerFalar.Stop();
                    timerEscrever.Stop();
                    textBoxAluno.Focus();
                    break;
                case 66:
                    textBoxAluno.Text = "";
                    textBoxAluno.Visible = false;
                    btEscrever.Enabled = false;
                    btFalar.Enabled = false;
                    btProximo.Enabled = false;
 pictureBox1.ClientSize = new Size(564,390) ;//tela inteira
                    pictureBox1.Image = Properties.Resources.hot_dog;
                    sd = listaAudio[1];//audio
                    txtPt.Text = listaPortugues[1];//legenda 
                    txtEn.Text = listaIngles[1];//legenda inglês
                 
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
            lbProfessor.ForeColor = lbProfessor.ForeColor == Color.Red ? Color.White : Color.Red;
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
