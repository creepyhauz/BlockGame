using BlockGame.Blocks;
using BlockGame.Buffers;
using BlockGame.Shaders;
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
    public class Chunk
    {
        public const int ChunkSize = 16;
        public const int ChunkHeight = 16;


        public static BlockRenderer BlockRenderer;
        public Block[,,] Blocks = new Block[ChunkSize, ChunkHeight, ChunkSize];

        public Chunk()
        {
            GenBlocks();
            BuildChunk();
        }

        public void GenBlocks()
        {
            for (int y = 0; y < ChunkHeight; y++)
                for (int z = 0; z < ChunkSize; z++)
                    for (int x = 0; x < ChunkSize; x++)
                    {
                        Blocks[x, y, z] = BlockGame.Blocks.Blocks.Dirt;
                    }

            for (int z = 1; z < ChunkSize-1; z++)
                for (int x = 1; x < ChunkSize-1; x++)
                {
                    Blocks[x, ChunkHeight-1, z] = null;
                }

            for (int z = 2; z < ChunkSize - 2; z++)
                for (int x = 2; x < ChunkSize - 2; x++)
                {
                    Blocks[x, ChunkHeight - 2, z] = null;
                }

            for (int z = 4; z < ChunkSize - 4; z++)
                for (int x = 4; x < ChunkSize - 4; x++)
                {
                    Blocks[x, ChunkHeight - 1, z] = BlockGame.Blocks.Blocks.Dirt;
                }

            for (int z = 3; z < ChunkSize - 3; z++)
                for (int x = 3; x < ChunkSize - 3; x++)
                {
                    Blocks[x, ChunkHeight - 2, z] = BlockGame.Blocks.Blocks.Dirt;
                }

        }

        List<TexturedVertex> ChunkVertices = new List<TexturedVertex>();
        List<Vector3i> ChunkIndices = new List<Vector3i>();
        public IBO IBO;
        public VBO<TexturedVertex> VBO;
        public VAO<TexturedVertex> VAO;
        public void BuildChunk()
        {
            for (int y = 0; y < ChunkHeight; y++)
                for (int z = 0; z < ChunkSize; z++)
                    for (int x = 0; x < ChunkSize; x++)
                    {
                        if (Blocks[x, y, z] == null)
                            continue;

                        List<Faces> OpenFaces = new List<Faces>() { Faces.TOP, Faces.BOTTOM, Faces.FRONT, Faces.BACK, Faces.LEFT, Faces.RIGHT };

                        if (x - 1 >= 0 && Blocks[x - 1, y, z] != null)
                            OpenFaces.Remove(Faces.LEFT);

                        if (x + 1 < Blocks.GetLength(0) && Blocks[x + 1, y, z] != null)
                            OpenFaces.Remove(Faces.RIGHT);

                        if (z - 1 >= 0 && Blocks[x, y, z - 1] != null)
                            OpenFaces.Remove(Faces.BACK);

                        if (z + 1 < Blocks.GetLength(2) && Blocks[x, y, z + 1] != null)
                            OpenFaces.Remove(Faces.FRONT);

                        if (y + 1 < Blocks.GetLength(1) && Blocks[x, y + 1, z] != null)
                            OpenFaces.Remove(Faces.TOP);

                        if (y - 1 >= 0 && Blocks[x, y - 1, z] != null)
                            OpenFaces.Remove(Faces.BOTTOM);

                        foreach (var face in OpenFaces)
                        {
                            ChunkVertices.AddRange(FaceDataRaw.RawVertices[face].Select(v => new TexturedVertex(v.Position + new Vector3(x, y, z), v.UV)));
                            ChunkIndices.Add(new Vector3i(ChunkVertices.Count - 4, ChunkVertices.Count - 3, ChunkVertices.Count - 2));
                            ChunkIndices.Add(new Vector3i(ChunkVertices.Count - 2, ChunkVertices.Count - 1, ChunkVertices.Count - 4));
                        }
                    }

            VBO = new VBO<TexturedVertex>(ChunkVertices);
            VAO = new VAO<TexturedVertex>(VBO);
            IBO = new IBO(ChunkIndices);
        }

        public void Render(Shader shader, Camera camera)
        {
            BlockGame.Blocks.Blocks.Dirt.Texture.Use(0);
            shader.SetMatrix4("aTransform", camera.CameraTransform);
            VAO.Bind();
            IBO.Bind();
            GL.DrawElements(PrimitiveType.Triangles, ChunkIndices.Count * 3, DrawElementsType.UnsignedInt, 0);
        }
    }
}
