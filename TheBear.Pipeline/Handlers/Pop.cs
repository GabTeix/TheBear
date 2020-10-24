
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Pop : IHandler
    {
        public int ID => 5;
        public Code ILCode => Code.Pop;
        public object ResolveOperand(Restorer restorer) => null;
    }
}
