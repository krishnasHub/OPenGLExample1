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

        public MyGame(int w, int h) : base(w, h)
        {
            GL.Enable(EnableCap.Texture2D);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            texture = ContentManager.LoadTexture("sample_texture_1.jpg");
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.CornflowerBlue);

            GL.BindTexture(TextureTarget.Texture2D, texture.ID);
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Red);
            GL.TexCoord2(0, 0);
            GL.Vertex2(0, 0);

            GL.Color3(Color.Green);
            GL.TexCoord2(1, 0);
            GL.Vertex2(0.9f, 0);

            GL.Color3(Color.Blue);
            GL.TexCoord2(1, 1);
            GL.Vertex2(1, -0.9f);

            GL.Color3(Color.WhiteSmoke);
            GL.TexCoord2(0, 1);
            GL.Vertex2(0, -1);

            GL.End();

            this.SwapBuffers();
        }

    }
}
