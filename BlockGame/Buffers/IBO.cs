using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame.Buffers
{
    public class IBO
    {
        public int Handle { get; private set; }

        public IBO(List<Vector3i> Indices)
        {
            Handle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Handle);
            GL.BufferData(BufferTarget.ElementArrayBuffer,Indices.Count * Vector3i.SizeInBytes, Indices.ToArray(), BufferUsageHint.StaticDraw);
        }

        public void Bind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, Handle);

        public void Unbind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

        public void Delete()
        {
            Unbind();
            GL.DeleteBuffer(Handle);
        }
    }
}
