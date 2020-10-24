using dnlib.DotNet;
using dnlib.DotNet.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBear.Core
{
    public class FileContext
    {
        public string Path { get; }
        public ModuleDefMD Module { get; }
        public FileContext(string path)
        {
            Path = path;
            Module = ModuleDefMD.Load(path);

            LoadReferences();
        }

        private void LoadReferences()
        {
            var asmResolver = new AssemblyResolver { EnableTypeDefCache = true };
            var modCtx = new ModuleContext(asmResolver);
            asmResolver.DefaultModuleContext = modCtx;
            var asmRefs = Module.GetAssemblyRefs().ToList();
            Module.Context = modCtx;
            foreach (var asmRef in asmRefs)
            {
                try
                {
                    if (asmRef == null)
                        continue;
                    var asm = asmResolver.Resolve(asmRef.FullName, Module);
                    if (asm == null)
                        continue;
                    Logger.PrintInfo("Reference : " + asm.FullName);
                    (Module.Context.AssemblyResolver as AssemblyResolver).AddToCache(asm);

                }
                catch
                {

                }

            }
        }

        public byte[] ReadSection(string name)
        {
            var peImage = Module.Metadata.PEImage;
            var section = peImage.ImageSectionHeaders.Single(x => x.DisplayName == name);
            var reader = peImage.CreateReader();
            reader.Position = section.PointerToRawData;
            return reader.ReadBytes((int)section.SizeOfRawData);
        }

        public void Save()
        {
            var options = new ModuleWriterOptions(Module)
            {
                Logger = DummyLogger.NoThrowInstance,
            };
            options.MetadataOptions.Flags = MetadataFlags.PreserveAll;

            string output = Path.Replace(".exe", ".thebear.exe");
            Module.Write(output, options);

            Logger.Blank();
            Logger.PrintSuccess(output);
            Logger.ReadLine();
        }
    }
}
