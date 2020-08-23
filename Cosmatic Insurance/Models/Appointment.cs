using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cosmatic_Insurance.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int SurgeonId { get; set; }
        public Surgeon Surgeon { get; set; }
    }
}