using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame.Buffers
{
    public class VAO<T> where T : struct, IVertexInfo
    {
        public int Handle { get; private set; }
        public VBO<T> VBO { get; }

        public VAO(VBO<T> vBO)
        {
            Handle = GL.GenVertexArray();
            VBO = vBO;

            this.Bind();

            foreach (VertexAttribute attribute in VBO.Attributes)
            {
                GL.VertexAttribPointer(attribute.Index, attribute.ComponentCount, attribute.Type, false, VBO.VertexSize, attribute.Offset);
                GL.EnableVertexAttribArray(attribute.Index);
            }

            this.Unbind();
        }

        public void Bind()
        {
            GL.BindVertexArray(Handle);
            VBO.Bind();
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
            VBO.Unbind();
        }

        public void Delete()
        {
            Unbind();
            GL.DeleteVertexArray(Handle);
        }
    }
}
