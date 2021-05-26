using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsPackage
{
    static class Matrices
    {
        public static int[] Scale(this int[] arr,int x,int y)
        {
            if (arr.Length > 2 || arr.Length < 2 ) return arr;
            int[] Vector = new int[3] { arr[0], arr[1], 1 };
            int[,] ScaleMatrix = new int[3,3] { { x, 0, 0 }, { 0, y, 0 }, { 0, 0, 1 } };
            int[] OutputVector = new int[3];
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    OutputVector[i] += ScaleMatrix[i, j] * Vector[j];
                }
            }
            return new int[2] { OutputVector[0], OutputVector[1] };
        }

        public static double[] Scale(this double[] arr, double x, double y)
        {
            if (arr.Length > 2 || arr.Length < 2) return arr;
            double[] Vector = new double[3] { arr[0], arr[1], 1 };
            double[,] ScaleMatrix = new double[3, 3] { { x, 0, 0 }, { 0, y, 0 }, { 0, 0, 1 } };
            double[] OutputVector = new double[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    OutputVector[i] += ScaleMatrix[i, j] * Vector[j];
                }
            }
            return new double[2] { OutputVector[0], OutputVector[1] };
        }

        public static int[] Translation(this int[] arr, int x, int y)
        {
            if (arr.Length > 2 || arr.Length < 2) return arr;
            int[] Vector = new int[3] { arr[0], arr[1], 1 };
            int[,] TranslationMatrix = new int[3, 3] { { 1, 0, x }, { 0, 1, y }, { 0, 0, 1 } };
            int[] OutputVector = new int[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    OutputVector[i] += TranslationMatrix[i, j] * Vector[j];
                }
            }
            return new int[2] { OutputVector[0], OutputVector[1] };
        }

        public static double[] Translation(this double[] arr, double x, double y)
        {
            if (arr.Length > 2 || arr.Length < 2) return arr;
            double[] Vector = new double[3] { arr[0], arr[1], 1 };
            double[,] TranslationMatrix = new double[3, 3] { { 1, 0, x }, { 0, 1, y }, { 0, 0, 1 } };
            double[] OutputVector = new double[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    OutputVector[i] += TranslationMatrix[i, j] * Vector[j];
                }
            }
            return new double[2] { OutputVector[0], OutputVector[1] };
        }

        public static double[] Rotate(this int[] arr,double degree)
        {
            if (arr.Length > 2 || arr.Length < 2) return new double[] { };
            degree = Math.PI * degree / 180.0;
            int[] Vector = new int[3] { arr[0], arr[1], 1 };
            double[,] TranslationMatrix = new double[3, 3] 
                { { Math.Cos(degree), -Math.Sin(degree), 0 }, { Math.Sin(degree), Math.Cos(degree), 0 }, { 0, 0, 1 } };
            double[] OutputVector = new double[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    OutputVector[i] += TranslationMatrix[i, j] * Vector[j];
                }
            }
            return new double[2] { OutputVector[0], OutputVector[1] };
        }

        public static double[] Rotate(this double[] arr, double degree)
        {
            if (arr.Length > 2 || arr.Length < 2) return arr;
            degree = Math.PI * degree / 180.0;
            double[] Vector = new double[3] { arr[0], arr[1], 1 };
            double[,] TranslationMatrix = new double[3, 3]
                { { Math.Cos(degree), -Math.Sin(degree), 0 }, { Math.Sin(degree), Math.Cos(degree), 0 }, { 0, 0, 1 } };
            double[] OutputVector = new double[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    OutputVector[i] += TranslationMatrix[i, j] * Vector[j];
                }
            }
            return new double[2] { OutputVector[0], OutputVector[1] };
        }

        public static int[] ShearingX(this int[] arr,int xShear)
        {
            if (arr.Length > 2 || arr.Length < 2) return arr;
            int[] Vector = new int[3] { arr[0], arr[1], 1 };
            int[,] ScaleMatrix = new int[3, 3] { { 1, xShear, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            int[] OutputVector = new int[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    OutputVector[i] += ScaleMatrix[i, j] * Vector[j];
                }
            }
            return new int[2] { OutputVector[0], OutputVector[1] };
        }

        public static double[] ShearingX(this int[] arr, double xShear)
        {
            int[] Vector = new int[3] { arr[0], arr[1], 1 };
            double[,] ScaleMatrix = new double[3, 3] { { 1, xShear, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            double[] OutputVector = new double[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    OutputVector[i] += ScaleMatrix[i, j] * Vector[j];
                }
            }
            return new double[2] { OutputVector[0], OutputVector[1] };
        }

        public static double[] ShearingX(this double[] arr, double xShear)
        {
            double[] Vector = new double[3] { arr[0], arr[1], 1 };
            double[,] ScaleMatrix = new double[3, 3] { { 1, xShear, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            double[] OutputVector = new double[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    OutputVector[i] += ScaleMatrix[i, j] * Vector[j];
                }
            }
            return new double[2] { OutputVector[0], OutputVector[1] };
        }
        public static int[] ShearingY(this int[] arr, int yShear)
        {
            if (arr.Length > 2 || arr.Length < 2) return arr;
            int[] Vector = new int[3] { arr[0], arr[1], 1 };
            int[,] ScaleMatrix = new int[3, 3] { { 1, 0, 0 }, { yShear, 1, 0 }, { 0, 0, 1 } };
            int[] OutputVector = new int[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    OutputVector[i] += ScaleMatrix[i, j] * Vector[j];
                }
            }
            return new int[2] { OutputVector[0], OutputVector[1] };
        }
        public static double[] ShearingY(this int[] arr, double yShear)
        {
            int[] Vector = new int[3] { arr[0], arr[1], 1 };
            double[,] ScaleMatrix = new double[3, 3] { { 1, 0, 0 }, { yShear, 1, 0 }, { 0, 0, 1 } };
            double[] OutputVector = new double[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    OutputVector[i] += ScaleMatrix[i, j] * Vector[j];
                }
            }
            return new double[2] { OutputVector[0], OutputVector[1] };
        }

        public static double[] ShearingY(this double[] arr, double yShear)
        {
            double[] Vector = new double[3] { arr[0], arr[1], 1 };
            double[,] ScaleMatrix = new double[3, 3] { { 1, 0, 0 }, { yShear, 1, 0 }, { 0, 0, 1 } };
            double[] OutputVector = new double[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    OutputVector[i] += ScaleMatrix[i, j] * Vector[j];
                }
            }
            return new double[2] { OutputVector[0], OutputVector[1] };
        }
    }
}
