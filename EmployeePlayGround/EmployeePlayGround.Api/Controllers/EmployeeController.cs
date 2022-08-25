using EmployeePlayGround.Core.Dtos;
using EmployeePlayGround.Core.Entities;
using EmployeePlayGround.Infrastructure.Data;
using EmployeePlayGround.Infrastructure.Repositories;
using EmployeePlayGround.Infrastructure.Repositories.EntityFramwork;
using EmployeePlayGround.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeePlayGround.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository(new EmployeeContext());
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
            return await _employeeRepository.GetEmployeeAsync(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<Employee> Post([FromBody] EmployeeVm employeeVm)
        {
            var employee = new Employee { Name = employeeVm.Name, Email = employeeVm.Email, Salary = employeeVm.Salary, DepartmentId = employeeVm.DepartmentId };
            return await _employeeRepository.CreateAsync(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<Employee> Put(int id, [FromBody] EmployeeVm employeeVm)
        {
            var employee = new Employee { Id = employeeVm.Id, Name = employeeVm.Name, Email = employeeVm.Email, Salary = employeeVm.Salary, DepartmentId = employeeVm.DepartmentId };
            return await _employeeRepository.UpdateAsync(id, employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}
