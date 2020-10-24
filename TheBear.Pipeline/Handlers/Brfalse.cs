
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Brfalse : IHandler
    {
        public int ID => 8;
        public Code ILCode => Code.Brfalse_S;
        public object ResolveOperand(Restorer restorer)
        {
            restorer.AddTarget(restorer.Reader.ReadInt32());
            return OpCodes.Nop.ToInstruction();
        }
    }
}
