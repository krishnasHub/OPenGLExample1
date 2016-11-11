using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine1Core
{
    public struct Texture2D
    {
        
        public int ID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Texture2D(int id, int width, int height)
        {
            ID = id;
            Width = width;
            Height = height;
        }
    }
}
