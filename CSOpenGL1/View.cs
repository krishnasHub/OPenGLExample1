using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace CSOpenGL1
{
    class View
    {
        public Vector2 Position;
        /// <summary>
        /// In Radians: + => clockwise
        /// </summary>
        public double Rotation;

        /// <summary>
        /// A value if 1 is no Zoom, 2 is two times and 0.5 is Zoomed out 2 times.
        /// </summary>
        public double Zoom;

        public View(Vector2 startPosition, double startZoom = 1.0, double startRotation = 0.0)
        {
            this.Position = startPosition;
            this.Zoom = startZoom;
            this.Rotation = startRotation;
        }

        public void Update()
        {

        }

        public void ApplyTransform()
        {
            Matrix4 transform = Matrix4.Identity;

            transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-Position.X, -Position.Y, 0));
            transform = Matrix4.Mult(transform, Matrix4.CreateRotationZ(-(float) Rotation));
            transform = Matrix4.Mult(transform, Matrix4.CreateScale((float) Zoom, (float) Zoom, 1.0f));

            GL.MultMatrix(ref transform);
        }
    }
}
