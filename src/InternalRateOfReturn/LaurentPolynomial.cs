
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternalRateOfReturn
{
    public class LaurentPolynomial
    {
        private readonly Dictionary<int, double> _terms;
        public LaurentPolynomial(Dictionary<int, double> terms)
        {
            _terms = terms;
        }
        
        public LaurentPolynomial Derivative
        {
            get
            {
                var terms = new Dictionary<int, double>();
                foreach (var term in _terms.Where(x => x.Key != 0))
                {
                    if (term.Key != 0)
                    {
                        terms.Add(term.Key - 1, term.Key*term.Value);
                    }
                }
                return new LaurentPolynomial(terms);
            }
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

        public override string ToString()
        {
            var orderedKeys = _terms.Keys.OrderByDescending(x => x).Select(x => string.Format("{0}X^{1}",_terms[x], x));
            return string.Join("+", orderedKeys);
        }
    }
}
