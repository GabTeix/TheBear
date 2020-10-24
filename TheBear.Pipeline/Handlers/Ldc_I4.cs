
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Ldc_I4 : IHandler
    {
        public int ID => 1;
        public Code ILCode => Code.Ldc_I4;
        public object ResolveOperand(Restorer restorer) => restorer.Reader.ReadInt32();
    }
}
