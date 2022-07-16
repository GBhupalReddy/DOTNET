
using QualmindsApp.Core.Entities;
using System.Text;

namespace QualmindsApp.Core.Contracts_Infrastructure
{
    public interface IEmployeeService
    {
        public bool InitializeEmployeeService();

        public Employee AddEmployee(Employee employee);

        public IEnumerable<Employee> AddEmployees(IEnumerable<Employee> employees);

        public StringBuilder GetEmployees();

        public void DeleteEmployees();
    }
}
