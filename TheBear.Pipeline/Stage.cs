using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBear.Pipeline
{
    public abstract class Stage
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract void Execute(Devirtualizer devirtualizer);
    }
}
