using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Controllers.Collision
{
    public class CollisionComposite : CollisionComponent, IEnumerable
    {
        public static int MAX_COLLISION_COMPONENTS = 1000;
        private CollisionComponent[] children;
        private int componentCount = 0;
        private int capacity;

        public CollisionComposite()
        {
            children = new CollisionComponent[10];
            capacity = 10;
        }

        public override void Add(CollisionComponent collisionComponent)
        {
            if (componentCount == MAX_COLLISION_COMPONENTS)
            {
                throw new OverflowException();
            }
            if (componentCount == capacity)
            {
                capacity *= 2;
                Array.Resize(ref children, capacity);
            }
            children[componentCount++] = collisionComponent;
        }

        public override CollisionComponent GetChild(int index)
        {
            return children[index];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public CollisionComponentEnumerator GetEnumerator()
        {
            return new CollisionComponentEnumerator(children);
        }

        public override bool CheckCollisions(CollisionObject collisionObject)
        {
            foreach (CollisionComponent component in this)
            {
                if (component.CheckCollisions(collisionObject))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
