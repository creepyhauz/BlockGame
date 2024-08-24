using BlockGame.Buffers;
using BlockGame.VertexStructs;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame
{
    public class BlockRenderer
    {
        public IBO IBO;
        public VBO<TexturedVertex> VBO;
        public VAO<TexturedVertex> VAO;

        public TexturedVertex[] Vertices =
            [
               // front face
            new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), new Vector2(0f, 1f)), // topleft vert
            new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), new Vector2(1f, 1f)), // topright vert
            new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), new Vector2(1f, 0f)), // bottomright vert
            new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), new Vector2(0f, 0f)), // bottomleft vert

                // right face
            new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), new Vector2(0f, 1f)), // topleft vert
            new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), new Vector2(1f, 1f)), // topright vert
            new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), new Vector2(1f, 0f)), // bottomright vert
            new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), new Vector2(0f, 0f)), // bottomleft vert

                // back face
            new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), new Vector2(0f, 1f)), // topleft vert
            new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), new Vector2(1f, 1f)), // topright vert
            new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f), new Vector2(1f, 0f)), // bottomright vert
            new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), new Vector2(0f, 0f)), // bottomleft vert

                // left face
            new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), new Vector2(0f, 1f)), // topleft vert
            new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), new Vector2(1f, 1f)), // topright vert
            new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), new Vector2(1f, 0f)), // bottomright vert
            new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f),  new Vector2(0f, 0f)), // bottomleft vert

                // top face
            new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), new Vector2(0f, 1f)), // topleft vert
            new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), new Vector2(1f, 1f)), // topright vert
            new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), new Vector2(1f, 0f)), // bottomright vert
            new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), new Vector2(0f, 0f)), // bottomleft vert

                // bottom face
            new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), new Vector2(0f, 1f)), // topleft vert
            new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), new Vector2(1f, 1f)), // topright vert
            new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), new Vector2(1f, 0f)), // bottomright vert
            new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f), new Vector2(0f, 0f)), // bottomleft vert
            ];

        public Vector3i[] Indices =
            [
            // first face
            new Vector3i(0, 1, 2), // top triangle
            new Vector3i(2, 3, 0), // bottom triangle

            new Vector3i(4, 5, 6),
            new Vector3i(6, 7, 4),

            new Vector3i(8, 9, 10),
            new Vector3i(10, 11, 8),

            new Vector3i(12, 13, 14),
            new Vector3i(14, 15, 12),

            new Vector3i(16, 17, 18),
            new Vector3i(18, 19, 16),

            new Vector3i(20, 21, 22),
            new Vector3i(22, 23, 20)
            ];

        public BlockRenderer()
        {
            VBO = new VBO<TexturedVertex>(Vertices.ToList());
            VAO = new VAO<TexturedVertex>(VBO);
            IBO = new IBO(Indices.ToList());
        }

        public void Render()
        {
            VAO.Bind();
            IBO.Bind();
            GL.DrawElements(PrimitiveType.Triangles, Indices.Length*3, DrawElementsType.UnsignedInt, 0);
        }
    }
}
