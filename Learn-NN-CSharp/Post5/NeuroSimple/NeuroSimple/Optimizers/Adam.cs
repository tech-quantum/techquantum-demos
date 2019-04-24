using System;
using System.Collections.Generic;
using System.Text;
using NeuroSimple.Layers;
using System.Linq;

namespace NeuroSimple.Optimizers
{
    /// <summary>
    /// Adam is an optimization algorithm that can used instead of the classical stochastic gradient descent procedure to update network weights iterative based in training data.
    /// <para>
    /// Adam was presented by Diederik Kingma from OpenAI and Jimmy Ba from the University of Toronto in their 2015 ICLR paper(poster) titled “Adam: A Method for Stochastic Optimization“. 
    /// I will quote liberally from their paper in this post, unless stated otherwise.
    /// </para>
    /// </summary>
    public class Adam : BaseOptimizer
    {
        /// <summary>
        /// Gets or sets the beta 1 value.
        /// </summary>
        /// <value>
        /// The beta1.
        /// </value>
        public double Beta1 { get; set; }

        /// <summary>
        /// Gets or sets the beta 2 value.
        /// </summary>
        /// <value>
        /// The beta2.
        /// </value>
        public double Beta2 { get; set; }

        private Dictionary<string, NDArray> ms;
        private Dictionary<string, NDArray> vs;

        public Adam(double lr = 0.01, double beta_1 = 0.9, double beta_2 = 0.999, double decayRate = 0) : base(lr, "adam")
        {
            Beta1 = beta_1;
            Beta2 = beta_2;
            DecayRate = decayRate;
            ms = new Dictionary<string, NDArray>();
            vs = new Dictionary<string, NDArray>();
        }

        public override void Update(int iteration, BaseLayer layer)
        {
            if (DecayRate > 0)
            {
                LearningRate = LearningRate * (1 / (1 + DecayRate * iteration));
            }

            foreach (var p in layer.Parameters.ToList())
            {
                string paramName = p.Key;
                NDArray param = p.Value;
                NDArray grad = layer.Grads[paramName];

                if (!ms.ContainsKey(paramName))
                {
                    var ms_new = new NDArray(param.Shape);
                    ms_new.Fill(0);
                    ms[paramName] = ms_new;
                }

                if (!vs.ContainsKey(paramName))
                {
                    var vs_new = new NDArray(param.Shape);
                    vs_new.Fill(0);
                    vs[paramName] = vs_new;
                }
                    
                ms[paramName] = (Beta1 * ms[paramName]) + (1 - Beta1) * grad;
                vs[paramName] = (Beta2 * vs[paramName]) + (1 - Beta2) * Square(grad);

                var m_cap = ms[paramName] / (1 - Math.Pow(Beta1, iteration));
                var v_cap = vs[paramName] / (1 - Math.Pow(Beta2, iteration));

                layer.Parameters[paramName] = param - (LearningRate * m_cap / (Sqrt(v_cap) + Epsilon));
            }
        }
    }
}
