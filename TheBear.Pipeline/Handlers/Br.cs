
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Br : IHandler
    {
        public int ID => 10;
        public Code ILCode => Code.Br_S;
        public object ResolveOperand(Restorer restorer)
        {
            restorer.AddTarget(restorer.Reader.ReadInt32());
            return OpCodes.Nop.ToInstruction();
        }
    }
}
