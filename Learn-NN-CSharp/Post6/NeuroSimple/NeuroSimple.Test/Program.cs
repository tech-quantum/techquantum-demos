using NeuroSimple.Cost;
using NeuroSimple.Layers;
using NeuroSimple.Metrics;
using NeuroSimple.Optimizers;
using System;

namespace NeuroSimple.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations K = new Operations();

            //Load array to the tensor
            NDArray x = new NDArray(4, 2);
            x.Load(0, 0, 0, 1, 1, 0, 1, 1);
            x.Print("Load X Values");

            NDArray y = new NDArray(4, 1);
            y.Load(0, 1, 1, 0);
            y.Print("Load Y Values");

            var optimizer = new Adam();
            var cost = new BinaryCrossEntropy();
            var metric = new BinaryAccuacy();
            NNet model = new NNet(optimizer, cost, metric);
            model.Add(new FullyConnected(2, 32, "relu"));
            model.Add(new FullyConnected(32, 64, "relu"));
            model.Add(new FullyConnected(64, 1, "sigmoid"));

            model.Train(x, y, 100, 2);

            Console.ReadLine();
        }
    }
}
