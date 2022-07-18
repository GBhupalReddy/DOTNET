using QualmindsApp.Core.Constants;
using QualmindsApp.Core.Contracts_Infrastructure;
using QualmindsApp.Core.Entities;
using System.Text;

namespace QualmindsApp.Infrastructure.IO
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string _filePath;
        public Employee employee;
        StringBuilder stres=new StringBuilder();


        public EmployeeService(string filePath)
        {
            _filePath = filePath;
            InitializeEmployeeService();
        }
        public bool InitializeEmployeeService()
        {
            if (!File.Exists(_filePath))
            {
                StreamWriter? streamWriter = null;
                try
                {
                    streamWriter = File.CreateText(_filePath);
                    streamWriter.WriteLine($"{FileConstants.EmployeeIdField}{FileConstants.Delimeter}{FileConstants.EmployeeNameField}{FileConstants.Delimeter}{FileConstants.EmployeeDesignationField}");
                }
                catch (Exception ex)
                {
                    // Log.Error(ex, ex.Message);
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    streamWriter?.Flush();
                    streamWriter?.Close();
                }
                return true;
            }
            return false;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            File.AppendAllText(_filePath, $"{employee.Id}{FileConstants.Delimeter}{employee.Name}{FileConstants.Delimeter}{employee.Designation}\n");
            return employee;
        }

        public IEnumerable<Employee> AddEmployees(IEnumerable<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public StringBuilder GetEmployees()
        {
            var employeesCommaSeparatedList = File.ReadAllLines(_filePath).Skip(1);
            foreach (var employeeRow in employeesCommaSeparatedList)
            {
                var employeeData = employeeRow.Split(FileConstants.Delimeter);
                stres.AppendLine($"{Guid.Parse(employeeData[0])}\t {employeeData[1]}\t {employeeData[2]}");
            }
            return stres;
        }

        public void DeleteEmployees()
        {
            File.Delete(_filePath);
            Console.WriteLine("Successfully Delete File");
        }

    }
        
}
