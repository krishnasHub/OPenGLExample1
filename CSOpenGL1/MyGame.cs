using OpenTK;
using System;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSOpenGL1
{
    class MyGame : GameWindow
    {

        Texture2D texture;
        View view;

        public MyGame(int w, int h) : base(w, h)
        {
            GL.Enable(EnableCap.Texture2D);
            view = new View(Vector2.Zero, 1.0, MathHelper.PiOver4);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            texture = ContentManager.LoadTexture("sample_texture_1.jpg");
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            view.Rotation += 5 * MathHelper.Pi / 360.0;

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

            view.Update();
        }

        int dir = 1;
        float pos_x = 0.0f;

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.CornflowerBlue);

            SpriteBatch.Begin(this.Width, this.Height);

            TextureLight[] lights = new TextureLight[] { new TextureLight(new Vector2(pos_x, -100), 0.65f), new TextureLight(new Vector2(pos_x + texture.Width / 2, -100), 0.65f) };

            SpriteBatch.Draw(texture, new Vector2(pos_x, -100), new Vector2(0.5f, 0.5f), Color.Green, new Vector2(10, 50), lights);


            SpriteBatch.Draw(texture, Vector2.Zero, new Vector2(1f, 1f), Color.Green, new Vector2(10, 50), lights);
            SpriteBatch.Draw(texture, new Vector2(-800, 0), new Vector2(1f, 1f), Color.Green, new Vector2(10, 50), lights);

            SpriteBatch.Draw(texture, new Vector2(-800, -800), new Vector2(1f, 1f), Color.Green, new Vector2(10, 50), lights);
            SpriteBatch.Draw(texture, new Vector2(0, -800), new Vector2(1f, 1f), Color.Green, new Vector2(10, 50), lights);

            this.SwapBuffers();
        }

    }
}
