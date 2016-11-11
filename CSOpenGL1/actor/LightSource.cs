using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine1Core
{
    public class LightSource : GameObject
    {
        private TextureLight textureLight;

        public LightSource(Vector2 position, float intensity)
        {
            Position = position;
            textureLight = new TextureLight(position, intensity);
        }

        public void SetIntensity(float intensity)
        {
            textureLight.Intensity = intensity;
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
            textureLight.Position = position;
        }

        public TextureLight GetTextureLight()
        {
            return textureLight;
        }

        public override void Tick()
        {
            // Update the Intensity perhaps..?
        }

        public override void Draw(List<GameObject> lights)
        {
            // Nothing to draw for a Lightsource
        }
    }
}
