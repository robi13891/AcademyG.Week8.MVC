﻿using AcademyG.Week8.Core.Models;
using AcademyG.Week8.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.MVC.Helpers
{
    public static class MappingExtensions
    {
        public static EmployeeViewModel ToViewModel(this Employee employee)
        {
            return new EmployeeViewModel
            {
                Code = employee.Code,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate
            };
        }

        public static IEnumerable<EmployeeViewModel> ToViewModel
            (this IEnumerable<Employee> employees)
        {
            return employees.Select(e => e.ToViewModel());
        } 
    }
}
