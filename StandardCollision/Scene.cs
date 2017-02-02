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
    public abstract class Scene //TODO: this?  done?
    {
        //hold if the scene is active or not, pretty much the current scene. 
        //If a scene is not active it is not drawing its objects and not updating or checking collision for them  
        public abstract bool Active { get; set; }       

        //holds the list values for objects, colliders, and dynamic objects
        public abstract List<IObject> objectList { get; set; }
        public abstract List<ICollider> colliderList { get; set; }
        public abstract List<IDynamic> dynamicList { get; set; }

        public void AddStaticObject(IObject obj)
        {
            objectList.Add(obj);
        }

        public void AddDynamicObject(IDynamic dynamic)
        {
            objectList.Add(dynamic);
            dynamicList.Add(dynamic);
        }

        public void AddDynamicCollider(ICollider col, IDynamic dynamic)
        {
            objectList.Add(dynamic);
            colliderList.Add(col);
            dynamicList.Add(dynamic);
        }

        public void AddCollider(ICollider col)
        {
            objectList.Add(col);
            colliderList.Add(col);
        }

        //TODO: HiddenUpdate() that calls Update()?  can have foreach that cdalls the update for each object.
        public abstract void Update();
        public void Draw(SpriteBatch spriteBatch) //no collider or dynamic, draw the object part.
        {
            foreach (IObject obj in objectList)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void Collision() //TODO: add collision logic here.
        {

        } 
    }
}
