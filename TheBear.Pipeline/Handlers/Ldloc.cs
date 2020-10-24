
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Ldloc : IHandler
    {
        public int ID => 11;
        public Code ILCode => Code.Ldloc_S;
        public object ResolveOperand(Restorer restorer)
        {
            var index = restorer.Reader.ReadInt32();
            var method = restorer.CurrentMethod;
            if (method.Locals.ContainsKey(index))
                return method.Locals[index];
            var local = new Local(restorer.Module.ImportAsTypeSig(typeof(object)));
            method.Locals.Add(index, local);
            return local;
        }
    }
}
