using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBear.Pipeline.Stages
{
    public class Restoring : Stage
    {
        public override string Name => "Restoring";
        public override string Description => "Restore the VMIL Bodies back to IL Bodies.";
        public override void Execute(Devirtualizer devirtualizer)
        {
            var restorer = new Restorer(devirtualizer);

            foreach (var method in devirtualizer.Methods)
            {
                restorer.RestoreMethod(method);
            }

        }
    }
}
