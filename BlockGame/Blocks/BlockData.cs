using BlockGame.VertexStructs;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame.Blocks
{
    public enum Faces
    {
        FRONT,
        BACK,
        LEFT,
        RIGHT,
        TOP,
        BOTTOM
    }

    public struct FaceData
    {
        public List<TexturedVertex> vertices;

        public FaceData(List<TexturedVertex> vertices)
        {
            this.vertices = vertices;
        }
    }

    public struct FaceDataRaw
    {
        public static readonly Dictionary<Faces, List<TexturedVertex>> RawVertices = new Dictionary<Faces, List<TexturedVertex>>()
        {

            {
                Faces.FRONT, new List<TexturedVertex>(){
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), new Vector2(0f, 1f)), // topleft vert
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), new Vector2(1f, 1f)), // topright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), new Vector2(1f, 0f)), // bottomright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), new Vector2(0f, 0f)), // bottomleft vert
                }
            },

            {
                Faces.BACK, new List<TexturedVertex>(){
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), new Vector2(0f, 1f)), // topleft vert
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), new Vector2(1f, 1f)), // topright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f), new Vector2(1f, 0f)), // bottomright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), new Vector2(0f, 0f)), // bottomleft vert
                }
            },

            {
                Faces.LEFT, new List<TexturedVertex>(){
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), new Vector2(0f, 1f)), // topleft vert
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), new Vector2(1f, 1f)), // topright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), new Vector2(1f, 0f)), // bottomright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f), new Vector2(0f, 0f)), // bottomleft vert
                }
            },

            {
                Faces.RIGHT, new List<TexturedVertex>(){
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), new Vector2(0f, 1f)), // topleft vert
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), new Vector2(1f, 1f)), // topright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), new Vector2(1f, 0f)), // bottomright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), new Vector2(0f, 0f)), // bottomleft vert
                }
            },

            {
                Faces.TOP, new List<TexturedVertex>(){
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), new Vector2(0f, 1f)), // topleft vert
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), new Vector2(1f, 1f)), // topright vert
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), new Vector2(1f, 0f)), // bottomright vert
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), new Vector2(0f, 0f)), // bottomleft vert
                }
            },

            {
                Faces.BOTTOM, new List<TexturedVertex>(){
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), new Vector2(0f, 1f)), // topleft vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), new Vector2(1f, 1f)), // topright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), new Vector2(1f, 0f)), // bottomright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f), new Vector2(0f, 0f)), // bottomleft vert
                }
            }

        };

        public static readonly Dictionary<Faces, List<Vector3>> RawVVertices = new Dictionary<Faces, List<Vector3>>()
        {

            {
                Faces.FRONT, new List<Vector3>(){
                    new Vector3(-0.5f, +0.5f, +0.5f), // topleft vert
                    new Vector3(+0.5f, +0.5f, +0.5f), // topright vert
                    new Vector3(+0.5f, -0.5f, +0.5f), // bottomright vert
                    new Vector3(-0.5f, -0.5f, +0.5f), // bottomleft vert
                }
            },

            {
                Faces.BACK, new List<Vector3>(){
                    new Vector3(+0.5f, +0.5f, -0.5f), // topleft vert
                    new Vector3(-0.5f, +0.5f, -0.5f), // topright vert
                    new Vector3(-0.5f, -0.5f, -0.5f), // bottomright vert
                    new Vector3(+0.5f, -0.5f, -0.5f), // bottomleft vert
                }
            },

            {
                Faces.LEFT, new List<Vector3>(){
                    new Vector3(-0.5f, +0.5f, -0.5f), // topleft vert
                    new Vector3(-0.5f, +0.5f, +0.5f), // topright vert
                    new Vector3(-0.5f, -0.5f, +0.5f), // bottomright vert
                    new Vector3(-0.5f, -0.5f, -0.5f), // bottomleft vert
                }
            },

            {
                Faces.RIGHT, new List<Vector3>(){
                    new Vector3(+0.5f, +0.5f, +0.5f), // topleft vert
                    new Vector3(+0.5f, +0.5f, -0.5f), // topright vert
                    new Vector3(+0.5f, -0.5f, -0.5f), // bottomright vert
                    new Vector3(+0.5f, -0.5f, +0.5f), // bottomleft vert
                }
            },

            {
                Faces.TOP, new List<Vector3>(){
                    new Vector3(-0.5f, +0.5f, -0.5f), // topleft vert
                    new Vector3(+0.5f, +0.5f, -0.5f), // topright vert
                    new Vector3(+0.5f, +0.5f, +0.5f), // bottomright vert
                    new Vector3(-0.5f, +0.5f, +0.5f), // bottomleft vert
                }
            },

            {
                Faces.BOTTOM, new List<Vector3>(){
                    new Vector3(-0.5f, -0.5f, +0.5f), // topleft vert
                    new Vector3(+0.5f, -0.5f, +0.5f), // topright vert
                    new Vector3(+0.5f, -0.5f, -0.5f), // bottomright vert
                    new Vector3(-0.5f, -0.5f, -0.5f), // bottomleft vert
                }
            }

        };

        public static readonly Dictionary<Faces, List<Vector3i>> RawIndices = new Dictionary<Faces, List<Vector3i>>()
        {
            {Faces.BACK, new List<Vector3i>()
            {
                new Vector3i(0, 1, 2),
                new Vector3i(2, 3, 0),
            }},

            {Faces.FRONT, new List<Vector3i>()
            {
                new Vector3i(4, 5, 6),
                new Vector3i(6, 7, 4),
            }},

            {Faces.LEFT, new List<Vector3i>()
            {
                new Vector3i(8, 9, 10),
                new Vector3i(10, 11, 8),
            }},

            {Faces.RIGHT, new List<Vector3i>() {
                new Vector3i(12, 13, 14),
                new Vector3i(14, 15, 12)
            }},

            {Faces.TOP, new List<Vector3i>()
            {
                new Vector3i(16, 17, 18),
                new Vector3i(18, 19, 16)
            }},

            {Faces.BOTTOM, new List<Vector3i>()
            {
                new Vector3i(20, 21, 22),
                new Vector3i(22, 23, 20)
            }}
        };
    }

    public class BlockData
    {

    }
}
