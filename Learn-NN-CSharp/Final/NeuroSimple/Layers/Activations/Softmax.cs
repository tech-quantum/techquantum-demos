using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple.Layers.Activations
{
    public class Softmax : BaseActivation
    {
        public Softmax() : base("softmax")
        {

        }

        public override void Forward(NDArray x)
        {
            base.Forward(x);
            Output = 1 / (1 + Exp(-x));
        }

        public override void Backward(NDArray grad)
        {
            InputGrad = grad * Output * (1 - Output);
        }
    }
}
