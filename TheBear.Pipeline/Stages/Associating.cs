using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBear.Pipeline.Stages
{
    public class Associating : Stage
    {
        public override string Name => "Associating";
        public override string Description => "Associates handlers to his new value.";
        public override void Execute(Devirtualizer devirtualizer)
        {
            var section = devirtualizer.Context.ReadSection(".Nasha2");
            var reader = new BinaryReader(new MemoryStream(section));
            var handlers = devirtualizer.Handlers;
            var newHandlers = new Dictionary<int, IHandler>();

            reader.ReadInt32();
            reader.ReadInt32();

            for (int i = 0; i < handlers.Count; i++)
            {
                reader.ReadInt32();
                var ID = reader.ReadInt32();
                if (ID == 777)
                    break;

                var handler = handlers[ID];

                reader.ReadInt32();

                var newID = reader.ReadInt32(); 

                reader.ReadInt32();
                reader.ReadInt32();
                newHandlers.Add(newID, handler);
            }

            devirtualizer.Handlers = newHandlers;
        }
    }
}
