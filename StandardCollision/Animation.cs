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
    /// Remember to initialize the animation
    /// </summary>
    public abstract class Animation  //TODO: make sure this works, probably does.
    {
        public bool animationActive = true;

        private List<Texture2D> animations;  //holds all of the texture atlases
        private List<int> framesInAnimation;  //holds the length value of the current animation
        private List<Vector3> sizeRowColumns;  //holds the texture size, rows in the atlas, and columns in the atlas.

        public int activeAnimation;  //holds the value in the list of the currently active animation

        private int currentAnimationFrame;
        public int CurrentAnimationFrame { get { return currentAnimationFrame; } }  //readonly to outside, cannot be changed except this class

        /// <summary>
        /// how many frames go by before the aniumation plays once.  Being set to 5 means change the animation once every 5 frames.
        /// </summary>
        public int animationFramePerFrames = 0;
        private int framesTilNextAnimationFrame = 0;

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
            sizeRowColumns.Add(new Vector3(textureSize, textureRowsHorizontal, textureColumnsVertical));  //sets the texture atlas information values.
            framesInAnimation.Add(textureRowsHorizontal * textureColumnsVertical);  //how many frames the animation has
            animations.Add(textureAtlas);

            activeAnimation = animations.Count - 1;  //sets active animation panel
        }

        /// <param name="index">number to find the animation, first animation added is 0, 1, 2, 3, etc.</param>
        public void ActivateAnimation(int index)
        {
            activeAnimation = index;  //sets active animation
        }

        /// <summary>
        /// please call this in the Draw() method.
        /// </summary>
        public void DrawAnimation(SpriteBatch spriteBatch, Rectangle destinationRect)
        {
            if (animationFramePerFrames <= framesTilNextAnimationFrame) //checks if the animations should play this frame
            {
                //finds the place of the current texture in the textureAtlas.  //thanks rb whitaker
                int width = animations[activeAnimation].Width / (int)sizeRowColumns[activeAnimation].Z;
                int height = animations[activeAnimation].Height / (int)sizeRowColumns[activeAnimation].Y;
                int row = (int)(currentAnimationFrame / sizeRowColumns[activeAnimation].Z);
                int column = currentAnimationFrame % (int)sizeRowColumns[activeAnimation].Z;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);  //finds the tiny rectangle inside of the texture atlas to draw.

                if (currentAnimationFrame < framesInAnimation[activeAnimation])  //checks if the animation need to reste to the first state.  //TODO: make sure this works
                {
                    spriteBatch.Draw(animations[activeAnimation], destinationRect, sourceRectangle, Color.White);  //draws the current animation frame in this animation
                    currentAnimationFrame++;
                    framesTilNextAnimationFrame = 0;  //frame has been met so it resets
                }
                else
                {
                    spriteBatch.Draw(animations[activeAnimation], destinationRect, sourceRectangle, Color.White);  //draws frame one
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
