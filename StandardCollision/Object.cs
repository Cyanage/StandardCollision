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
    public abstract class Object : IObject  //Inherit this to make a class an object
    {
        //This is done.
        public abstract bool isDynamic { get; set; }

        public void HiddenUpdate() { Update(); }  //nothing here for regular object

        public void Draw(SpriteBatch spriteBatch)  //draws object's texture if visible
        {
            if (isVisible == true)
                spriteBatch.Draw(Texture, Rect, Color.White);
        } 

        public abstract bool isVisible { get; set; }  //is the obejct drawn to the screen.
        public abstract string Tag { get; set; }            //All objects have a tag so you can find / catagorize them
        public abstract Rectangle Rect { get; set; }        //Position of the object
        public abstract Texture2D Texture { get; set; }     
        //public abstract Point TextureSize { get; set; }     //Size of the texture (if texture needs to be larger or smaller than rect's bounds)       //TODO: prolly not use this for objects?

        public abstract void Update();
        
    }
}
