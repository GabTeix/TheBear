
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Ldarg : IHandler
    {
        public int ID => 13;
        public Code ILCode => Code.Ldarg;
        public object ResolveOperand(Restorer restorer)
        {
            var index = restorer.Reader.ReadInt16();
            var method = restorer.CurrentMethod.Method;
            return method.Parameters[index];
        }
    }
}
