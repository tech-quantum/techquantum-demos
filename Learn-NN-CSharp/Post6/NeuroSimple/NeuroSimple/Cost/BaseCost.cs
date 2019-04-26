using NeuroSimple.Layers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple.Cost
{
    public abstract class BaseCost : Operations
    {
        public string Name { get; set; }

        public BaseCost(string name)
        {
            Name = name;
        }

        public abstract NDArray Forward(NDArray preds, NDArray labels);

        public abstract NDArray Backward(NDArray preds, NDArray labels);
    }
}
