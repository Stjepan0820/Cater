using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cater
{
    public class FrmEventArgs:EventArgs
    {
        public int Temp { get; set; }
        public object obj { get; set; }
    }
}
