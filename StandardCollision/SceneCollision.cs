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
    //Don't worry, this all works :P
    public class SceneCollision //holds background collision logic
    {
        //If only one collider is static (wall) it will be col2
        //In dynamic to static collision static is col2
        //col2's isDynamic will most likely never be false 
        //both colliders will be active (probably?)
        public void Collide(ICollider col1, ICollider col2)  //finds the type of collision to call and calls it
        {
            //TODO: Order these by most likely to occur.  Also re-order these later to change prefromance later in the game. (depending on what types of objects exist)
            if ((col1.collisionType == CollisionType.Dynamic || col1.collisionType == CollisionType.Simple) && (col2.collisionType == CollisionType.Dynamic || col2.collisionType == CollisionType.Simple))  //calls regular collision if both colliders are either dynamic or simple
            {
                RegularCollision(col1, col2);
            }
            else if ((col1.collisionType == CollisionType.Wall || col1.collisionType == CollisionType.SimpleWall) || (col2.collisionType == CollisionType.Wall || col2.collisionType == CollisionType.SimpleWall))  //calls wall collision if one or two colliders are a wall (or simple wall)
            {
                if (col2.isDynamic == false)  //col2 is the static collider in dynamic vs static collision
                {
                    if (col2.collisionType == CollisionType.Wall)   //col2 is the static wall and doesn't want to be moved
                        WallCollision(col2, col1);
                    else
                        WallCollision(col1, col2);
                }
                else if (col1.isDynamic == false)  //col2 is the static collider in dynamic vs static collision     //in case something is changed in an on Collision method
                {
                    if (col1.collisionType == CollisionType.Wall)   //col2 is the static wall and doesn't want to be moved
                        WallCollision(col1, col2);
                    else
                        WallCollision(col2, col1);
                }
                else  //calls collision for two dynamic walls and doesn't move either of them
                {
                    CallCollision(col1, col2);
                }
            }
            else if (col1.collisionType == CollisionType.Trigger ^ col2.collisionType == CollisionType.Trigger)  //checks if only one collider is a trigger (^ is xor and xor checks if the boolean values are different)  //calls the CallCollision() method because neither objects should move
            {
                CallCollision(col1, col2);
            }
            else if (col1.collisionType == CollisionType.Trigger && col2.collisionType == CollisionType.Trigger)  //two triggers call regular collision
            {
                RegularCollision(col1, col2);
            }
        }

        public void CallCollision(ICollider col1, ICollider col2)  //calls the OnCollision method of the colliders if they are the right type (it cheks if they are the right type)
        {
            if (col1.collisionType != CollisionType.Simple && col1.collisionType != CollisionType.Simple)  //makes sure col1 is not simple or simple wall (simple means dont call OnCollision)
                col1.OnCollision();

            if (col2.collisionType != CollisionType.Simple && col2.collisionType != CollisionType.Simple)  //makes sure col2 is not simple or simple wall (simple means dont call OnCollision)
                col2.OnCollision();
        }

        public void RegularCollision(ICollider col1, ICollider col2)  //collision where both objects are pushed back.
        {
            //TODO: re-check this, prolly done
            if (col1.Rect.X > col2.Rect.X) //finds what side of the wall the player is on (X axis)
            {
                if (col1.Rect.Y > col2.Rect.Y) //ditto but with Y
                {   //  Intersect rectangle width                       <  Intersect rectangle height 
                    if ((col2.Rect.Width - (col1.Rect.X - col2.Rect.X)) < (col2.Rect.Height - (col1.Rect.Y - col2.Rect.Y))) //Checks which direction to push the colliders
                    {
                        col1.Rect = new Rectangle(col1.Rect.X + (col2.Rect.Width - (col1.Rect.X - col2.Rect.X)) / 2, col1.Rect.Y, col1.Rect.Width, col1.Rect.Height);  //pushes col1 back half.
                        col2.Rect = new Rectangle(col2.Rect.X - (col2.Rect.Width - (col1.Rect.X - col2.Rect.X)) / 2, col2.Rect.Y, col2.Rect.Width, col2.Rect.Height);  //and col2 back the other half in the opposite direction.
                    }
                    else
                    {
                        col1.Rect = new Rectangle(col1.Rect.X, col1.Rect.Y + (col2.Rect.Height - (col1.Rect.Y - col2.Rect.Y)) / 2, col1.Rect.Width, col1.Rect.Height);  //pushes col1 back half.
                        col2.Rect = new Rectangle(col2.Rect.X, col2.Rect.Y - (col2.Rect.Height - (col1.Rect.Y - col2.Rect.Y)) / 2, col2.Rect.Width, col2.Rect.Height);  //and col2 back the other half in the opposite direction.
                    }
                }
                else
                {   //  Intersect rectangle width                       <  Intersect rectangle height 
                    if ((col2.Rect.Width - (col1.Rect.X - col2.Rect.X)) < (col1.Rect.Height + (col1.Rect.Y - col2.Rect.Y))) //Checks which direction to push the colliders
                    {
                        col1.Rect = new Rectangle(col1.Rect.X + (col2.Rect.Width - (col1.Rect.X - col2.Rect.X)) / 2, col1.Rect.Y, col1.Rect.Width, col1.Rect.Height);  //pushes col1 back half.
                        col2.Rect = new Rectangle(col2.Rect.X - (col2.Rect.Width - (col1.Rect.X - col2.Rect.X)) / 2, col2.Rect.Y, col2.Rect.Width, col2.Rect.Height);  //and col2 back the other half in the opposite direction.
                    }
                    else
                    {
                        col1.Rect = new Rectangle(col1.Rect.X, col1.Rect.Y - (col1.Rect.Height + (col1.Rect.Y - col2.Rect.Y)) / 2, col1.Rect.Width, col1.Rect.Height);  //pushes col1 back half.
                        col2.Rect = new Rectangle(col2.Rect.X, col2.Rect.Y + (col1.Rect.Height + (col1.Rect.Y - col2.Rect.Y)) / 2, col2.Rect.Width, col2.Rect.Height);  //and col2 back the other half in the opposite direction.
                    }
                }
            }
            else
            {
                if (col1.Rect.Y > col2.Rect.Y)
                {   //  Intersect rectangle width                       <  Intersect rectangle height 
                    if ((col1.Rect.Width + (col1.Rect.X - col2.Rect.X)) < (col2.Rect.Height - (col1.Rect.Y - col2.Rect.Y))) //Checks which direction to push the colliders
                    {
                        col1.Rect = new Rectangle(col1.Rect.X - (col1.Rect.Width + (col1.Rect.X - col2.Rect.X)) / 2, col1.Rect.Y, col1.Rect.Width, col1.Rect.Height);
                        col2.Rect = new Rectangle(col2.Rect.X + (col1.Rect.Width + (col1.Rect.X - col2.Rect.X)) / 2, col2.Rect.Y, col2.Rect.Width, col2.Rect.Height);
                    }
                    else
                    {
                        col1.Rect = new Rectangle(col1.Rect.X, col1.Rect.Y + (col2.Rect.Height - (col1.Rect.Y - col2.Rect.Y)) / 2, col1.Rect.Width, col1.Rect.Height);
                        col2.Rect = new Rectangle(col2.Rect.X, col2.Rect.Y - (col2.Rect.Height - (col1.Rect.Y - col2.Rect.Y)) / 2, col2.Rect.Width, col2.Rect.Height);
                    }
                }
                else
                {   //  Intersect rectangle width                       <  Intersect rectangle height 
                    if ((col1.Rect.Width + (col1.Rect.X - col2.Rect.X)) < (col1.Rect.Height + (col1.Rect.Y - col2.Rect.Y))) //Checks which direction to push the colliders
                    {
                        col1.Rect = new Rectangle(col1.Rect.X - (col1.Rect.Width + (col1.Rect.X - col2.Rect.X)) / 2, col1.Rect.Y, col1.Rect.Width, col1.Rect.Height);
                        col2.Rect = new Rectangle(col2.Rect.X + (col1.Rect.Width + (col1.Rect.X - col2.Rect.X)) / 2, col2.Rect.Y, col2.Rect.Width, col2.Rect.Height);
                    }
                    else
                    {
                        col1.Rect = new Rectangle(col1.Rect.X, col1.Rect.Y - (col1.Rect.Height + (col1.Rect.Y - col2.Rect.Y)) / 2, col1.Rect.Width, col1.Rect.Height);
                        col2.Rect = new Rectangle(col2.Rect.X, col2.Rect.Y - (col1.Rect.Height + (col1.Rect.Y - col2.Rect.Y)) / 2, col2.Rect.Width, col2.Rect.Height);
                    }
                }
            }
        }

        public void WallCollision(ICollider col1, ICollider col2)  //collision where collider two is pushed back
        {
            if (col1.Rect.X > col2.Rect.X) //finds what side of the wall the player is on (X axis)
            {
                if (col1.Rect.Y > col2.Rect.Y) //ditto but with Y
                {
                    if ((col2.Rect.Width - (col1.Rect.X - col2.Rect.X)) < (col2.Rect.Height - (col1.Rect.Y - col2.Rect.Y))) //Checks which direction to push the collider
                    {
                        col1.Rect = new Rectangle(col1.Rect.X + (col2.Rect.Width - (col1.Rect.X - col2.Rect.X)), col1.Rect.Y, col1.Rect.Width, col1.Rect.Height);
                    }
                    else
                    {
                        col1.Rect = new Rectangle(col1.Rect.X, col1.Rect.Y + (col2.Rect.Height - (col1.Rect.Y - col2.Rect.Y)), col1.Rect.Width, col1.Rect.Height);
                    }
                }
                else
                {
                    if ((col2.Rect.Width - (col1.Rect.X - col2.Rect.X)) < (col1.Rect.Height + (col1.Rect.Y - col2.Rect.Y))) //Checks which direction to push the collider
                    {
                        col1.Rect = new Rectangle(col1.Rect.X + (col2.Rect.Width - (col1.Rect.X - col2.Rect.X)), col1.Rect.Y, col1.Rect.Width, col1.Rect.Height);
                    }
                    else
                    {
                        col1.Rect = new Rectangle(col1.Rect.X, col1.Rect.Y - (col1.Rect.Height + (col1.Rect.Y - col2.Rect.Y)), col1.Rect.Width, col1.Rect.Height);

                    }
                }
            }
            else
            {
                if (col1.Rect.Y > col2.Rect.Y)
                {
                    if ((col1.Rect.Width + (col1.Rect.X - col2.Rect.X)) < (col2.Rect.Height - (col1.Rect.Y - col2.Rect.Y))) //Checks which direction to push the collider
                    {
                        col1.Rect = new Rectangle(col1.Rect.X - (col1.Rect.Width + (col1.Rect.X - col2.Rect.X)), col1.Rect.Y, col1.Rect.Width, col1.Rect.Height);
                    }
                    else
                    {
                        col1.Rect = new Rectangle(col1.Rect.X, col1.Rect.Y + (col2.Rect.Height - (col1.Rect.Y - col2.Rect.Y)), col1.Rect.Width, col1.Rect.Height);
                    }
                }
                else
                {
                    if ((col1.Rect.Width + (col1.Rect.X - col2.Rect.X)) < (col1.Rect.Height + (col1.Rect.Y - col2.Rect.Y))) //Checks which direction to push the collider
                    {
                        col1.Rect = new Rectangle(col1.Rect.X - (col1.Rect.Width + (col1.Rect.X - col2.Rect.X)), col1.Rect.Y, col1.Rect.Width, col1.Rect.Height);
                    }
                    else
                    {
                        col1.Rect = new Rectangle(col1.Rect.X, col1.Rect.Y - (col1.Rect.Height + (col1.Rect.Y - col2.Rect.Y)), col1.Rect.Width, col1.Rect.Height);
                    }
                }
            }
        }
    }
}
