using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Width = 800;
            Height = 800;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            timer1.Interval = 100;
            timer1.Start();
            bt.Width = 20;
            bt.Height = 20;
            bt.Left = b;
            bt.Top = c;
            bt.FlatStyle = FlatStyle.Flat;
            bt.FlatAppearance.BorderSize = 0;
            bt.BackColor = Color.RoyalBlue;

            this.Controls.Add(textBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            quyruq();

        }
        public void ilann()
        {
            this.Controls.Add(hisseler[bedensayi - 1]);
        }

       
        public static Random a = new Random();
        public int b = a.Next(1, 580);
        public int c = a.Next(1, 680);
        public static List<Button> hisseler = new List<Button>();
        public int quyruqa = 0; 
        public int x;
        public int y;
        public int say = 0;
        public int bedensayi = 1;
        public void quyruq()
        {
            for (int i = 0; i < bedensayi; i++)
            {
                Button quyruq = new Button();
                quyruq.Width = 20;
                quyruq.Height = 20;
                quyruq.Top = 100;
                quyruq.Left = 120 - (i * 20);
                quyruq.FlatAppearance.BorderSize = 0;
                quyruq.FlatStyle = FlatStyle.Flat;
                quyruq.BackColor = Color.Black;
                hisseler.Add(quyruq);
                Controls.Add(quyruq);
            }
            hisseler[0].BackColor = Color.Red;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = bedensayi-1; i >=0; i--)
            {
                if(i==0)
                {
                    hisseler[i].Location = new Point(hisseler[i].Location.X + x, hisseler[i].Location.Y);

                    hisseler[i].Location = new Point(hisseler[i].Location.X, hisseler[i].Location.Y + y);
                }
                else
                {
                    hisseler[i].Location = new Point(hisseler[i-1].Location.X, hisseler[i-1].Location.Y);

                }
            }

            if (hisseler[0].Left < bt.Left + 20 && hisseler[0].Left > bt.Left - 20 && hisseler[0].Top > bt.Top - 20 && hisseler[0].Top < bt.Top + 20)
            {

                bt.Location = new Point(a.Next(1, 580), a.Next(1, 650));
                say++;
                textBox1.Text = "Say: " + say;
                Button elave = new Button();
                elave.Top = -20;
                elave.Left = -20;
                elave.BackColor = Color.Black;
                bedensayi++;
                hisseler.Add(elave);
                elave.Width = 20;
                elave.Height = 20;
                elave.FlatStyle = FlatStyle.Flat;
                elave.FlatAppearance.BorderSize = 0;
                ilann();
            }
            for (int i = 1; i < bedensayi; i++)
            {
                if (hisseler[0].Left == hisseler[i].Left && hisseler[0].Top == hisseler[i].Top)
                {
                    timer1.Stop();
                    MessageBox.Show(" Uduzdunuz" + "\r\n" + " Neticeniz " + say+ "-dir");
                    Application.Exit();
                }

            }
            
            if (hisseler[0].Top > 740)
            {
                hisseler[0].Location = new Point(hisseler[0].Location.X, 740);
                timer1.Stop();
                MessageBox.Show("Oyun Bitti" + "\r\n" + "Sizin Neticeniz: " + say + "-dir");
                Application.Exit();
            }
            if (hisseler[0].Left > 770)
            {
                hisseler[0].Location = new Point(770, hisseler[0].Location.Y);
                timer1.Stop();
                MessageBox.Show("Oyun Bitti" + "\r\n" + "Sizin Neticeniz: " + say + "-dir");
                Application.Exit();
            }
            if (hisseler[0].Left < 0)
            {
                hisseler[0].Location = new Point(0, hisseler[0].Location.Y);
                timer1.Stop();
                MessageBox.Show("Oyun Bitti" + "\r\n" + "Sizin Neticeniz: " + say + "-dir");
                Application.Exit();
            }
            if (hisseler[0].Top < 0)
            {
                hisseler[0].Location = new Point(hisseler[0].Location.X, 0);
                timer1.Stop();
                MessageBox.Show("Oyun Bitti" + "\r\n" + "Sizin Neticeniz: " + say + "-dir");

                Application.Exit();
            }

           


        }
        public Keys asdf = Keys.U;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            x = 0;
            y = 0;
            Keys newArrow = e.KeyCode;
            if (asdf == Keys.Up && newArrow == Keys.Down)
            {
                newArrow = Keys.Up;
            }
            if (asdf == Keys.Down && newArrow == Keys.Up)
            {
                newArrow = Keys.Down;
            }
            if (asdf == Keys.Left && newArrow == Keys.Right)
            {
                newArrow = Keys.Left;
            }
            if (asdf == Keys.Right && newArrow == Keys.Left)
            {
                newArrow = Keys.Left;
            }
            if (newArrow == Keys.Up)
            {
                y = -20;
                asdf = Keys.Up;
            }
            if (newArrow == Keys.Down)
            {
                y = 20;
                asdf = Keys.Down;
            }
            if (newArrow == Keys.Left)
            {
                x = -20;
                asdf = Keys.Left;
            }
            if (newArrow == Keys.Right)
            {
                x = 20;
                asdf = Keys.Right;
               
            }
            
           
                
            
        }
    }
}

