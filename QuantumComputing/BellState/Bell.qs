namespace BellState
{
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Primitive;

    //Set operation to set the Qubit to a initial value (One or Zero)
    operation SetQ (desired: Result, q1: Qubit) : Unit {
        //Get the current Qubit state
        let current = M(q1);

        //Check if the current and desired state is not equal
        if(current != desired)
        {
            //Flip the state to the desired state
            X(q1);
        }
    }

    //Oeration to count the number of times Zero or One was measured from the Qubit
    operation BellTest (count: Int, initial: Result) : (Int, Int){
        //Initiate counter which is defined mutable means the value can be changed
        mutable numOnes = 0;

        //Use a Qubit
        using(qubit = Qubit())
        {
            //Loop till the count specified
            for(test in 1..count)
            {
                //Set the initial value of the Qubit
                SetQ(initial, qubit);

                //Measure the current state of the Qubit
                let res = M(qubit);

                //Count the number of One's measured by increamentin the numOnes
                if(res == One)
                {
                    set numOnes = numOnes + 1;
                }
            }

            //Reset the Qubit to initial value
            SetQ(Zero, qubit);
        }

        //Return the tuple of result with no. of zero's and one's observered
        return (count - numOnes, numOnes);
    }

    //Oeration to count the number of times Zero or One was measured from the Qubit
    //Manipulate the Qubit by creating superposition and then measure the value
    operation BellTestWithSuperposition (count: Int, initial: Result) : (Int, Int){
        //Initiate counter which is defined mutable means the value can be changed
        mutable numOnes = 0;

        //Use a Qubit
        using(qubit = Qubit())
        {
            //Loop till the count specified
            for(test in 1..count)
            {
                //Set the initial value of the Qubit
                SetQ(initial, qubit);

                //Hadamard gate to flip the qubit between 0 and 1 creating superposition
                H(qubit);

                //Measure the current state of the Qubit
                let res = M(qubit);

                //Count the number of One's measured by increamentin the numOnes
                if(res == One)
                {
                    set numOnes = numOnes + 1;
                }
            }

            //Reset the Qubit to initial value
            SetQ(Zero, qubit);
        }

        //Return the tuple of result with no. of zero's and one's observered
        return (count - numOnes, numOnes);
    }

    //Oeration to count the number of times Zero or One was measured from the Qubit
    //Manipulate the Qubit by creating superposition and then measure the value
    //showcase the theory of entanglement
    operation BellTestWithSuperpositionAndEntanglement (count: Int, initial: Result) : (Int, Int, Int){
        //Initiate counter which is defined mutable means the value can be changed
        mutable numOnes = 0;
        mutable agree = 0;

        //Use two Qubit
        using(qubit = Qubit[2])
        {
            //Loop till the count specified
            for(test in 1..count)
            {
                //Set the initial value of the Qubit
                SetQ(initial, qubit[0]);
                SetQ(Zero, qubit[0]);

                //Hadamard gate to flip the qubit between 0 and 1 creating superposition
                H(qubit[0]);

                //Entagle the first qubit with the second one
                CNOT(qubit[0], qubit[1]);

                //Measure the current state of the Qubit 0
                let res = M(qubit[0]);

                if(M(qubit[1]) == res)
                {
                    set agree = agree + 1;
                }

                //Count the number of One's measured by increamentin the numOnes
                if(res == One)
                {
                    set numOnes = numOnes + 1;
                }
            }

            //Reset the Qubits to initial value
            SetQ(Zero, qubit[0]);
            SetQ(Zero, qubit[1]);
        }

        //Return the tuple of result with no. of zero's and one's observered
        return (count - numOnes, numOnes, agree);
    }
}
