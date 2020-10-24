
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Nop : IHandler
    {
        public int ID => 4;
        public Code ILCode => Code.Nop;
        public object ResolveOperand(Restorer restorer) => null;
    }
}
