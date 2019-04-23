using NeuroSimple.Cost;
using NeuroSimple.Layers;
using NeuroSimple.Metrics;
using System;

namespace NeuroSimple.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations K = new Operations();

            //Load array to the tensor
            NDArray x = new NDArray(3, 3);
            x.Load(1, 2, 3, 4, 5, 6, 7, 8, 9);
            x.Print("Load X Values");

            NDArray y = new NDArray(3, 1);
            y.Load(3, 6, 9);
            y.Print("Load Y Values");

            //Create two layers, one with 6 neurons and another with 1
            FullyConnected fc1 = new FullyConnected(3, 6, "relu");
            FullyConnected fc2 = new FullyConnected(6, 1, "sigmoid");

            //Connect input by passing data from one layer to another
            fc1.Forward(x);
            x = fc1.Output;
            x.Print("FC1 Output");

            fc2.Forward(x);
            var preds = fc2.Output;
            preds.Print("FC2 Output");

            BaseCost cost = new MeanSquaredError();
            var costValues = cost.Forward(preds, y);
            costValues.Print("Cost");

            BaseMetric metric = new MeanAbsoluteError();
            var metricValues = metric.Calculate(preds, y);
            costValues.Print("Cost");

            Console.ReadLine();
        }
    }
}
