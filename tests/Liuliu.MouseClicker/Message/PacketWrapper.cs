using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Message
{
    public class PacketWrapper
    {
        public RawCapture p;

        public int Count { get; private set; }
        public PosixTimeval Timeval { get { return p.Timeval; } }
        public LinkLayers LinkLayerType { get { return p.LinkLayerType; } }
        public int Length { get { return p.Data.Length; } }

        public PacketWrapper(int count, RawCapture p)
        {
            this.Count = count;
            this.p = p;
        }
    }
}
