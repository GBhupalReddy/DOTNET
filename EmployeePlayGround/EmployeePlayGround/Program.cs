// See https://aka.ms/new-console-template for more information
using AutoMapper;
using EmployeePlayGround.Configuration;
using EmployeePlayGround.Core.Contracts.Infrastructure.Repositories;
using EmployeePlayGround.Core.Entities;
using EmployeePlayGround.Infrastructure.Data;
using EmployeePlayGround.Infrastructure.Repositories;
using EmployeePlayGround.ViewModels;

Console.WriteLine("Hello, World!");

#region Configure and Register AutoMapper
var config = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper mapper = config.CreateMapper();

#endregion



//IdepartmentRepository departmentRepository = new DepartmentRepository();
////await departmentRepository.CreateAsync(new Department() { Id = 1, Name = "HR" });


//await departmentRepository.CreateRangeAsync(
//   new List<Department>
//   {
//      new Department() { Id = 2, Name =  "IT" },
//      new Department() { Id = 3, Name = "Accounting" }
//   }
//   );

using (var employeeContext = new EmployeeContext())
{
    IEmployeeRepository employeeRepository = new EmployeeRepository(employeeContext);
    var orderEmployeeData=await employeeRepository.GetEmployeeesAsync(2, 5, "Id");
    foreach(var employee in orderEmployeeData)
    {
        Console.WriteLine($"{employee.Id} {employee.Name} {employee.Email} {employee.Salary} {employee.DepartmentName}");
    }

    //await employeeRepository.CreateRangeAsync(
    //    new List<Employee>
    //    {
    //        new() { Name="Bhupal",Salary=35000,Email="bhupal@gmail.com",DepartmentId=1},
    //        new() { Name="Mallika",Salary=25000,Email="mallika@gmail.com",DepartmentId=2},
    //        new() { Name="Ramna",Salary=20000,Email="ramna@gmail.com",DepartmentId=3},
    //        new() { Name="Krishna",Salary=27000,Email="krishna@gmail.com",DepartmentId=1},
    //        new() { Name="Kameswari",Salary=25000,Email="Kameswari@gmail.com",DepartmentId=2},
    //        new() { Name="Navneet",Salary=29000,Email="navneet@gmail.com",DepartmentId=3},
    //        new() { Name="Aruna",Salary=30000,Email="aruna@gmail.com",DepartmentId=1},
    //        new() { Name="Amani",Salary=33000,Email="amani@gmail.com",DepartmentId=2},
    //        new() { Name="Prasanna",Salary=27000,Email="prasanna@gmail.com",DepartmentId=3},
    //        new() { Name="Vamshi",Salary=25000,Email="pamshi@gmail.com",DepartmentId=1},
    //        new() { Name="Maruthi",Salary=35000,Email="maruthi@gmail.com",DepartmentId=2},
    //        new() { Name="Nagesh",Salary=22000,Email="nagesh@gmail.com",DepartmentId=3},
    //        new() { Name="Srikanth",Salary=21000,Email="srikanth@gmail.com",DepartmentId=1},
    //        new() { Name="Manikantta",Salary=20000,Email="manikantta@gmail.com",DepartmentId=2},
    //        new() { Name="Rajesh",Salary=22000,Email="rajesh@gmail.com",DepartmentId=3},
    //        new() { Name="Ravindra",Salary=29000,Email="ravindra@gmail.com",DepartmentId=1},
    //        new() { Name="Bhanu",Salary=30000,Email="bhanu@gmail.com",DepartmentId=2},
    //        new() { Name="Charan",Salary=32000,Email="charan@gmail.com",DepartmentId=3},
    //        new() { Name="Suresh",Salary=31000,Email="suresh@gmail.com",DepartmentId=1},
    //        });

    //var anilVm = new EmployeeVm
    //{
    //    Name = "Anil Kumar",
    //    Email = "anil@global.com",
    //    Salary = 10000m,
    //    DepartmentId = 1
    //};


    //// Do validation and other formatting on View Model received from UI.

    //// Transform your VM to Entity which can be saved to DB.
    //var amilEntity = mapper.Map<EmployeeVm, Employee>(anilVm);

    //var anil = await employeeRepository.CreateAsync(amilEntity);
    //var sunil = await employeeRepository.CreateAsync(new Employee
    //{
    //    Name = "Sunil Kumar",
    //    Email = "sunil@global.com",
    //    Salary = 10600m,
    //    DepartmentId = 2
    //});
    //Console.WriteLine($"Created Employees: {anil.Id} {anil.Name}, {sunil.Id} {sunil.Name}");

    //var employees = await employeeRepository.GetEmployeesAsync();
    //Console.WriteLine($"Total Employee Records: {employees.Count()}");

    //var updatedAnilData = new Employee
    //{
    //    Name = "Anil Kumar",
    //    Email = "anil@email.com",
    //    Salary = 12000m,
    //    DepartmentId = 1
    //};
    //var udatedEmployee = await employeeRepository.UpdateAsync(anil.Id, updatedAnilData);
    //Console.WriteLine($"Updated Employee: {udatedEmployee.Id} {udatedEmployee.Name} {udatedEmployee.Email} {udatedEmployee.Salary}");

    //await employeeRepository.DeleteAsync(sunil?.Id ?? 0);

    //var deletedRecord = await employeeRepository.GetEmployeeAsync(sunil?.Id ?? 0);
    //Console.WriteLine($"Was record deleted successfully? {deletedRecord == null: true ? false}");
}
