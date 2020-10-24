
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Stsfld : IHandler
    {
        public int ID => 7;
        public Code ILCode => Code.Stsfld;
        public object ResolveOperand(Restorer restorer)
        {
            restorer.Reader.ReadInt16();
            return restorer.ResolveField(restorer.Reader.ReadInt32());
        }
    }
}
