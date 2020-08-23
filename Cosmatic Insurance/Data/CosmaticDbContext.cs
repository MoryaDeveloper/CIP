using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Cosmatic_Insurance.Models;

namespace Cosmatic_Insurance.Data
{
    public class CosmaticDbContext : DbContext
    {
        public CosmaticDbContext() : base("CosmaticDb")
        {
        }
      
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Surgeon> Surgeons { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Policy> Policys { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}