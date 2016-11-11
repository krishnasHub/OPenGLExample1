using OpenTK;
using System;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine1Core
{
    public class GameWindow : OpenTK.GameWindow
    {

        private List<GameObject> GameObjects;

        //private List<Texture2D> Textures;
        //private List<TextureLight> TextureLights;
        private View view;

        public GameWindow(int w, int h) : base(w, h)
        { 
            GL.Enable(EnableCap.Texture2D);
            view = new View(Vector2.Zero, 1.0, 0.0f);

            GameObjects = new List<GameObject>();

            //Textures = new List<Texture2D>();
            //TextureLights = new List<TextureLight>();

            GameInput.Initialize(this);
        }

        public void AddGameObject(GameObject a)
        {
            GameObjects.Add(a);
        }

        public void RemoveGameObject(GameObject a)
        {
            while (GameObjects.Contains(a))
                GameObjects.Remove(a);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            GameObjects.ForEach(go => go.Tick());
            
            if(GameInput.MousePress(OpenTK.Input.MouseButton.Left))
            {
                Vector2 pos = new Vector2(Mouse.X, Mouse.Y) - new Vector2(this.Width, this.Height) / 2f;
                pos = view.ToWorld(pos);
                view.SetPosition(pos, TweenType.QuadraticInOut, 60);

            }

            if(GameInput.KeyDown(OpenTK.Input.Key.Right))
            {
                view.SetPosition(view.PositionGoto + new Vector2(5, 0), TweenType.QuadraticInOut, 15);
            }

            view.Update();
            GameInput.Update();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            if (GameObjects.Count == 0)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.CornflowerBlue);
            

            SpriteBatch.Begin(this.Width, this.Height);
            view.ApplyTransform();

            //TextureLight[] lights = new TextureLight[] { new TextureLight(new Vector2(pos_x, -100), 0.65f), new TextureLight(new Vector2(pos_x + Textures[0].Width / 2, -100), 0.65f) };

            //SpriteBatch.Draw(Textures[0], new Vector2(pos_x, -100), new Vector2(0.5f, 0.5f), Color.Green, new Vector2(10, 50), TextureLights);

            var lights = GameObjects.Where(go => go.GetType().Equals(typeof(LightSource))).ToList();
            var objects = GameObjects.Where(go => !go.GetType().Equals(typeof(LightSource))).ToList();

            objects.ForEach(a => a.Draw(lights));

            //Textures.ForEach(t => SpriteBatch.Draw(t, Vector2.Zero, new Vector2(1f, 1f), Color.White, new Vector2(0, 0), TextureLights));

            this.SwapBuffers();
        }

    }
}
