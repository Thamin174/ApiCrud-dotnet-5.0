using EmpRegd.Model;
using EmpRegd.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace newproj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeServices _adminContext;
        public EmployeeController(EmployeeServices context)
        {
            _adminContext = context;
        }

        [HttpPost]
        [ActionName("Insert")]
        public string insert(Employee emAdmin)
        {
            return _adminContext.insert(emAdmin);
        }

        [HttpGet]
        [Route("User")]
        public new List<Employee> User()
        {
            return _adminContext.User();
        }
        [HttpPut]
        [Route("Update")]
        public string Upadte(Employee employee)
        {
            return _adminContext.UpdateUser(employee);
        }
        [HttpDelete]
        [Route("Delete")]
        public void Delete(int id)
        {
            _adminContext.DeleteUser(id);
        }
    }
}
