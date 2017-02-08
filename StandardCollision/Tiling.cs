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
    public abstract class Tiling //TODO: this, add tiling background logic.
    {
        //TODO: add collider resizing
        /// <summary>
        /// Draws the tiles of the object, if using this don't draw the object (again) :C
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="tex"></param>
        /// <param name="rect"></param>
        /// <param name="offSet">the offset of the texture</param>
        /// <param name="textureSize"></param>
        public void TilingDraw(SpriteBatch spriteBatch, Texture2D tex, Rectangle rect, Point offSet, Point textureSize)  //will update and draw the tiles.
        {
            for (int i = 0; i < tiles.X; i++)
            {
                for (int i2 = 0; i2 < tiles.Y; i2++)
                {
                    spriteBatch.Draw(tex, new Rectangle(rect.X + i * 64 + offSet.X, rect.Y + i2 * 64 + offSet.Y, textureSize.X, textureSize.Y), Color.White);
                }
            }
        }

        public abstract Point tiles { get; set; }    //amount of tiles object is made of.  
    }
}
