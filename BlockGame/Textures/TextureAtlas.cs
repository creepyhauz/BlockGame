using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame.Textures
{
    public static class TextureAtlas
    {
        private static Texture _atlas = null; //Временно использую старый атлас из Minecraft.
        private static Vector2i textureSize;

        public static Texture Atlas => _atlas;

        public static Vector2i TextureSize => textureSize; public static void Generate(Vector2i size)
        {
            _atlas = Texture.LoadFromFile("Textures/terrain.png"); //Временно использую старый атлас из Minecraft.
            textureSize = size;
            // TODO
        }

        public static void AddTexture(Texture texture)
        {
            // TODO
        }

        public static void AddTexture(Texture texture, Vector2i position)
        {
            // TODO
        }

        public static void AddTexture(Texture texture, Vector2i position, Vector2i size)
        {
            // TODO
        }

        public static Texture GetTexture(Vector2i position)
        {
            // TODO
            return null;
        }

        public static List<Vector2> GetAtlasUV(int x, int y) => GetAtlasUV(new Vector2i(x, y));

        public static List<Vector2> GetAtlasUV(Vector2i pos)
        {
            Vector2 PRatio = (Vector2)textureSize / (Vector2)Atlas.Size;

            Vector2 BasePos = pos * PRatio;


            return
                [
                    BasePos+new Vector2(0,PRatio.Y),
                    BasePos+new Vector2(PRatio.X,PRatio.Y),
                    BasePos+new Vector2(PRatio.X,0),
                    BasePos
                ];
        }
    }
}
