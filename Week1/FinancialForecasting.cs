using System;

namespace FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter The Present Sum:");
            int presentSum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the rate in percent (e.g., 5 for 5%):");
            double rate = double.Parse(Console.ReadLine()) / 100;

            Console.WriteLine("Enter the Time Period (in years):");
            int time = int.Parse(Console.ReadLine());

            double futureValue = Forecasting(presentSum, rate, time);

            Console.WriteLine($"Forecasted Future Value after {time} years: Rs{futureValue:F2}");
        }

        public static double Forecasting(double presentSum, double rate, int time)
        {
            if (time == 0)
            {
                return presentSum;
            }

            return Forecasting(presentSum * (1 + rate), rate, time - 1);
        }
    }
}
