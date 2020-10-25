
using TheBear.Core;

namespace TheBear.Pipeline.Stages
{
    public class Restoring : Stage
    {
        public override string Name => "Restoring";
        public override string Description => "Restore the VMIL Bodies back to IL Bodies.";
        public override void Execute(Devirtualizer devirtualizer)
        {
            var restorer = new Restorer(devirtualizer);

            Logger.Blank();

            foreach (var method in devirtualizer.Methods)
            {
                restorer.RestoreMethod(method);
            }

        }
    }
}
