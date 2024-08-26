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
    public class StoneBlock : Block
    {
        public StoneBlock() : base("Stone")
        {
        }

        public override FaceData GetFace(Faces face)
        {
            List<Vector2> UV = TextureAtlas.GetAtlasUV(1, 15);
            switch (face)
            {
                case Faces.FRONT:
                    return new FaceData(
                        [
                        new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), UV[0]), // topleft vert
                        new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), UV[1]), // topright vert
                        new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), UV[2]), // bottomright vert
                        new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), UV[3]), // bottomleft vert
                        ]);

                case Faces.RIGHT:
                    return new FaceData(
                        [
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), UV[0]), // topleft vert
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), UV[1]), // topright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), UV[2]), // bottomright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), UV[3]), // bottomleft vert
                ]);

                case Faces.BACK:
                    return new FaceData(
                        [
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), UV[0]), // topleft vert
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), UV[1]), // topright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f), UV[2]), // bottomright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), UV[3]), // bottomleft vert
                ]);

                case Faces.LEFT:
                    return new FaceData(
                        [
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), UV[0]), // topleft vert
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), UV[1]), // topright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), UV[2]), // bottomright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f), UV[3]), // bottomleft vert
                ]);

                case Faces.TOP:
                    return new FaceData(
                        [
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, -0.5f), UV[0]), // topleft vert
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, -0.5f), UV[1]), // topright vert
                    new TexturedVertex(new Vector3(+0.5f, +0.5f, +0.5f), UV[2]), // bottomright vert
                    new TexturedVertex(new Vector3(-0.5f, +0.5f, +0.5f), UV[3]), // bottomleft vert
                ]);

                case Faces.BOTTOM:
                    return new FaceData(
                        [
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, +0.5f), UV[0]), // topleft vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, +0.5f), UV[1]), // topright vert
                    new TexturedVertex(new Vector3(+0.5f, -0.5f, -0.5f), UV[2]), // bottomright vert
                    new TexturedVertex(new Vector3(-0.5f, -0.5f, -0.5f), UV[3]), // bottomleft vert
                ]);


                default:
                    return new FaceData(FaceDataRaw.RawVertices[face]);
            }
        }
    }
}
