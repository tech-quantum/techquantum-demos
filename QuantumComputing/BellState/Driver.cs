using System;

using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace BellState
{
    class Driver
    {
        static void Main(string[] args)
        {
            //Load the simulator
            using (var qsim = new QuantumSimulator())
            {
                //Declare the initial values
                Result[] initials = new Result[] {Result.Zero, Result.One};

                //Loop through the initials
                foreach(Result initial in initials)
                {
                    //Run the BellTest operation for the initial value for 1000 loops
                    //var res = BellTest.Run(qsim, 1000, initial).Result;

                    //var res = BellTestWithSuperposition.Run(qsim, 1000, initial).Result;

                    var res = BellTestWithSuperpositionAndEntanglement.Run(qsim, 1000, initial).Result;

                    //Print the result
                    var (numZeros, numOnes, agree) = res;
                    System.Console.WriteLine(
                        $"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4} agree={agree,-4}");
                }
            }

            System.Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}