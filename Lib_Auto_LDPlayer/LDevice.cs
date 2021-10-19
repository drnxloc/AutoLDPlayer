using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_LDPlayer
{
    public struct LDevice
    {
        public int index;
        public string name;
        public string adb_id;
        public IntPtr topHandle;
        public IntPtr bindHandle;
        public int androidState;
        public int dnplayerPID;
        public int vboxPID;
    }
}
