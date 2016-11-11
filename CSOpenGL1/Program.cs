using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine1Core
{
    class Program
    {

        // Installed OPenTK from Nuget
        // Added reference to System.Drawing
        // https://www.youtube.com/watch?v=c1y51ld6BmU

        // next video - https://www.youtube.com/watch?v=eX_Zmi6I0tU

        static void Main(string[] args)
        {
            var gw = new GameWindow(1024, 768);
            gw.Run();
        }
    }
}
