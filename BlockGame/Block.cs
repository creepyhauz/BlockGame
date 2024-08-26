using BlockGame.Blocks;
using OpenTK.Mathematics;

namespace BlockGame
{
    public abstract class Block
    {

        public string ID { get; set; }
        public Texture Texture { get; set; }

        public Block(string id)
        {
            ID = id;
        }

        public abstract FaceData GetFace(Faces face);
    }
}