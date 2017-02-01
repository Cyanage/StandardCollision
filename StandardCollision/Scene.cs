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
        public abstract List<IObject> ObjectList { get; set; }
        public abstract List<ICollider> ColliderList { get; set; }
        public abstract List<IDynamic> DynamicList { get; set; }

        public void AddStaticObject(IObject obj)
        {
            ObjectList.Add(obj);
        }

        public void AddDynamicObject(IDynamic dynamic)
        {
            ObjectList.Add(dynamic);
            DynamicList.Add(dynamic);
        }

        public void AddDynamicCollider(ICollider col, IDynamic dynamic)
        {
            ObjectList.Add(dynamic);
            ColliderList.Add(col);
            DynamicList.Add(dynamic);
        }

        public void AddCollider(ICollider col)
        {
            ObjectList.Add(col);
            ColliderList.Add(col);
        }

        public abstract void Update();
        public void Draw(SpriteBatch spriteBatch) //no collider or dynamic, draw the object.
        {
            foreach (IObject obj in ObjectList)
            {
                obj.Draw(spriteBatch);
            }
        }
        public void Collision() //TODO: add collision logic here.
        {

        } 
    }
}
