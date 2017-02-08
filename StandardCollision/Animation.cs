using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StandardCollision
{
    public abstract class Animation
    {
        public abstract List<Texture2D> textureList { get; set; } //holds all of the frames     //todo: change name

        public Animation()
        {
            //when does this get called?
        }
    }
}
