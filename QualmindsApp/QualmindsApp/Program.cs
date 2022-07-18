
using QualmindsApp.Core.Contracts_Infrastructure;
using QualmindsApp.Core.Entities;
using QualmindsApp.Infrastructure.IO;
using System.Text;
using System.Text.Json;

Console.WriteLine("please enter the Directory Path");
string directory= Console.ReadLine();
string directoryPath = directory;
string fileName = "Employee.csv";
IEmployeeService employeeservice = new EmployeeService(Path.Combine(directoryPath, fileName));
if (File.Exists((Path.Combine(directoryPath, fileName))))
{
Console.WriteLine($"created {fileName} with predefined headers");
Console.WriteLine("Do you want Adding Employees Details please enter Yes else No");
string addingResult = Console.ReadLine();
    Add(addingResult);
    void Add(string value)
    {
        //string result = "Yes";
        if (value=="Yes")
        {
         Console.WriteLine("\n Adding Employees : \n");
        Console.WriteLine("Please Enter Employee Name");
        string Name=Console.ReadLine();
        Console.WriteLine("Please Enter Designation");
        string Designation = Console.ReadLine();
        employeeservice.AddEmployee(new Employee { Name = Name, Designation = Designation });
        Console.WriteLine("Do you want Adding More Employees Details please enter Yes else No");
        string addingResult1 = Console.ReadLine();
        Add(addingResult1);
    }
    else if(value!="No")
     {
        Console.WriteLine("Please enter valid Input");
            Console.WriteLine("Do you want Adding Employees Details please enter Yes else No");
            string addingResult = Console.ReadLine();
            Add(addingResult);
        }
      
}
    Console.WriteLine("Do You Want Display Employees Please Enter Yes");
    string dipalplayResult = Console.ReadLine();
    if (dipalplayResult == "Yes")
    {
        StringBuilder employees = employeeservice.GetEmployees();
        Console.WriteLine("ID \t\t\t\t\t  Name \t\t Designation");
        Console.WriteLine(employees);
    }
    Console.WriteLine("Do You Want Delete the File Please Enter Yes ");
    string deleteResult=Console.ReadLine();
    if(deleteResult == "Yes")
    {
        employeeservice.DeleteEmployees();
        
    }
}
