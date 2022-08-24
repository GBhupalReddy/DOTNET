using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Data;
using EmployeeRecordBook.Infrastructure.Repositories;

Console.WriteLine("hello world");



//departmentRepository.Create(new Department() { Name = "HR" });
//departmentRepository.Create(new Department() { Name = "IT" });
//departmentRepository.Create(new Department() { Name = "Accounting" });

using (var employeeContext = new EmployeeContext())
{
    IDepartmentRepository departmentRepository = new DepartmentRepository(employeeContext);
     var hr = await departmentRepository.CreateAsync(new Department() { Name = "HR" });
    var it = await departmentRepository.CreateAsync(new Department() { Name = "IT" });
    var accounts = await departmentRepository.CreateAsync(new Department() { Name = "Accounts" });
    IEmployeeRepository employeeRepository = new EmployeeRepository(employeeContext);
    var bhupal = await employeeRepository.CreateAsync(new Employee
    {
        Name = "Bhupal Reddy",
        Email = "bhupal@gamil.com",
        Salary = 10000m,
        DepartmentId = 1
    });
   
   var mallika=await employeeRepository.CreateAsync(new Employee
    {
        Name = "mallika",
        Email = "mallika@gamil.com",
        Salary = 10500m,
        DepartmentId = 2
    });
    Console.WriteLine($"Create Employee : {bhupal.Id} { bhupal.Name}, {mallika.Id} {mallika.Name}");
    var employees = await employeeRepository.GetEmployeesAsync();

    Console.WriteLine($"Total Employee Records : {employees.Count()} ");

    var updatedBhupalData = new Employee
    {
        Name = "Bhupal Reddy",
        Email = "bhupal@mail.com",
        Salary = 12000m,
        DepartmentId = 1
    };
    var updatedEmployee = await employeeRepository.UpadteAsync(bhupal.Id, updatedBhupalData);
    Console.WriteLine($"Updated Employee : {updatedEmployee.Id} {updatedEmployee.Name} {updatedEmployee.Email} {updatedEmployee.Salary}");

    await employeeRepository.DeleteAsync(mallika.Id);

    var deletedRecord = await employeeRepository.GetEmployeeAsync(mallika?.Id ?? 0);
    Console.WriteLine($"was record deleted successfully? {deletedRecord == null: true ? false}");
}
