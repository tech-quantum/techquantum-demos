using Deedle;
using NeuroSimple.Cost;
using NeuroSimple.Layers;
using NeuroSimple.Metrics;
using NeuroSimple.Optimizers;
using System;
using System.Diagnostics;
using System.Linq;

namespace NeuroSimple.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new NDArray(3, 3);
            x.Load(1, 2, -3, 4, -5, 6, 7, -8, 9);
            Operations.Softmax(x).Print();
            //TrainMINST();
            Console.ReadLine();
        }

        private static void TrainMINST()
        {
            var model = new NeuralNet(new Adam(), new MeanSquaredError(), new MeanAbsoluteError());
            model.Add(new FullyConnected(13, 784, "relu"));
            model.Add(new FullyConnected(784, 784, "relu"));
            model.Add(new FullyConnected(784, 1));

            model.EpochEnd += Model_EpochEnd;

            var (x, y) = LoadTrain();

            model.Train(x, y, 25, 32);
        }

        private static void Model_EpochEnd(object sender, EpochEndEventArgs e)
        {
            Console.WriteLine(string.Format("Iteration: {0}, Loss: {1}, Metric: {2}, Duration: {3}"
                                , e.Epoch, e.Loss, e.Metric, e.Duration));
        }

        private static (NDArray, NDArray) LoadTrain()
        {
            //Using deedle which is similar to Pandas in python
            var frame = Frame.ReadCsv("train.csv", true);
            frame.DropColumn("ID");
            
            //Load Deedle frame to Tensor frame

            var yData = frame.GetColumn<float>("medv", Lookup.Exact).Values.ToArray();
            frame.DropColumn("medv");
            var data = frame.ToArray2D<float>().Cast<float>().ToArray();

            var x = new NDArray(frame.RowCount, frame.ColumnCount);
            x.Load(data);

            var y = new NDArray(frame.RowCount, 1);
            y.Load(yData);
            return (x, y);
        }
    }
}
