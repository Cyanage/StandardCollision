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
    public enum CollisionType
    {                   
        Dynamic,        //Scene does rect collision and calls its OnCollision method
        Trigger,        //Collider does not collide but calls ITS OnCollision method.  if an object hits this its OnCollision method is not called.
        Wall,           //Collider cannot be moved during dynamic Collision.  If a dynamic object runs into this and this is dynamic, this will not be pushed.
        Simple,         //Collider does rect collision and does NOT call its OnCollision method
        SimpleWall      //Simple + Wall
    };

    public interface ICollider : IObject    //Is also an object... what if dynamic collider, two objects?  TODO: this
    {
        bool isActive { get; set; }         //sees if the collider is active

        /// <summary>
        /// If this collider is not dynamic do not choose Dynamic as collision type.
        /// </summary>
        CollisionType collisionType { get; set; }   //holds the type of collision this collider object has

        void OnCollision();                 //oncollision
    }
}
