#pragma warning disable 1591
using System;
using Microsoft.Quantum.Core;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;

[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"QuantumGates\",\"Name\":\"SetQ\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/QuantumGates/Operations.qs\",\"Position\":{\"Item1\":5,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":15}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"desired\"]},\"Type\":{\"Case\":\"Result\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":17},\"Item2\":{\"Line\":1,\"Column\":24}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"q\"]},\"Type\":{\"Case\":\"Qubit\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":34},\"Item2\":{\"Line\":1,\"Column\":35}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Result\"},{\"Case\":\"Qubit\"}]]},\"ReturnType\":{\"Case\":\"UnitType\"},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"QuantumGates\",\"Name\":\"SetQ\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/QuantumGates/Operations.qs\",\"Position\":{\"Item1\":5,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":15}},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"QuantumGates\",\"Name\":\"HardmadGate\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/QuantumGates/Operations.qs\",\"Position\":{\"Item1\":14,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":22}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"input\"]},\"Type\":{\"Case\":\"Result\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":24},\"Item2\":{\"Line\":1,\"Column\":29}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"Result\"},\"ReturnType\":{\"Case\":\"Int\"},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"QuantumGates\",\"Name\":\"HardmadGate\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/QuantumGates/Operations.qs\",\"Position\":{\"Item1\":14,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":22}},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"QuantumGates\",\"Name\":\"PauliXGate\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/QuantumGates/Operations.qs\",\"Position\":{\"Item1\":32,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":21}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"input\"]},\"Type\":{\"Case\":\"Result\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":23},\"Item2\":{\"Line\":1,\"Column\":28}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"Result\"},\"ReturnType\":{\"Case\":\"Int\"},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"QuantumGates\",\"Name\":\"PauliXGate\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/QuantumGates/Operations.qs\",\"Position\":{\"Item1\":32,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":21}},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"QuantumGates\",\"Name\":\"PauliYGate\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/QuantumGates/Operations.qs\",\"Position\":{\"Item1\":51,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":21}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"input\"]},\"Type\":{\"Case\":\"Result\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":23},\"Item2\":{\"Line\":1,\"Column\":28}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"Result\"},\"ReturnType\":{\"Case\":\"Int\"},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"QuantumGates\",\"Name\":\"PauliYGate\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/QuantumGates/Operations.qs\",\"Position\":{\"Item1\":51,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":21}},\"Documentation\":[]}")]
#line hidden
namespace QuantumGates
{
    public class SetQ : Operation<(Result,Qubit), QVoid>, ICallable
    {
        public SetQ(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Result,Qubit)>, IApplyData
        {
            public In((Result,Qubit) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits
            {
                get
                {
                    yield return Data.Item2;
                }
            }
        }

        String ICallable.Name => "SetQ";
        String ICallable.FullName => "QuantumGates.SetQ";
        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        public override Func<(Result,Qubit), QVoid> Body => (__in) =>
        {
            var (desired,q) = __in;
#line 8 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
            var current = M.Apply(q);
#line 9 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
            if ((desired != current))
            {
#line 11 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                MicrosoftQuantumPrimitiveX.Apply(q);
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
        }

        public override IApplyData __dataIn((Result,Qubit) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Result desired, Qubit q)
        {
            return __m__.Run<SetQ, (Result,Qubit), QVoid>((desired, q));
        }
    }

    public class HardmadGate : Operation<Result, Int64>, ICallable
    {
        public HardmadGate(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "HardmadGate";
        String ICallable.FullName => "QuantumGates.HardmadGate";
        protected Allocate Allocate
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected ICallable<(Result,Qubit), QVoid> SetQ
        {
            get;
            set;
        }

        public override Func<Result, Int64> Body => (__in) =>
        {
            var input = __in;
#line 16 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
            var output = 0L;
#line hidden
            {
#line 17 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                var q = Allocate.Apply();
#line 18 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                SetQ.Apply((input, q));
#line 19 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                MicrosoftQuantumPrimitiveH.Apply(q);
#line 21 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                var res = M.Apply(q);
#line 22 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                if ((res == Result.One))
                {
#line 24 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                    output = 1L;
                }

#line 27 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                SetQ.Apply((Result.Zero, q));
#line hidden
                Release.Apply(q);
            }

#line 30 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
            return output;
        }

        ;
        public override void Init()
        {
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.SetQ = this.Factory.Get<ICallable<(Result,Qubit), QVoid>>(typeof(SetQ));
        }

        public override IApplyData __dataIn(Result data) => new QTuple<Result>(data);
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__, Result input)
        {
            return __m__.Run<HardmadGate, Result, Int64>(input);
        }
    }

    public class PauliXGate : Operation<Result, Int64>, ICallable
    {
        public PauliXGate(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "PauliXGate";
        String ICallable.FullName => "QuantumGates.PauliXGate";
        protected Allocate Allocate
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        protected ICallable<(Result,Qubit), QVoid> SetQ
        {
            get;
            set;
        }

        public override Func<Result, Int64> Body => (__in) =>
        {
            var input = __in;
#line 34 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
            var output = 0L;
#line hidden
            {
#line 35 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                var q = Allocate.Apply();
#line 36 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                SetQ.Apply((input, q));
#line 37 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                MicrosoftQuantumPrimitiveH.Apply(q);
#line 38 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                MicrosoftQuantumPrimitiveX.Apply(q);
#line 40 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                var res = M.Apply(q);
#line 41 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                if ((res == Result.One))
                {
#line 43 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                    output = 1L;
                }

#line 46 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                SetQ.Apply((Result.Zero, q));
#line hidden
                Release.Apply(q);
            }

#line 49 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
            return output;
        }

        ;
        public override void Init()
        {
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
            this.SetQ = this.Factory.Get<ICallable<(Result,Qubit), QVoid>>(typeof(SetQ));
        }

        public override IApplyData __dataIn(Result data) => new QTuple<Result>(data);
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__, Result input)
        {
            return __m__.Run<PauliXGate, Result, Int64>(input);
        }
    }

    public class PauliYGate : Operation<Result, Int64>, ICallable
    {
        public PauliYGate(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "PauliYGate";
        String ICallable.FullName => "QuantumGates.PauliYGate";
        protected Allocate Allocate
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveY
        {
            get;
            set;
        }

        protected ICallable<(Result,Qubit), QVoid> SetQ
        {
            get;
            set;
        }

        public override Func<Result, Int64> Body => (__in) =>
        {
            var input = __in;
#line 53 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
            var output = 0L;
#line hidden
            {
#line 54 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                var q = Allocate.Apply();
#line 55 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                SetQ.Apply((input, q));
#line 56 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                MicrosoftQuantumPrimitiveH.Apply(q);
#line 57 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                MicrosoftQuantumPrimitiveX.Apply(q);
#line 58 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                MicrosoftQuantumPrimitiveY.Apply(q);
#line 60 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                var res = M.Apply(q);
#line 61 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                if ((res == Result.One))
                {
#line 63 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                    output = 1L;
                }

#line 66 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
                SetQ.Apply((Result.Zero, q));
#line hidden
                Release.Apply(q);
            }

#line 69 "C:\\git\\tech-quantum\\QuantumComputing\\QuantumGates\\Operations.qs"
            return output;
        }

        ;
        public override void Init()
        {
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
            this.MicrosoftQuantumPrimitiveY = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.Y));
            this.SetQ = this.Factory.Get<ICallable<(Result,Qubit), QVoid>>(typeof(SetQ));
        }

        public override IApplyData __dataIn(Result data) => new QTuple<Result>(data);
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__, Result input)
        {
            return __m__.Run<PauliYGate, Result, Int64>(input);
        }
    }
}