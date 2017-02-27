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
    public abstract class Collider : ICollider //TODO: shit got confusing
    {
        public bool isDynamic { get { return false; } }  //An object is not dynamic

        public void HiddenUpdate() //nothing here?
        {

        }

        public void Draw(SpriteBatch spriteBatch)  //draws object's texture.
        {
            spriteBatch.Draw(Texture, Rect, Color.White);
        }

        public abstract bool isVisible { get; set; }  //is the obejct drawn to the screen.

        public abstract string Tag { get; set; }            //All objects have a tag so you can find / catagorize them
        public abstract Rectangle Rect { get; set; }        //Position of the object
        public abstract Texture2D Texture { get; set; }     //Texture of the object
        public abstract Point TextureSize { get; set; }     //Size of the texture

        public abstract void Update();


        public abstract bool isActive { get; set; } //collider active

        public abstract CollisionType collisionType { get; set; }   //holds the type of collision this collider object has

        public abstract void OnCollision();    //oncollision
    }
}
