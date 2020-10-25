
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Ldftn : IHandler
    {
        public int ID => 18;
        public Code ILCode => Code.Ldftn;
        public object ResolveOperand(Restorer restorer)
        {
            restorer.Reader.ReadInt16();
            return restorer.ResolveMethod(restorer.Reader.ReadInt32());
        }
    }
}
