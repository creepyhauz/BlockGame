using BlockGame.Textures;
using BlockGame.VertexStructs;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame.Blocks
{
    public class Grass : Block
    {
        public Grass() : base("Grass")
        {
        }

        public override FaceData GetFace(Faces face)
        {
            List<Vector2> UVTop = TextureAtlas.GetAtlasUV(7, 13);
            List<Vector2> UVBottom = TextureAtlas.GetAtlasUV(2, 15);
            List<Vector2> UVSide = TextureAtlas.GetAtlasUV(3, 15);
            switch (face)
            {
                case Faces.FRONT:
                    return new FaceData(
                        [
                        new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), UVSide[0]), // topleft vert
                        new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), UVSide[1]), // topright vert
                        new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), UVSide[2]), // bottomright vert
                        new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), UVSide[3]), // bottomleft vert
                        ]);

                case Faces.RIGHT:
                    return new FaceData(
                        [
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), UVSide[0]), // topleft vert
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), UVSide[1]), // topright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), UVSide[2]), // bottomright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), UVSide[3]), // bottomleft vert
                ]);

                case Faces.BACK:
                    return new FaceData(
                        [
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), UVSide[0]), // topleft vert
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), UVSide[1]), // topright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f), UVSide[2]), // bottomright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), UVSide[3]), // bottomleft vert
                ]);

                case Faces.LEFT:
                    return new FaceData(
                        [
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), UVSide[0]), // topleft vert
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), UVSide[1]), // topright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), UVSide[2]), // bottomright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f), UVSide[3]), // bottomleft vert
                ]);

                case Faces.TOP:
                    return new FaceData(
                        [
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), UVTop[0]), // topleft vert
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), UVTop[1]), // topright vert
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), UVTop[2]), // bottomright vert
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), UVTop[3]), // bottomleft vert
                ]);

                case Faces.BOTTOM:
                    return new FaceData(
                        [
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), UVBottom[0]), // topleft vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), UVBottom[1]), // topright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), UVBottom[2]), // bottomright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f), UVBottom[3]), // bottomleft vert
                ]);


                default:
                    return new FaceData(FaceDataRaw.RawVertices[face]);
            }
        }
    }
}
