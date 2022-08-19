using Dapper;
using EmployeePlayGround.Core.Dtos;
using EmployeePlayGround.Core.Entities;
using System.Data;

namespace EmployeePlayGround.Infrastructure.Repositories.Dapper
{
    public class EmployeeDapperRepository : IEmployeeRepository
    {
        private readonly IDbConnection _dbConnection;
        public EmployeeDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
           
           var command = "Insert Employee(Name, Email, Salary, DepartmentId) Values(@Name, @Email, @Salary, @DepartmentId)";
            await _dbConnection.ExecuteAsync(command, employee);
            return employee;
        }

        public async Task CreateRangeAsync(IEnumerable<Employee> employees)
        {
             await _dbConnection.ExecuteAsync($"InsertRecord{employees}");
        }

        public async Task DeleteAsync(int employeeId)
        {
            var command = "Delete from Employee where Id = @Id";
            await _dbConnection.ExecuteAsync(command, new { Id = employeeId });
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            var query = "Select * from Employee where Id = @employeeId";  
            return (await _dbConnection.QueryAsync<Employee>(query, new { employeeId })).FirstOrDefault();
        }

        public async Task GetEmployeeDetailsAsync(int empId)
        {
            var query = "Select * from Employee where Id = @employeeId";  
         (await _dbConnection.QueryAsync<Employee>(query, new { empId })).FirstOrDefault();
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string? filterText = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsExitorNot(string? email = null, int? id = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> UpdateAsync(int employeeId, Employee employee)
        {
            employee.Id = employeeId;
            var command = "Update Employee Set Name = @Name, Salary = @Salary Where Id = @Id";
            await _dbConnection.ExecuteAsync(command, employee);
            return employee;
        }
    }
}
