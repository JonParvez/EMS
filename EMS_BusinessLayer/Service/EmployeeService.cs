using EMS_DataAccessLayer.Interface;
using EMS_DataAccessLayer.Models;
using EMS_DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BusinessLayer.Service
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _Employee;

        public EmployeeService(IRepository<Employee> employee)
        {
            _Employee = employee;
        }
        //Get Employee Details By Employee Id  
        public Employee GetEmployeeById(int Id)
        {
            return _Employee.GetById(Id);
        }
        //GET All Employee Details   
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return _Employee.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Add Employee  
        public async Task<Employee> AddEmployee(Employee Employee)
        {
            Employee.Id = 0; //Identity Column will be auto incremented, no need to send value
            return await _Employee.Create(Employee);
        }
        //Delete Employee   
        public bool DeleteEmployee(int Id)
        {

            try
            {
                var item = _Employee.GetById(Id);
                if (item != null)
                {
                    _Employee.Delete(item);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        //Update Employee Details  
        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                var dataToBeUpdated = _Employee.GetById(employee.Id);
                if (dataToBeUpdated != null)
                {
                    dataToBeUpdated.FirstName = employee.FirstName;
                    dataToBeUpdated.MiddleName = employee.MiddleName;
                    dataToBeUpdated.LastName = employee.LastName;
                    _Employee.Update(dataToBeUpdated);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
