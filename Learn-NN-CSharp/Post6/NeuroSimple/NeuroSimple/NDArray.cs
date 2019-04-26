using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NeuroSimple
{
    public class NDArray
    {
        /// <summary>
        /// Variable to hold the data in form of array
        /// </summary>
        private double[] variable;

        /// <summary>
        /// Shape of the dataset, can be anything from 1D, 2D or 3D. For 2D: (3, 5) which will be a matrix of size 3 x 5
        /// </summary>
        public int[] Shape
        {
            get;
            set;
        }

        /// <summary>
        /// The number of elements the array will hold.
        /// </summary>
        public int Elements
        {
            get
            {
                return Shape.Aggregate((a, b) => a * b);
            }
        }

        /// <summary>
        /// Declaration for the NDArray with Shape as parameter
        /// </summary>
        /// <param name="shape"></param>
        public NDArray(params int[] shape)
        {
            Shape = shape;
            variable = new double[Elements];
        }

        /// <summary>
        /// Helper function to load the data in the NDArray
        /// </summary>
        /// <param name="data"></param>
        public void Load(params double[] data)
        {
            variable = data;
        }

        /// <summary>
        /// Fill the array with constant value
        /// </summary>
        /// <param name="value"></param>
        public void Fill(double value)
        {
            for (int i = 0; i < Elements; i++)
            {
                variable[i] = value;
            }
        }

        /// <summary>
        /// Get the value at specific index
        /// </summary>
        /// <param name="indices"></param>
        /// <returns></returns>
        public double this[params int[] indices]
        {
            get
            {
                var strides = GetContiguousStride();
                long index = 0;
                for (int i = 0; i < indices.Length; ++i)
                {
                    index += indices[i] * strides[i];
                }

                return variable[index];
            }
            set
            {
                var strides = GetContiguousStride();
                long index = 0;
                for (int i = 0; i < indices.Length; ++i)
                {
                    index += indices[i] * strides[i];
                }

                variable[index] = value;
            }
        }

        /// <summary>
        /// Access or assign the value of the tensor using index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double this[int index]
        {
            get
            {
                return variable[index];
            }
            set
            {
                variable[index] = value;
            }
        }

        public int[] GetContiguousStride()
        {
            int acc = 1;
            var stride = new int[Shape.Length];

            for (int i = Shape.Length - 1; i >= 0; --i)
            {
                stride[i] = acc;
                acc *= Shape[i];
            }

            return stride;
        }

        /// <summary>
        /// Print the dataset in matrix form
        /// </summary>
        public void Print(string title = "")
        {
            if(!string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine(title);
            }

            Console.WriteLine("---------{0}----------", string.Join(" x ", Shape));
            for (int i = 0; i < Shape[0]; i++)
            {
                for (int j = 0; j < Shape[1]; j++)
                {
                    Console.Write(Math.Round(this[i, j], 2) + "  ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("-----------------------\n\n");
        }

        public double[] Data
        {
            get
            {
                return variable;
            }
        }

        /// <summary>
        /// Addition of two NDArray
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray operator +(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            for (int i = 0; i < a.Elements; i++)
            {
                r[i] = a[i] + b[i];
            }

            return r;
        }

        public static NDArray operator +(NDArray a, double b)
        {
            NDArray t_b = new NDArray(a.Shape);
            t_b.Fill(b);
            return a + t_b;
        }

        public static NDArray operator +(double a, NDArray b)
        {
            NDArray t_a = new NDArray(b.Shape);
            t_a.Fill(a);
            return t_a + b;
        }

        /// <summary>
        /// Subtraction of two NDArray
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray operator -(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            for (int i = 0; i < a.Elements; i++)
            {
                r[i] = a[i] - b[i];
            }

            return r;
        }

        public static NDArray operator -(NDArray a, double b)
        {
            NDArray t_b = new NDArray(a.Shape);
            t_b.Fill(b);
            return a - t_b;
        }

        public static NDArray operator -(double a, NDArray b)
        {
            NDArray t_a = new NDArray(b.Shape);
            t_a.Fill(a);
            return t_a - b;
        }

        /// <summary>
        /// Multiplication of two NDArray
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray operator *(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            for (int i = 0; i < a.Elements; i++)
            {
                r[i] = a[i] * b[i];
            }

            return r;
        }

        public static NDArray operator *(NDArray a, double b)
        {
            NDArray t_b = new NDArray(a.Shape);
            t_b.Fill(b);
            return a * t_b;
        }

        public static NDArray operator *(double a, NDArray b)
        {
            NDArray t_a = new NDArray(b.Shape);
            t_a.Fill(a);
            return t_a * b;
        }

        /// <summary>
        /// Division of two NDArray
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray operator /(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            for (int i = 0; i < a.Elements; i++)
            {
                r[i] = a[i] / b[i];
            }

            return r;
        }

        public static NDArray operator /(NDArray a, double b)
        {
            NDArray t_b = new NDArray(a.Shape);
            t_b.Fill(b);
            return a / t_b;
        }

        public static NDArray operator /(double a, NDArray b)
        {
            NDArray t_a = new NDArray(b.Shape);
            t_a.Fill(a);
            return t_a / b;
        }

        /// <summary>
        /// Negates the values in the tensor
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static NDArray operator -(NDArray a)
        {
            NDArray r = new NDArray(a.Shape);

            for (int i = 0; i < a.Elements; i++)
            {
                r[i] = -a[i];
            }

            return r;
        }

        /// <summary>
        /// Check a == b between two tensor elementwise
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray operator ==(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            for (int i = 0; i < a.Elements; i++)
            {
                r[i] = a[i] == b[i] ? 1 : 0;
            }

            return r;
        }

        public static NDArray operator ==(NDArray a, double b)
        {
            NDArray t_b = new NDArray(a.Shape);
            t_b.Fill(b);
            return a == t_b;
        }

        public static NDArray operator ==(double a, NDArray b)
        {
            NDArray t_a = new NDArray(b.Shape);
            t_a.Fill(a);
            return t_a == b;
        }

        /// <summary>
        /// Check a != b between two tensor elementwise
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray operator !=(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            for (int i = 0; i < a.Elements; i++)
            {
                r[i] = a[i] != b[i] ? 1 : 0;
            }

            return r;
        }

        public static NDArray operator !=(NDArray a, double b)
        {
            NDArray t_b = new NDArray(a.Shape);
            t_b.Fill(b);
            return a != t_b;
        }

        public static NDArray operator !=(double a, NDArray b)
        {
            NDArray t_a = new NDArray(b.Shape);
            t_a.Fill(a);
            return t_a != b;
        }

        /// <summary>
        /// Check a > b between two tensor elementwise
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray operator >(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            for (int i = 0; i < a.Elements; i++)
            {
                r[i] = a[i] > b[i] ? 1 : 0;
            }

            return r;
        }

        public static NDArray operator >(NDArray a, double b)
        {
            NDArray t_b = new NDArray(a.Shape);
            t_b.Fill(b);
            return a > t_b;
        }

        public static NDArray operator >(double a, NDArray b)
        {
            NDArray t_a = new NDArray(b.Shape);
            t_a.Fill(a);
            return t_a > b;
        }

        /// <summary>
        /// Check a >= b between two tensor elementwise
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray operator >=(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            for (int i = 0; i < a.Elements; i++)
            {
                r[i] = a[i] >= b[i] ? 1 : 0;
            }

            return r;
        }

        public static NDArray operator >=(NDArray a, double b)
        {
            NDArray t_b = new NDArray(a.Shape);
            t_b.Fill(b);
            return a >= t_b;
        }

        public static NDArray operator >=(double a, NDArray b)
        {
            NDArray t_a = new NDArray(b.Shape);
            t_a.Fill(a);
            return t_a >= b;
        }

        /// <summary>
        /// Check a < b between two tensor elementwise
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray operator <(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            for (int i = 0; i < a.Elements; i++)
            {
                r[i] = a[i] < b[i] ? 1 : 0;
            }

            return r;
        }

        public static NDArray operator <(NDArray a, double b)
        {
            NDArray t_b = new NDArray(a.Shape);
            t_b.Fill(b);
            return a < t_b;
        }

        public static NDArray operator <(double a, NDArray b)
        {
            NDArray t_a = new NDArray(b.Shape);
            t_a.Fill(a);
            return t_a < b;
        }

        /// <summary>
        /// Check a <= b between two tensor elementwise
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static NDArray operator <=(NDArray a, NDArray b)
        {
            NDArray r = new NDArray(a.Shape);

            for (int i = 0; i < a.Elements; i++)
            {
                r[i] = a[i] >= b[i] ? 1 : 0;
            }

            return r;
        }

        public static NDArray operator <=(NDArray a, double b)
        {
            NDArray t_b = new NDArray(a.Shape);
            t_b.Fill(b);
            return a <= t_b;
        }

        public static NDArray operator <=(double a, NDArray b)
        {
            NDArray t_a = new NDArray(b.Shape);
            t_a.Fill(a);
            return t_a <= b;
        }

        /// <summary>
        /// Transpose the axis of 2D array generally referred to matrix transpose
        /// </summary>
        /// <returns></returns>
        public NDArray Transpose()
        {
            Operations operations = new Operations();
            return operations.Transpose(this);
        }

        public NDArray Slice(int start, int count)
        {
            start = Shape[1] * start;
            count = Shape[1] * count;

            var slicedData = variable.Skip(start).Take(count).ToArray();

            NDArray result = new NDArray((slicedData.Length / Shape[1]), Shape[1]);
            result.Load(slicedData);
            return result;
        }

        public bool Next(int start, int count)
        {
            if (start >= variable.Length)
            {
                return false;
            }

            return true;
        }
    }
}
