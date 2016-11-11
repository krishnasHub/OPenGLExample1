using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace Engine1Core
{

    public enum TweenType
    {
        Instant,
        Linear,
        QuadraticInOut,
        CubicInOut,
        QuarticOut
    }

    class View
    {
        public Vector2 Position
        {
            get
            {
                return this.position;
            }
        }

        public Vector2 PositionGoto
        {
            get { return positionGoto; }
        }

        private Vector2 positionGoto, positionFrom;
        private TweenType tweentType;
        private int currentStep, tweenSteps;

        private Vector2 position;
        /// <summary>
        /// In Radians: + => clockwise
        /// </summary>
        public double Rotation;

        /// <summary>
        /// A value if 1 is no Zoom, 2 is two times and 0.5 is Zoomed out 2 times.
        /// </summary>
        public double Zoom;

        public Vector2 ToWorld(Vector2 input)
        {
            input /= (float)Zoom;
            Vector2 dx = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
            Vector2 dy = new Vector2((float)Math.Cos(Rotation + MathHelper.PiOver2), (float)Math.Sin(Rotation + MathHelper.PiOver2));

            return (this.Position + dx * input.X + dy * input.Y);
        }

        public View(Vector2 startPosition, double startZoom = 1.0, double startRotation = 0.0)
        {
            this.position = startPosition;
            this.Zoom = startZoom;
            this.Rotation = startRotation;
        }

        public void Update()
        {
            if(currentStep < tweenSteps)
            {
                currentStep++;

                switch (tweentType)
                {
                    case TweenType.Linear:
                        position = positionFrom + (positionGoto - positionFrom) * GetLinear((float)currentStep / tweenSteps);
                        break;

                    case TweenType.QuadraticInOut:
                        position = positionFrom + (positionGoto - positionFrom) * GetQuadraticInOut((float)currentStep / tweenSteps);
                        break;

                    case TweenType.CubicInOut:
                        position = positionFrom + (positionGoto - positionFrom) * GetCubicInOut((float)currentStep / tweenSteps);
                        break;

                    case TweenType.QuarticOut:
                        position = positionFrom + (positionGoto - positionFrom) * GetQuarticOut((float)currentStep / tweenSteps);
                        break;
                }
            }
            else
            {
                position = positionGoto;
            }
        }

        public float GetLinear(float t)
        {
            return t;
        }

        public float GetQuadraticInOut(float t)
        {
            return (t * t) / ((2 * t * t)  - (2 * t) + 1);
        }

        public float GetCubicInOut(float t)
        {
            return (t * t * t) / ((3 * t * t) - (3 * t) + 1);
        }

        public float GetQuarticOut(float t)
        {
            return -((t - 1) * (t - 1) * (t - 1) * (t - 1)) + 1;
        }

        public void SetPosition(Vector2 newPosition)
        {
            this.position = newPosition;
            this.positionFrom = newPosition;
            this.positionGoto = newPosition;

            tweentType = TweenType.Instant;
            currentStep = 0;
            tweenSteps = 0;
        }

        public void SetPosition(Vector2 newPosition, TweenType type, int numStep)
        {
            this.positionFrom = this.position;
            this.position = newPosition;
            
            this.positionGoto = newPosition;

            tweentType = type;
            currentStep = 0;
            tweenSteps = numStep;
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
