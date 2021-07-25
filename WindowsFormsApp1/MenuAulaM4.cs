using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MenuAulaM4 : Form
    {
        public MenuAulaM4()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void btOuvir_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible=false;
           // axWindowsMediaPlayer1.URL = "C:/Users/Mauricio/source/repos/Easy/WindowsFormsApp1/gifs/video.mp4";
            Aula1M2 nova = new Aula1M2();
            nova.Show();
           
            this.Hide();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void MenuAulas_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            //axWindowsMediaPlayer1.URL = "C:/Users/Mauricio/source/repos/Easy/WindowsFormsApp1/gifs/video.mp4";
            Aula2M2 nova = new Aula2M2();
            nova.Show();

            this.Hide();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            //axWindowsMediaPlayer1.URL = "C:/Users/Mauricio/source/repos/Easy/WindowsFormsApp1/gifs/video.mp4";
            Aula3M2 nova = new Aula3M2();
            nova.Show();

            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            //axWindowsMediaPlayer1.URL = "C:/Users/Mauricio/source/repos/Easy/WindowsFormsApp1/gifs/video.mp4";
            Aula4M2 nova = new Aula4M2();
            nova.Show();

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            //axWindowsMediaPlayer1.URL = "C:/Users/Mauricio/source/repos/Easy/WindowsFormsApp1/gifs/video.mp4";
            Aula5M2 nova = new Aula5M2();
            nova.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            //axWindowsMediaPlayer1.URL = "C:/Users/Mauricio/source/repos/Easy/WindowsFormsApp1/gifs/video.mp4";
            Aula6M1 nova = new Aula6M1();
            nova.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            //axWindowsMediaPlayer1.URL = "C:/Users/Mauricio/source/repos/Easy/WindowsFormsApp1/gifs/video.mp4";
          //  Aula7M1 nova = new Aula7M1();
            //nova.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            //axWindowsMediaPlayer1.URL = "C:/Users/Mauricio/source/repos/Easy/WindowsFormsApp1/gifs/video.mp4";
         //   Aula7M1 nova = new Aula7M1();
           // nova.Show();

            this.Hide();
        }

        private void btOuvir_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "";
            Aula1M4 nova = new Aula1M4();
            nova.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "";
            Aula2M4 nova = new Aula2M4();
            nova.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "";
            Aula3M4 nova = new Aula3M4();
            nova.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "";
            Aula4M4 nova = new Aula4M4();
            nova.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "";
            Aula5M4 nova = new Aula5M4();
            nova.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "";
            Aula6M4 nova = new Aula6M4();
            nova.Show();

            this.Hide();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "";
            Aula7M4 nova = new Aula7M4();
            nova.Show();

            this.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "";
            Aula8M4 nova = new Aula8M4();
            nova.Show();

            this.Hide();


        }
    }
}
