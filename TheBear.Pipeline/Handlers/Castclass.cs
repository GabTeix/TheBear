
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Castclass : IHandler
    {
        public int ID => 15;
        public Code ILCode => Code.Castclass;
        public object ResolveOperand(Restorer restorer)
        {
            restorer.Reader.ReadInt16();
            return restorer.ResolveType(restorer.Reader.ReadInt32());
        }
    }
}

