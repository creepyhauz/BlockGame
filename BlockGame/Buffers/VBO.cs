using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame.Buffers
{
    public class VBO<T> where T : struct, IVertexInfo
    {
        public int Handle { get; }

        public int VertexSize => (int)typeof(T).GetProperties().ToList().Find(p => p.Name == "VertexByteSize").GetValue(null, null);
        public VertexAttribute[] Attributes => (VertexAttribute[])typeof(T).GetProperties().ToList().Find(p => p.Name == "VertexAttributes").GetValue(null, null);

        public VBO(List<T> Vertices)
        {
            Handle = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);
            GL.BufferData(BufferTarget.ArrayBuffer, Vertices.Count * VertexSize, Vertices.ToArray(), BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Bind() => GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);

        public void Unbind() => GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

        public void Delete()
        {
            Unbind();
            GL.DeleteBuffer(Handle);
        }
    }
}
