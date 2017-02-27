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
    /// <summary>
    /// Remember to initialize the animation, :D
    /// </summary>
    public abstract class Animation
    {
        public bool animationActive = true;

        private List<Texture2D> animations;  //holds all of the texture atlases
        private List<int> framesInAnimation;  //holds the length value of the current animation
        private List<Vector3> sizeRowColumns;  //holds the texture size, rows in the atlas, and columns in the atlas.

        public int activeAnimationIndex;  //holds the value in the list of the currently active animation
        public bool isAnimationStopped = false;  //guess what it does?

        private int currentAnimationFrame;
        public int CurrentAnimationFrame { get { return currentAnimationFrame; } }  //readonly to outside, cannot be changed except this class

        /// <summary>
        /// how many frames go by before the aniumation plays once.  Being set to 5 means change the animation once every 5 frames.  Is the speed the animation plays at.
        /// </summary>
        public int animationFramePerFrames = 0;
        public int framesTilNextAnimationFrame = 0;

        /// <param name="animationFramePerFrames">how many frames go by before the animation plays once.  Being set to 5 means change the animation once every 5 frames.</param>
        public void InitializeAnimation(int animationFramePerFrames)
        {
            //sets the animation frame speed.
            this.animationFramePerFrames = animationFramePerFrames;

            animations = new List<Texture2D>();
            framesInAnimation = new List<int>();
            sizeRowColumns = new List<Vector3>();
        }

        /// <summary>
        /// Call this in the constructor please.
        /// </summary>
        public void AddAnimation(Texture2D textureAtlas, int textureSize, short textureRowsHorizontal, short textureColumnsVertical)
        {
            animations.Add(textureAtlas);
            framesInAnimation.Add(textureRowsHorizontal * textureColumnsVertical);  //how many frames the animation has
            sizeRowColumns.Add(new Vector3(textureSize, textureRowsHorizontal, textureColumnsVertical));  //sets the texture atlas information values.

            activeAnimationIndex = animations.Count - 1;  //sets active animation
        }

        /// <param name="index">Number to find the animation, first animation added is 0, 1, 2, 3, etc.</param>
        public void PlayAnimation(int index, int animationFramePerFrames)
        {
            activeAnimationIndex = index;  //sets active animation
            currentAnimationFrame = 0;
            framesTilNextAnimationFrame = 0;

            this.animationFramePerFrames = animationFramePerFrames;
        }

        /// <summary>
        /// Stops the animation at the current frame.
        /// </summary>
        public void StopAnimation()
        {
            isAnimationStopped = true;
        }

        /// <summary>
        /// Call this in the Draw() method.
        /// </summary>
        public void DrawAnimation(SpriteBatch spriteBatch, Rectangle destinationRect)  //This draws the current frame then sees if it should draw the next frame next time.
        {
            //finds the place of the current texture in the textureAtlas.  //thanks rb whitaker
            int width = animations[activeAnimationIndex].Width / (int)sizeRowColumns[activeAnimationIndex].Z;
            int height = animations[activeAnimationIndex].Height / (int)sizeRowColumns[activeAnimationIndex].Y;
            int row = (int)(currentAnimationFrame / sizeRowColumns[activeAnimationIndex].Z);
            int column = currentAnimationFrame % (int)sizeRowColumns[activeAnimationIndex].Z;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);  //finds the tiny rectangle inside of the texture atlas to draw.

            spriteBatch.Draw(animations[activeAnimationIndex], destinationRect, sourceRectangle, Color.White);  //Draws the frame

            if (isAnimationStopped == false)  //makes sure animation is playing
            {
                if (animationFramePerFrames <= framesTilNextAnimationFrame) //checks if the animations should change this frame
                {
                    if (currentAnimationFrame < framesInAnimation[activeAnimationIndex])  //checks if the animation need to reset to the first state.
                    {
                        currentAnimationFrame++;  //Goes to next frame
                        framesTilNextAnimationFrame = 0; 
                    }
                    else
                    {
                        currentAnimationFrame = 0;  //animation state resets
                    }
                }
                else
                {
                    framesTilNextAnimationFrame++;  //increments if frame has not been met
                }
            }
        }
    }

    //           ▄███▄  /
    //           ██▄██▄ -- <Quack!>
    //       ▄█▄▄▄███▄  \
    //       ██████████
    //       ▀███████▀
    //   ________________________
    //  |CODE DUCK STRIKES AGAIN!|
    //  |________________________|

    /*▀ ▄ █*/
}
