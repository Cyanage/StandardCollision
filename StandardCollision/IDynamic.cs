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
    public interface IDynamic : IObject //Is also an object
    {
        Vector2 Velocity { get; set; }  //velocity is the force and object gets added to the position each frame.
    }
}
