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
string? curdoperation;
do
{
    do
    {
        Console.WriteLine("Please select below options to Perform CRUD Operations");
        Console.WriteLine("PRESS 1: Department data");
        Console.WriteLine("PRESS 2: Employee data");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input == 1 || input == 2)
        {
            await employeePlayGroundService.CrudOperctionAsync(input);
            validaction = false;
        }
        else
        {
            Console.WriteLine("Please enter only 1 or 2 ");
            validaction = true;
        }
    } while (validaction);
    Console.WriteLine("Do want once gain enter curd operation please enter yes ");
    curdoperation = Console.ReadLine();
    
}while((string.IsNullOrEmpty(curdoperation) ? String.Empty : curdoperation).ToLower().Equals("yes"));

