using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsPackage
{
    public static class Drawing
    { 
        public static List<Point> DDA(int x0,int y0,int xEnd,int yEnd)
        {
            List<Point> list = new();
            int dx = xEnd - x0, dy = yEnd - y0, steps, k;
            float xIncrement, yIncrement, x = x0, y = y0;
            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);
            xIncrement = (float)dx / (float)steps;
            yIncrement = (float)dy / (float)steps;

            list.Add(new Point((int)Math.Round(x),(int) Math.Round(y)));
            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement;
                list.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
            }
            return list;
        }

        public static List<Point> LineBres(int x0, int y0, int xEnd, int yEnd)
        {
            List<Point> list = new();
            int dx =Math.Abs(xEnd - x0), dy =Math.Abs(yEnd - y0);
            int x, y, p = 2 * dy - dx;
            int twoDy = 2 * dy, twoDyMinusDx = 2 * (dy - dx);
            if (x0 > xEnd)
            {
                x = xEnd; y = yEnd; xEnd = x0;
            }
            else
            {
                x = x0; y = y0;
            }
            list.Add(new Point(x, y));
            while (x < xEnd)
            {
                x++;
                if (p < 0)
                    p += twoDy;
                else
                {
                    y++;
                    p += twoDyMinusDx;
                }
                list.Add(new Point(x, y));
            }
            return list;
        }

        private static void SaveCirclePoints(int xCenter,int yCenter,int x,int y,List<Point> points)
        {
            points.Add(new Point(xCenter + x, yCenter + y));
            points.Add(new Point(xCenter - x, yCenter + y));
            points.Add(new Point(xCenter + x, yCenter - y));
            points.Add(new Point(xCenter - x, yCenter - y));
            points.Add(new Point(xCenter + y, yCenter + x));
            points.Add(new Point(xCenter - y, yCenter + x));
            points.Add(new Point(xCenter + y, yCenter - x));
            points.Add(new Point(xCenter - y, yCenter - x));
        }

        public static List<Point> CircleMidPoint(int xCenter,int yCenter,int radius)
        {
            List<Point> list = new();
            int x = 0;
            int y = radius;
            int p = 1 - radius;
            SaveCirclePoints(xCenter, yCenter, x, y, list);
            while (x < y)
            {
                x++;
                if (p < 0)
                {
                    p += 2 * x + 1;
                } 
                else
                {
                    y--;
                    p += 2*(x - y) + 1;
                }
                SaveCirclePoints(xCenter, yCenter, x, y, list);
            }
            return list;
        }
    }
}
