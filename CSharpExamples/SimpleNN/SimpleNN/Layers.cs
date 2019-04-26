using System;
using System.Collections.Generic;
using System.Numerics.Tensors;

namespace SimpleNN
{
    /// <summary>
    /// Abstract class for the NN Layer
    /// </summary>
    public abstract class NNLayer
    {
        public Matrix<double> Input { get; set; }

        public Matrix<double> Output { get; set; }

        public Dictionary<string, Matrix<double>> Params { get; set; }

        public Dictionary<string, Matrix<double>> Grads { get; set; }

        public NNLayer()
        {
            Params = new Dictionary<string, Matrix<double>>();
            Grads = new Dictionary<string, Matrix<double>>();
        }

        public virtual void Forward(Matrix<double> x)
        {
            Input = x;
        }

        public virtual void Backward(Matrix<double> grad)
        {

        }
    }

    public class FullyConnected : NNLayer
    {
        public FullyConnected(int sizeIn, int sizeOut)
        {
            
            
            var w = Matrix<double>.Build.Random(sizeIn, sizeOut, new ContinuousUniform(-1, 1)) / Math.Sqrt(sizeIn / 2);
            var b = Matrix<double>.Build.Dense(1, sizeOut, 0);
            Params.Add("w", w);
            Params.Add("b", b);
        }

        public override void Forward(Matrix<double> x)
        {
            base.Forward(x);

            Output = Matrix<double>.op_DotMultiply(x, Params["w"]);
        }

        public override void Backward(Matrix<double> dout)
        {
            Grads["w"] = Matrix<double>.op_DotMultiply(Input.Transpose(), dout);
        }
    }
}
