using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame
{

    public interface IVertexInfo
    {
        public static abstract Type VertexType { get; }
        public static abstract int VertexByteSize { get; }
        public static abstract VertexAttribute[] VertexAttributes { get; }
    }

    public struct VertexInfo
    {
        public readonly Type VertexType;
        public readonly int size;
        public readonly VertexAttribute[] attributes;

        public VertexInfo(Type type, params VertexAttribute[] attributes)
        {
            VertexType = type;
            size = 0;
            this.attributes = attributes;

            foreach (var attribute in attributes)
                size += attribute.ComponentCount * attribute.Size;
        }
    }

    public class VertexAttribute
    {
        public readonly string Name;
        public readonly int Index;
        public readonly int Size;
        public readonly int ComponentCount;
        public readonly int Offset;
        public readonly VertexAttribPointerType Type = VertexAttribPointerType.Float;
        public VertexAttribute(string name, int index, int size, int componentCount, int offset, VertexAttribPointerType Type = VertexAttribPointerType.Float)
        {
            Name = name;
            Index = index;
            ComponentCount = componentCount;
            Offset = offset;
            Size = size;
            this.Type = Type;
        }
    }
}
