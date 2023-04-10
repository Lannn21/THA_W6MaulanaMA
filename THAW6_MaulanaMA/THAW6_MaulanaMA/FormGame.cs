using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THAW6_MaulanaMA
{
    public partial class FormGame : Form
    {
        
        public FormGame()
        {
            InitializeComponent();
        }
        public static int text = 0; 
        static int aa = 0;
        static string isi = "";
        static string[] kata = File.ReadAllText("Wordle_Word _List.txt").Split(',');
        static Random random = new Random();
        static int rndm = random.Next(14000);
        static string kata2 = kata[rndm];
        static string kata3 = kata2.ToUpper();
        List<string> keyboard = new List<string>() { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Enter", "Z", "X", "C", "V", "B", "N", "M", "Delete" };
        List<Button> btnn1 = new List<Button>();
        List<Button> btnn2 = new List<Button>();
        List<string> cekcolor = new List<string>();
        public static int kondisi = 0;
        string katanya = "";
        int cnt = 0;
        int color = 0;
        int pencet = 0;
        int grading = 0;
        private void FormGame_Load(object sender, EventArgs e)
        {
            katanya = kata[random.Next(0,kata.Length)];
            int x = 10;
            int y = 10;
            int keyx = 240;
            int keyy = 50;
            label1.Text = kata3;
            for (int i = 0; i < text; i++)
            {
                for (int m = 0; m < 5 ; m++)
                {
                    Button btn1 = new Button();
                    btn1.Size = new System.Drawing.Size(40, 40);
                    btn1.Location = new Point(x, y);
                    x += 40;
                    btn1.Click += Buttonclick;
                    btnn1.Add(btn1);
                    Controls.Add(btn1);
                }
                x = 10;
                y += 40;
            }
            cnt = 0;
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    keyx = 240;
                    keyy = 50;
                    
                    for (int m = 0; m < 10; m++)
                    {
                        Button btn2 = new Button();
                        btn2.Size = new System.Drawing.Size(35, 35);
                        btn2.Location = new Point(keyx, keyy);
                        btn2.Tag = keyboard[cnt].ToString();
                        btn2.Text = keyboard[cnt].ToString();
                        keyx += 35;
                        cnt++;
                        btn2.Click += Buttonclick;
                        btnn2.Add(btn2);
                        Controls.Add(btn2);
                    }
                }
                else
                {
                    keyx = 260;
                    keyy += 35;
                    for (int m = 0; m < 9; m++)
                    {
                        Button btn3 = new Button();
                        btn3.Size = new System.Drawing.Size(35, 35);
                        btn3.Location = new Point(keyx, keyy);
                        btn3.Tag = keyboard[cnt].ToString();
                        btn3.Text = keyboard[cnt].ToString();
                        if (keyboard[cnt].ToString() == "Enter")
                        {
                            btn3.Location = new Point(keyx - 35, keyy);
                            btn3.Size = new Size(70, 30);
                            btn3.Click += Buttonenter;
                        }
                        else if (keyboard[cnt].ToString() == "Delete")
                        {
                            btn3.Location = new Point(keyx, keyy);
                            btn3.Size = new Size(70, 30);
                            btn3.Click += Buttondelete;
                        }
                        else
                        {
                            btn3.Click += Buttonclick;
                        }
                        keyx += 35;
                        cnt++;
                        btnn2.Add(btn3);
                        Controls.Add(btn3);
                    }
                }
            }
        }

        private void Buttonclick (object sender, EventArgs e)
        {
            Button klik = sender as Button;
            if (pencet < 5)
            {
                btnn1[aa].Text = klik.Tag.ToString();
                pencet++;
                aa++;
            }
        }
        
        public void Cekgrading()
        {
            if(grading == 5) 
            {
                MessageBox.Show("Kamu menang");
                this.Close();
            }
            if(pencet == kondisi * 5 && grading != 5) 
            {
                MessageBox.Show("Kamu kalah, coba lagi");
                this.Close();
            }
        }
        private void Buttonenter(object sender, EventArgs e)
        {
            isi = "";
            if (pencet < 5)
            {
                MessageBox.Show("Masukkan huruf sesuai jumlah kolom");
            }
            else
            {
                isi = btnn1[aa - 5].Text.ToLower() + btnn1[aa - 4].Text.ToLower() + btnn1[aa - 3].Text.ToLower() + btnn1[aa - 2].Text.ToLower() + btnn1[aa - 1].Text.ToLower();
                if (kata.Contains(isi))
                {
                    string isi2 = isi.ToUpper();
                    for (int i = 0; i < isi.Length; i--)
                    {
                        if (isi[i] == isi2[i])
                        {
                            btnn1[(aa - 1) - (4-i)].BackColor = Color.Green;
                        }
                    }
                    if (pencet == 5)
                    {
                        pencet = 0;
                    }
                }
                else
                {
                    MessageBox.Show(isi.ToUpper() + "tidak ada di kata");
                }
            }
            
        }
        private void Buttondelete(object sender, EventArgs e)
        {
            if(pencet > 0)
            {
                btnn1[aa - 1].Text = "";
                pencet--;
                aa--;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
