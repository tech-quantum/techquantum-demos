namespace QuantumGates
{
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Primitive;

    operation SetQ (desired: Result, q: Qubit) : Unit
    {
        let current = M(q);
        if (desired != current)
        {
            X(q);
        }
    }

    operation HardmadGate (input: Result) : Int {
        mutable output = 0;
        using (q = Qubit()) {
            SetQ(input, q);
            H(q);

            let res = M(q);
            if(res == One)
            {
                set output = 1;
            }

            SetQ(Zero, q);
        }

        return output;
    }

    operation PauliXGate (input: Result) : Int {
        mutable output = 0;
        using (q = Qubit()) {
            SetQ(input, q);
            H(q);
            X(q);

            let res = M(q);
            if(res == One)
            {
                set output = 1;
            }

            SetQ(Zero, q);
        }

        return output;
    }

    operation PauliYGate (input: Result) : Int {
        mutable output = 0;
        using (q = Qubit()) {
            SetQ(input, q);
            H(q);
            X(q);
            Y(q);

            let res = M(q);
            if(res == One)
            {
                set output = 1;
            }

            SetQ(Zero, q);
        }

        return output;
    }
}
