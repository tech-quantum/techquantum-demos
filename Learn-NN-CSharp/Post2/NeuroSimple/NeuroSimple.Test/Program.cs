using NeuroSimple.Layers;
using System;

namespace NeuroSimple.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load array to the tensor
            NDArray x = new NDArray(1, 3);
            x.Load(1, 2, 3);
            x.Print("Load array");

            //Create two layers, one with 6 neurons and another with 1
            FullyConnected fc1 = new FullyConnected(3, 6, "relu");
            FullyConnected fc2 = new FullyConnected(6, 1, "sigmoid");

            //Connect input by passing data from one layer to another
            fc1.Forward(x);
            x = fc1.Output;
            x.Print("FC1 Output");

            fc2.Forward(x);
            x = fc2.Output;
            x.Print("FC2 Output");

            Console.ReadLine();
        }
    }
}
