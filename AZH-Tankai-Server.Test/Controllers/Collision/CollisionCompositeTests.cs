using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using AZH_Tankai_Server.Controllers.Collision;

namespace AZH_Tankai_Server.Test.Controllers.Collision
{
    class CollisionCompositeTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(100)]
        [TestCase(1000)]
        public void CollisionCompositeSizeTest(int size)
        {
            CollisionComposite collisionComposite = new CollisionComposite();
            for (int i = 0; i < size; i++)
            {
                collisionComposite.Add(new CollisionComponent());
            }
            Assert.AreEqual(collisionComposite.componentCount, size);
        }
        [TestCase]
        public void CollisionCompositeOverflowTest()
        {
            CollisionComposite collisionComposite = new CollisionComposite();
            for (int i = 0; i < CollisionComposite.MAX_COLLISION_COMPONENTS; i++)
            {
                collisionComposite.Add(new CollisionComponent());
            }
            Assert.Throws(typeof(OverflowException), new TestDelegate(() => collisionComposite.Add(new CollisionComponent())));
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(999)]
        public void CollisionCompositeGetChildTest(int index)
        {
            CollisionComposite collisionComposite = new CollisionComposite();
            for (int i = 0; i < CollisionComposite.MAX_COLLISION_COMPONENTS; i++)
            {
                collisionComposite.Add(new CollisionComponent());
            }
            var child = collisionComposite.GetChild(index);
            Assert.IsTrue(child is CollisionComponent);
        }

        [TestCase(-1)]
        [TestCase(1000)]
        public void CollisionCompositeGetChildOutOfBoundsTest(int index)
        {
            CollisionComposite collisionComposite = new CollisionComposite();
            for (int i = 0; i < CollisionComposite.MAX_COLLISION_COMPONENTS; i++)
            {
                collisionComposite.Add(new CollisionComponent());
            }
            Assert.Throws(typeof(IndexOutOfRangeException), new TestDelegate(() => collisionComposite.GetChild(index)));
        }
    }
}
