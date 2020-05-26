using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RentApartment.Models
{
    public class Visitor
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Arrival => DateTime.Now;
        public bool Male { get; set; }
        public int Age { get; set; }

        public double Price { get; set; }
        public int Nights { get; set; }
        public double Amount => Price * Nights;
        public bool Adult => Age >= 18;
        public string Country { get; set; }
    }
}
