using RazorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorWebApp.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee()
                {
                    Id = 0, Name = "Karl", Email = "Karl@gmail.com", PhotoPath = "avatar2.png", Department = Dept.Hr
                },
                new Employee()
                {
                    Id = 1, Name = "Mark", Email = "Mark@gmail.com", PhotoPath = "avatar.png", Department = Dept.IT
                },
                new Employee()
                {
                    Id = 2, Name = "Tom", Email = "Tom@gmail.com", Department = Dept.Payroll
                },
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }
    }
}
