using CompanyPlayGround.Core.Dto;
using CompanyPlayGround.Core.Entities;
using CompanyPlayGround.Infrastructure.Data;
using CompanyPlayGround.Infrastructure.Repository;
using CompanyPlayGround.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyPlayGround.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //private readonly CompenyContext _compenyContext;

        //public EmployeeController(CompenyContext compenyContext)
        //{
        //    _compenyContext = compenyContext;
        //}
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository(new CompenyContext());
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _employeeRepository.GetEmployeesAsync(id);
            
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<Employee> Post([FromBody] EmployeeVm employeeVm)
        {
            var employee=new Employee { Name=employeeVm.Name, Email = employeeVm.Email, Salary = employeeVm.Salary, DepartmentId = employeeVm.DepartmentId };
           return await _employeeRepository.CreateAsync(employee);
            

            

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<Employee> Put(int id, [FromBody] EmployeeVm employeeVm)
        {
            var employee = new Employee { Name = employeeVm.Name, Email = employeeVm.Email, Salary = employeeVm.Salary, DepartmentId = employeeVm.DepartmentId };
            await _employeeRepository.UpdateEmployeeAsync(id,employee);

            return employee;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);

        }
    }
}
