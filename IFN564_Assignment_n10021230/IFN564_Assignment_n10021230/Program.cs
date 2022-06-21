using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFN564BikeRentalEnterpriseApp
{
    class Program
    {
        // The following tests are performed in a sequential nature to demonstrate a common use case as 
        // well as to illustrate the correctness of the implementation in that it operates as intended. 
        static void Main(string[] args)
        {
            //****************ADD/REMOVE CLIENT TESTING****************//

            var clientA = new Client("Fred", "Cash", "0454215485"); //initialises new clients for the list
            var clientB = new Client("Ted", "Card", "0458778552");

            ClientLinkedList<Client> list = new(); // initialises the client linked list data structure

            // ADDING CLIENTS
            list.AddClientToTail(clientA); // adds a client to the list to the tail node
            Console.WriteLine("The current client list contains 1 client:");
            list.Display();
            list.AddClientToTail(clientB); // adds a second client to the list to the tail node
            Console.WriteLine("The current client list after a second client is added:");
            list.Display();


            // REMOVING A CLIENT
            list.RemoveClient(clientB); // removes the second client from the linked list
            Console.WriteLine("The current client list after the second client is removed:");
            list.Display();

            //Console.ReadKey(); // uncomment to step through tests
            Console.WriteLine("\n"); // console readability purposes



            //********************BIKES QUEUE TESTING*******************//

            // Initialises the bikesQueue (availabe bikes in circulation)
            IBikesQueue bikesQueue = new BikesQueue(); 

            // Creates bike objects to be added to the BikesQueue
            int bike1 = 1; 
            int bike2 = 2;
            int bike3 = 3;

            // Adds 3 new bikes to the BikesQueue data structure
            Console.WriteLine("Adding Bikes Testing: ");
            Console.WriteLine("Adding first bike to the queue...");
            bikesQueue.EnqueueBike(bike1); // Enqueues the first bike
            Console.WriteLine("The total number of bikes in the queue are:");
            Console.WriteLine(bikesQueue.Incrementer); // shows the current size of the queue

            Console.WriteLine("Adding second bike to the queue...");
            bikesQueue.EnqueueBike(bike2); // Enqueues the second bike
            Console.WriteLine("The total number of bikes in the queue are:");
            Console.WriteLine(bikesQueue.Incrementer); // shows the updated size of the queue

            Console.WriteLine("Adding third bike to the queue...");
            bikesQueue.EnqueueBike(bike3);  // Enqueues the third bike
            Console.WriteLine("The total number of bikes in the queue are:");
            Console.WriteLine(bikesQueue.Incrementer); // shows the updated size of the queue

            Console.WriteLine("The next available bike in bikesQueue has the id of: " + bikesQueue.Head());

            //Console.ReadKey(); // uncomment to step through tests
            Console.WriteLine("\n"); //console readability purposes



            //*****************BIKE MAINTENANCE TESTING******************//

            // Inititalises the maintenanceQueue (bikes awaiting repairs)
            IMaintenanceQueue maintenanceQueue = new MaintenanceQueue();

            Console.WriteLine("Maintenance Testing: ");
            Console.WriteLine("The total available bikes in bikesQueue is currently: " + bikesQueue.Incrementer);
            Console.WriteLine("The first bike in bikesQueue of id: " + bikesQueue.Head() + " is damaged.");
            Console.WriteLine("Now to move the bike from available pool (bikesQueue) to the maintenanceQueue..."); 
            // Takes the bikeId from the beginning of the bikesQueue and enqueues it onto maintenanceQueue
            maintenanceQueue.EnqueueBike(bikesQueue.Head());
            Console.WriteLine("The next bike to be fixed in maintenanceQueue is of id: " + maintenanceQueue.Head());
            // Dequeues the bike that's been moved from bikesQueue
            bikesQueue.DequeueBike();
            Console.WriteLine("The total available bikes in bikesQueue is currently: " + bikesQueue.Incrementer);
            Console.WriteLine("The next available bike in bikesQueue has the id of: " + bikesQueue.Head());

            //Console.ReadKey(); // uncomment to step through tests
            Console.WriteLine("\n");  //console readability purposes



            //*******************BIKE RENTAL TESTING********************//

            Console.WriteLine("Bike Rental Testing: ");
            Console.WriteLine("The total available bikes in bikesQueue is currently: " + bikesQueue.Incrementer);
            Console.WriteLine("The next available bike in bikesQueue has the id of: " + bikesQueue.Head());
            Console.WriteLine("The client: " + clientA.ClientName + " will now rent it out.");
            clientA.RentalBikeId = (int)bikesQueue.Head(); // copies the bikeId from bikesQueue to the Client RentalBikeId property
            Console.WriteLine(clientA.ClientName + " has successfully rented out bike id: " + clientA.RentalBikeId);
            bikesQueue.DequeueBike(); // removes the bike object from the bikesQueue data structure
            Console.WriteLine("The next available bike in bikesQueue has the id of: " + bikesQueue.Head());

            //Console.ReadKey();  // uncomment to step through tests
            Console.WriteLine("\n");  //console readability purposes


            //*******************BIKE RETURN TESTING*********************//

            Console.WriteLine("Bike Return Testing: ");
            Console.WriteLine("The total available bikes in bikesQueue is currently: " + bikesQueue.Incrementer);
            Console.WriteLine("The next available bike in bikesQueue has the id of: " + bikesQueue.Head());
            Console.WriteLine("The client: " + clientA.ClientName + " will now return bike id: " + clientA.RentalBikeId);
            bikesQueue.EnqueueBike(clientA.RentalBikeId); // uses the value of the RentalBikedId property to enqueue
            clientA.RentalBikeId = 0; // change the client's RentalBikeId back to 0 to indicate no current rentals
            Console.WriteLine("The client: " + clientA.ClientName + " has successfully returned the bike.");
            Console.WriteLine("The total available bikes in bikesQueue is currently: " + bikesQueue.Incrementer);
            Console.WriteLine("The next bike available has the id of: " + bikesQueue.Head());
            Console.WriteLine("Bike id: " + bikesQueue.Head() + " was rented out by another client...");
            bikesQueue.DequeueBike(); // dequeue next bike to prove clientA did indeed return the bike to the queue
            Console.WriteLine("The next bike available has the id of: " + bikesQueue.Head());            
            
            Console.ReadKey();    // uncomment to step through tests
            Console.WriteLine("\n");  //console readability purposes
        }
    }
}