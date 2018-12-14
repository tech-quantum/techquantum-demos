#pragma warning disable 1591
using System;
using Microsoft.Quantum.Core;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;

[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"BellState\",\"Name\":\"SetQ\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/BellState/Bell.qs\",\"Position\":{\"Item1\":6,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":15}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"desired\"]},\"Type\":{\"Case\":\"Result\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":17},\"Item2\":{\"Line\":1,\"Column\":24}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"q1\"]},\"Type\":{\"Case\":\"Qubit\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":34},\"Item2\":{\"Line\":1,\"Column\":36}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Result\"},{\"Case\":\"Qubit\"}]]},\"ReturnType\":{\"Case\":\"UnitType\"},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"BellState\",\"Name\":\"SetQ\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/BellState/Bell.qs\",\"Position\":{\"Item1\":6,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":15}},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"BellState\",\"Name\":\"BellTest\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/BellState/Bell.qs\",\"Position\":{\"Item1\":19,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":19}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"count\"]},\"Type\":{\"Case\":\"Int\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":21},\"Item2\":{\"Line\":1,\"Column\":26}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"initial\"]},\"Type\":{\"Case\":\"Result\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":33},\"Item2\":{\"Line\":1,\"Column\":40}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Int\"},{\"Case\":\"Result\"}]]},\"ReturnType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Int\"},{\"Case\":\"Int\"}]]},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"BellState\",\"Name\":\"BellTest\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/BellState/Bell.qs\",\"Position\":{\"Item1\":19,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":19}},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"BellState\",\"Name\":\"BellTestWithSuperposition\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/BellState/Bell.qs\",\"Position\":{\"Item1\":52,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":36}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"count\"]},\"Type\":{\"Case\":\"Int\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":38},\"Item2\":{\"Line\":1,\"Column\":43}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"initial\"]},\"Type\":{\"Case\":\"Result\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":50},\"Item2\":{\"Line\":1,\"Column\":57}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Int\"},{\"Case\":\"Result\"}]]},\"ReturnType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Int\"},{\"Case\":\"Int\"}]]},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"BellState\",\"Name\":\"BellTestWithSuperposition\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/BellState/Bell.qs\",\"Position\":{\"Item1\":52,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":36}},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"BellState\",\"Name\":\"BellTestWithSuperpositionAndEntanglement\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/BellState/Bell.qs\",\"Position\":{\"Item1\":89,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":51}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"count\"]},\"Type\":{\"Case\":\"Int\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":53},\"Item2\":{\"Line\":1,\"Column\":58}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"initial\"]},\"Type\":{\"Case\":\"Result\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":65},\"Item2\":{\"Line\":1,\"Column\":72}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Int\"},{\"Case\":\"Result\"}]]},\"ReturnType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Int\"},{\"Case\":\"Int\"},{\"Case\":\"Int\"}]]},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"BellState\",\"Name\":\"BellTestWithSuperpositionAndEntanglement\"},\"SourceFile\":\"C:/git/tech-quantum/QuantumComputing/BellState/Bell.qs\",\"Position\":{\"Item1\":89,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":51}},\"Documentation\":[]}")]
#line hidden
namespace BellState
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
        String ICallable.FullName => "BellState.SetQ";
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
            var (desired,q1) = __in;
#line 9 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
            var current = M.Apply(q1);
