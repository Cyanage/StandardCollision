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
    public abstract class Scene //TODO: this
    {
        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
