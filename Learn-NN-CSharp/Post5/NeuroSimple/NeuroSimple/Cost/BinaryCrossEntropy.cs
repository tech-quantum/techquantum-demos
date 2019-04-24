using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple.Cost
{
    public class BinaryCrossEntropy : BaseCost
    {
        public BinaryCrossEntropy() : base("binary_crossentropy")
        {
            
        }

        public override NDArray Forward(NDArray preds, NDArray labels)
        {
            var output = Clip(preds, Epsilon, 1 - Epsilon);

            output = Mean(-(labels * Log(output) + (1 - labels) * Log(1 - output)));
            return output;
        }

        public override NDArray Backward(NDArray preds, NDArray labels)
        {
            return (preds - labels) / (preds * (1 - preds));
        }
    }
}
