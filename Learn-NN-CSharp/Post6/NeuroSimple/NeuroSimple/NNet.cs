using NeuroSimple.Cost;
using NeuroSimple.Layers;
using NeuroSimple.Metrics;
using NeuroSimple.Optimizers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NeuroSimple
{
    public class NNet
    {
        public List<BaseLayer> Layers { get; set; }

        public BaseOptimizer Optimizer { get; set; }

        public BaseCost Cost { get; set; }

        public BaseMetric Metric { get; set; }

        public List<double> TrainingLoss { get; set; }

        public List<double> TrainingMetrics { get; set; }

        public NNet(BaseOptimizer optimizer, BaseCost cost, BaseMetric metric = null)
        {
            Layers = new List<BaseLayer>();
            this.Optimizer = optimizer != null ? optimizer : throw new Exception("Need optimizer");
            this.Cost = cost != null ? cost : throw new Exception("Need cost");
        }

        public void Add(BaseLayer layer)
        {
            Layers.Add(layer);
        }

        public void Train(NDArray x, NDArray y, int numIterations, int batchSize)
        {
            List<double> batchLoss = new List<double>();
            List<double> batchMetrics = new List<double>();

            for (int i = 1; i <= numIterations; i++)
            {
                int currentIndex = 0;
                batchLoss.Clear();
                batchMetrics.Clear();
                while (x.Next(currentIndex, batchSize))
                {
                    var xtrain = x.Slice(currentIndex, batchSize);
                    var ytrain = y.Slice(currentIndex, batchSize);

                    if (xtrain.Equals(null))
                        break;

                    var ypred = Forward(xtrain);

                    var costVal = Cost.Forward(ypred, ytrain);
                    batchLoss.AddRange(costVal.Data);

                    if (Metric != null)
                    {
                        var metric = Metric.Calculate(ypred, ytrain);
                        batchMetrics.AddRange(metric.Data);
                    }

                    var grad = Cost.Backward(ypred, ytrain);
                    Backward(grad);

                    foreach (var layer in Layers)
                    {
                        Optimizer.Update(i, layer);
                    }

                    currentIndex++;
                }

                TrainingLoss.Add(batchLoss.Average());

                if(batchMetrics.Count > 0)
                    TrainingMetrics.Add(batchMetrics.Average());

                Console.WriteLine("Iteration: {0}, Loss: {1}, Metric: {2}", i, Math.Round(batchLoss.Average(), 2), Math.Round(batchMetrics.Average(), 2));
            }
        }

        public NDArray Predict(NDArray x)
        {
            return Forward(x);
        }

        private NDArray Forward(NDArray x)
        {
            BaseLayer lastLayer = null;

            foreach (var layer in Layers)
            {
                if (lastLayer == null)
                    layer.Forward(x);
                else
                    layer.Forward(lastLayer.Output);

                lastLayer = layer;
            }

            return lastLayer.Output;
        }

        private void Backward(NDArray gradOutput)
        {
            var curGradOutput = gradOutput;
            for (int i = Layers.Count - 1; i >= 0; --i)
            {
                var layer = Layers[i];

                layer.Backward(curGradOutput);
                curGradOutput = layer.InputGrad;
            }
        }
    }
}
