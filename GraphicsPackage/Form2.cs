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
    public partial class Form2 : Form
    {
        private List<PointF> filterdPoints;
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            NegativeNumbers.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            UpdateFillterPoints();
            g.DrawPolygon(Pens.Black, filterdPoints.ToArray());
        }

        private void UpdateFillterPoints()
        {
            filterdPoints = new();
            double[,] points = { { (double)x1.Value, (double)y1.Value },
                { (double)x2.Value, (double)y2.Value },
                { (double)x3.Value, (double)y3.Value },
                { (double)x4.Value, (double)y4.Value },
                { (double)x5.Value, (double)y5.Value },
                { (double)x6.Value, (double)y6.Value }};
            for (int i = 0; i < points.Length / 2; i++)
            {
                if (points[i, 0] == 0 && points[i, 1] == 0)
                {
                    continue;
                }
                else
                {
                    filterdPoints.Add(new PointF((float)points[i, 0], (float)points[i, 1]));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            UpdateFillterPoints();
            PointF[] points = filterdPoints.ToArray();
            for(int i = 0; i < points.Length; i++)
            {
                double[] point = { points[i].X, points[i].Y };
                point=point.Translation((double)xTranslate.Value,(double)yTranslate.Value);
                points[i].X = (float) point[0];
                points[i].Y = (float) point[1];
            }
            CheckNegativeNumbers(points);
            g.DrawPolygon(Pens.Black, points);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            UpdateFillterPoints();
            PointF[] points = filterdPoints.ToArray();
            double xCenter = points[0].X,yCenter = points[0].Y;
            for (int i = 0; i < points.Length; i++)
            {
                double[] point = { points[i].X, points[i].Y };
                point = point.Translation(-xCenter,-yCenter);
                point = point.Rotate((double)RotateDegree.Value);
                point = point.Translation(xCenter, yCenter);
                points[i].X = (float)point[0];
                points[i].Y = (float)point[1];
            }
            CheckNegativeNumbers(points);
            g.DrawPolygon(Pens.Black, points);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            UpdateFillterPoints();
            PointF[] points = filterdPoints.ToArray();
            for (int i = 0; i < points.Length; i++)
            {
                double[] point = { points[i].X, points[i].Y };
                point = point.Scale((double)xScale.Value, (double)yScale.Value);
                points[i].X = (float)point[0];
                points[i].Y = (float)point[1];
            }

            CheckNegativeNumbers(points);
            g.DrawPolygon(Pens.Black, points);
        }

        private void CheckNegativeNumbers(PointF[] points)
        {
            int found = 0;
            NegativeNumbers.Text = "";
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].X < 0 || points[i].Y < 0)
                {
                    found += 1;
                    if (found == 1)
                    {
                        NegativeNumbers.Text = "Points We can't show:\n";
                    }
                    NegativeNumbers.Text += $"X:{points[i].X} , Y:{points[i].Y} \n";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (xShear.Value > 0 && yShear.Value > 0)
                return;
            else if (xShear.Value > 0)
            {
                Graphics g = panel1.CreateGraphics();
                UpdateFillterPoints();
                PointF[] points = filterdPoints.ToArray();
                for (int i = 0; i < points.Length; i++)
                {
                    double[] point = { points[i].X, points[i].Y };
                    point = point.ShearingX((double)xShear.Value);
                    points[i].X = (float)point[0];
                    points[i].Y = (float)point[1];
                }
                g.DrawPolygon(Pens.Black, points);
                return;
            }else if (yShear.Value > 0)
            {
                Graphics g = panel1.CreateGraphics();
                UpdateFillterPoints();
                PointF[] points = filterdPoints.ToArray();
                for (int i = 0; i < points.Length; i++)
                {
                    double[] point = { points[i].X, points[i].Y };
                    point = point.ShearingX((double)yShear.Value);
                    points[i].X = (float)point[0];
                    points[i].Y = (float)point[1];
                }
                g.DrawPolygon(Pens.Black, points);
                return;
            }
        }
    }
}
