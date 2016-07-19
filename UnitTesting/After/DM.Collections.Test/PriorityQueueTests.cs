using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DM.Collections;

namespace DM.Collections.Test
{

    

    [TestClass]
    public class PriorityQueueTests
    {
        private PriorityQueue<int> q = new PriorityQueue<int>();

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void Ctor_WhenCreated_ShouldHaveCount0()
        {
        
            Assert.AreEqual(0, q.Count);
        }

        [TestMethod]
        public void Enqueue_WhenCalled_ShouldIncreaseCountByOne()
        {
        
            q.Enqueue(1);

            Assert.AreEqual(1,q.Count);
        }

        [TestMethod]
        public void Dequeue_WhenCalledAfterEnqueue_ShouldReturnCountToInitialValue()
        {
            int count = q.Count;
            q.Enqueue(1);
            q.Dequeue();

            Assert.AreEqual(count, q.Count);
        }

        [TestMethod]
        public void Dequeue_WhenCalledAfterSingleEnqueue_ShouldReturnEnquedItem()
        {
     

            q.Enqueue(1);

            int dequeuedItem = q.Dequeue();

            Assert.AreEqual(1,dequeuedItem);
        }

        [TestMethod]
        public void Dequeue_WhenCalledAfterEnqueuingTwoItems_ShouldReturnFirstItem()
        {
            List<int> itemsToEnqueue = new List<int>(){1, 2};
           

            itemsToEnqueue.ForEach(i => q.Enqueue(i));

            Assert.AreEqual(itemsToEnqueue[0],q.Dequeue());

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_WhenCalledWithEmptyQueue_ShouldThrowInvalidOperationException()
        {
           

            q.Dequeue();
        }


        [TestMethod]
        public void Dequeue_WhenEnqueueWithHighPriority_ShouldDequeueHighPriorityFirst()
        {
            int val = 42;
            q.Enqueue(5);
            q.Enqueue(val, Priority.High);
            int result = q.Dequeue();
            Assert.AreEqual(val, result);
        }
    }
}
