using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine1Core
{
    public abstract class Actor : GameObject
    {
        public Texture2D Texture { get; set; }
        protected List<GameObject> GameObjects;

        public Actor()
        {
            GameObjects = new List<GameObject>();
            Position = Vector2.Zero;
            Origin = Vector2.Zero;
        }

        public Actor(Texture2D texture)
        {
            this.Texture = texture;
            Position = Vector2.Zero;
            GameObjects = new List<GameObject>();
            Origin = Vector2.Zero;
        }

        public Actor(Vector2 pos)
        {
            this.Position = pos;
            GameObjects = new List<GameObject>();
            Origin = pos;
        }
        public Actor(Texture2D texture, Vector2 pos)
        {
            GameObjects = new List<GameObject>();
            Position = pos;
            Texture = texture;
            Origin = pos;
        }

        public Actor(Texture2D texture, Vector2 pos, Vector2 origin)
        {
            GameObjects = new List<GameObject>();
            Position = pos;
            Texture = texture;
            Origin = origin;
        }

        public void AddActor(Actor a)
        {
            this.GameObjects.Add(a);
        }

        public void SetTexture(string path)
        {
            Texture = ContentManager.LoadTexture(path);
        }

        public override void Draw(List<GameObject> lights)
        {
            var lightSources = lights.ConvertAll(l => ((LightSource)l).GetTextureLight()).ToList();

            SpriteBatch.Draw(Texture, Position, new Vector2(1f, 1f), Color.White, Origin, lightSources);
        }
    }
}
