using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple.Metrics
{
    public class MeanAbsoluteError : BaseMetric
    {
        public MeanAbsoluteError() : base("mean_absolute_error")
        {

        }

        public override NDArray Calculate(NDArray preds, NDArray labels)
        {
            var error = preds - labels;
            return Mean(Abs(error));
        }
    }
}
