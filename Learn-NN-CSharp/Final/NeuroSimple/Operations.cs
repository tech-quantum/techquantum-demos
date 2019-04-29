using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Threading;

namespace NeuroSimple
{
    public class Operations
    {
        public static int LayerIndex = 0;
        static Random random = new Random();
        
        public static float Epsilon = 1e-7f;

        /// <summary>
        /// Create a tensor with random data. Used for declaring weights for the neural network
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public static NDArray RandomVariable(params int[] shape)
        {
            NDArray t = new NDArray(shape);
            
            Parallel.For(0, t.Elements, i =>
            {
                t[i] = (float)random.NextDouble();
            });

            t = t - 0.5f;

            return t;
        }

        public static NDArray Constant(float value, params int[] shape)
        {
            NDArray x = new NDArray(shape);

            Parallel.For(0, x.Elements, i =>
            {
                x[i] = value;
            });

            return x;
        }

        /// <summary>
        /// Perform the dot product between two matrix. Only applicable to 2D Tensor. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray Dot(NDArray a, NDArray b)
        {
            if(a.Shape[1] != b.Shape[0])
            {
                throw new Exception("a->Cols must be equal to b->Rows");
            }

            int m = a.Shape[0];
            int q = b.Shape[1];
            int n = a.Shape[1];
            NDArray r = new NDArray(m, q);

            Parallel.For(0, m, i =>
            {
                Parallel.For(0, q, j =>
                {
                    Parallel.For(0, n, k =>
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    });
                });
            });

            return r;
        }

        /// <summary>
        /// Calculates the exponential of the tensor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static NDArray Exp(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            
            Parallel.For(0, x.Elements, i =>
            {
                result[i] = (float)Math.Exp(x[i]);
            });

            return result;
        }

        /// <summary>
        /// Calculates the logrithmic of the tensor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static NDArray Log(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
           
            Parallel.For(0, x.Elements, i =>
            {
                result[i] = (float)Math.Log(x[i]);
            });

            return result;
        }

        /// <summary>
        /// Calculates the square root of the tensor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static NDArray Sqrt(NDArray x)
        {
            NDArray r = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, i =>
            {
                r[i] = (float)Math.Sqrt(x[i]);
            });

            return r;
        }

        /// <summary>
        /// Calculates the square of the tensor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static NDArray Square(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, i =>
            {
                result[i] = (float)Math.Pow(x[i], 2);
            });

            return result;
        }

        /// <summary>
        /// Transpose the matrix which is formed by turning all the rows of a given matrix into columns and vice-versa.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static NDArray Transpose(NDArray x)
        {
            NDArray result = new NDArray(x.Shape[1], x.Shape[0]);

            Parallel.For(0, x.Shape[1], i =>
            {
                Parallel.For(0, x.Shape[0], j => {
                    result[i, j] = x[j, i];
                });
            });

            return result;
        }

        /// <summary>
        /// Clip the values in tensor between min and max values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static NDArray Clip(NDArray x, float min, float max)
        {
            NDArray result = new NDArray(x.Shape);
            
            Parallel.For(0, x.Elements, i =>
            {
                result[i] = (x[i] < min) ? min : (x[i] > max) ? max : x[i];
            });

            return result;
        }

        /// <summary>
        /// Round the values in the tensor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static NDArray Round(NDArray x)
        {
            NDArray r = new NDArray(x.Shape);
            Parallel.For(0, x.Elements , i =>
            {
                r[i] = (float)Math.Round(x[i]);
            });

            return r;
        }

        public static NDArray Abs(NDArray x)
        {
            NDArray r = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, i =>
            {
                r[i] = Math.Abs(x[i]);
            });

            return r;
        }

        /// <summary>
        /// Find the mean value of the tensor accross axis or as a whole
        /// </summary>
        /// <param name="x"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public static NDArray Mean(NDArray x)
        {
            NDArray result = null;

            result = new NDArray(1, 1);
            result.Load(x.Data.Average());

            return result;
        }

        public static int GetNext()
        {
            return LayerIndex++;
        }

        //Basic Math Ops
        /// <summary>
        /// Add two tensor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray Add(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            Parallel.For(0, a.Elements, i =>
            {
                r[i] = a[i] + b[i];
            });

            return r;
        }

        /// <summary>
        /// Subtraction of two NDArray
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray Sub(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            Parallel.For(0, a.Elements, i =>
            {
                r[i] = a[i] - b[i];
            });

            return r;
        }

        /// <summary>
        /// Multiplication of two NDArray
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray Mul(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            Parallel.For(0, a.Elements, i =>
            {
                r[i] = a[i] * b[i];
            });

            return r;
        }

        /// <summary>
        /// Division of two NDArray
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray Div(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            Parallel.For(0, a.Elements, i =>
            {
                r[i] = a[i] / b[i];
            });

            return r;
        }

        /// <summary>
        /// Negates the values in the tensor
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static NDArray Neg(NDArray a)
        {
            NDArray r = new NDArray(a.Shape);

            Parallel.For(0, a.Elements, i =>
            {
                r[i] = -a[i];
            });

            return r;
        }

        public static NDArray ArgMax(NDArray x)
        {
            NDArray result = new NDArray(x.Shape[0], 1);

            Parallel.For(0, x.Shape[0], i =>
            {
                float maxVal = 0;
                float maxIndex = 0;

                Parallel.For(0, x.Shape[1], j =>
                {
                    if (x[i, j] > maxVal)
                    {
                        maxVal = x[i, j];
                        maxIndex = j;
                    }
                });

                result[i] = maxIndex;
            });

            return result;
        }

        public static NDArray SumY(NDArray x)
        {
            NDArray result = new NDArray(x.Shape[0], 1);

            Parallel.For(0, x.Shape[0], i =>
            {
                Parallel.For(0, x.Shape[1], j =>
                {
                    result[i] += x[i, j];
                });
            });

            return result;
        }

        public static NDArray MaxY(NDArray x)
        {
            NDArray result = new NDArray(x.Shape[0], 1);

            Parallel.For(0, x.Shape[0], i =>
            {
                float maxVal = 0;
                Parallel.For(0, x.Shape[1], j =>
                {
                    if (x[i, j] > maxVal)
                    {
                        maxVal = x[i, j];
                    }
                });

                result[i] = maxVal;
            });

            return result;
        }

        public static NDArray Softmax(NDArray x)
        {
            var e = Exp(x - MaxY(x));
            var s = SumY(e);
            return e / s;
        }
    }
}
