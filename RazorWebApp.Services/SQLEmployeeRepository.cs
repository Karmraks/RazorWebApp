using Microsoft.EntityFrameworkCore;
using RazorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorWebApp.Services
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Employee Add(Employee newEmployee)
        {
            //_context.Add(newEmployee);
            //_context.SaveChanges();

            _context.Database.ExecuteSqlRaw("spAddNewEmployee {0},{1},{2},{3}",
                        newEmployee.Name, 
                        newEmployee.Email, 
                        newEmployee.PhotoPath, 
                        newEmployee.Department);

            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employeeToDelete = _context.Employees.Find(id);

            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
            }

            return employeeToDelete;
        }

        public IEnumerable<DeptHandCount> EmployeeCountByDept(Dept? dept)
        {

            IEnumerable<Employee> query = _context.Employees;

            if (dept != null)
            {
                query = query.Where(x => x.Department == dept.Value);
            }

            var test = query.GroupBy(x => x.Department).Select(x => new DeptHandCount
            {
                Department = x.Key.Value,
                Count = x.Count()
            }).ToList();

            return test;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            //return _context.Employees;
            return _context.Employees
                .FromSqlRaw<Employee>("Select * From Employees").ToList();
        }   

        public Employee GetEmployee(int id)
        {
            //return _context.Employees.Find(id);
            return _context.Employees.FromSqlRaw<Employee>("CodeFirstSpGetEmployeeById {0}", id)
                .ToList()
                .FirstOrDefault();
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _context.Employees;
            }

            return _context.Employees.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) ||
                x.Email.ToLower().Contains(searchTerm.ToLower()));
        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = _context.Employees.Attach(updatedEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return updatedEmployee;
        }
    }
}
