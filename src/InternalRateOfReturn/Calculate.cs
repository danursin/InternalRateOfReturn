using System;
using System.Collections.Generic;

namespace InternalRateOfReturn
{
    public static class Calculate
    {
        public static double InternalRateOfReturn(double[] cashflow)
        {
            const double initialGuess = 0.1;
            const double epsilon = 0.000001;
            const int maxIterations = 100;

            var terms = new Dictionary<int, double>();
            for (var exponent = 0; exponent < cashflow.Length; exponent++)
            {
                terms.Add(-1*exponent, cashflow[exponent]);
            }

            var f = new LaurentPolynomial(terms);
            var fPrime = f.Derivative;

            var onePlusRi = (1 + initialGuess);
            var iterations = 0;
            while (iterations < maxIterations)
            {
                var onePlusRiPlus1 = onePlusRi - f.ValueAt(onePlusRi)/fPrime.ValueAt(onePlusRi);
                if (Math.Abs(onePlusRiPlus1 - onePlusRi) < epsilon)
                {
                    return (onePlusRiPlus1 - 1);
                }
                onePlusRi = onePlusRiPlus1;
                iterations += 1;
            }
            return onePlusRi;
        }
    }
}
