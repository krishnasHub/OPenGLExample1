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
        private List<Texture2D> Textures;


        //Texture2D texture;
        View view;

        public GameWindow(int w, int h) : base(w, h)
        { 
            GL.Enable(EnableCap.Texture2D);
            view = new View(Vector2.Zero, 1.0, 0.0f);

            Textures = new List<Texture2D>();

            GameInput.Initialize(this);
        }

        public void AddTexture(string path)
        {
            Textures.Add(ContentManager.LoadTexture(path));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //texture = ContentManager.LoadTexture("sample_texture_1.jpg");
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            //view.Rotation += 5 * MathHelper.Pi / 360.0;

            pos_x += (dir) * 1f;

            if (pos_x >= 500)
            {
                dir = -1;
                pos_x = 500 - 20.0f;
            }
            if (pos_x <= -500)
            {
                dir = 1;
                pos_x = -500 + 20.0f;
            }

            
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

        int dir = 1;
        float pos_x = 0.0f;

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            if (Textures.Count == 0)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.CornflowerBlue);
            

            SpriteBatch.Begin(this.Width, this.Height);
            view.ApplyTransform();

            TextureLight[] lights = new TextureLight[] { new TextureLight(new Vector2(pos_x, -100), 0.65f), new TextureLight(new Vector2(pos_x + Textures[0].Width / 2, -100), 0.65f) };

            SpriteBatch.Draw(Textures[0], new Vector2(pos_x, -100), new Vector2(0.5f, 0.5f), Color.Green, new Vector2(10, 50), lights);

            

            Textures.ForEach(t => SpriteBatch.Draw(t, Vector2.Zero, new Vector2(1f, 1f), Color.Green, new Vector2(10, 50), lights));

            this.SwapBuffers();
        }

    }
}
