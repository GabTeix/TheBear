
using dnlib.DotNet.Emit;
using System.Linq;
using TheBear.Core;

namespace TheBear.Pipeline.Stages
{
    public class Mapping : Stage
    {
        public override string Name => "Mapping";
        public override string Description => "Map all the virtualized methods.";
        public override void Execute(Devirtualizer devirtualizer)
        {
            var module = devirtualizer.Context.Module;

            foreach (var type in module.GetTypes())
            {
                foreach (var method in type.Methods)
                {
                    if (!method.HasBody || !method.Body.HasInstructions)
                        continue;

                    method.Body.SimplifyMacros(method.Parameters);

                    var instrs = method.Body.Instructions;

                    if (instrs.Count < 6)
                        continue;
                    if (instrs[0].OpCode != OpCodes.Newobj)
                        continue;
                    if (instrs[instrs.Count - 5].OpCode != OpCodes.Ldc_I4)
                        continue;
                    if (instrs[instrs.Count - 4].OpCode != OpCodes.Ldsfld)
                        continue;
                    if (instrs[instrs.Count - 3].OpCode != OpCodes.Call)
                        continue;

                    var offset = instrs[instrs.Count - 5].GetLdcI4Value();

                    devirtualizer.Methods.Add(new VirtualizedMethod(method, offset));
                }
            }
        }
    }
}
