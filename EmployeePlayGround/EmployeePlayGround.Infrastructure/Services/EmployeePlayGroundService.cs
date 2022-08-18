using EmployeePlayGround.Core.Contracts.Infrastructure.Repositories;
using EmployeePlayGround.Core.Entities;
using EmployeePlayGround.Infrastructure.Data;
using EmployeePlayGround.Infrastructure.Repositories;

namespace EmployeePlayGround.Infrastructure.Services
{
    public class EmployeePlayGroundService
    {
       
        public async Task CrudOperctionAsync(int value)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            bool inValid = false;

            if (value == 1)
                {
                try { 
                    IDepartmentRepository departmentRepository = new DepartmentRepository(employeeContext);
                    Console.WriteLine("PRESS 1: Add department details");
                    Console.WriteLine("PRESS 2: Update department details");
                    Console.WriteLine("PRESS 3: Get department details");
                    Console.WriteLine("PRESS 4: Get departments ");
                    int deptData = Convert.ToInt32(Console.ReadLine());
                    if (deptData < 0)
                    {
                        throw new InvalidDataException();
                    }
                    switch (deptData)
                    {
                        case 1:
                            //await departmentRepository.CreateAsync(new Department() { Id = 1, Name = "HR" });
                            Console.WriteLine("How many department records, do you want to add?");
                            int addDepartmentCount = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < addDepartmentCount; i++)
                            {
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("please enter department name ");
                                        string? departmentName = Console.ReadLine();
                                        if (departmentRepository.IsExitorNot(departmentName))
                                        {
                                            await departmentRepository.CreateRangeAsync(
                                           new List<Department>
                                           { new Department()  {Name = string.IsNullOrEmpty(departmentName) ? String.Empty : departmentName }});

                                            Console.WriteLine("department added successfully");
                                        }
                                        else
                                        {
                                            Console.WriteLine("This department is already exit please enter another department name");
                                            inValid = true;
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        inValid = true;
                                        Console.WriteLine("Please enter valid input ");
                                    }
                                } while (inValid);
                            }
                            break;
                        case 2:
                            do
                            {
                                Console.WriteLine("Enter department Id to update the deportment record");
                                int updateDeptId = Convert.ToInt32(Console.ReadLine());
                                if (departmentRepository.IsExitorNot(departmentId: updateDeptId))
                                {
                                    Console.WriteLine("Enter department new name ");
                                    string? deptName = Console.ReadLine();
                                    var updatedDepartmetData = new Department
                                    {
                                        Name = string.IsNullOrEmpty(deptName) ? String.Empty : deptName
                                    };
                                    await departmentRepository.UpdateAsync(updateDeptId, updatedDepartmetData);
                                    inValid = false;
                                }
                                else
                                {
                                    Console.WriteLine($"{updateDeptId} This id not found ");
                                    inValid = true;
                                }
                            } while (inValid);
                            Console.WriteLine("Successfully updated department record ");
                            break;
                        case 3:
                            Console.WriteLine("Enter department Id ");
                            int deptId = Convert.ToInt32(Console.ReadLine());
                            var depData = departmentRepository.GetDepartmetDeatilsAsync(deptId);
                            break;
                        case 4:
                            Console.WriteLine($"Enter pageIndex");
                            int pageIndex = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Enter pageSize");
                            int pageSize = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Enter sortField");
                            string? sortField = Console.ReadLine();
                            Console.WriteLine($"Enter sortOrder");
                            string? sortOrder = Console.ReadLine();
                            Console.WriteLine($"Enter filterText");
                            string? filterText = Console.ReadLine()?.ToLower();

                            var orderDepartmentData = await departmentRepository.GetDepartmentsAsync(pageIndex, pageSize, sortField, sortOrder: sortOrder, filterText: filterText);

                            if (orderDepartmentData.Any())
                            {
                                foreach (var employee in orderDepartmentData)
                                {
                                    Console.WriteLine($"{employee.Id} {employee.Name}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("DATA NOT FOUND");
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Please enter only 1 to 4 ");
                    }
                }
                catch (ArgumentOutOfRangeException arore)
                {
                    Console.WriteLine(arore.Message);
                    await CrudOperctionAsync(1);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter valid input ");
                    await CrudOperctionAsync(1);
                }
                catch (InvalidDataException)
                {
                    Console.WriteLine("Please enter valid input");
                    await CrudOperctionAsync(1);
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter valid input");
                    await CrudOperctionAsync(1);
                }
            }
            else if (value == 2)
            {
                try
                {
                    IEmployeeRepository employeeRepository = new EmployeeRepository(employeeContext);
                    Console.WriteLine("PRESS 1: Add employee details");
                    Console.WriteLine("PRESS 2: Update employee details");
                    Console.WriteLine("PRESS 3: Get employee details");
                    Console.WriteLine("PRESS 4: Get employees details");
                    Console.WriteLine("PRESS 5: Delete employee");
                    int empData = Convert.ToInt32(Console.ReadLine());
                    if (empData < 0)
                    {
                        throw new InvalidDataException();
                    }
                    switch (empData)
                    {
                        case 1:
                            Console.WriteLine("how many employees add");
                            int addEmployeeCount = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < addEmployeeCount; i++)
                            {
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("please enter Employee name ");
                                        string? employeeName = Console.ReadLine();
                                        Console.WriteLine("please enter Employee salary ");
                                        decimal employeeSalary = Convert.ToDecimal(Console.ReadLine());
                                        Console.WriteLine("please enter Employee email ");
                                        string? employeeMail = Console.ReadLine();
                                        Console.WriteLine("please enter Employee depertmentId ");
                                        int depertmentId = Convert.ToInt32(Console.ReadLine());

                                        if (employeeRepository.IsExitorNot(employeeMail))
                                        {
                                            await employeeRepository.CreateRangeAsync(
                                            new List<Employee> {
                                            new Employee()
                                            { Name = string.IsNullOrEmpty(employeeName) ? String.Empty : employeeName,
                                              Salary=employeeSalary,
                                              Email=string.IsNullOrEmpty(employeeMail) ? String.Empty : employeeMail,
                                              DepartmentId=depertmentId }});

                                            Console.WriteLine("Employee added successfully");
                                        }

                                        else
                                        {
                                            Console.WriteLine("This employee is already exit please enter another department name");
                                            inValid = true;
                                        }
                                    }
                                    catch(FormatException)
                                    {
                                        inValid = true;
                                        Console.WriteLine("Please enter valid input ");
                                    }
                                } while (inValid);
                            }
                            break;
                        case 2:
                            do
                            {
                                Console.WriteLine("Enter employee Id to update the deportment record");
                                int updateEmpId = Convert.ToInt32(Console.ReadLine());
                                if (employeeRepository.IsExitorNot(id: updateEmpId))
                                {
                                    Console.WriteLine("please enter Employee new name ");
                                    string? empName = Console.ReadLine();
                                    Console.WriteLine("please enter Employee new salary ");
                                    decimal empSalary = Convert.ToDecimal(Console.ReadLine());
                                    Console.WriteLine("please enter Employee new  email ");
                                    string? empEmail = Console.ReadLine();
                                    Console.WriteLine("please enter Employee new depertmentId ");
                                    int empdepartmentId = Convert.ToInt32(Console.ReadLine());

                                    var updatedEmployeeData = new Employee
                                    {
                                        Name = string.IsNullOrEmpty(empName) ? String.Empty : empName,
                                        Email = string.IsNullOrEmpty(empEmail) ? String.Empty : empEmail,
                                        Salary = empSalary,
                                        DepartmentId = empdepartmentId
                                    };
                                    var udatedEmployee = await employeeRepository.UpdateAsync(updateEmpId, updatedEmployeeData);
                                    Console.WriteLine($"Updated Employee: {udatedEmployee.Id} {udatedEmployee.Name} {udatedEmployee.Email} {udatedEmployee.Salary}");
                                    inValid = false;
                                }
                                else
                                {
                                    Console.WriteLine($"{updateEmpId} This id not found ");
                                    inValid = true; 
                                }
                            } while (inValid);
                            Console.WriteLine("Successfully updated employee record ");
                            break;
                        case 3:
                            Console.WriteLine("Enter employee Id which employee details display");
                            int getEmpId = Convert.ToInt32(Console.ReadLine());
                            await employeeRepository.GetEmployeeDetailsAsync(getEmpId);

                            break;
                        case 4:

                            Console.WriteLine($"Enter pageIndex");
                            int pageIndex = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Enter pageSize");
                            int pageSize = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Enter sortField");
                            string? sortField = Console.ReadLine();
                            Console.WriteLine($"Enter sortOrder");
                            string? sortOrder = Console.ReadLine();
                            Console.WriteLine($"Enter filterText");
                            string? filterText = Console.ReadLine();

                            var orderEmployeeData = await employeeRepository.GetEmployeesAsync(pageIndex, pageSize, sortField, sortOrder: sortOrder, filterText: filterText);

                            if (orderEmployeeData.Any())
                            {
                                foreach (var employee in orderEmployeeData)
                                {
                                    Console.WriteLine($"{employee.Id} {employee.Name} {employee.Email} {employee.Salary} {employee.DepartmentName}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("DATA NOT FOUND");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Enter employee Id");
                            int deleteEmpId = Convert.ToInt32(Console.ReadLine());
                            var deletedRecord = await employeeRepository.GetEmployeeAsync(deleteEmpId);
                            Console.WriteLine($"  deleted successfully? {deletedRecord == null: true ? false}");
                            break;
                        default:
                           
                            throw new ArgumentOutOfRangeException("Please enter 1 to 5 numbers only");
                           
                    }
                }
                catch(ArgumentOutOfRangeException arore)
                {
                    
                    Console.WriteLine(arore.Message);
                   await CrudOperctionAsync(2);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Please enter valid input ");
                    await CrudOperctionAsync(2);
                }
                catch(InvalidDataException)
                {
                    Console.WriteLine("Please enter valid input");
                    await CrudOperctionAsync(2);
                }
                catch(Exception)
                {
                    Console.WriteLine("Please enter valid input" +
                        "");
                    await CrudOperctionAsync(2);
                }
            }

        }
    }
}
