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
    public abstract class TileSetCollider : ICollider //TODO: shit got confusing
    {
        //TODO: add collider resizing (tiles needs to change size wehn the rectangle changes sizes)

        /// <summary>
        /// Draws the tiles of the object, if using this don't draw the object (again) :C  Also remember to call this
        /// </summary>
        /// <param name="tex">the texture</param>
        /// <param name="rect">the rectangle</param>
        /// <param name="offSet">the offset of the texture</param>
        /// <param name="texSize">the size of the texture</param>
        public void TilesetDraw(SpriteBatch spriteBatch, Texture2D tex, Rectangle rect, Point offSet, Point texSize)  //will update and draw the tiles.
        {
            for (int i = 0; i < tiles.X; i++)   //finds x
            {
                for (int i2 = 0; i2 < tiles.Y; i2++)    //finds y
                {
                    spriteBatch.Draw(tex, new Rectangle(rect.X + i * 64 + offSet.X, rect.Y + i2 * 64 + offSet.Y, texSize.X, texSize.Y), Color.White);
                }
            }
        }

        public abstract Point tiles { get; set; }    //amount of tiles object is made of.  

        //Object Stuff
        public void HiddenUpdate() //what is here for collider tileset?
        {
            Update();
        }

        public void Draw(SpriteBatch spriteBatch)  //draws object's texture if visible
        {
            if (isVisible == true)
                spriteBatch.Draw(Texture, Rect, Color.White);
        }

        public abstract bool isDynamic { get; set; }
        public abstract bool isVisible { get; set; }  //is the object drawn to the screen.
        public abstract string Tag { get; set; }  //All objects have a tag so you can find / catagorize them
        public abstract Rectangle Rect { get; set; }  //Position of the object
        public abstract Texture2D Texture { get; set; }
        public abstract Point TextureSize { get; set; }  //Size of the texture (if texture needs to be larger or smaller than rect bounds)

        public abstract void Update();

        //Collider stuff
        public abstract bool isColliderActive { get; set; }  //collider wise
        public abstract CollisionType collisionType { get; set; }   //holds the type of collision this collider object has

        public abstract void OnCollision();
    }
}
