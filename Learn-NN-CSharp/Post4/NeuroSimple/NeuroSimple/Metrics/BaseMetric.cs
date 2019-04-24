using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple.Metrics
{
    public abstract class BaseMetric : Operations
    {
        public string Name { get; set; }

        public BaseMetric(string name)
        {
            Name = name;
        }

        public abstract NDArray Calculate(NDArray preds, NDArray labels);
    }
}
