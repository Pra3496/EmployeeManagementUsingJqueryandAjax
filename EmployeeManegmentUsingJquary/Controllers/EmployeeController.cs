using Bussiness.Interface;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System;
using System.Linq;

namespace EmployeeManegmentUsingJquary.Controllers
{
    public class EmployeeController : Controller 
    {
        private readonly IEmployeeBussiness employeeBussiness;
        public EmployeeController(IEmployeeBussiness employeeBussiness) 
        {
            this.employeeBussiness = employeeBussiness;
        }


        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddEmployee(EmployeeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = this.employeeBussiness.CreateEmployee(model);
                    var data = this.employeeBussiness.GetAllEmployee();

                    if (result != false)
                    {
                        
                        return Json(data);
                    }
                    else
                    {
                        return Json(data);   
                    }
                }
                else
                {
                    return Json("Data Not Valid");
                }
                

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public JsonResult GetEmployee()
        {
            var result = this.employeeBussiness.GetAllEmployee();

            if (result != null)
            {
                return Json(result);
            }
            else
            {
                return Json("null");
            }
          

        }

        [HttpPost]
        public JsonResult GetEmployee(string search)
        {
            var result = this.employeeBussiness.GetAllEmployee();

            var employee = result.Where(x=> x.Name == search || x.Department == search || x.Notes == search).ToList();

            if (employee != null)
            {
                return Json(employee);
            }
            else
            {
                return Json("null");
            }


        }

        [HttpPut]

        public JsonResult EditEmployee(EmployeeModel model)
        {
            try
            {
                var result = this.employeeBussiness.UpdateEmployee(model);
             
                if (result != false)
                {
                    return Json("Employee is Updated");
                }
                else
                {
                    return Json("Employee is NOT Updated");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public JsonResult DeleteEmployee(EmployeeModel model)
        {
            try
            {
                var result = this.employeeBussiness.DeleteEmployee(model.UserId);

                if (result != false)
                {

                    return Json("Employee is Deleted");
                }
                else
                {
                    return Json("Employee is NOT Deleted");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
