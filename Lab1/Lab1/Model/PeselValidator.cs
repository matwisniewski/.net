using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    class PeselValidator
    {
        public User User { get; set; }
        public PeselValidator(User user)
        {
            this.User = user;
        }

        public bool IsValid()
        {
            return (User.PESEL.Length > 0 && User.PESEL != null);
        }

        public string GeneratePesel()
        {
            string generatedPesel = User.YearOfBirth.ToString().Substring(2, 2);

            generatedPesel += "0801";

            Random rand = new Random();

            generatedPesel += rand.Next(10000, 99999);

            return generatedPesel;
        }
    }
}
