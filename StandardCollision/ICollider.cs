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
    interface ICollider
    {
        Rectangle ObjectRect { get; set; }      //rectagle that is the collider of the object and the position the texture is drawn at.
        Texture2D ObjectTexture { get; set; }   //texture that is drawn to the screen.
        Point TextureSize { get; set; }         //size of the texture
        void Draw(SpriteBatch spriteBatch);     //Draw method so that the collider's texture is drawn to the screen.
    }
}
