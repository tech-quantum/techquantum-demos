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
                int index = 0;
                
                for (int i = 0; i < indices.Length; i++)
                {
                    index += (indices[i] * (i + 1));
                }

                return variable[index];
            }
            set
            {
                int index = 0;
                for (int i = 0; i < indices.Length; i++)
                {
                    index += indices[i] * (i + 1);
                }

                variable[index] = value;
            }
        }

        /// <summary>
        /// Print the dataset in matrix form
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < Shape[0]; i++)
            {
                for (int j = 0; j < Shape[1]; j++)
                {
                    Console.Write(this[i, j] + "\t");
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
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

        /// <summary>
        /// Transpose the axis of 2D array generally referred to matrix transpose
        /// </summary>
        /// <returns></returns>
        public NDArray Transpose()
        {
            Operations operations = new Operations();
            return operations.Transpose(this);
        }
    }
}
