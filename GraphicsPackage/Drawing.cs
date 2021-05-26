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

        public static List<Point> EllipseMidPoint(int rx, int ry,int xc, int yc)
        {
            List<Point> points = new();
            float dx, dy, d1, d2, x, y;
            x = 0;
            y = ry;

            d1 = (ry * ry) - (rx * rx * ry) + (0.25f * rx * rx);
            dx = 2 * ry * ry * x;
            dy = 2 * rx * rx * y;

            while (dx < dy)
            {
                DrawEllipse(xc, yc, points, x, y);

                if (d1 < 0)
                {
                    x++;
                    dx = dx + (2 * ry * ry);
                    d1 = d1 + dx + (ry * ry);
                }
                else
                {
                    x++;
                    y--;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d1 = d1 + dx - dy + (ry * ry);
                }
            }

            d2 = ((ry * ry) * ((x + 0.5f) * (x + 0.5f))) +
                 ((rx * rx) * ((y - 1) * (y - 1))) -
                  (rx * rx * ry * ry);

            while (y >= 0)
            {
                DrawEllipse(xc, yc, points, x, y);

                if (d2 > 0)
                {
                    y--;
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + (rx * rx) - dy;
                }
                else
                {
                    y--;
                    x++;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + dx - dy + (rx * rx);
                }
            }
            return points;
        }

        private static void DrawEllipse(int xc, int yc, List<Point> points, float x, float y)
        {
            points.Add(new Point((int)x + xc, (int)y + yc));
            points.Add(new Point((int)-x + xc, (int)y + yc));
            points.Add(new Point((int)x + xc, (int)-y + yc));
            points.Add(new Point((int)-x + xc, (int)-y + yc));
        }
    }
}
