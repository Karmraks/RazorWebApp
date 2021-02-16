using RazorWebApp.Models;
using System.Collections.Generic;

namespace RazorWebApp.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Search(string searchTerm);

        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployee(int id);

        Employee Update(Employee updatedEmployee);

        Employee Add(Employee newEmployee);

        Employee Delete(int id);

        IEnumerable<DeptHandCount> EmployeeCountByDept(Dept? dept);
    }
}
