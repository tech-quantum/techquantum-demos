#pragma warning disable 1591
using System;
using Microsoft.Quantum.Core;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;

[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"BellState\",\"Name\":\"Set\"},\"SourceFile\":\"c:/git/tech-quantum/QuantumComputing/BellState/Operations.qs\",\"Position\":{\"Item1\":5,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":14}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"UnitType\"},\"ReturnType\":{\"Case\":\"UnitType\"},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"BellState\",\"Name\":\"Set\"},\"SourceFile\":\"c:/git/tech-quantum/QuantumComputing/BellState/Operations.qs\",\"Position\":{\"Item1\":5,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":14}},\"Documentation\":[]}")]
#line hidden
namespace BellState
{
    public class Set : Operation<QVoid, QVoid>, ICallable
    {
        public Set(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "Set";
        String ICallable.FullName => "BellState.Set";
        protected ICallable<String, QVoid> Message
        {
            get;
            set;
        }

        public override Func<QVoid, QVoid> Body => (__in) =>
        {
#line 7 "c:\\git\\tech-quantum\\QuantumComputing\\BellState\\Operations.qs"
            Message.Apply("Hello quantum world!");
#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.Message = this.Factory.Get<ICallable<String, QVoid>>(typeof(Microsoft.Quantum.Primitive.Message));
        }

        public override IApplyData __dataIn(QVoid data) => data;
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__)
        {
            return __m__.Run<Set, QVoid, QVoid>(QVoid.Instance);
        }
    }
}