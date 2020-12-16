using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Controllers.Collision
{
    public class CollisionComponentEnumerator : IEnumerator
    {
        public CollisionComponent[] collisionComponents;

        int position = -1;

        public CollisionComponentEnumerator(CollisionComponent[] collisionComponents)
        {
            this.collisionComponents = collisionComponents;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public CollisionComponent Current
        {
            get
            {
                try
                {
                    return collisionComponents[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < collisionComponents.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
