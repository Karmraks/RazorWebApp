using RazorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorWebApp.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployee(int id);
    }
}
