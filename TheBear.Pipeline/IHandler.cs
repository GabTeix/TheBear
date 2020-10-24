
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline
{
    public interface IHandler
    {
        int ID { get; }
        Code ILCode { get; }
        object ResolveOperand(Restorer restorer);
    }
}
