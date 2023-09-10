using Bussiness.Interface;
using Common.Model;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Services
{
    public class EmployeeBussiness : IEmployeeBussiness
    {
        private readonly IEmployeeRepository EmpRepository;

        public EmployeeBussiness(IEmployeeRepository empRepository)
        {
            EmpRepository = empRepository;
        }

        public bool CreateEmployee(EmployeeModel model)
        {
            try
            {
                return this.EmpRepository.CreateEmployee(model);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<UserEntity> GetAllEmployee()
        {
            try
            {
                return this.EmpRepository.GetAllEmployee();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateEmployee(EmployeeModel model)
        {
            try
            {
                return this.EmpRepository.UpdateEmployee(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool DeleteEmployee(long UserId)
        {
            try
            {
                return this.EmpRepository.DeleteEmployee(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
