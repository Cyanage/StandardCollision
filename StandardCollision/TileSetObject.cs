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
    //Note: The tileset will not change sizes when you change the size of the tileSetObject's rect.
    //    : Call TileSetDraw() in the draw method.
    public abstract class TileSetObject : IObject
    {
        //IObject:
        public void HiddenUpdate() { Update(); }  //Nothing here for a tileSetObject.

        public abstract bool isDynamic { get; set; }
        public abstract bool isVisible { get; set; }  //Is the obejct drawn to the screen.
        public abstract string Tag { get; set; }  //All objects have a tag so you can find / catagorize them.
        public abstract Rectangle Rect { get; set; }  //Position of the tileSetObject.
        public abstract Texture2D Texture { get; set; }

        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);

        //New:
        /// <summary>
        /// Draws the tiles of the object, if using this don't draw the object (again). :C
        /// </summary>
        /// <param name="offSet">The amount of pixels the texture is outside the rectangle.</param>
        public void TileSetDraw(SpriteBatch spriteBatch, Point offSet)  //Will update and draw the tiles.
        {
            if (isVisible == true)
            {
                //Finds the size of texture that will fit in the grid (tiles).
                int tileSizeWidth = Rect.Width / tiles.X;
                int tileSizeHeight = Rect.Height / tiles.Y;

                for (int x = 0; x < tiles.X; x++)  //Finds the x position of the current tile.
                {
                    for (int y = 0; y < tiles.Y; y++)  //Finds the y position of the current tile.
                    {
                        spriteBatch.Draw(Texture, new Rectangle(Rect.X + (x * tileSizeWidth) + offSet.X, Rect.Y + (y * tileSizeHeight) + offSet.Y, tileSizeWidth, tileSizeHeight), Color.White);
                    }
                }
            }
        }
        /// <summary>
        /// Draws the tiles of the object, if using this don't draw the object (again). :C
        /// </summary>
        /// <param name="offSet">The amount of pixels the texture is outside the rectangle.</param>
        /// <param name="texSize">The size of the texture.</param>
        public void TileSetDraw(SpriteBatch spriteBatch, Point offSet, Point texSize)  //Will update and draw the tiles.
        {
            if (isVisible == true)
            {
                //Finds the size of texture that will fit in the grid (tiles).
                int tileSizeWidth = Rect.Width / tiles.X;
                int tileSizeHeight = Rect.Height / tiles.Y;

                for (int x = 0; x < tiles.X; x++)  //Finds the x position of the current tile.
                {
                    for (int y = 0; y < tiles.Y; y++)  //Finds the y position of the current tile.
                    {
                        spriteBatch.Draw(Texture, new Rectangle(Rect.X + (x * tileSizeWidth) + offSet.X, Rect.Y + (y * tileSizeHeight) + offSet.Y, texSize.X, texSize.Y), Color.White);
                    }
                }
            }
        }

        public abstract Point tiles { get; set; }  //Amount of tiles the object is made of.  
    }
}
