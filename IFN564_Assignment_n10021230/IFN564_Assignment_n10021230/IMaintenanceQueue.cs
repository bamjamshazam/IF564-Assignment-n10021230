using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFN564BikeRentalEnterpriseApp
{
    public interface IMaintenanceQueue
    {
        int MaxSize { get; } // gets the maximum size of MaintenanceQueue

        int Incrementer { get; }    // gets the amount of objects in MaintenanceQueue

        bool QueueIsEmpty();    // true, then only true if satisfied

        bool QueueIsFull();     // true, then only true if satisfied

        void Clear();       // true, then resets the MaintenanceQueue data structure
        void EnqueueBike(Object bikeId);
        Object Head();      // returns the value in the head position 
    }
}
