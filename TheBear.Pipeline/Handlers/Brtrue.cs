
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Brtrue : IHandler
    {
        public int ID => 9;
        public Code ILCode => Code.Brtrue_S;
        public object ResolveOperand(Restorer restorer)
        {
            restorer.AddTarget(restorer.Reader.ReadInt32());
            return OpCodes.Nop.ToInstruction();
        }
    }
}
