﻿using System;
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
    public partial class MenuAulaM2 : Form
    {
        public MenuAulaM2()
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
            axWindowsMediaPlayer1.URL = "video/M2A1V.mp4";
            Aula1M2 nova = new Aula1M2();
            nova.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M2A2V.mp4";
            Aula2M2 nova = new Aula2M2();
            nova.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M2A3V.mp4";
            Aula3M2 nova = new Aula3M2();
            nova.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M2A4V.mp4";
            Aula4M2 nova = new Aula4M2();
            nova.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M2A5V.mp4";
            Aula5M2 nova = new Aula5M2();
            nova.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M2A5V.mp4";
            Aula6M2 nova = new Aula6M2();
            nova.Show();
            this.Hide();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M2A7V.mp4";
            Aula7M2 nova = new Aula7M2();
            nova.Show();
            this.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal novo = new MenuPrincipal();
            novo.Visible = false;
            axWindowsMediaPlayer1.URL = "video/M2A8V.mp4";
            Aula8M2 nova = new Aula8M2();
            nova.Show();
            this.Hide();

        }
    }
}
