// See https://aka.ms/new-console-template for more information
using AutoMapper;
using EmployeePlayGround.Configuration;
using EmployeePlayGround.Core.Contracts.Infrastructure.Repositories;
using EmployeePlayGround.Core.Entities;
using EmployeePlayGround.Infrastructure.Data;
using EmployeePlayGround.Infrastructure.Repositories;
using EmployeePlayGround.Infrastructure.Services;
using EmployeePlayGround.ViewModels;

Console.WriteLine("Hello, World!");

#region Configure and Register AutoMapper
var config = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper mapper = config.CreateMapper();

#endregion

var employeeContext = new EmployeeContext();
var employeePlayGroundService = new EmployeePlayGroundService();
bool validaction=false;
do
{
    Console.WriteLine("Please select below options to Perform CRUD Operations");
    Console.WriteLine("PRESS 1: Department data");
    Console.WriteLine("PRESS 2: Employee data");
    int input = Convert.ToInt32(Console.ReadLine());
    if (input == 1 || input == 2)
    {
       await employeePlayGroundService.CrudOperctionAsync(input);
        validaction=false;
    }
    else
    {
        Console.WriteLine("Please enter only 1 or 2 ");
        validaction= true;
    }
}while(validaction);
//if (input == 1)
//{
//    IDepartmentRepository departmentRepository = new DepartmentRepository(employeeContext);
//    Console.WriteLine("PRESS 1: Add department details");
//    Console.WriteLine("PRESS 2: update department details");
//    Console.WriteLine("PRESS 3: Get department details");
//    Console.WriteLine("PRESS 4: Get departments ");
//    int deptData = Convert.ToInt32(Console.ReadLine());
//    switch (deptData)
//    {
//        case 1:
//            //await departmentRepository.CreateAsync(new Department() { Id = 1, Name = "HR" });
//            Console.WriteLine("how many departments add");
//            int addDepartmentCount = Convert.ToInt32(Console.ReadLine());
//            for (int i = 0; i < addDepartmentCount; i++)
//            {
//                bool valid = false;
//                do
//                {
//                    Console.WriteLine("please enter department name ");
//                    string? departmentName = Console.ReadLine();
//                    if (departmentRepository.CheckDepatment(departmentName))
//                    {
//                        await departmentRepository.CreateRangeAsync(
//                       new List<Department>
//                       {
//                                 new Department()  {Name = departmentName }
//                       });
//                    }
//                    else
//                    {
//                        Console.WriteLine("This department is already exit please enter another department name");
//                        valid = true;
//                    }
//                } while (valid);
//            }
//            break;
//        case 2:
//            Console.WriteLine("Enter department Id which department details you update");
//            int updateDeptId = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Enter department new name ");
//            string deptName = Console.ReadLine();
//            var updatedDepartmetData = new Department
//            {
//                Name = deptName
//            };
//            departmentRepository.UpdateAsync(updateDeptId, updatedDepartmetData);
//            break;
//        case 3:
//            Console.WriteLine("Enter department Id ");
//            int deptId = Convert.ToInt32(Console.ReadLine());
//            var depData = departmentRepository.GetDepartmetDeatilsAsync(deptId);
//            break;
//        case 4:
//            Console.WriteLine($"Enter pageIndex");
//            int pageIndex = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine($"Enter pageSize");
//            int pageSize = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine($"Enter sortField");
//            string sortField = Console.ReadLine();
//            Console.WriteLine($"Enter sortOrder");
//            string sortOrder = Console.ReadLine();
//            Console.WriteLine($"Enter filterText");
//            string filterText = Console.ReadLine();

//            var orderDepartmentData = await departmentRepository.GetDepartmentsAsync(pageIndex, pageSize, sortField, sortOrder: sortOrder, filterText: filterText);

//            if (orderDepartmentData.Any())
//            {
//                foreach (var employee in orderDepartmentData)
//                {
//                    Console.WriteLine($"{employee.Id} {employee.Name}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("DATA NOT FOUND");
//            }
//            break;
//        default:
//            throw new ArgumentOutOfRangeException();
//            break;
//    }

