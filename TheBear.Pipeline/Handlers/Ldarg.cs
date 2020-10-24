
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Ldarg : IHandler
    {
        public int ID => 13;
        public Code ILCode => Code.Ldarg;
        public object ResolveOperand(Restorer restorer)
        {
            // Their current code is wrong, they don't serialize the index of ldarg
            // So I handled it in a dummy way, which is always grabbing the index 0 of parameters

            // Here's the proper code to use when they fix it

            //var index = restorer.Reader.ReadInt16();
            //var method = restorer.CurrentMethod.Method;
            //return method.Parameters[index];

            return restorer.CurrentMethod.Method.Parameters[0];
        }
    }
}
