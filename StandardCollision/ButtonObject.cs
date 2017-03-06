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
    public abstract class ButtonObject : IObject
    {
        //IObject:
        public void HiddenUpdate()  //Do buttonObject update stuff.
        {
            ButtonUpdate();
            Update();
        }  
        public void Draw(SpriteBatch spriteBatch)  //Draws buttonObject's texture if visible.
        {
            if (isVisible == true)
                spriteBatch.Draw(Texture, Rect, Color.White);
        }

        public abstract bool isDynamic { get; set; }
        public abstract bool isVisible { get; set; }  //Is the object drawn to the screen.
        public abstract string Tag { get; set; }  //All objects have a tag so you can find / catagorize them.
        public abstract Rectangle Rect { get; set; }  //Position and click area of the buttonObject.
        public abstract Texture2D Texture { get; set; }

        public abstract void Update();

        //New:
        public bool isMouseOver;
        public bool isClicked;  //Checks for left click.

        /// <summary>
        /// This is called in the HiddenUpdate() method, before the regular update.
        /// </summary>
        public void ButtonUpdate()
        {
            //This checks if the mouse is hovering over the button.
            if (Mouse.GetState().X > Rect.Left && Mouse.GetState().X < Rect.Right &&
                Mouse.GetState().Y > Rect.Top && Mouse.GetState().Y < Rect.Bottom)  
            {
                isMouseOver = true;
                HoverOn();
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)  //Checks if the left mouse button is clicked.
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
            else if (isMouseOver == true)
            {
                isMouseOver = false;
                HoverOff();
            }
        }

        /// <summary>
        /// Called continuously when the button is clicked and held.  (Before Update()).
        /// </summary>
        public abstract void ButtonDown();
        /// <summary>
        /// Called once when the mouse button clicking the button goes up.  (Before Update()).
        /// </summary>
        public abstract void ButtonUp();
        /// <summary>
        /// Called continuously when the cursor is hovering over the button.  (Before Update()).
        /// </summary>
        public abstract void HoverOn();
        /// <summary>
        /// Called once when the cursor moves off the button.  (Before Update()).
        /// </summary>
        public abstract void HoverOff();
    }
}
