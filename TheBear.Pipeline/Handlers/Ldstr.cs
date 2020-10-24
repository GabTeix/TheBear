
using dnlib.DotNet.Emit;

using System.Text;

namespace TheBear.Pipeline.Handlers
{
    public class Ldstr : IHandler
    {
        public int ID => 2;
        public Code ILCode => Code.Ldstr;
        public object ResolveOperand(Restorer restorer)
        {
            var len = restorer.Reader.ReadInt32();
            var bytes = restorer.Reader.ReadBytes(len);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
