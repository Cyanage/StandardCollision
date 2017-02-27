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
    public abstract class Scene : SceneCollision
    {
        //hold if the scene is active or not, pretty much the current scene. 
        //If a scene is not active it is not drawing its objects and not updating or checking collision for them  
        //public abstract bool Active { get; set; }       
        //TODO: make sure this ^ is obselete

        //holds the list values for objects, colliders, and dynamic objects
        public abstract List<IObject> objectList { get; set; }      
        public abstract List<ICollider> colliderList { get; set; }  

        //dynamic list does not call draw or update for it's class becasue it is a separate interface that object while collider is the same interface.
        public abstract List<IDynamic> dynamicList { get; set; }    

        public abstract void SceneUpdate();

        public void HiddenUpdate()
        {
            foreach (IDynamic dynamic in dynamicList) {  //moves the object based on the current dynamic variable.  //best solution?
                foreach (IObject obj in dynamicList)  //does it for objects
                {
                    if (dynamic.GetType() == obj.GetType())  //checks if they both have the same base class.
                    {
                        obj.Rect = new Rectangle(obj.Rect.X - dynamic.Velocity.X, obj.Rect.Y, obj.Rect.Width, obj.Rect.Height);
                    }
                }
                foreach (ICollider col in dynamicList)  //does it for colliders
                { 
                    if (dynamic.GetType() == col.GetType())  //checks if they both have the same base class.
                    {
                        col.Rect = new Rectangle(col.Rect.X - dynamic.Velocity.X, col.Rect.Y, col.Rect.Width, col.Rect.Height);
                    }
                }
            }

            foreach (IObject obj in dynamicList) {  //updates all objects
                obj.HiddenUpdate();
            }
            foreach (ICollider col in dynamicList) {  //updates all colliders
                col.HiddenUpdate();
            }

            SceneUpdate();
        }

        public void AddObject(IObject obj)  //adds an object to the scene
        {
            objectList.Add(obj);
        }

        public void AddCollider(ICollider col)  //adds a collider to the scene
        {
            colliderList.Add(col);
        }

        public void AddDynamicObject(IDynamic dynamic, IObject obj)  //dynamic is a separate interface //adds a dynamic object to the scene
        {
            objectList.Add(obj);
            dynamicList.Add(dynamic);
        }

        public void AddDynamicCollider(IDynamic dynamic, ICollider col)  //dynamic is a separate interface //adds a dynamic collider to the scene
        {
            colliderList.Add(col);
            dynamicList.Add(dynamic);   
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();  //start drawing   //TODO: put camera here
            foreach (IObject obj in objectList) {  //draws objects
                obj.Draw(spriteBatch);
            }
            foreach (ICollider col in objectList) {  //draws colliders
                col.Draw(spriteBatch);
            }
            spriteBatch.End();  //stop drawing
        }

        public void Collision()
        {
            foreach (ICollider col in colliderList)
            {
                if (col.isDynamic == true)  //all dynamic colldiers
                {  
                    foreach (ICollider col2 in colliderList)
                    {
                        if (col2.isDynamic == false)  //all static colldiers
                        {
                            if (col.isActive == false || col2.isActive == false)  //if either of these are not active dont collide them 
                            {
                                //TODO: find distance here, before checking intersection
                                if (col.Rect.Intersects(col2.Rect)) //checks if objects intersect
                                {
                                    Collide(col, col2); //collides the objects
                                }
                            }
                        }
                    }
                }
            }

            //Collides all dynamic colliders with all dynamic colliders
            for (int i = 0; i < colliderList.Count; i++) //y        
            {
                if (colliderList[i].isDynamic == true)  //all dynamic colldiers
                {
                    for (int i2 = colliderList.Count - 1; i2 > i; i2--) //x
                    {
                        if (colliderList[i2].isDynamic == true)  //all dynamic colliders
                        {
                            if (colliderList[i].isActive == false || colliderList[i2].isActive == false)  //if either of these 
                            {
                                //TODO: find distance here, before checking intersection
                                if (colliderList[i].Rect.Intersects(colliderList[i2].Rect)) //checks if objects intersect
                                {
                                    Collide(colliderList[i], colliderList[i2]); //collides the objects
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
