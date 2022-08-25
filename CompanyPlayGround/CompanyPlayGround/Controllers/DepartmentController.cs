using CompanyPlayGround.Core.Dto;
using CompanyPlayGround.Core.Entities;
using CompanyPlayGround.Infrastructure.Data;
using CompanyPlayGround.Infrastructure.Repository;
using CompanyPlayGround.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyPlayGround.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentRepositoy _departmentRepositoy;
        public DepartmentController()
        {
            _departmentRepositoy = new DepartmentRepositoy(new CompenyContext());
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IEnumerable<DepartmentDto>> Get()
        {
            return await _departmentRepositoy.GetDepartmentsAsync();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<Department> Get(int id)
        {
            return await _departmentRepositoy.GetDepartmentAsync(id);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<Department> Post([FromBody] DepartmentVm departmentVm)
        {
            var dept = new Department { Name = departmentVm.Name };
           return await _departmentRepositoy.CreateAsync(dept);

        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task<Department> Put(int id, [FromBody] DepartmentVm departmentVm)
        {
            var dept=new Department { Name = departmentVm.Name };
            return await _departmentRepositoy.UpdateDepartmentAsync(id, dept);    
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _departmentRepositoy.DeleteDepartmentAsync(id);

        }
    }
}
