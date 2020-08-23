using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Cosmatic_Insurance.Models
{

    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public string Address { get; set; }

        public DateTime DateTime { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int Age
        {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - BirthDate.Year;
                if (BirthDate > now.AddYears(-age)) age--;
                return age;
            }
        }
        public ICollection<Appointment> Appointments { get; set; }

        public Patient()
        {
            Appointments = new Collection<Appointment>();

        }
    }
}