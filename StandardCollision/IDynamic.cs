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
    public interface IDynamic   //Is NOT an object
    {
        /// <summary>
        /// This is how you put words in the tiny panel (hint type [ / ] three times above a variable)
        /// </summary>
        Point Velocity { get; set; }  //velocity is the force the object gets added to the position each frame.
    }
}
