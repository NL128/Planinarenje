using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public class Ocena:IModels
    {
        public int OcenaID { get; set; }
        public Nullable<int> Nivo1 { get; set; } = 0;
        public Nullable<int> Nivo2 { get; set; } = 0;
        public Nullable<int> Nivo3 { get; set; } = 0;
        public Nullable<int> Nivo4 { get; set; } = 0;
        public Nullable<int> Nivo5 { get; set; } = 0;

        public int GetAverage()
        {
            int devider = ((int)Nivo1 + (int)Nivo2 + (int)Nivo3 + (int)Nivo4 + (int)Nivo5);
            if (devider > 0)
            {
                return (1 * (int)Nivo1 + 2 * (int)Nivo2 + 3 * (int)Nivo3 + 4 * (int)Nivo4 + 5 * (int)Nivo5) / devider;
            }else { return 0; }
        }
    }
    public class LongOcena : Ocena
    {
        public long OcenaIDLong { get; set; }
    }
}
