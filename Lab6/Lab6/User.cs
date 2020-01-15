using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }

        public User() { }

        public User(string firstName, string lastName, string email, string city, string street, string houseNumber, string flatNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.City = city;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.FlatNumber = flatNumber;
        }

        public override string ToString()
        {
            return this.FirstName + ", " + this.LastName + ", " + this.Email;
        }
    }
}
