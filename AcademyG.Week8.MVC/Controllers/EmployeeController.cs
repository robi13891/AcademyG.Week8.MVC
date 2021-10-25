using AcademyG.Week8.Core.Interfaces;
using AcademyG.Week8.MVC.Helpers;
using AcademyG.Week8.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMainBusinessLayer mainBL;

        public EmployeeController(IMainBusinessLayer bl)
        {
            this.mainBL = bl;
        }

        public IActionResult Index()
        {
            //recupero i dati degli impiegati tramite bl
            var result = mainBL.FetchEmployees();

            //mappare da Employee (entità in core) --> EmployeeViewModel

            //SENZA EXTENSION METHODS
            //var resultMapping = new List<EmployeeViewModel>();
            //foreach(var item in result)
            //{
            //    resultMapping.Add(new EmployeeViewModel
            //    {
            //        Code = item.Code,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        BirthDate = item.BirthDate
            //    }
            //        );
            //}

            //CON EXTENSION METHODS
            var resultMapping = result.ToViewModel();
            
            return View(resultMapping);
        }

        //GET Employees/Detail/{code}
        public IActionResult Detail(string code)
        {
            if (string.IsNullOrEmpty(code))
                return View("Error");
            var employee = this.mainBL.GetEmployeeByCode(code);
            if (employee == null)
                return View("NotFound");
            var resultMapped = employee.ToViewModel();
            return View(resultMapped);
        }
    }
}
