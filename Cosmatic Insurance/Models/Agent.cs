using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cosmatic_Insurance.Models
{

    public class Agent
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}