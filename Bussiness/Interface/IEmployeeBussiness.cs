﻿using Common.Model;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interface
{
    public interface IEmployeeBussiness
    {
        public bool CreateEmployee(EmployeeModel model);

        public List<UserEntity> GetAllEmployee();

        public bool UpdateEmployee(EmployeeModel model);


        public bool DeleteEmployee(long UserId);
    }
}
