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
    public abstract class Button : IObject
    {
        public Rectangle buttonRect;
        public Texture2D buttonTexture;

        public bool isMouseHover;
        public bool isClicked;

        /// <summary>
        /// Call this in the constructor.
        /// </summary>
        public void InitializeButton(Rectangle rect)
        {
            buttonRect = rect;
        }

        /// <summary>
        /// Call this in update()
        /// </summary>
        public void ButtonUpdate()  //TODO: Done?
        {
            if (Mouse.GetState().X > buttonRect.Left && Mouse.GetState().X < buttonRect.Right &&
               Mouse.GetState().Y > buttonRect.Top && Mouse.GetState().Y < buttonRect.Bottom)  //This checks if the mouse is over the button
            {
                isMouseHover = true;
                HoverOn();
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)  //Checks if click on button
                {
                    isClicked = true;
                    ButtonDown();
                }
                else if (isClicked == true)
                {
                    isClicked = false;
                    ButtonUp();
                }
            }
            else if (isMouseHover == true)
            {
                isMouseHover = false;
                HoverOff();
            }
        }

        /// <summary>
        /// Called contuniueously when the button is clicked and held.
        /// </summary>
        public abstract void ButtonDown();
        /// <summary>
        /// Called when the button is un-clicked.
        /// </summary>
        public abstract void ButtonUp();
        /// <summary>
        /// Called contuniueously when the cursor is hovering over the button.
        /// </summary>
        public abstract void HoverOn();
        /// <summary>
        /// Called when the cursor moves off the button.
        /// </summary>
        public abstract void HoverOff();

        //IObjectStuff
        public bool isDynamic { get { return false; } }  //An object is not dynamic

        public void HiddenUpdate() //nothing here
        {
            Update();
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
    }
}
