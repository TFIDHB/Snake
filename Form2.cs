using System;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form2 : Form
    {
        private Form1 Form_1 = new Form1();
        private int _width = 720;
        private int _height = 390;
        public Form2()
        {
            Width = _width; 
            Height = _height;
            InitializeComponent();
            drawMap();
            Title();
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.Black;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.BorderColor = Color.Black;

        }

        public void drawMap()
        {
            for (int i = 0; i < _height/10; i++) {
                PictureBox line = new PictureBox();
                line.BackColor = Color.DarkOliveGreen;
                line.Size = new Size(1, _height);
                line.Location = new Point(20*i, 0);
                Controls.Add(line);
            }

            for (int i = 0; i < _width/40; i++)
            {
                PictureBox line = new PictureBox();
                line.BackColor = Color.DarkOliveGreen;
                line.Size = new Size(_width, 1);
                line.Location = new Point(0, i*20);
                Controls.Add(line);
            }

        }
        public void Title()
        {
            int count = 0;
            for (int i = 0; i < _width / 20; i++)
            {
                PictureBox Up_pic = new PictureBox();
                Up_pic.Size = new Size(20, 20);
                Up_pic.BackColor = Color.Black;
                Up_pic.Location = new Point(i * 20, 0);
                Controls.Add(Up_pic);
                
                PictureBox Bot_pic = new PictureBox();
                Bot_pic.Size = new Size(20, 20);
                Bot_pic.BackColor = Color.Black;
                Bot_pic.Location = new Point(i * 20, 100);
                Controls.Add(Bot_pic);
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form_1.Show();
            Form_1.timerStart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form_1.Close();
        }
    }
}
