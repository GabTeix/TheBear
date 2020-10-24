
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Ldsfld : IHandler
    {
        public int ID => 6;
        public Code ILCode => Code.Ldsfld;
        public object ResolveOperand(Restorer restorer) 
        {
            restorer.Reader.ReadInt16();
            return restorer.ResolveField(restorer.Reader.ReadInt32());
        }

    }
}
