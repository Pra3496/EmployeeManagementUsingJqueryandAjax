using Bussiness.Interface;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

namespace EmployeeManegmentUsingJquary.Controllers
{
    public class EmployeeController : Controller 
    {
        private readonly IEmployeeBussiness employeeBussiness;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;
        public EmployeeController(IEmployeeBussiness employeeBussiness, IMemoryCache memoryCache, IDistributedCache distributedCache) 
        {
            this.employeeBussiness = employeeBussiness;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
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
            try
            {
                var cacheKey = "customerList";
                string serializedCustomerList;
                var users = new List<UserEntity>();

                var redisCustomerList = distributedCache.Get(cacheKey);
                if (redisCustomerList != null)
                {
                    serializedCustomerList = Encoding.UTF8.GetString(redisCustomerList);
                    users = JsonConvert.DeserializeObject<List<UserEntity>>(serializedCustomerList);

                    return Json(users);
                }
                else
                {
                    var usersToRedis = this.employeeBussiness.GetAllEmployee();
                    serializedCustomerList = JsonConvert.SerializeObject(usersToRedis);
                    redisCustomerList = Encoding.UTF8.GetBytes(serializedCustomerList);
                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                    distributedCache.Set(cacheKey, redisCustomerList, options);

                    return Json(usersToRedis);
                }
            }
            catch(Exception ex)
            { 
                throw new Exception(ex.Message); 
            
            }

        }


        
        [HttpPost]
        public JsonResult GetEmployee(string search)
        {
            try
            {
                var result = this.employeeBussiness.GetAllEmployee();

                var employee = result.Where(x => x.Name == search || x.Department == search || x.Notes == search).ToList();

                if (employee != null)
                {
                    return Json(employee);
                }
                else
                {
                    return Json("null");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
        }
    }
}
