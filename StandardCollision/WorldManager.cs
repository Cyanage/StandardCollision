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
    public class WorldManager
    {
        public List<World> worldList = new List<World>();  //holds all of the worlds
        public World activeWorld;  //holds the active world that is currently getting drawn and updated.

        public void SetActiveWorld(World toBeActiveWorld)
        {
            activeWorld = toBeActiveWorld;  //sets currently active world.
        }

        public void WorldManagerUpdate()
        {
            activeWorld.WorldUpdate();  //calls the hidden update method which in turn calls the regular update method.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            activeWorld.Draw(spriteBatch);  //calls the active scene draw method.
        }
    }
}