#line 12 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
            if ((current != desired))
            {
#line 15 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                MicrosoftQuantumPrimitiveX.Apply(q1);
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
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Result desired, Qubit q1)
        {
            return __m__.Run<SetQ, (Result,Qubit), QVoid>((desired, q1));
        }
    }

    public class BellTest : Operation<(Int64,Result), (Int64,Int64)>, ICallable
    {
        public BellTest(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Result)>, IApplyData
        {
            public In((Int64,Result) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        public class Out : QTuple<(Int64,Int64)>, IApplyData
        {
            public Out((Int64,Int64) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "BellTest";
        String ICallable.FullName => "BellState.BellTest";
        protected ICallable<(Result,Qubit), QVoid> SetQ
        {
            get;
            set;
        }

        protected Allocate Allocate
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

        public override Func<(Int64,Result), (Int64,Int64)> Body => (__in) =>
        {
            var (count,initial) = __in;
#line 22 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
            var numOnes = 0L;
#line hidden
            {
#line 25 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                var qubit = Allocate.Apply();
#line 28 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                foreach (var test in new Range(1L, count))
#line hidden
                {
#line 31 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    SetQ.Apply((initial, qubit));
#line 34 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    var res = M.Apply(qubit);
#line 37 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    if ((res == Result.One))
                    {
#line 39 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                        numOnes = (numOnes + 1L);
                    }
                }

#line 44 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                SetQ.Apply((Result.Zero, qubit));
#line hidden
                Release.Apply(qubit);
            }

#line 48 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
            return ((count - numOnes), numOnes);
        }

        ;
        public override void Init()
        {
            this.SetQ = this.Factory.Get<ICallable<(Result,Qubit), QVoid>>(typeof(SetQ));
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
        }

        public override IApplyData __dataIn((Int64,Result) data) => new In(data);
        public override IApplyData __dataOut((Int64,Int64) data) => new Out(data);
        public static System.Threading.Tasks.Task<(Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<BellTest, (Int64,Result), (Int64,Int64)>((count, initial));
        }
    }

    public class BellTestWithSuperposition : Operation<(Int64,Result), (Int64,Int64)>, ICallable
    {
        public BellTestWithSuperposition(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Result)>, IApplyData
        {
            public In((Int64,Result) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        public class Out : QTuple<(Int64,Int64)>, IApplyData
        {
            public Out((Int64,Int64) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "BellTestWithSuperposition";
        String ICallable.FullName => "BellState.BellTestWithSuperposition";
        protected ICallable<(Result,Qubit), QVoid> SetQ
        {
            get;
            set;
        }

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

        public override Func<(Int64,Result), (Int64,Int64)> Body => (__in) =>
        {
            var (count,initial) = __in;
#line 55 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
            var numOnes = 0L;
#line hidden
            {
#line 58 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                var qubit = Allocate.Apply();
#line 61 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                foreach (var test in new Range(1L, count))
#line hidden
                {
#line 64 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    SetQ.Apply((initial, qubit));
#line 67 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    MicrosoftQuantumPrimitiveH.Apply(qubit);
#line 70 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    var res = M.Apply(qubit);
#line 73 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    if ((res == Result.One))
                    {
#line 75 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                        numOnes = (numOnes + 1L);
                    }
                }

#line 80 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                SetQ.Apply((Result.Zero, qubit));
#line hidden
                Release.Apply(qubit);
            }

#line 84 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
            return ((count - numOnes), numOnes);
        }

        ;
        public override void Init()
        {
            this.SetQ = this.Factory.Get<ICallable<(Result,Qubit), QVoid>>(typeof(SetQ));
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
        }

        public override IApplyData __dataIn((Int64,Result) data) => new In(data);
        public override IApplyData __dataOut((Int64,Int64) data) => new Out(data);
        public static System.Threading.Tasks.Task<(Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<BellTestWithSuperposition, (Int64,Result), (Int64,Int64)>((count, initial));
        }
    }

    public class BellTestWithSuperpositionAndEntanglement : Operation<(Int64,Result), (Int64,Int64,Int64)>, ICallable
    {
        public BellTestWithSuperpositionAndEntanglement(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Result)>, IApplyData
        {
            public In((Int64,Result) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        public class Out : QTuple<(Int64,Int64,Int64)>, IApplyData
        {
            public Out((Int64,Int64,Int64) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "BellTestWithSuperpositionAndEntanglement";
        String ICallable.FullName => "BellState.BellTestWithSuperpositionAndEntanglement";
        protected ICallable<(Result,Qubit), QVoid> SetQ
        {
            get;
            set;
        }

        protected Allocate Allocate
        {
            get;
            set;
        }

        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumPrimitiveCNOT
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

        public override Func<(Int64,Result), (Int64,Int64,Int64)> Body => (__in) =>
        {
            var (count,initial) = __in;
#line 92 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
            var numOnes = 0L;
#line 93 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
            var agree = 0L;
#line hidden
            {
#line 96 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                var qubit = Allocate.Apply(2L);
#line 99 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                foreach (var test in new Range(1L, count))
#line hidden
                {
#line 102 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    SetQ.Apply((initial, qubit[0L]));
#line 103 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    SetQ.Apply((Result.Zero, qubit[0L]));
#line 106 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    MicrosoftQuantumPrimitiveH.Apply(qubit[0L]);
#line 109 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    MicrosoftQuantumPrimitiveCNOT.Apply((qubit[0L], qubit[1L]));
#line 112 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    var res = M.Apply(qubit[0L]);
#line 114 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    if ((M.Apply(qubit[1L]) == res))
                    {
#line 116 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                        agree = (agree + 1L);
                    }

#line 120 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                    if ((res == Result.One))
                    {
#line 122 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                        numOnes = (numOnes + 1L);
                    }
                }

#line 127 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                SetQ.Apply((Result.Zero, qubit[0L]));
#line 128 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
                SetQ.Apply((Result.Zero, qubit[1L]));
#line hidden
                Release.Apply(qubit);
            }

#line 132 "C:\\git\\tech-quantum\\QuantumComputing\\BellState\\Bell.qs"
            return ((count - numOnes), numOnes, agree);
        }

        ;
        public override void Init()
        {
            this.SetQ = this.Factory.Get<ICallable<(Result,Qubit), QVoid>>(typeof(SetQ));
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumPrimitiveCNOT = this.Factory.Get<IUnitary<(Qubit,Qubit)>>(typeof(Microsoft.Quantum.Primitive.CNOT));
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
        }

        public override IApplyData __dataIn((Int64,Result) data) => new In(data);
        public override IApplyData __dataOut((Int64,Int64,Int64) data) => new Out(data);
        public static System.Threading.Tasks.Task<(Int64,Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<BellTestWithSuperpositionAndEntanglement, (Int64,Result), (Int64,Int64,Int64)>((count, initial));
        }
    }
}