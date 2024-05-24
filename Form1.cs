using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private int rand_point_x, rand_point_y;
        private PictureBox point;
        
        private PictureBox[] snake = new PictureBox[200];
        private Label labelScore = new Label();
        private int _x;
        private int _y; 
        private int _width = 600;
        private int _height = 600;
        private int size = 20;
        private int score = 0;  
        public Form1()
        {
            _x = 1;
            _y = 0;
            Width = _width;
            Height = _height;
            point = new PictureBox();            
            point.BackColor = Color.Black;
            point.Size = new Size(size, size);
            snake[0] = new PictureBox();
            snake[0].Location = new Point(200,200);
            snake[0].Size = new Size(size, size);
            snake[0].BackColor = Color.Black;
            labelScore.Font = new Font(labelScore.Font, FontStyle.Bold);
            labelScore.Text = "Score: 0";
            labelScore.Location = new Point(0,0);
            Controls.Add(labelScore);
            Controls.Add(snake[0]);
            InitializeComponent();
            KeyDown += new KeyEventHandler(Movement);
            Map();
            genPoints();
            border();
            timer.Tick += new EventHandler(Update);
            timer.Interval = 200;
            
        }
        public void timerStart()
        {
            timer.Start();
        }
        public void border()
        {
            for (int i = 0; i < _width / size; i++)
            {
                PictureBox borderPartTop = new PictureBox();
                borderPartTop.Size = new Size(size, size);
                borderPartTop.BackColor = Color.Black;
                borderPartTop.Location = new Point(i * size, 40);
                Controls.Add(borderPartTop);

                PictureBox borderPartBottom = new PictureBox();
                borderPartBottom.Size = new Size(size, size);
                borderPartBottom.BackColor = Color.Black;
                borderPartBottom.Location = new Point(i * size, _width - size * 3);
                Controls.Add(borderPartBottom);
            }

            for (int i = 0; i < _height / size - 4; i++) {
                PictureBox borderPartLeft = new PictureBox();
                borderPartLeft.Size = new Size(size, size);
                borderPartLeft.BackColor = Color.Black;
                borderPartLeft.Location = new Point(0 ,i * size + 40);
                Controls.Add(borderPartLeft);

                PictureBox borderPartRight = new PictureBox();
                borderPartRight.Size = new Size(size, size);
                borderPartRight.BackColor = Color.Black;
                borderPartRight.Location = new Point(_width, i * size + 40);
                Controls.Add(borderPartRight);
            }
        }
        private void eatPoint()
        {
            if (snake[0].Location.X == rand_point_x && snake[0].Location.Y == rand_point_y) {
                labelScore.Text = "Score: " + ++score;
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + 20*_x, snake[score - 1].Location.Y - 20*_y);
                snake[score].Size = new Size(size, size);
                snake[score].BackColor = Color.Black;
                Controls.Add(snake[score]);
                genPoints();
            }
        }

        private void Crash()
        {
            for (int i = 1; i < score; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    timer.Stop();
                    DialogResult result = MessageBox.Show("Игра окончена!");
                    if (result == DialogResult.OK)
                    {
                        Form2 Form_2 = new Form2();
                        Form_2.Show();
                        Hide();
                    }
                }
            }                
            if (snake[0].Location.X < 0 || snake[0].Location.X >= _width ||
                       snake[0].Location.Y <= 40 || snake[0].Location.Y >= _width - size * 3)
                {
                    timer.Stop();
                DialogResult result = MessageBox.Show("Игра окончена!");
                if (result == DialogResult.OK)
                {
                    Form2 Form_2 = new Form2();
                    Form_2.Show();
                    Hide();
                }
            }
        }
        private void moveSnake()
        {
            for(int i = score; i >= 1; i--) {
                snake[i].Location = snake[i - 1].Location;
            }
            snake[0].Location = new Point(snake[0].Location.X + _x * size, snake[0].Location.Y + _y * size);
        }
        private void Update(Object myObject, EventArgs eventArgs)
        {
            Crash();
            eatPoint();
            moveSnake();
        }

        private void genPoints() 
        { 
            
            Random random = new Random();
            rand_point_x = random.Next(0, _height - size + 40);
            int temp1 = rand_point_x % size;
            rand_point_x -= temp1;
            rand_point_y = random.Next(size + 40, _height - size * 3);
            int temp2 = rand_point_y % size;
            rand_point_y -= temp2;
            point.Location = new Point(rand_point_x, rand_point_y);
            Controls.Add(point);
        }

        private void Map() { 
            for (int i = 2; i < _width/size; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.DarkOliveGreen;
                pic.Location = new Point(0, size * i);
                pic.Size = new Size(_width+40, 1);
                Controls.Add(pic);

            }

            for (int i = 0; i < _height / size; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.DarkOliveGreen;
                pic.Location = new Point(size * i, 40);
                pic.Size = new Size(1, _height);
                Controls.Add(pic);

            }
        }

        private void Movement(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode.ToString())
            {
                case "Up":
                    _y = -1;
                    _x = 0;
                    break;

                case "Down":
                    _y = 1;
                    _x = 0;
                    break;

                case "Left":
                    _x = -1;
                    _y = 0;
                    break;

                case "Right":
                    _x = 1;
                    _y = 0;
                    break;
            }
        }
    }
}
