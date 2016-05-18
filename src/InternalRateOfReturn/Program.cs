using System;

namespace InternalRateOfReturn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome");

            var cashflow = new double[]
            {
                -2000, 100, 100, 2600
            };

            var irr = Calculate.InternalRateOfReturn(cashflow);
            Console.WriteLine("IRR: {0}", irr);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
