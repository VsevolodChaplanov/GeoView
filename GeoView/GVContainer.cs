using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoView
{
    internal class GVContainer
    {
        // Число делений по осям x,y
        public int Nx { set; get; }
        public int Ny { set; get; }
        // Минимальное и максимальное значение по осям
        public double xMin { set; get; }
        public double xMax { set; get; }
        public double yMin { set; get; }
        public double yMax { set; get; }
        public double zMin { set; get; }
        public double zMax { set; get; }
        // Контейнер хранения значений функции
        public List<double> funcValues = new List<double>();
        public List<List<double>> derivatives = new List<List<double>>();

        private double hx;
        private double hy;

        public GVContainer() { }
        public GVContainer(int Nx, int Ny,
                double xMin, double xMax, double yMin, double yMax,
                List<double> values)
        {
            this.Nx = Nx;
            this.Ny = Ny;
            this.xMax = xMax;
            this.xMin = xMin;
            this.yMax = yMax;
            this.yMin = yMin;
            this.funcValues = values;
        }

        public bool isData()
        {
            if (funcValues.Count != 0)
            {
                return true;
            }
            return false;
        }

        public void calculateNormals()
        {
            for (int j = 0; j < Ny; j++)
            {
                for (int i = 0; i < Nx; i++)
                {
                    derivatives.Add(calculateNormalsInPoint(i, j));
                }
            }
        }

        private List<double> calculateNormalsInPoint(int i, int j)
        {
            // Туду разбить и аызывать при загрузке

            this.hx = (xMax - xMin) / (Nx - 1);
            this.hy = (yMax - yMin) / (Ny - 1);

            double derdx = dzdx(i, j, hx, hy);
            double derdy = dzdy(i, j, hx, hy);

            return new List<double> { - derdx, 1, -derdy };
        }

        private double dzdx(int i, int j, double hx, double hy)
        {
            double dxDerivative;
            if (i == Nx - 1)
            {
                dxDerivative = (funcValues[Index(i, j)] - funcValues[Index(i - 1, j)]) / (hx);
                return dxDerivative;
            }
            if (i == 0)
            {
                dxDerivative = (funcValues[Index(i + 1, j)] - funcValues[Index(i, j)]) / (hx);
                return dxDerivative;
            }
            dxDerivative = (funcValues[Index(i + 1, j)] - funcValues[Index(i - 1, j)]) / (2 * hx);
            return dxDerivative;
        }

        private double dzdy(int i, int j, double hx, double hy)
        {
            double dyDerivative;
            if (j == Ny - 1)
            {
                dyDerivative = (funcValues[Index(i, j)] - funcValues[Index(i, j - 1)]) / (hy);
                return dyDerivative;
            }
            if (j == 0)
            {
                dyDerivative = (funcValues[Index(i, j + 1)] - funcValues[Index(i, j)]) / (hy);
                return dyDerivative;
            }
            dyDerivative = (funcValues[Index(i, j + 1)] - funcValues[Index(i, j - 1)]) / (2 * hy);
            return dyDerivative;
        }


        private int Index(int i, int j)
        {
            int result = i + j * Nx;
            return result;
        }
    }
}
