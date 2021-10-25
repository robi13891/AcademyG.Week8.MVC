using AcademyG.Week8.Core.Interfaces;
using AcademyG.Week8.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8.Core
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        
        private readonly IRepositoryEmployee repoEmp; // potevo fare anche la proprietà
                                                      // senza set

        public MainBusinessLayer(IRepositoryEmployee repoEmployee)
        {
            this.repoEmp = repoEmployee;
        }

        public IEnumerable<Employee> FetchEmployees(Func<Employee, bool> filter = null)
        {
            return repoEmp.Fetch(filter);
        }

        public Employee GetEmployeeByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return null;
            return repoEmp.GetEmployeeByCode(code);
        }

        public Employee GetEmployeeById(int id)
        {
            if (id <= 0)
                return null;
            return repoEmp.GetById(id);


        }
    }
}
