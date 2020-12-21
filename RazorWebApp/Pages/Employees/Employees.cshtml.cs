using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApp.Models;
using RazorWebApp.Services;

namespace RazorWebApp.Pages.Employees
{
    public class EmployeesModel : PageModel
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeesModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> Employees { get; set; }

        public void OnGet()
        {
            Employees = _employeeRepository.GetAllEmployees();
        }
    }
}
