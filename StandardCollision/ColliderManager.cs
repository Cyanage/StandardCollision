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
    class ColliderManager   //TODO: will be replaced with scene abstract class
    {
        public static ICollider playerCollider; //the collider of the player
        public static IDynamic playerVelocity; //the velocity of the player, add the moving player object to these two variables.
        public static List<ICollider> enviromentColliderList = new List<ICollider>();   //list that hold all the colliders that are part of the enviroment.  Add non-moving collider classes to this. 

        public static void Initialize() //this is static so no constructor, use this as constructor.
        {
            //TODO: add classes that inherit ICollider to playerCollider and envoromentColliderList.
        }

        public static void Update() //holds all the update logic.
        {
            //moving the player by its velocity.
            playerCollider.Rect = new Rectangle((int)(playerCollider.Rect.X + playerVelocity.Velocity.X), (int)(playerCollider.Rect.Y + playerVelocity.Velocity.Y), playerCollider.Rect.Width, playerCollider.Rect.Height);
            Collision(); //checks object collision
        }

        private static void Collision()
        {
            foreach (ICollider col in enviromentColliderList)
            {
                if (playerCollider.Rect.Intersects(col.Rect)) //checks if the player is colliding with the current object in the foreach loop.
                {
                    //TODO: add distance checker
                    if (playerCollider.Rect.X > col.Rect.X) //finds what side of the wall the player is on
                    {
                        if (playerCollider.Rect.Y > col.Rect.Y) //ditto
                        {
                            if ((col.Rect.Width - (playerCollider.Rect.X - col.Rect.X)) < (col.Rect.Height - (playerCollider.Rect.Y - col.Rect.Y))) //Checks which direction to push the character
                            {
                                playerCollider.Rect = new Rectangle(playerCollider.Rect.X + (col.Rect.Width - (playerCollider.Rect.X - col.Rect.X)),
                                                                          playerCollider.Rect.Y,
                                                                          playerCollider.Rect.Width,
                                                                          playerCollider.Rect.Height);
                                playerVelocity.Velocity = new Point(0, playerVelocity.Velocity.Y); //when the player hits an object velocity disapears in one axis
                            }
                            else
                            {
                                playerCollider.Rect = new Rectangle(playerCollider.Rect.X,
                                                                          playerCollider.Rect.Y + (col.Rect.Height - (playerCollider.Rect.Y - col.Rect.Y)),
                                                                          playerCollider.Rect.Width,
                                                                          playerCollider.Rect.Height);
                                playerVelocity.Velocity = new Point(playerVelocity.Velocity.X, 0); //when the player hits an object velocity disapears in one axis

                            }
                        }
                        else
                        {
                            if ((col.Rect.Width - (playerCollider.Rect.X - col.Rect.X)) < (playerCollider.Rect.Height + (playerCollider.Rect.Y - col.Rect.Y))) //Checks which direction to push the character
                            {
                                playerCollider.Rect = new Rectangle(playerCollider.Rect.X + (col.Rect.Width - (playerCollider.Rect.X - col.Rect.X)),
                                                                          playerCollider.Rect.Y,
                                                                          playerCollider.Rect.Width,
                                                                          playerCollider.Rect.Height);
                                playerVelocity.Velocity = new Point(0, playerVelocity.Velocity.Y); //when the player hits an object velocity disapears in one axis
                            }
                            else
                            {
                                playerCollider.Rect = new Rectangle(playerCollider.Rect.X,
                                                                          playerCollider.Rect.Y - (playerCollider.Rect.Height + (playerCollider.Rect.Y - col.Rect.Y)),
                                                                          playerCollider.Rect.Width,
                                                                          playerCollider.Rect.Height);
                                playerVelocity.Velocity = new Point(playerVelocity.Velocity.X, 0); //when the player hits an object velocity disapears in one axis

                            }
                        }
                    }
                    else
                    {
                        if (playerCollider.Rect.Y > col.Rect.Y)
                        {
                            if ((playerCollider.Rect.Width + (playerCollider.Rect.X - col.Rect.X)) < (col.Rect.Height - (playerCollider.Rect.Y - col.Rect.Y))) //Checks which direction to push the character
                            {
                                playerCollider.Rect = new Rectangle(playerCollider.Rect.X - (playerCollider.Rect.Width + (playerCollider.Rect.X - col.Rect.X)),
                                                                          playerCollider.Rect.Y,
                                                                          playerCollider.Rect.Width,
                                                                          playerCollider.Rect.Height);
                                playerVelocity.Velocity = new Point(0, playerVelocity.Velocity.Y); //when the player hits an object velocity disapears in one axis
                            }
                            else
                            {
                                playerCollider.Rect = new Rectangle(playerCollider.Rect.X,
                                                                          playerCollider.Rect.Y + (col.Rect.Height - (playerCollider.Rect.Y - col.Rect.Y)),
                                                                          playerCollider.Rect.Width,
                                                                          playerCollider.Rect.Height);
                                playerVelocity.Velocity = new Point(playerVelocity.Velocity.X, 0); //when the player hits an object velocity disapears in one axis
                            }
                        }
                        else
                        {
                            if ((playerCollider.Rect.Width + (playerCollider.Rect.X - col.Rect.X)) < (playerCollider.Rect.Height + (playerCollider.Rect.Y - col.Rect.Y))) //Checks which direction to push the character
                            {
                                playerCollider.Rect = new Rectangle(playerCollider.Rect.X - (playerCollider.Rect.Width + (playerCollider.Rect.X - col.Rect.X)),
                                                                          playerCollider.Rect.Y,
                                                                          playerCollider.Rect.Width,
                                                                          playerCollider.Rect.Height);
                                playerVelocity.Velocity = new Point(0, playerVelocity.Velocity.Y); //when the player hits an object velocity disapears in one axis
                            }
                            else
                            {
                                playerCollider.Rect = new Rectangle(playerCollider.Rect.X,
                                                                          playerCollider.Rect.Y - (playerCollider.Rect.Height + (playerCollider.Rect.Y - col.Rect.Y)),
                                                                          playerCollider.Rect.Width,
                                                                          playerCollider.Rect.Height);
                                playerVelocity.Velocity = new Point(playerVelocity.Velocity.X, 0); //when the player hits an object velocity disapears in one axis
                            }
                        }
                    }
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch) // draws all the textures in the collider lists.
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Matrix.CreateTranslation(-playerCollider.Rect.X + 320, -playerCollider.Rect.Y + 256, 0)); //TODO: make camera values middle of screen.
            foreach (ICollider col in enviromentColliderList)
            {
                col.Draw(spriteBatch); //draw all collider classes in enviroment list.
            }
            playerCollider.Draw(spriteBatch);  //draw player
            spriteBatch.End();
        }
    }
}
