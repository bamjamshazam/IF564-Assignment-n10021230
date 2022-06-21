using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFN564BikeRentalEnterpriseApp
{
    // Unchanging factors: 0 <= Incrementer <= MaxSize
    public interface IBikesQueue
    {
        int MaxSize { get; } // gets the maximum size of BikesQueue

        int Incrementer { get; } // gets the amount of objects in BikesQueue

        bool QueueIsEmpty();    // true, then only true if satisfied

        bool QueueIsFull();     // true, then only true if satisfied

        void Clear(); // true, then resets the BikesQueue data structure

        void EnqueueBike(Object bikeId); 

        Object DequeueBike();

        Object Head();  // returns the value in the head position            
    }
}
