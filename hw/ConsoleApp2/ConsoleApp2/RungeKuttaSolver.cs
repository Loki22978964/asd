using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class RungeKuttaSolver
    {
        public delegate double[] SystemEquations(double t, double[] Y);

        public static List<(double t, double[] Y)> Solve(SystemEquations eqs, double[] Y0, double t0, double tEnd, double h)
        {
            var results = new List<(double t, double[] Y)>();
            double t = t0;
            double[] Y = (double[])Y0.Clone();

            results.Add((t, (double[])Y.Clone()));

            while (t < tEnd)
            {
                int len = Y.Length;

                double[] k1 = eqs(t, Y);

                double[] tempY2 = new double[len];
                for (int i = 0; i < len; i++) tempY2[i] = Y[i] + 0.5 * h * k1[i];
                double[] k2 = eqs(t + 0.5 * h, tempY2);

                double[] tempY3 = new double[len];
                for (int i = 0; i < len; i++) tempY3[i] = Y[i] + 0.5 * h * k2[i];
                double[] k3 = eqs(t + 0.5 * h, tempY3);

                double[] tempY4 = new double[len];
                for (int i = 0; i < len; i++) tempY4[i] = Y[i] + h * k3[i];
                double[] k4 = eqs(t + h, tempY4);

                for (int i = 0; i < len; i++)
                {
                    Y[i] = Y[i] + (h / 6.0) * (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]);
                }

                t += h;
                results.Add((t, (double[])Y.Clone()));
            }

            return results;
        }
    }
}