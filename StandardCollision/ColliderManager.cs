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
    class ColliderManager
    {
        public static ICollider playerCollider; //the collider of the player
        public static IVelocity playerVelocity; //the velocity of the player, add the moving player object to these two variables.
        public static List<ICollider> enviromentColliderList = new List<ICollider>();   //list that hold all the colliders that are part of the enviroment.  Add non-moving collider classes to this. 

        public static void Initialize() //this is static so no constructor, use this as constructor.
        {
            //TODO: add classes that inherit ICollider to playerCollider and envoromentColliderList.
        }

        public static void Update() //holds all the update logic.
        {
            //moving the player by its velocity.
            playerCollider.ObjectRect = new Rectangle((int)(playerCollider.ObjectRect.X + playerVelocity.ObjectVelocity.X), (int)(playerCollider.ObjectRect.Y + playerVelocity.ObjectVelocity.Y), playerCollider.ObjectRect.Width, playerCollider.ObjectRect.Height);
            Collision(); //checks object collision
        }

        private static void Collision()
        {
            foreach (ICollider col in enviromentColliderList)
            {
                if (playerCollider.ObjectRect.Intersects(col.ObjectRect)) //checks if the player is colliding with the current object in the foreach loop.
                {
                    //TODO: add distance checker
                    if (playerCollider.ObjectRect.X > col.ObjectRect.X) //finds what side of the wall the player is on
                    {
                        if (playerCollider.ObjectRect.Y > col.ObjectRect.Y) //ditto
                        {
                            if ((col.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X)) < (col.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y))) //Checks which direction to push the character
                            {
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X + (col.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X)),
                                                                          playerCollider.ObjectRect.Y,
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                                playerVelocity.ObjectVelocity = new Vector2(0, playerVelocity.ObjectVelocity.Y); //when the player hits an object velocity disapears in one axis
                            }
                            else
                            {
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X,
                                                                          playerCollider.ObjectRect.Y + (col.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y)),
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                                playerVelocity.ObjectVelocity = new Vector2(playerVelocity.ObjectVelocity.X, 0); //when the player hits an object velocity disapears in one axis

                            }
                        }
                        else
                        {
                            if ((col.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X)) < (playerCollider.ObjectRect.Height + (playerCollider.ObjectRect.Y - col.ObjectRect.Y))) //Checks which direction to push the character
                            {
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X + (col.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X)),
                                                                          playerCollider.ObjectRect.Y,
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                                playerVelocity.ObjectVelocity = new Vector2(0, playerVelocity.ObjectVelocity.Y); //when the player hits an object velocity disapears in one axis
                            }
                            else
                            {
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X,
                                                                          playerCollider.ObjectRect.Y - (playerCollider.ObjectRect.Height + (playerCollider.ObjectRect.Y - col.ObjectRect.Y)),
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                                playerVelocity.ObjectVelocity = new Vector2(playerVelocity.ObjectVelocity.X, 0); //when the player hits an object velocity disapears in one axis

                            }
                        }
                    }
                    else
                    {
                        if (playerCollider.ObjectRect.Y > col.ObjectRect.Y)
                        {
                            if ((playerCollider.ObjectRect.Width + (playerCollider.ObjectRect.X - col.ObjectRect.X)) < (col.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y))) //Checks which direction to push the character
                            {
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X - (playerCollider.ObjectRect.Width + (playerCollider.ObjectRect.X - col.ObjectRect.X)),
                                                                          playerCollider.ObjectRect.Y,
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                                playerVelocity.ObjectVelocity = new Vector2(0, playerVelocity.ObjectVelocity.Y); //when the player hits an object velocity disapears in one axis
                            }
                            else
                            {
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X,
                                                                          playerCollider.ObjectRect.Y + (col.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y)),
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                                playerVelocity.ObjectVelocity = new Vector2(playerVelocity.ObjectVelocity.X, 0); //when the player hits an object velocity disapears in one axis
                            }
                        }
                        else
                        {
                            if ((playerCollider.ObjectRect.Width + (playerCollider.ObjectRect.X - col.ObjectRect.X)) < (playerCollider.ObjectRect.Height + (playerCollider.ObjectRect.Y - col.ObjectRect.Y))) //Checks which direction to push the character
                            {
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X - (playerCollider.ObjectRect.Width + (playerCollider.ObjectRect.X - col.ObjectRect.X)),
                                                                          playerCollider.ObjectRect.Y,
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                                playerVelocity.ObjectVelocity = new Vector2(0, playerVelocity.ObjectVelocity.Y); //when the player hits an object velocity disapears in one axis
                            }
                            else
                            {
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X,
                                                                          playerCollider.ObjectRect.Y - (playerCollider.ObjectRect.Height + (playerCollider.ObjectRect.Y - col.ObjectRect.Y)),
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                                playerVelocity.ObjectVelocity = new Vector2(playerVelocity.ObjectVelocity.X, 0); //when the player hits an object velocity disapears in one axis
                            }
                        }
                    }
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch) // draws all the textures in the collider lists.
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Matrix.CreateTranslation(-playerCollider.ObjectRect.X + 320, -playerCollider.ObjectRect.Y + 256, 0)); //TODO: make camera values middle of screen.
            foreach (ICollider col in enviromentColliderList)
            {
                col.Draw(spriteBatch); //draw all collider classes in enviroment list.
            }
            playerCollider.Draw(spriteBatch);  //draw player
            spriteBatch.End();
        }
    }
}
