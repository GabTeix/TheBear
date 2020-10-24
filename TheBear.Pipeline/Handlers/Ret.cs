
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Ret : IHandler
    {
        public int ID => 0;
        public Code ILCode => Code.Ret;
        public object ResolveOperand(Restorer restorer) => null;
    }
}
