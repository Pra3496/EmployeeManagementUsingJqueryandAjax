using Common.Model;
using Microsoft.Extensions.Configuration;
using Repository.Context;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Services
{
    public class EmployeeServices : IEmployeeRepository
    {
        private readonly IConfiguration configuration;

        private readonly ContextDB context;
        public EmployeeServices(IConfiguration configuration, ContextDB context) 
        {
            this.configuration = configuration;
            this.context = context;
        }


        public bool CreateEmployee(EmployeeModel model)
        {
            try
            {
                UserEntity user = new UserEntity();

                user.Name = model.Name;

                user.Gender = model.Gender;

                user.Department = model.Department;

                user.Salary = model.Salary; 

                user.StartDate = model.StartDate;

                user.Notes = model.Notes;

                if(user != null)
                {
                    context.UsersTable.Add(user);

                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<UserEntity> GetAllEmployee()
        {
            try
            {
                var result = context.UsersTable.ToList();

                if (result != null)
                {
                    return result;
                   
                }
                else
                {
                    return null;
                }

            }
            catch
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public bool UpdateEmployee(EmployeeModel model)
        {
            try
            {
                var result = context.UsersTable.FirstOrDefault(x=> x.UserId == model.UserId);

                if (result != null)
                {

                    result.Name = model.Name;

                    result.Gender = model.Gender;

                    result.Department = model.Department;

                    result.Salary = model.Salary;

                    result.StartDate = model.StartDate;

                    result.Notes = model.Notes;

                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteEmployee(long UserId)
        {
            try
            {
                var result = context.UsersTable.FirstOrDefault(x => x.UserId == UserId);

                if (result != null)
                {
                    context.UsersTable.Remove(result);
                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
