using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardCollision
{
    public abstract class World
    {
        public abstract List<World> worldList { get; set; }
    }
}
