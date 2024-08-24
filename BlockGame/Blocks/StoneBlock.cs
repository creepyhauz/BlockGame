using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGame.Blocks
{
    public class StoneBlock : Block
    {
        public StoneBlock() : base("Stone", Texture.LoadFromFile("Textures/Blocks/stone.png"))
        {
        }
    }
}
