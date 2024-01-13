
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace schoolManagment.Models
{
    public class ContextDb:DbContext
    {
        public ContextDb():base("name=defaultConnection") { }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
    }
}
//hadi katdir liaason m3a data base