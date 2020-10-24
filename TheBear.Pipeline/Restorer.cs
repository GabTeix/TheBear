
using dnlib.DotNet;
using dnlib.DotNet.Emit;

using System.Collections.Generic;
using System.IO;

using TheBear.Core;

namespace TheBear.Pipeline
{
    public class Restorer
    {
        public ModuleDefMD Module { get; }
        public BinaryReader Reader { get; }
        public Dictionary<int, IHandler> Handlers { get; }
        public VirtualizedMethod CurrentMethod { get; set; }
        public Restorer(Devirtualizer devirtualizer)
        {
            Module = devirtualizer.Context.Module;

            var sectionBytes = devirtualizer.Decompress(devirtualizer.Context.ReadSection(".Nasha0"));
            Reader = new BinaryReader(new MemoryStream(sectionBytes));
            Handlers = devirtualizer.Handlers;
        }

        public void RestoreMethod(VirtualizedMethod method)
        {
            CurrentMethod = method;
            Reader.BaseStream.Position = method.Offset;

            var count = Reader.ReadInt32();

            for (int i =0; i < count; i++)
            {
                var handlerID = Reader.ReadByte();
                var handler = Handlers[handlerID];
                var instruction = new Instruction()
                {
                    OpCode = handler.ILCode.ToOpCode(),
                    Operand = handler.ResolveOperand(this)
                };
                CurrentMethod.Instructions.Add(instruction);
            }
            CurrentMethod.RestoreBody();
            CurrentMethod.RestoreTargets();

            Logger.PrintSuccess($"Restored Method {method.Method.Name}.");
        }
        public void AddTarget(int target) => CurrentMethod.Targets.Add(CurrentMethod.Instructions.Count, target);
        public IField ResolveField(int token) => Module.ResolveToken(token) as IField;
        public IMethod ResolveMethod(int token) => Module.ResolveToken(token) as IMethod;
    }
}
