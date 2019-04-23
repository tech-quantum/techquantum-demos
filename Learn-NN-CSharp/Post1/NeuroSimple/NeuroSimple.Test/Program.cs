using System;

namespace NeuroSimple.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations K = new Operations();

            //Load array to the tensor
            NDArray a = new NDArray(3, 6);
            a.Load(1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 8, 7, 6, 5, 4, 3, 2, 1);
            a.Print("Load array");

            //Transpose of the matrix
            NDArray t = a.Transpose();
            t.Print("Transpose");

            //Create a tensor with all value 5
            NDArray b = new NDArray(6, 3);
            b.Fill(5);
            b.Print("Constant 5");

            //Create a tensor with all value 3
            NDArray c = new NDArray(6, 3);
            c.Fill(3);
            c.Print("Constant 3");

            // Subtract two tensor
            b = b - c;

            //Perform dot product
            NDArray r = K.Dot(a, b);
            r.Print("Dot product");

            Console.ReadLine();
        }
    }
}
