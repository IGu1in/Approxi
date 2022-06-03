using Approximation.Functions;
using System;
using System.Collections.Generic;

namespace Approximation
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List<double> { -3.99, -2.4, 0.02, 2.4, 3.99 };
            var list2 = new List<double> { 0.02, 3.2, 3.99, 3.2, 0.02 };
            try
            {
                var approxim = new Function(list1, list2);
                double minDeviation = double.MaxValue;

                var exhib = new Exhibitor(list1, list2);
                var exhibValue = exhib.Calculate();

                if (exhibValue < minDeviation)
                {
                    minDeviation = exhibValue;
                    approxim = exhib;
                }

                var pow = new Power(list1, list2);
                var powValue = pow.Calculate();

                if (powValue < minDeviation)
                {
                    minDeviation = powValue;
                    approxim = pow;
                }

                var hyperbol = new Hyperbol(list1, list2);
                var hypebolValue = hyperbol.Calculate();

                if (hypebolValue < minDeviation)
                {
                    minDeviation = hypebolValue;
                    approxim = hyperbol;
                }

                var linear = new Linear(list1, list2);
                var linearValue = linear.Calculate();

                if (linearValue < minDeviation)
                {
                    minDeviation = linearValue;
                    approxim = linear;
                }

                var logarithm = new Logarithm(list1, list2);
                var logarithValue = logarithm.Calculate();

                if (logarithValue < minDeviation)
                {
                    minDeviation = logarithValue;
                    approxim = logarithm;
                }

                for (int i = 2; i < list1.Count; i++)
                {
                    var polynom = new Polynomial(list1, list2, i);
                    var polynomValue = polynom.Calculate();

                    if (polynomValue < minDeviation)
                    {
                        minDeviation = polynomValue;
                        approxim = polynom;
                    }
                }

                Console.WriteLine("Функция аппроксимации {0}", approxim.ToString());
                Console.WriteLine("Сумма квадратов отколений = {0}", minDeviation);
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
            }

            Console.ReadLine();
        }
    }
}
