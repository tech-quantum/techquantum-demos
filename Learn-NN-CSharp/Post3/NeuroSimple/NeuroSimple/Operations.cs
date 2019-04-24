using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NeuroSimple
{
    public class Operations
    {
        public double Epsilon = 1e-7;

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

        /// <summary>
        /// Clip the values in tensor between min and max values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public NDArray Clip(NDArray x, double min, double max)
        {
            NDArray result = new NDArray(x.Shape);
            for (int i = 0; i < x.Elements; i++)
            {
                result[i] = (x[i] < min) ? min : (x[i] > max) ? max : x[i];
            }

            return result;
        }

        /// <summary>
        /// Round the values in the tensor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public NDArray Round(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            for (int i = 0; i < x.Elements; i++)
            {
                result[i] = Math.Round(x[i]);
            }

            return result;
        }

        public NDArray Abs(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            for (int i = 0; i < x.Elements; i++)
            {
                result[i] = Math.Abs(x[i]);
            }

            return result;
        }

        /// <summary>
        /// Find the mean value of the tensor accross axis or as a whole
        /// </summary>
        /// <param name="x"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public NDArray Mean(NDArray x, uint? axis = null)
        {
            NDArray result = null;

            if(axis.HasValue)
            {
                List<double> meanValues = new List<double>();
                if (axis.Value == 1)
                {
                    result = new NDArray(x.Shape[0], 1);
                    for (int i = 0; i < x.Shape[0]; i++)
                    {
                        double total = 0;
                        for (int j = 0; j < x.Shape[1]; j++)
                        {
                            total += x[i, j];
                        }

                        meanValues.Add(total / x.Shape[1]);
                    }

                }
                else if (axis.Value == 0)
                {
                    result = new NDArray(1, x.Shape[1]);
                    for (int i = 0; i < x.Shape[1]; i++)
                    {
                        double total = 0;
                        for (int j = 0; j < x.Shape[0]; j++)
                        {
                            total += x[i, j];
                        }

                        meanValues.Add(total / x.Shape[0]);
                    }
                }

                

                result.Load(meanValues.ToArray());
            }
            else
            {
                result = new NDArray(1, 1);
                result.Load(x.Data.Average());
            }

            return result;
        }
    }
}
