using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine1Core
{
    public abstract class GameObject
    {
        public Vector2 Position;
        public Vector2 Origin;

        public abstract void Tick();

        public abstract void Draw(List<GameObject> lights);
    }
}
