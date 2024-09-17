using BlockGame.Shaders;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame
{
    public class World
    {

        public const int WorldSize = 16;

        public Chunk[,] chunks = new Chunk[WorldSize, WorldSize];


        public World()
        {
            for (int z = -WorldSize / 2; z < WorldSize / 2; z++)
            {
                for (int x = -WorldSize / 2; x < WorldSize / 2; x++)
                {
                    chunks[x + WorldSize / 2, z + WorldSize / 2] = new Chunk(new Vector2i(x, z));
                }
            }
        }


        public void Render(Shader shader, Player camera)
        {
            for (int z = 0; z < WorldSize; z++)
            {
                for (int x = 0; x < WorldSize; x++)
                {
                    chunks[x, z].Render(shader, camera);
                }
            }
        }
    }
}
