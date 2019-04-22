using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple
{
    public class Operations
    {
        public NDArray RandomVariable(params int[] shape)
        {
            NDArray t = new NDArray(shape);
            Random rand = new Random();
            for (int i = 0; i < t.Elements; i++)
            {
                t[i] = rand.NextDouble();
            }

            return t;
        }

        public NDArray Dot(NDArray a, NDArray b)
        {
            if(a.Shape[1] != b.Shape[0])
            {
                throw new Exception("a->Cols must be equal to b->Rows");
            }

            int m = a.Shape[0];
            int q = b.Shape[1];
            int n = a.Shape[1];
            NDArray r = new NDArray(m, q);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < q; j++)
                {
                    r[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return r;
        }

        public NDArray Exp(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            for (int i = 0; i < x.Elements; i++)
            {
                result[i] = Math.Exp(x[i]);
            }

            return result;
        }

        public NDArray Log(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            for (int i = 0; i < x.Elements; i++)
            {
                result[i] = Math.Log(x[i]);
            }

            return result;
        }

        public NDArray Sqrt(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            for (int i = 0; i < x.Elements; i++)
            {
                result[i] = Math.Sqrt(x[i]);
            }

            return result;
        }

        public NDArray Square(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            for (int i = 0; i < x.Elements; i++)
            {
                result[i] = Math.Pow(x[i], 2);
            }

            return result;
        }

        public NDArray Transpose(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);

            for(int i=0;i<x.Shape[0];i++)
            {
                for (int j = 0; j < x.Shape[1]; j++)
                {
                    result[i, j] = x[j, i];
                }
            }

            return result;
        }
    }
}
