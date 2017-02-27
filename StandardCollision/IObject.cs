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
    public interface IObject
    {
        /// <summary>
        /// Define this bool as true if the collider is dynamic, if else false.
        /// </summary>
        bool isDynamic { get; }         //make sure to define an object as dynamic if it is dynamic      //no set cause you dont want to change it
        bool isVisible { get; set; }  //is the obejct drawn to the screen.

        string Tag { get; set; }            //All objects have a tag so you can find / catagorize them
        Rectangle Rect { get; set; }        //Position of the object
        Texture2D Texture { get; set; }     //Texture of the object
        Point TextureSize { get; set; }     //Size of the texture

        void HiddenUpdate(); //calls update and has the abstract class update stuff in it.
        void Update();
        void Draw(SpriteBatch spriteBatch); //main draw method for the object
    }
}
