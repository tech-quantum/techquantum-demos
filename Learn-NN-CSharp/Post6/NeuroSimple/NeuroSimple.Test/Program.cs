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

            NDArray y = new NDArray(4, 1);
            y.Load(0, 1, 1, 0);

            var optimizer = new Adam();
            var cost = new BinaryCrossEntropy();
            var metric = new BinaryAccuacy();
            NeuralNet model = new NeuralNet(optimizer, cost, metric);
            model.Add(new FullyConnected(2, 4, "relu"));
            //model.Add(new FullyConnected(20, 16, "relu"));
            model.Add(new FullyConnected(4, 1, "sigmoid"));

            model.Train(x, y, 1000, 4);

            Console.ReadLine();
        }
    }
}
