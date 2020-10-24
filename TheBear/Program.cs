
using TheBear.Core;
using TheBear.Pipeline;

namespace TheBear
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.PrintLogo();

            if (args.Length != 1)
            {
                Logger.PrintError("Invalid usage, just drag and drop the file.");
                Logger.ReadLine();
                return;
            }

            var context = new FileContext(args[0]);

            new Devirtualizer(context).Execute();

            context.Save();
        }
    }
}
