using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFN564BikeRentalEnterpriseApp
{
    class Client
    {
        // Phone numbers are stored as strings to remedy formatting issues when logging.
        // Leading 0's aren't considered to have values so mobile numbers are misrepresented.
        // This shouldn't impact functionality since we aren't using it for arithmetic.
        private string clientname;
        private string paymentmethod;
        private string phonenumber;

        // Client Class public properties
        public string ClientName
        {
            get { return clientname; }
            set { clientname = value; }
        }

        public string PaymentMethod
        {
            get { return paymentmethod; }
            set { paymentmethod = value; }                         
        }

        public string PhoneNumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }
        
        // RentalBikeId - i.e. the bikeID of the bike that the client rents out.
        // A single integer to represent this means that each client may only rent
        // a single bike at any time.
        public int RentalBikeId { get; set; }

        public Client(string clientName, string paymentMethod, string phoneNumber)
        {
            this.clientname = clientName;
            this.paymentmethod = paymentMethod;
            this.phonenumber = phoneNumber;
        }

        // This ToString() method returns a string concatenation of the client's name,
        // payment method, and mobile number and the id of the bike they are renting
        // (RentalBikeId) for the purposes of displaying each of their details.
        public override string ToString()
        {
            return ("Name: " + clientname + "\n" + "Payment Method: " + paymentmethod + "\n" + "Phone Number: " + phonenumber + "\n" + "Rental Bike Id: " + RentalBikeId.ToString() + "\n");
        }
    }
}