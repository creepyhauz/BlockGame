using BlockGame.Blocks;
using BlockGame.Buffers;
using BlockGame.Shaders;
using BlockGame.Textures;
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
        public const int ChunkHeight = 32;
        public Vector2i ChunkPos = new Vector2i(0, 0);

        public static BlockRenderer BlockRenderer;
        public Block[,,] Blocks = new Block[ChunkSize, ChunkHeight, ChunkSize];

        public Chunk(Vector2i chunkPos)
        {
            ChunkPos = chunkPos;
            GenBlocks(GenChunkHeights());
            BuildChunk();
        }

        public void GenBlocks(float[,] Heights)
        {

            for (int z = 0; z < ChunkSize; z++)
                for (int x = 0; x < ChunkSize; x++)
                    for (int y = 0; y < (Heights[x, z]/10); y++)
                    {
                        if (y >= 15)
                            Blocks[x, y, z] = BlockGame.Blocks.Blocks.Dirt;
                        else
                            Blocks[x, y, z] = BlockGame.Blocks.Blocks.Stone;
                    }


            for (int z = 0; z < ChunkSize; z++)
                for (int x = 0; x < ChunkSize; x++)
                    for (int y = 0; y < (Heights[x, z] / 10); y++)
                    {
                        if (Blocks[x, y, z] == BlockGame.Blocks.Blocks.Dirt && ( y+1> ChunkHeight || Blocks[x, y+1, z] == null))
                            Blocks[x, y, z] = BlockGame.Blocks.Blocks.Grass;
                    }

            Blocks[0, 0, 0] = BlockGame.Blocks.Blocks.DownDoor;
        }

        List<TexturedVertex> ChunkVertices = new List<TexturedVertex>();
        List<Vector3i> ChunkIndices = new List<Vector3i>();
        public IBO IBO;
        public VBO<TexturedVertex> VBO;
        public VAO<TexturedVertex> VAO;

        public float[,] GenChunkHeights()
        {
            float[,] Heights = new float[ChunkSize, ChunkSize];
            for (int z = 0; z < ChunkSize; z++)
                for (int x = 0; x < ChunkSize; x++)
                    Heights[x, z] = SimplexNoise.Noise.CalcPixel2D((int)(ChunkPos.X * ChunkSize + x), (int)(ChunkPos.Y * ChunkSize + z), 0.01f);

            return Heights;
        }

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
                            AddFace(Blocks[x, y, z], face, new Vector3(x, y, z));
                        }
                    }

            VBO = new VBO<TexturedVertex>(ChunkVertices);
            VAO = new VAO<TexturedVertex>(VBO);
            IBO = new IBO(ChunkIndices);
        }

        public void AddFace(Block block, Faces face, Vector3 Pos)
        {
            Vector2i CHUNK_POS = (ChunkPos * ChunkSize);
            ChunkVertices.AddRange(block.GetFace(face).vertices.Select(v => new TexturedVertex(v.Position + Pos + new Vector3(CHUNK_POS.X, 0, CHUNK_POS.Y), v.UV)));
            ChunkIndices.Add(new Vector3i(ChunkVertices.Count - 4, ChunkVertices.Count - 3, ChunkVertices.Count - 2));
            ChunkIndices.Add(new Vector3i(ChunkVertices.Count - 2, ChunkVertices.Count - 1, ChunkVertices.Count - 4));
        }

        public void Render(Shader shader, Player camera)
        {
            TextureAtlas.Atlas.Use(0);
            shader.SetMatrix4("aTransform", camera.CameraTransform);
            VAO.Bind();
            IBO.Bind();
            GL.DrawElements(PrimitiveType.Triangles, ChunkIndices.Count * 3, DrawElementsType.UnsignedInt, 0);
        }
    }
}
