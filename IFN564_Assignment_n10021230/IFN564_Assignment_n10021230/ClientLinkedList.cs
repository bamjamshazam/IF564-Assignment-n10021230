using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFN564BikeRentalEnterpriseApp
{
    // The ClientLinkedList class that stores Client objects in a singly linked list and features
    // the following methods: AddClientToTail(T client), RemoveClient(T client), display()
    class ClientLinkedList<T> where T : class
    {
        protected class LinkedListNode
        {
            public T Client; // the data field to contain a client object
            public LinkedListNode Next = null; // pointer to the next node

            public LinkedListNode(T client)
            {
                this.Client = client;
            }
        }

        // Returns the length of the ClientLinkedList
        public int ListLength 
        { 
            get { return this.listLength; }
        }

        // Integer variable for storage of the linked list's length
        protected int listLength = 0;

        // The head of the linked list is initialised to null
        protected LinkedListNode Head = null;

        // Adds the client object to the tail of the ClientLinkedList class
        public void AddClientToTail(T client)
        {
            var node = new LinkedListNode(client); 
            if (this.Head == null)
            {
                this.Head = node;
            }
            else
            {
                LinkedListNode previous = this.Head;
                while (previous.Next != null)
                {
                    previous = previous.Next;
                }
                previous.Next = node;
                node.Next = null;
            }
            this.listLength += 1;
        }

        // Given a Client object as a parameter, this method removes
        // the client from the data structure
        public void RemoveClient(T client)
        {
            if (Head == null) // check if the list is empty first-off
                return;
            if (Head.Client == client) // Check if the data we're looking for is in the head
            {
                Head = Head.Next;
            }
            else
            {
                LinkedListNode previous = Head;
                LinkedListNode current = Head.Next;

                while (current != null)
                {
                    // if the data we're looking for is at the end of the linked list
                    // set the previous pointer to null to act as the new end of the list
                    if (current.Client == client) 
                    {
                        previous.Next = current.Next;
                        break;
                    }
                    previous = current;
                    current = current.Next;
                }                
            }
        }
        

        // Display() prints out all the associated information 
        // about the clients held within the data structure
        public void Display()
        {
            var node = Head;
            while (node != null)
            {
                Console.WriteLine(node.Client.ToString());
                node = node.Next;
            }

        }
    }
}