using EMS_DataAccessLayer.DBContext;
using EMS_DataAccessLayer.Interface;
using EMS_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DataAccessLayer.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Employee> Create(Employee _object)
        {
            var obj = await _dbContext.Employees.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Employee _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Employee GetById(int Id)
        {
            return _dbContext.Employees.Where(x => x.Id == Id).SingleOrDefault();
        }

        public void Update(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
        }
    }
}
