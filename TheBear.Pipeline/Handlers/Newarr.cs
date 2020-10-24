
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Newarr : IHandler
    {
        public int ID => 14;
        public Code ILCode => Code.Nop; // they don't have support for that
        public object ResolveOperand(Restorer restorer) => null;
    }
}

