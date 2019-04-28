using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple.Cost
{
    public class MeanSquaredError : BaseCost
    {
        public MeanSquaredError() : base("mean_squared_error")
        {
            
        }

        public override NDArray Forward(NDArray preds, NDArray labels)
        {
            var error = preds - labels;
            return Mean(Square(error));
        }

        public override NDArray Backward(NDArray preds, NDArray labels)
        {
            double norm = 2 / (double)preds.Shape[0];
            return norm * (preds - labels);
        }
    }
}
