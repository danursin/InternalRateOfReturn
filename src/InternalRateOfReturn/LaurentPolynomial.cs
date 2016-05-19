
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternalRateOfReturn
{
    public class LaurentPolynomial
    {
        private const double Epsilon = 1e-12;
        private readonly Dictionary<int, double> _terms;
        public LaurentPolynomial(Dictionary<int, double> terms)
        {
            _terms = terms;
        }
        
        public LaurentPolynomial Derivative()
        {
            var terms = new Dictionary<int, double>();
            foreach (var term in _terms.Where(x => x.Key != 0))
            {
                terms.Add(term.Key - 1, term.Key*term.Value);
            }
            return new LaurentPolynomial(terms);
        }

        public double ValueAt(double x)
        {
            double val = 0;
            foreach (var term in _terms)
            {
                val += term.Value*Math.Pow(x, term.Key);
            }
            return val;
        }

        public double Root(double guess, int maxIterations = 20)
        {
            var f = this;
            var fPrime = Derivative();
            
            var current = guess;
            var iterations = 0;
            while (iterations < maxIterations)
            {
                // Newton's Method
                var next = current - f.ValueAt(current) / fPrime.ValueAt(current);
                if (Math.Abs(next - current) < Epsilon)
                {
                    return next;
                }
                current = next;
                iterations += 1;
            }
            return current;
        }
    }
}
