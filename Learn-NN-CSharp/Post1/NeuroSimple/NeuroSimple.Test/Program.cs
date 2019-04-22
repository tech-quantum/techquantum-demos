using System;

namespace NeuroSimple.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations K = new Operations();

            NDArray a = new NDArray(3, 3);
            a.Load(1, 2, 3, 4, 5, 6, 7, 8, 9);
            a.Print();

            NDArray r = K.Transpose(a);
            r.Print();

            Console.ReadLine();
        }
    }
}
