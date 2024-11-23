using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_2
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Position: {Position}, Salary: {Salary:C}";
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Employee Management");
            var employees = new List<Employee>();
            while (true)
            {
                Console.WriteLine(" 1. Add\n 2. List All\n 3. Find\n 4. Update\n 5. Delete\n 6. Exit");
                if (!int.TryParse(Console.ReadLine(), out int command))
                    continue;

                switch (command)
                {
                    case 1:
                        Console.Write("Enter Employee ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int addId) || addId <= 0)
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }
                        if (employees.Any(e => e.Id == addId))
                        {
                            Console.WriteLine("ID already exists.");
                            break;
                        }
                        Console.Write("Enter Employee Name: ");
                        string addName = Console.ReadLine();
                        Console.Write("Enter Employee Position: ");
                        string addPosition = Console.ReadLine();
                        Console.Write("Enter Employee Salary: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal addSalary) || addSalary < 0)
                        {
                            Console.WriteLine("Invalid salary.");
                            break;
                        }
                        employees.Add(new Employee { Id = addId, Name = addName, Position = addPosition, Salary = addSalary });
                        Console.WriteLine("Employee added.");
                        break;

                    case 2:
                        if (!employees.Any())
                        {
                            Console.WriteLine("No employees to display.");
                            break;
                        }
                        Console.WriteLine("All Employees:");
                        foreach (var employee in employees)
                            Console.WriteLine(employee);
                        break;

                    case 3:
                        Console.Write("Enter Employee ID to find: ");
                        if (!int.TryParse(Console.ReadLine(), out int findId))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }
                        var foundEmployee = employees.FirstOrDefault(e => e.Id == findId);
                        if (foundEmployee == null)
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        else
                        {
                            Console.WriteLine(foundEmployee);
                        }
                        break;

                    case 4:
                        Console.Write("Enter Employee ID to update: ");
                        if (!int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }
                        var employeeToUpdate = employees.FirstOrDefault(e => e.Id == updateId);
                        if (employeeToUpdate == null)
                        {
                            Console.WriteLine("Employee not found.");
                            break;
                        }
                        Console.Write("Enter new Name: ");
                        employeeToUpdate.Name = Console.ReadLine();
                        Console.Write("Enter new Position: ");
                        employeeToUpdate.Position = Console.ReadLine();
                        Console.Write("Enter new Salary: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal updateSalary) || updateSalary < 0)
                        {
                            Console.WriteLine("Invalid salary.");
                            break;
                        }
                        employeeToUpdate.Salary = updateSalary;
                        Console.WriteLine("Employee updated.");
                        break;

                    case 5:
                        Console.Write("Enter Employee ID to delete: ");
                        if (!int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }
                        var employeeToDelete = employees.FirstOrDefault(e => e.Id == deleteId);
                        if (employeeToDelete == null)
                        {
                            Console.WriteLine("Employee not found.");
                            break;
                        }
                        employees.Remove(employeeToDelete);
                        Console.WriteLine("Employee deleted.");
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
    }
}
