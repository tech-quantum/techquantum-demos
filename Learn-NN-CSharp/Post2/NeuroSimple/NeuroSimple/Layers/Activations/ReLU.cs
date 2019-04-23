using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple.Layers.Activations
{
    public class ReLU : BaseActivation
    {
        public ReLU() : base("relu")
        {

        }

        public override void Forward(NDArray x)
        {
            base.Forward(x);

            NDArray matches = x > 0;
            Output = matches * x;
        }
    }
}
