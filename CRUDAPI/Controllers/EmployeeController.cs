using DtosLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Employee;

namespace CRUDAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetEmployees")]
        public ActionResult GetEmployees()
        {
            return Ok(_employeeService.GetEmployees());
        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public ActionResult GetEmployee(int id)
        {
            return Ok(_employeeService.GetEmployee(id));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public ActionResult AddEmployee([FromBody] EmployeeClass employee)
        {
            return Ok(_employeeService.AddEmployee(employee));
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public ActionResult UpdateEmployee([FromBody] EmployeeClass employee)
        {
            return Ok(_employeeService.UpdateEmployee(employee));
        }

        [HttpPost]
        [Route("DeleteEmployee/{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            return Ok(_employeeService.DeleteEmployee(id));
        }
    }
}