//    //await departmentRepository.CreateRangeAsync(
//    //   new List<Department>
//    //   {
//    //  new Department() { Id = 2, Name =  "IT" },
//    //  new Department() { Id = 3, Name = "Accounting" }
//    //   }
//    //   );
//}
//else if (input == 2)
//{
//    IEmployeeRepository employeeRepository = new EmployeeRepository(employeeContext);
//    Console.WriteLine("PRESS 1: Add employee details");
//    Console.WriteLine("PRESS 2: Update employee details");
//    Console.WriteLine("PRESS 3: Get employee details");
//    Console.WriteLine("PRESS 4: Get employees details");
//    Console.WriteLine("PRESS 5: Delete employee");
//    int deptData = Convert.ToInt32(Console.ReadLine());
//    switch (deptData)
//    {
//        case 1:
//            Console.WriteLine("how many employees add");
//            int addEmployeeCount = Convert.ToInt32(Console.ReadLine());
//            for (int i = 0; i < addEmployeeCount; i++)
//            {
//                bool valid = false;
//                do
//                {
//                    Console.WriteLine("please enter Employee name ");
//                    string? employeeName = Console.ReadLine();
//                    Console.WriteLine("please enter Employee salary ");
//                    decimal employeeSalary = Convert.ToDecimal(Console.ReadLine());
//                    Console.WriteLine("please enter Employee email ");
//                    string employeeMail = Console.ReadLine();
//                    Console.WriteLine("please enter Employee depertmentId ");
//                    int depertmentId = Convert.ToInt32(Console.ReadLine());

//                    if (employeeRepository.CheckEmployeeEmail(employeeMail))
//                    {
//                        await employeeRepository.CreateRangeAsync(
//                       new List<Employee> {
//                          new Employee()
//                          {Name=employeeName,Salary=employeeSalary,Email=employeeMail,DepartmentId=depertmentId }
//                       });
//                    }

//                    else
//                    {
//                        Console.WriteLine("This employee is already exit please enter another department name");
//                        valid = true;
//                    }
//                } while (valid);
//            }
//            break;
//        case 2:
//            Console.WriteLine("Enter employee Id which employee details you update");
//            int updateEmpId = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("please enter Employee new name ");
//            string? empName = Console.ReadLine();
//            Console.WriteLine("please enter Employee new salary ");
//            decimal empSalary = Convert.ToDecimal(Console.ReadLine());
//            Console.WriteLine("please enter Employee new  email ");
//            string? empEmail = Console.ReadLine();
//            Console.WriteLine("please enter Employee new depertmentId ");
//            int empdepartmentId = Convert.ToInt32(Console.ReadLine());

//            var updatedEmployeeData = new Employee
//            {
//                Name = empName,
//                Email = empEmail,
//                Salary = empSalary,
//                DepartmentId = empdepartmentId
//            };
//            var udatedEmployee = await employeeRepository.UpdateAsync(updateEmpId, updatedEmployeeData);
//            Console.WriteLine($"Updated Employee: {udatedEmployee.Id} {udatedEmployee.Name} {udatedEmployee.Email} {udatedEmployee.Salary}");
//            break;
//        case 3:
//            Console.WriteLine("Enter employee Id which employee details display");
//            int getEmpId = Convert.ToInt32(Console.ReadLine());
//            await employeeRepository.GetEmployeeDetailsAsync(getEmpId);

//            break;
//        case 4:

//            Console.WriteLine($"Enter pageIndex");
//            int pageIndex = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine($"Enter pageSize");
//            int pageSize = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine($"Enter sortField");
//            string? sortField = Console.ReadLine();
//            Console.WriteLine($"Enter sortOrder");
//            string? sortOrder = Console.ReadLine();
//            Console.WriteLine($"Enter filterText");
//            string? filterText = Console.ReadLine();

