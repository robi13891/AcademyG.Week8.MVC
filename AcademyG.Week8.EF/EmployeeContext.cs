using AcademyG.Week8.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8.EF
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { } // verrà specificato nel file di startup in mvc

        protected override void OnModelCreating(ModelBuilder builder) // lo facciamo qua invece che in un file esterno prche abbiamo solo una entita
        {

            var employeeEntity = builder.Entity<Employee>();

            employeeEntity.HasKey(e => e.Id);

            employeeEntity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(5);

            employeeEntity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            employeeEntity.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(40);

            employeeEntity.Property(e => e.BirthDate);

            //database gia istanziato
            employeeEntity.HasData(
                new Employee
                {
                    Id = 1,
                    Code = "EMP01",
                    FirstName = "Mario",
                    LastName = "Rossi",
                    BirthDate = new DateTime(1980, 1, 1)
                },
                 new Employee
                 {
                     Id = 2,
                     Code = "EMP02",
                     FirstName = "Matteo",
                     LastName = "Mattei",
                     BirthDate = new DateTime(1990, 2, 2)
                 }

                );
        }
    }
}
