
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Dup : IHandler
    {
        public int ID => 17;
        public Code ILCode => Code.Dup;
        public object ResolveOperand(Restorer restorer) => null;
    }
}
