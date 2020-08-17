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
    public partial class MenuAulaM1 : Form
    {
        public MenuAulaM1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void btOuvir_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible=false;
            axWindowsMediaPlayer1.URL = "video/M1A1V1.mp4";
            Aula1M1 nova = new Aula1M1();
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
            axWindowsMediaPlayer1.URL = "video/M1A2V2.mp4";
            Aula03 nova = new Aula03();
            nova.Show();

            this.Hide();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M1A3V3.mp4";
            Aula3M1 nova = new Aula3M1();
            nova.Show();

            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M1A4V4.mp4";
            Aula4M1 nova = new Aula4M1();
            nova.Show();

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M1A5V5.mp4";
            Aula5M1 nova = new Aula5M1();
            nova.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M1A6V6.mp4";
            Aula6M1 nova = new Aula6M1();
            nova.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M1A7V7.mp4";
            Aula7M1 nova = new Aula7M1();
            nova.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M1A8V8.mp4";
            Aula8M1 nova = new Aula8M1();
            nova.Show();

            this.Hide();
        }
    }
}
