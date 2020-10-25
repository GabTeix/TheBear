
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Newobj : IHandler
    {
        public int ID => 16;
        public Code ILCode => Code.Newobj;
        public object ResolveOperand(Restorer restorer)
        {
            restorer.Reader.ReadInt16();
            return restorer.ResolveMethod(restorer.Reader.ReadInt32());
        }
    }
}
