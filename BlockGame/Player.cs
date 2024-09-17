using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame
{
    public class Player
    {
        public float Speed = 5f;

        public Vector3 Position = new Vector3(32,100,32);
        public Vector3 Up = Vector3.UnitY;
        public Vector3 Right = Vector3.UnitX;
        public Vector3 Front = -Vector3.UnitZ;

        public Vector2 Size = new Vector2(800, 600);

        public float Pitch = 0;
        public float Yaw =  -90;

        Matrix4 View => Matrix4.LookAt(Position,Position+Front,Up);
        Matrix4 Projection => Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(90), Size.X / Size.Y, 0.01f, 100f);
        public Matrix4 CameraTransform => View * Projection;

        public bool IsFocused = true;
        public Vector2 LastMousePos = Vector2.Zero;

        public bool IsGrounded = true;

        public double YVelocity = 0;

        public void Update()
        {
            if (!IsGrounded)
            {
                if (YVelocity >= -0000.1)
                    YVelocity -= 0.000001f;
                

                Position += new Vector3(0, (float)YVelocity, 0);
            }
        }

        public void UpdateInput(KeyboardState keyboard, MouseState mouse, FrameEventArgs args)
        {
            if (keyboard.IsKeyDown(Keys.W))
                Position += Front * Speed * (float)args.Time;
            if (keyboard.IsKeyDown(Keys.S))
                Position -= Front * Speed * (float)args.Time;
            if (keyboard.IsKeyDown(Keys.D))
                Position += Right * Speed * (float)args.Time;
            if (keyboard.IsKeyDown(Keys.A))
                Position -= Right * Speed * (float) args.Time;
            if(keyboard.IsKeyDown(Keys.Space))
                Position += Vector3.UnitY * Speed * (float)args.Time;
            if (keyboard.IsKeyDown(Keys.LeftShift))
                Position -= Vector3.UnitY * Speed * (float)args.Time;

            if (keyboard.IsKeyDown(Keys.Space) && IsGrounded)
            {
                Position += Vector3.UnitY * Speed * (float)args.Time;
                IsGrounded=false;
            }

            if (IsFocused)
            {
                var delta = mouse.Position - LastMousePos;
                LastMousePos = mouse.Position;
                Yaw += delta.X * 0.1f;
                Pitch -= delta.Y * 0.1f;

                UpdateVectors();
            }

            Update();
        }

        private void UpdateVectors()
        {
            if(Pitch > 89.0f)
                Pitch = 89.0f;
            if(Pitch < -89.0f)
                Pitch = -89.0f;

            Front.X = MathF.Cos(MathHelper.DegreesToRadians(Pitch)) * MathF.Cos(MathHelper.DegreesToRadians(Yaw));
            Front.Y = MathF.Sin(MathHelper.DegreesToRadians(Pitch));
            Front.Z = MathF.Cos(MathHelper.DegreesToRadians(Pitch)) * MathF.Sin(MathHelper.DegreesToRadians(Yaw));

            Front = Vector3.Normalize(Front);

            Right = Vector3.Normalize(Vector3.Cross(Front,Vector3.UnitY));
            Up = Vector3.Normalize(Vector3.Cross(Right,Front));
        }
    }
}
