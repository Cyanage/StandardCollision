﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StandardCollision
{
    public abstract class Object : IObject  //Inherit this to make a class an object.
    {
        //IObject:
        public void HiddenUpdate() { Update(); }  //Nothing here for regular object.
        public void Draw(SpriteBatch spriteBatch)  //Draws object's texture if visible.
        {
            if (isVisible == true)
                spriteBatch.Draw(Texture, Rect, Color.White);
        }

        public abstract bool isDynamic { get; set; }
        public abstract bool isVisible { get; set; }  //Is the obejct drawn to the screen.
        public abstract string Tag { get; set; }  //All objects have a tag so you can find / catagorize them.
        public abstract Rectangle Rect { get; set; }  //Position of the object.
        public abstract Texture2D Texture { get; set; }

        public abstract void Update();
    }
}
