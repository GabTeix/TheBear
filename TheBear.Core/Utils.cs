
using dnlib.DotNet.Emit;

using System.Collections.Generic;

namespace TheBear.Core
{
    public static class Utils
    {
        public static bool FindPattern(List<Instruction> instrs, OpCode[] opCodes, int sub = 0)
        {
            if (instrs.Count < opCodes.Length)
                return false;

            int index = instrs.Count - opCodes.Length - sub;

            for (int i =0; i < opCodes.Length; i++)
            {
                if (instrs[i + index].OpCode != opCodes[i])
                    return false;
            }

            return true;
        }
    }
}
