using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple.Layers
{
    /// <summary>
    /// Base class for the layers with predefined variables and functions
    /// </summary>
    public abstract class BaseLayer : Operations
    {
        /// <summary>
        /// Name of the layer
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Input for the layer
        /// </summary>
        public NDArray Input { get; set; }

        /// <summary>
        /// Output after forwarding the input across the neurons
        /// </summary>
        public NDArray Output { get; set; }

        /// <summary>
        /// Trainable parameters list, eg, weight, bias
        /// </summary>
        public Dictionary<string, NDArray> Parameters { get; set; }

        /// <summary>
        /// Base layer instance
        /// </summary>
        /// <param name="name"></param>
        public BaseLayer(string name)
        {
            Name = name;
            Parameters = new Dictionary<string, NDArray>();
        }

        /// <summary>
        /// Virtual forward method to perform calculation and move the input to next layer
        /// </summary>
        /// <param name="x"></param>
        public virtual void Forward(NDArray x)
        {
            Input = x;
        }
    }
}
