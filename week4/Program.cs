using System;

class Week3
{
    class Vec
    {
        private double[] a;

        public Vec(params double[] a)
        {
            this.a = a;
        }

        public Vec(int size)
        {
            this.a = new double[size];
        }

        public double get(int i) => a[i];

        public double this[int i] //indexer//
        {
            get // get => a[i];
            {
                return a[i];
            }
            set
            {
                a[i] = value;
            }
        }

        public double this[Index i] => a[i];
        
        public int dims => a.Length;

        public static Vec add(Vec v, Vec w)
        {
            double[] b = new double[v.dims];

            for (int i = 0; i < v.dims; ++i)
            {
                b[i] = v[i] + w[i]; // v.a[i] + w.a[i] but we already wrote an indexer
            }

            return new Vec(b);
        }

        public double length
        {
            get
            {
                
            }
        }
    }
}