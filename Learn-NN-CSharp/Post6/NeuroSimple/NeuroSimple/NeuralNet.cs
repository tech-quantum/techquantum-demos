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
    /// <summary>
    /// Sequential model builder with train and predict
    /// </summary>
    public class NeuralNet
    {
        /// <summary>
        /// Layers which the model will contain
        /// </summary>
        public List<BaseLayer> Layers { get; set; }

        /// <summary>
        /// The optimizer instance used during training
        /// </summary>
        public BaseOptimizer Optimizer { get; set; }

        /// <summary>
        /// The cost instance for the training
        /// </summary>
        public BaseCost Cost { get; set; }

        /// <summary>
        /// The metric instance for the training
        /// </summary>
        public BaseMetric Metric { get; set; }

        /// <summary>
        /// Training losses for all the iterations
        /// </summary>
        public List<double> TrainingLoss { get; set; }

        /// <summary>
        /// Training metrices for all the iterations
        /// </summary>
        public List<double> TrainingMetrics { get; set; }

        /// <summary>
        /// Create instanec of the nerural net with parameters
        /// </summary>
        /// <param name="optimizer"></param>
        /// <param name="cost"></param>
        /// <param name="metric"></param>
        public NeuralNet(BaseOptimizer optimizer, BaseCost cost, BaseMetric metric = null)
        {
            Layers = new List<BaseLayer>();
            TrainingLoss = new List<double>();
            TrainingMetrics = new List<double>();

            this.Optimizer = optimizer != null ? optimizer : throw new Exception("Need optimizer");
            this.Cost = cost != null ? cost : throw new Exception("Need cost");
            Metric = metric;
        }

        /// <summary>
        /// Helper method to stack layer
        /// </summary>
        /// <param name="layer"></param>
        public void Add(BaseLayer layer)
        {
            Layers.Add(layer);
        }

        /// <summary>
        /// Train the model with training dataset, for certain number of iterations and using batch size
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="numIterations"></param>
        /// <param name="batchSize"></param>
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

                    currentIndex = currentIndex + batchSize; ;
                }

                double batchLossAvg = Math.Round(batchLoss.Average(), 2);

                double batchMetricAvg = Metric != null ? Math.Round(batchMetrics.Average(), 2) : 0;

                TrainingLoss.Add(batchLossAvg);

                if(batchMetrics.Count > 0)
                    TrainingMetrics.Add(batchMetricAvg);

                if(Metric != null)
                    Console.WriteLine("Iteration: {0}, Loss: {1}, Metric: {2}", i, batchLossAvg, batchMetricAvg);
                else
                    Console.WriteLine("Iteration: {0}, Loss: {1}", i, batchLossAvg);
            }
        }

        /// <summary>
        /// Prediction method
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public NDArray Predict(NDArray x)
        {
            return Forward(x);
        }

        /// <summary>
        /// Internal method to execute forward method accross all the layers
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Internal method to execute back-propagation method accross all the layers
        /// </summary>
        /// <param name="gradOutput"></param>
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
