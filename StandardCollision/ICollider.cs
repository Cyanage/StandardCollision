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
    {                   //TODO: implement this into the abstract scene class
        Regular,        //Scene does rect collision and calls its OnCollision method
        Trigger,        //Collider does not collide but calls ITS OnCollision method.  if an object hits this its OnCollision method is not called.
        Wall,           //Collider cannot be moved during dynamic Collision.  If a dynamic object runs into this and this is dynamic, this will not be pushed.
        Simple          //Collider does rect collisino and does NOT call its OnCollision method
    };

    public interface ICollider : IObject    //Is also an object... what if dynamic collider, two objects?  TODO: this
    {
        bool isActive { get; set; }
        Rectangle Rect { get; set; }        //rectagle that is the collider of the object and the position the texture is drawn at.

        void OnCollision();                 //oncollision
        CollisionType collisionType { get; set; }   //holds the type of collision this collider object has
    }
}
