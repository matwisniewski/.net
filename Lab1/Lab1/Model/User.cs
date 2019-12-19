using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Lab1.Model
{
    class User : IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string PESEL { get; set; }

        public User() { }

        public User(string firstName, string lastName, int yearOfBirth, string city, string street, int houseNumber, string postalCode, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
            PESEL = pesel;
        }

        public int GetAge()
        {
            DateTime date = DateTime.Now;
            int year = date.Year;
            return year - this.YearOfBirth;
        }
    }
}
