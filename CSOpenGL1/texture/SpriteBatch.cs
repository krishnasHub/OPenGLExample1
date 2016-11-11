using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Engine1Core
{
    class SpriteBatch
    {
        public static void Draw(Texture2D texture, Vector2 position, Vector2 scale, Color color, Vector2 origin, List<TextureLight> lights = null)
        {
            Vector2[] vertices = new Vector2[4]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1)
            };

            GL.Begin(PrimitiveType.Quads);
            GL.BindTexture(TextureTarget.Texture2D, texture.ID);

            GL.Color3(color);

            for (int i = 0; i < 4; ++i)
            {
                if(lights != null && lights.Count > 0)
                {
                    bool lightFound = false;
                    for(int j = 0; j < lights.Count; ++j)
                    {
                       // Vector2 lpos = new Vector2(lights[i].Position.X, lights[i].Position.Y);
                        Vector2 vi = new Vector2(vertices[i].X, vertices[i].Y);
                        vi.X *= texture.Width;
                        vi.Y *= texture.Height;
                        vi -= origin;
                        vi *= scale;
                        vi += position;

                        if ((vi - lights[j].Position).Length <= lights[j].Intensity * texture.Width)
                        {
                            GL.Color3(Color.White);
                            lightFound = true;
                            break;
                        }
                    }

                    if(!lightFound)
                    {
                        GL.Color3(Color.Black);
                    }
                }
                GL.TexCoord2(vertices[i]);

                vertices[i].X *= texture.Width;
                vertices[i].Y *= texture.Height;

                vertices[i] -= origin;
                vertices[i] *= scale;
                vertices[i] += position;

                GL.Vertex2(vertices[i]);
            }

            GL.End();
        }


        public static void Begin(int screenWidth, int screenHeight)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(-screenWidth / 2, screenWidth / 2, screenHeight / 2, -screenHeight / 2, 0f, 1f);
        }
    }
}
