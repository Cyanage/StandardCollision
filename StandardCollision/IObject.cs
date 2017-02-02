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
        bool isDynamic { get; }             //Checks if object is dynamic.
        string Tag { get; set; }            //All objects have a tag so you can find / catagorize them
        Point Position { get; set; }        //Position of the object
        Texture2D Texture { get; set; }     //Texture of the object
        Point TextureSize { get; set; }     //Size of the texture

        void Update();
        void Draw(SpriteBatch spriteBatch); //draw method for the object
    }
}
