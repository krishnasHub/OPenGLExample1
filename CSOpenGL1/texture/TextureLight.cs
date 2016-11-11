using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine1Core
{
    public struct TextureLight
    {
        public Vector2 Position { get; set; }
        public float Intensity { get; set; }

        public TextureLight(Vector2 position, float intensity)
        {
            this.Position = position;
            this.Intensity = intensity;
        }
    }
}
