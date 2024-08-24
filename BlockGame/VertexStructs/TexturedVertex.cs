using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame.VertexStructs
{
    public struct TexturedVertex : IVertexInfo
    {
        public Vector3 Position;
        public Vector2 UV;
        public TexturedVertex(Vector3 position, Vector2 UV)
        {
            Position = position;
            this.UV = UV;
        }

        public TexturedVertex(Vector3d position, Vector2d UV)
        {
            Position = (Vector3)position;
            this.UV = (Vector2)UV;
        }

        public static Type VertexType => typeof(TexturedVertex);
        public static int VertexByteSize => VertexAttributes.Sum(a => a.ComponentCount * a.Size);
        public static VertexAttribute[] VertexAttributes => 
            [
                new VertexAttribute("Position", 0, sizeof(float), 3, 0, OpenTK.Graphics.OpenGL4.VertexAttribPointerType.Float),
                new VertexAttribute("UV", 1, sizeof(float), 2, sizeof(float) * 3, OpenTK.Graphics.OpenGL4.VertexAttribPointerType.Float)
            ];
    }
}
