using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple
{
    public class Operations
    {
        /// <summary>
        /// Create a tensor with random data. Used for declaring weights for the neural network
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Perform the dot product between two matrix. Only applicable to 2D Tensor. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Calculates the exponential of the tensor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public NDArray Exp(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            for (int i = 0; i < x.Elements; i++)
            {
                result[i] = Math.Exp(x[i]);
            }

            return result;
        }

        /// <summary>
        /// Calculates the logrithmic of the tensor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public NDArray Log(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            for (int i = 0; i < x.Elements; i++)
            {
                result[i] = Math.Log(x[i]);
            }

            return result;
        }

        /// <summary>
        /// Calculates the square root of the tensor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public NDArray Sqrt(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            for (int i = 0; i < x.Elements; i++)
            {
                result[i] = Math.Sqrt(x[i]);
            }

            return result;
        }

        /// <summary>
        /// Calculates the square of the tensor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public NDArray Square(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            for (int i = 0; i < x.Elements; i++)
            {
                result[i] = Math.Pow(x[i], 2);
            }

            return result;
        }

        /// <summary>
        /// Transpose the matrix which is formed by turning all the rows of a given matrix into columns and vice-versa.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public NDArray Transpose(NDArray x)
        {
            NDArray result = new NDArray(x.Shape[1], x.Shape[0]);

            for (int i = 0; i < x.Shape[1]; i++)
            {
                for (int j = 0; j < x.Shape[0]; j++)
                {
                    result[i, j] = x[j, i];
                }
            }

            return result;
        }
    }
}
