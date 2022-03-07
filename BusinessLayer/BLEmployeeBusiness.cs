using System;
using System.Collections.Generic;
using CommonAccessLayer.Model;
using DataLayer;

namespace BusinessLayer
{
    public class BLEmployeeBusiness
    {
        private EmployeeDataDb employeeData;
        public BLEmployeeBusiness()
        {
            employeeData = new EmployeeDataDb();
        }
        public List<Employees> GetEmployees()
        {
            return employeeData.GetEmployees();
        }
        public Employees GetEmployeeById(int id)
        {
            return employeeData.GetEmployeeById(id);
        }
        public bool DeleteEmployee(int id)
        {
            return employeeData.DeleteEmployee(id);
        }
        public bool CreateEmployee(Employees emp)
        {
            return employeeData.CreateEmployee(emp);
        }
        public bool UpdateEmployee(Employees emp)
        {
            return employeeData.UpdateEmployee(emp);
        }
    }
}
