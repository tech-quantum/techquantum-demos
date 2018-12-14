using System;

using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace QuantumGates
{
    class Driver
    {
        static void Main(string[] args)
        {
            using (var qsim = new QuantumSimulator())
            {
                var res = PauliYGate.Run(qsim, Result.Zero).Result;
                Console.WriteLine("Measured Result: " + res);
                Console.ReadLine();
            }
        }
    }
}