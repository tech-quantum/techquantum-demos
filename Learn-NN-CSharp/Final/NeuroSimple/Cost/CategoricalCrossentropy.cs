using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple.Cost
{
    public class CategoricalCrossentropy : BaseCost
    {
        public CategoricalCrossentropy() : base("categorical_crossentropy")
        {
            
        }

        public override NDArray Forward(NDArray preds, NDArray labels)
        {
            var output = Clip(preds, Epsilon, 1 - Epsilon);

            output = Mean(-(labels * Log(output)));
            return output;
        }

        public override NDArray Backward(NDArray preds, NDArray labels)
        {
            var output = Clip(preds, Epsilon, 1 - Epsilon);
            return (output - labels) / output;
        }
    }
}
