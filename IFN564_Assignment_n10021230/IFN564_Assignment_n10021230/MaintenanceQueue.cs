using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFN564BikeRentalEnterpriseApp
{
    public class MaintenanceNode
    {
        private Object data;
        private MaintenanceNode next;

        // MaintenanceNode Class properties:
        public MaintenanceNode(Object obj)
        {
            data = obj;
            next = null;
        }

        public Object Data
        {
            get { return data; }
            set { data = value; }
        }

        public MaintenanceNode Next
        {
            get { return next; }
            set { next = value; }
        }
    }

    // The MaintenanceQueue data structure is that of a circular queue
    public class MaintenanceQueue : IMaintenanceQueue
    {
        private int maxSize = Int32.MaxValue;
        private int incrementer = 0;
        private MaintenanceNode tail = null;

        // Stores the length of the MaintenanceQueue
        public int MaxSize
        {
            get { return maxSize; }
        }

        // Tracks the enqueues in the MaintenanceQueue
        public int Incrementer
        {
            get { return incrementer; }
        }

        // Checks if the MaintenanceQueue is empty
        public bool QueueIsEmpty()
        {
            return incrementer == 0;
        }

        // Checks if the MaintenanceQueue is full
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

        // Adds a new bike to the MaintenanceQueue data structure
        public void EnqueueBike(Object bikeId)
        {
            if (!QueueIsFull())
            {
                MaintenanceNode aMaintenanceNode = new MaintenanceNode(bikeId);
                if (incrementer == 0) // checks to see if the queue is currently empty
                {
                    tail = aMaintenanceNode;
                    tail.Next = tail;
                }
                else // Most common use cases will trigger this
                {
                    aMaintenanceNode.Next = tail.Next;
                    tail.Next = aMaintenanceNode;
                    tail = aMaintenanceNode;
                }
                incrementer += 1;
            }
        }
    }
}
