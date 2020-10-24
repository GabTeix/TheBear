using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBear.Pipeline
{
    public class VirtualizedMethod
    {
        public MethodDef Method { get; }
        public int Offset { get; }
        public List<Instruction> Instructions { get; }
        public Dictionary<int, Local> Locals { get; }
        public Dictionary<int, int> Targets { get; }
        public VirtualizedMethod(MethodDef method, int offset)
        {
            Method = method;
            Offset = offset;
            Instructions = new List<Instruction>();
            Locals = new Dictionary<int, Local>();
            Targets = new Dictionary<int, int>();
        }

        public void RestoreBody()
        {
            Method.Body.Instructions.Clear();
            Method.Body.Variables.Clear();

            foreach (Local local in Locals.Values)
                Method.Body.Variables.Add(local);

            foreach (Instruction instr in Instructions)
                Method.Body.Instructions.Add(instr);
        }

        public void RestoreTargets()
        {
            if (Targets.Count < 1)
                return;

            foreach (var entry in Targets)
            {
                var current = entry.Key;
                var target = entry.Value;

                Instructions[current].Operand = Instructions[target];
            }
        }
    }
}
