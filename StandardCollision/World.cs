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
    public abstract class World
    {
        public abstract List<Scene> sceneList { get; set; }  //holds all of the scenes in the world
        public abstract Scene activeScene { get; set; }  //holds the active scene that is currently getting drawn and updated.
        
        public void WorldUpdate ()
        {
            activeScene.HiddenUpdate();  //calls the hidden update method which in turn calls the regular update method.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            activeScene.Draw(spriteBatch);  //calls the active scene draw method.
        } 
    }
}
