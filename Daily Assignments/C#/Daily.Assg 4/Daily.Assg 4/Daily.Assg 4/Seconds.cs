using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Assg_4
{
    internal class Seconds
    {
        private int _seconds;

        public int Hour
        {
            get { return _seconds; }
            set { _seconds = value * 3600; }
        }

    }
}
