using NeuroSimple.Layers.Activations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple.Layers
{
    /// <summary>
    /// Fully connected layer
    /// </summary>
    public class FullyConnected: BaseLayer
    {
        /// <summary>
        /// Number of incoming input features
        /// </summary>
        public int InputDim { get; set; }

        /// <summary>
        /// Number of neurons for this layers
        /// </summary>
        public int OutNeurons { get; set; }

        /// <summary>
        /// Non Linear Activation function for this layer of neurons. All neurons will have the same function
        /// </summary>
        public BaseActivation Activation { get; set; }

        /// <summary>
        /// Constructor with in and out parametes
        /// </summary>
        /// <param name="in">Number of incoming input features</param>
        /// <param name="out">Number of neurons for this layers</param>
        public FullyConnected(int input_dim, int output_neurons, string act) : base("fc")
        {
            Parameters["w"] = RandomVariable(input_dim, output_neurons);
            InputDim = input_dim;
            OutNeurons = output_neurons;

            Activation = BaseActivation.Get(act);
        }

        /// <summary>
        /// Forward the input data by performing calculation across all the neurons, store it in the Output to be accessible by next layer.
        /// </summary>
        /// <param name="x"></param>
        public override void Forward(NDArray x)
        {
            base.Forward(x);
            Output = Dot(x, Parameters["w"]);

            if(Activation!=null)
            {
                Activation.Forward(Output);
                Output = Activation.Output;
            }
        }

        /// <summary>
        /// Calculate the gradient of the layer. Usually a prtial derivative implemenation of the forward algorithm
        /// </summary>
        /// <param name="grad"></param>
        public override void Backward(NDArray grad)
        {
            InputGrad = Dot(grad, Parameters["w"].Transpose());
            Grads["w"] = Dot(Input.Transpose(), grad);
        }
    }
}