//            var orderEmployeeData = await employeeRepository.GetEmployeeesAsync(pageIndex, pageSize, sortField, sortOrder: sortOrder, filterText: filterText);

//            if (orderEmployeeData.Any())
//            {
//                foreach (var employee in orderEmployeeData)
//                {
//                    Console.WriteLine($"{employee.Id} {employee.Name} {employee.Email} {employee.Salary} {employee.DepartmentName}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("DATA NOT FOUND");
//            }
//            break;
//        case 5:
//            Console.WriteLine("Enter employee Id");
//            int deleteEmpId = Convert.ToInt32(Console.ReadLine());
//            var deletedRecord = await employeeRepository.GetEmployeeAsync(deleteEmpId);
//            Console.WriteLine($"  deleted successfully? {deletedRecord == null: true ? false}");
//            break;
//        default:
//            throw new ArgumentOutOfRangeException();
//            break;
//    }

//}

//#region Configure and Register AutoMapper

//#endregion
////using (var employeeContext = new EmployeeContext())
////{
////IEmployeeRepository employeeRepository1 = new EmployeeRepository(employeeContext);
////try
////{
////    var orderEmployeeData = await employeeRepository.GetEmployeeesAsync(1, 5, "Idddd", filterText: "ra");

////    if (orderEmployeeData.Any())
////    {
////        foreach (var employee in orderEmployeeData)
////        {
////            Console.WriteLine($"{employee.Id} {employee.Name} {employee.Email} {employee.Salary} {employee.DepartmentName}");
////        }
////    }
////    else
////    {
////        Console.WriteLine("DATA NOT FOUND");
////    }
////}
////catch(ArgumentOutOfRangeException)
////{
////    Console.WriteLine("Please enter valid input");
////}
////catch (Exception)
////{
////    Console.WriteLine("Please enter valid input");
////}
////await employeeRepository1.CreateRangeAsync(
////    new List<Employee>
////    {
////            new() { Name="Bhupal",Salary=35000,Email="bhupal@gmail.com",DepartmentId=1},
////            new() { Name="Mallika",Salary=25000,Email="mallika@gmail.com",DepartmentId=2},
////            new() { Name="Ramna",Salary=20000,Email="ramna@gmail.com",DepartmentId=3},
////            new() { Name="Krishna",Salary=27000,Email="krishna@gmail.com",DepartmentId=1},
////            new() { Name="Kameswari",Salary=25000,Email="Kameswari@gmail.com",DepartmentId=2},
////            new() { Name="Navneet",Salary=29000,Email="navneet@gmail.com",DepartmentId=3},
////            new() { Name="Aruna",Salary=30000,Email="aruna@gmail.com",DepartmentId=1},
////            new() { Name="Amani",Salary=33000,Email="amani@gmail.com",DepartmentId=2},
////            new() { Name="Prasanna",Salary=27000,Email="prasanna@gmail.com",DepartmentId=3},
////            new() { Name="Vamshi",Salary=25000,Email="pamshi@gmail.com",DepartmentId=1},
////            new() { Name="Maruthi",Salary=35000,Email="maruthi@gmail.com",DepartmentId=2},
////            new() { Name="Nagesh",Salary=22000,Email="nagesh@gmail.com",DepartmentId=3},
////            new() { Name="Srikanth",Salary=21000,Email="srikanth@gmail.com",DepartmentId=1},
////            new() { Name="Manikantta",Salary=20000,Email="manikantta@gmail.com",DepartmentId=2},
////            new() { Name="Rajesh",Salary=22000,Email="rajesh@gmail.com",DepartmentId=3},
////            new() { Name="Ravindra",Salary=29000,Email="ravindra@gmail.com",DepartmentId=1},
////            new() { Name="Bhanu",Salary=30000,Email="bhanu@gmail.com",DepartmentId=2},
////            new() { Name="Charan",Salary=32000,Email="charan@gmail.com",DepartmentId=3},
////            new() { Name="Suresh",Salary=31000,Email="suresh@gmail.com",DepartmentId=1},
////        });


