using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFN564BikeRentalEnterpriseApp
{
    public class BikesNode
    {
        private Object data;
        private BikesNode next;

        // BikesNode Class properties:
        public BikesNode(Object obj)
        {
            data = obj;
            next = null;
        }

        public Object Data
        {
            get { return data; }
            set { data = value; }
        }

        public BikesNode Next
        {
            get { return next; }
            set { next = value; }
        }
    }

    // The BikesQueue data structure is that of a circular queue
    public class BikesQueue : IBikesQueue
    {
        // BikesQueue Class private fields:
        private int maxSize = Int32.MaxValue;
        private int incrementer = 0;
        private BikesNode tail = null;

        // Stores the length of the BikesQueue
        public int MaxSize
        {
            get { return maxSize; }
        }

        // Tracks the enqueues and dequeues from the BikesQueue
        public int Incrementer
        {
            get { return incrementer; }
        }

        // Checks if the BikesQueue is empty
        public bool QueueIsEmpty()
        {
            return incrementer == 0;
        }

        // Checks if the BikesQueue is full
        public bool QueueIsFull()
        {
            return incrementer == maxSize;
        }

        // Resets the data structure
        public void Clear()
        {
            tail = null;
            incrementer = 0;
        }

        // In a circular linked list like this tail.Next is the head
        // because the tail points to the head instead of null
        public Object Head()
        {
            if (!QueueIsEmpty())
            {
                Object data = tail.Next.Data;
                return data;
            }
            else
                return null;
        }

        // Adds a new bike to the BikesQueue data structure
        public void EnqueueBike(Object bikeId)
        {
            if(!QueueIsFull())
            {
                BikesNode aBikesNode = new BikesNode(bikeId);
                if (incrementer == 0) // checks to see if the queue is currently empty
                {
                    tail = aBikesNode;
                    tail.Next = tail;
                }
                else // Most common use cases will trigger this
                {
                    aBikesNode.Next = tail.Next;
                    tail.Next = aBikesNode;
                    tail = aBikesNode;
                }
                incrementer += 1;
            }
        }

        // Removes a bike from the BikesQueue to either be rented out by a client or taken to maintenance
        public Object DequeueBike() // Takes no parameters since it always takes from the same position in the queue
        {
            if (!QueueIsEmpty())
            {
                Object data;
                if (incrementer == 1) // Checks if the BikesQueue has only a single object in it
                {
                    data = tail.Data;
                    tail = null;
                }
                else
                {
                    data = tail.Next.Data;
                    tail.Next = tail.Next.Next;
                }
                incrementer -= 1;
                return data;
            }
            else
                return null;
        }





    }
}
