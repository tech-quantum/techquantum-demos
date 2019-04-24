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
            x.Load(2, 4, 6, 1, 3, 5, 2, 3, 5);
            x.Print("Load X Values");

            NDArray y = new NDArray(3, 1);
            y.Load(1, 0, 1);
            y.Print("Load Y Values");

            //Create two layers, one with 6 neurons and another with 1
            FullyConnected fc1 = new FullyConnected(3, 6, "relu");
            FullyConnected fc2 = new FullyConnected(6, 1, "sigmoid");

            //Connect input by passing data from one layer to another
            fc1.Forward(x);
            fc2.Forward(fc1.Output);
            var preds = fc2.Output;
            preds.Print("Predictions");

            //Calculate the mean square error cost between the predicted and expected values
            BaseCost cost = new BinaryCrossEntropy();
            var costValues = cost.Forward(preds, y);
            costValues.Print("BCE Cost");

            //Calculate the mean absolute metric value for the predicted vs expected values
            BaseMetric metric = new BinaryAccuacy();
            var metricValues = metric.Calculate(preds, y);
            metricValues.Print("Acc Metric");

            var grad = cost.Backward(preds, y);
            fc2.Backward(grad);
            fc1.Backward(fc2.InputGrad);
            fc1.PrintParams();

            Console.ReadLine();
        }
    }
}
