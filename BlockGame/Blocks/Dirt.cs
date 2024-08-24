using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame.Blocks
{
    public class DirtBlock : Block
    {
        public DirtBlock() : base("Dirt", Texture.LoadFromFile("Textures/Blocks/dirt.png"))
        {
        }
    }
}
