
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

using TheBear.Core;
using TheBear.Pipeline.Stages;
using System;

namespace TheBear.Pipeline
{
    public class Devirtualizer
    {
        public FileContext Context { get; }
        public List<VirtualizedMethod> Methods { get; }
        public Dictionary<int, IHandler> Handlers { get; set; }
        public Devirtualizer(FileContext context)
        {
            Context = context;
            Methods = new List<VirtualizedMethod>();
            Handlers = GetHandlers();
        }

        public Stage[] Stages = new Stage[]
        {
            new Mapping(),
            new Associating(),
            new Restoring()
        };
        public void Execute()
        {
            Logger.Blank();
            foreach (var stage in Stages)
            {
                Logger.PrintInfo($"Executing {stage.Name} stage...");

                stage.Execute(this);
            }
        }

        public byte[] Decompress(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            MemoryStream nMS = new MemoryStream();

            var def = new DeflateStream(ms, CompressionMode.Decompress);
            def.CopyTo(nMS);

            return nMS.ToArray();
        }

        private Dictionary<int, IHandler> GetHandlers()
        {
            var result = new Dictionary<int, IHandler>();
            foreach (var type in typeof(IHandler).Assembly.DefinedTypes)
            {
                if (type.IsInterface)
                    continue;

                if (!typeof(IHandler).IsAssignableFrom(type))
                    continue;

                var instance = (IHandler)Activator.CreateInstance(type);

                result.Add(instance.ID, instance);
            }
            return result;
        }
    }
}
