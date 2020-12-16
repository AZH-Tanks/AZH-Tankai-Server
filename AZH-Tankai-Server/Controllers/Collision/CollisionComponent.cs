using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Controllers.Collision
{
    public class CollisionComponent
    {

        public virtual void Add(CollisionComponent collisionComponent)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(int index)
        {
            throw new NotImplementedException();
        }

        public virtual CollisionComponent GetChild(int index)
        {
            throw new NotImplementedException();
        }

        public virtual bool CheckCollisions(CollisionObject collisionObject)
        {
            throw new NotImplementedException();
        }
    }
}
