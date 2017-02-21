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
    public abstract class Button
    {
        public Rectangle buttonRect;
        public Texture2D buttonTexture;

        /// <summary>
        /// Call this in the constructor
        /// </summary>
        public void InitializeButton(Rectangle rect, Texture2D tex)
        {
            buttonRect = rect;
            buttonTexture = tex;
        }

        /// <summary>
        /// call this in update
        /// </summary>
        public void ButtonUpdate()  //TODO: implement regular button stuffs
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)  //click on button
            {

            }
        }
    }
}
