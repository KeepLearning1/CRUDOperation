using CognineCompany.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CognineCompany.DataLayer
{
    public class EmployeeContext : DbContext
    {


        public EmployeeContext() : base("name=mycon")
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}