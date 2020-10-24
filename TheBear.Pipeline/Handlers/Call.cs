
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Call : IHandler
    {
        public int ID => 3;
        public Code ILCode => Code.Call;
        public object ResolveOperand(Restorer restorer)
        {
            restorer.Reader.ReadInt16();
            return restorer.ResolveMethod(restorer.Reader.ReadInt32());
        }
    }
}
