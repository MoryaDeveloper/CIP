using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Cosmatic_Insurance.Models
{
    public class Surgeon
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }

        public string Specialization { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public Surgeon()
        {
            Appointments = new Collection<Appointment>();
        }

    }
}