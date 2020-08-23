using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cosmatic_Insurance.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public decimal Amount { get; set; }
        public decimal EMI { get; set; }
        public string PolicyCompanyName { get; set; }

    }
}