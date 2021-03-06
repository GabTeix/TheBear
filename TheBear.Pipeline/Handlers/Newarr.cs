﻿
using dnlib.DotNet.Emit;

namespace TheBear.Pipeline.Handlers
{
    public class Newarr : IHandler
    {
        public int ID => 14;
        public Code ILCode => Code.Newarr;
        public object ResolveOperand(Restorer restorer)
        {
            restorer.Reader.ReadInt16();
            return restorer.ResolveType(restorer.Reader.ReadInt32());
        }
    }
}

