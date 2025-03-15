using System;

class Tutorial
{
    class Polynomial
    {
        private double[] coefs;

        public Polynomial(params double[] coefs)
        {
            int start;
            for (start = 0; start < coefs.Length; start++)
            {
                if (coefs[start] != 0)
                {
                    break;
                }
            }

            this.coefs = new double[coefs.Length - start];
            for (int i = 0; i < this.coefs.Length; i++)
            {
                this.coefs[i] = coefs[i + start];
            }
        }
        public int Degree // => returns coefs.Length - 1
        {
            get { return coefs.Length - 1; } 
        }

        static public Polynomial operator +(Polynomial left, Polynomial right)
        {
            if (left.Degree < right.Degree)
            {
                (left, right) = (right, left);
            }
            // left is the bigger one
            double[] newCoefs = [.. left.coefs];
            for (int i = 1; i <= right.Degree + 1; i++)
            {
                newCoefs[^i] += right.coefs[^i];
            }

            return new(newCoefs);
        }

        static public Polynomial operator -(Polynomial left, Polynomial right) => left + (-1) * right;

        static public Polynomial operator *(Polynomial left, Polynomial right)
        {
            if (left.Degree == -1 || right.Degree == -1)
            {
                return new();
            }

            int newDegree = left.Degree + right.Degree;
            double[] newCoefs = new double[newDegree + 1];
            for (int i = 1; i <= left.Degree + 1; i++)
            {
                for (int j = 1; j <= right.Degree + 1; j++)
                {
                    newCoefs[^(i + j - 1)] += left.coefs[^i] * right.coefs[^j];
                }
            }

            return new(newCoefs);
        }

        static public Polynomial operator *(Polynomial left, double right) => left * new Polynomial(right);
        static public Polynomial operator *(double left, Polynomial right) => new Polynomial(left) * right;

    }

    static void Main(string[] args)
    {
        Polynomial p = new(1, 2, 3);
        Console.WriteLine(p.Degree);
    }
}