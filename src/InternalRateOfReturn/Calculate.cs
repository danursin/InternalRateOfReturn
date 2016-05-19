using System;
using System.Collections.Generic;

namespace InternalRateOfReturn
{
    public static class Calculate
    {
        public static double InternalRateOfReturn(double[] cashflow)
        {
            const double initialGuess = 0.1;

            // f(x) = C0 + C1(x)^-1 + C2(x)^-2 + ... + Cn(x)^-n
            var terms = new Dictionary<int, double>();
            for (var exponent = 0; exponent < cashflow.Length; exponent++)
            {
                terms.Add(-1 * exponent, cashflow[exponent]);
            }

            var f = new LaurentPolynomial(terms);

            var onePlusIrr = f.Root(1 + initialGuess);
            var irr = onePlusIrr - 1;
            
            return irr;
        }
    }
}
