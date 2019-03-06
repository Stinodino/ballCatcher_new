using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallCatcher
{
    public class Controls
    {
        public Keys Links { get; set; }
        public Keys Rechts { get; set; }
        public Keys Omhoog { get; set; }

        public Controls(Keys links, Keys rechts, Keys omhoog)
        {
            Links = links;
            Rechts = rechts;
            Omhoog = omhoog;
        }
    }
}
