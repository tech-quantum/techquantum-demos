using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroSimple.Metrics
{
    public class Accuacy : BaseMetric
    {
        public Accuacy() : base("accurary")
        {
        }

        public override NDArray Calculate(NDArray preds, NDArray labels)
        {
            var pred_idx = ArgMax(preds);
            var label_idx = ArgMax(labels);

            return Mean(pred_idx == label_idx);
        }
    }
}
