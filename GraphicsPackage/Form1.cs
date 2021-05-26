using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsPackage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            label6.Text = "X: " + e.X + " Y: " + e.Y;
        }

        private void Draw(List<Point> points,Graphics g)
        {
            for (int i = 0; i < points.Count; i++)
            {
                g.FillRectangle(Brushes.Black, points[i].X, points[i].Y, 1, 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            List<Point> points = Drawing.DDA((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, (int)numericUpDown4.Value);
            Draw(points, g);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            List<Point> points = Drawing.LineBres((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, (int)numericUpDown4.Value);
            Draw(points, g);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            List<Point> points = Drawing.CircleMidPoint((int)numericUpDown5.Value, (int)numericUpDown6.Value, (int)numericUpDown7.Value);
            Draw(points, g);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            List<Point> points = Drawing.EllipseMidPoint((int)xEllipse.Value, (int)yEllipse.Value, (int)numericUpDown10.Value, (int)numericUpDown11.Value);
            Draw(points, g);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form2 = new();
            this.Hide();
            form2.ShowDialog();
            this.Close();
        }
    }
}
