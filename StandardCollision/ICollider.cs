﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StandardCollision
{
    public interface ICollider : IObject   //Is also an obvject
    {
        bool isActive { get; set; }
        Rectangle Rect { get; set; }      //rectagle that is the collider of the object and the position the texture is drawn at.
    }
}