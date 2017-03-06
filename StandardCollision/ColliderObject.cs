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
    public abstract class ColliderObject : ICollider
    {
        //IObject:
        public void HiddenUpdate() { Update(); }  //Nothing here for a colliderObject.
        public void Draw(SpriteBatch spriteBatch)  //Draws Collider's texture if visible.
        {
            if (isVisible == true)
                spriteBatch.Draw(Texture, Rect, Color.White);
        }

        public abstract bool isDynamic { get; set; }
        public abstract bool isVisible { get; set; }  //Is the obejct drawn to the screen.
        public abstract string Tag { get; set; }  //All objects have a tag so you can find / catagorize them.
        public abstract Rectangle Rect { get; set; }  //Position and collider of the colliderObject.
        public abstract Texture2D Texture { get; set; }

        public abstract void Update();

        //IColllider:
        public abstract bool isColliderActive { get; set; }  //Does the collider of the colliderObject function?
        public abstract Point TextureSize { get; set; }  //Size of the texture (if texture needs to be larger or smaller than rect bounds).
        public abstract CollisionType collisionType { get; set; }

        public abstract void OnCollision();
    }
}
