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
    public abstract class Animation
    {
        public bool animationActive = true;

        private List<Texture2D[]> Animations; //holds all of the frames
        public short activeAnimation;  //holds the value in the list of the currently active animation

        private int currentAnimationFrame;
        public int CurrentAnimationFrame { get { return currentAnimationFrame; } }  //readonly to outside

        /// <summary>
        /// how many frames go by before the aniumation plays once.  Being set to 5 means change the animation once every 5 frames.
        /// </summary>
        public int animationFramePerFrames = 0;
        private int framesTilNextAnimationFrame = 0;

        /// <param name="animationFramePerFrames">how many frames go by before the aniumation plays once.  Being set to 5 means change the animation once every 5 frames.</param>
        public void InitializeAnimation(int animationFramePerFrames)
        {
            this.animationFramePerFrames = animationFramePerFrames;
            Animations = new List<Texture2D[]>();
        }

        
        /// <summary>
        /// please call this in the Draw() method.
        /// </summary>
        public void DrawAnimation(SpriteBatch spriteBatch, Rectangle drawRect)
        {
            if (animationFramePerFrames <= framesTilNextAnimationFrame) //checks if the animations should play this frame
            {
                spriteBatch.Draw(Animations[activeAnimation][currentAnimationFrame], drawRect, Color.White);  //draws the current animation frame in this animation
                currentAnimationFrame++;
                framesTilNextAnimationFrame = 0;  //frame has been met so it resets
            }
            else
            {
                framesTilNextAnimationFrame++;  //increments if frame has not been met
            }
        }

        /// <summary>
        /// Call this in the constructor please.
        /// </summary>
        public void AddAnimation(Texture2D textureAtlas, int textureSize, short textureRowsHorizontal, short textureColumnsVertical)
        {
            //TODO: cuttheAtlas and add it to animations
        }
    }
}
