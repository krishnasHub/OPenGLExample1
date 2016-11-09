using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSOpenGL1
{
    class Program
    {

        // Installed OPenTK from Nuget
        // Added reference to System.Drawing
        // https://www.youtube.com/watch?v=c1y51ld6BmU

        // next video - https://www.youtube.com/watch?v=NWw05zor3qk

        static void Main(string[] args)
        {
            var gw = new MyGame(1024, 768);
            gw.Run();
        }
    }
}
