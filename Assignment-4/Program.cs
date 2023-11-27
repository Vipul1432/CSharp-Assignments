using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class Program
{
    IList<Employee> employeeList;
    IList<Salary> salaryList;

    public Program()
    {
        employeeList = new List<Employee>
        {
            new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
            new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
            new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
            new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
            new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
            new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
            new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}
        };

        salaryList = new List<Salary>
        {
            new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
        };
    }

    public static void Main()
    {
        Program program = new Program();

        program.Task1();

        program.Task2();

        program.Task3();
    }

    public void Task1()
    {
        //Implementation
        // Calculate the total salary of each employee and order the results by total salary
        var totalSalaries = employeeList
                                    .Join(salaryList, e => e.EmployeeID, s => s.EmployeeID, (e, s) => new { e, s })
                                    .GroupBy(x => new { x.e.EmployeeFirstName, x.e.EmployeeLastName })
                                    .Select(g => new
                                    {
                                        Name = $"{g.Key.EmployeeFirstName} {g.Key.EmployeeLastName}",
                                        TotalSalary = g.Sum(x => x.s.Amount)
                                    })
                                    .OrderBy(x => x.TotalSalary);

        Console.WriteLine("Total Salary of all employees in ascending order:");
        foreach (var item in totalSalaries)
        {
            Console.WriteLine($"{item.Name}: {item.TotalSalary}");
        }

        Console.WriteLine();
    }

    public void Task2()
    {
        //Implementation
        // Retrieve details of the second oldest employee by ordering the employeeList
        // in descending order of age, skipping the first employee, and selecting the first one.
        var secondOldestEmployeeDetails = employeeList
                                                    .OrderByDescending(e => e.Age)
                                                    .Skip(1)
                                                    .FirstOrDefault();

        if (secondOldestEmployeeDetails != null)
        {
            // Calculate the total monthly salary of the second oldest employee
            var monthlySalary = salaryList
                                        .Where(s => s.EmployeeID == secondOldestEmployeeDetails.EmployeeID && s.Type == SalaryType.Monthly)
                                        .Sum(s => s.Amount);

            Console.WriteLine($"Details of the 2nd oldest employee ({secondOldestEmployeeDetails.EmployeeFirstName} {secondOldestEmployeeDetails.EmployeeLastName}):");
            Console.WriteLine($"Age: {secondOldestEmployeeDetails.Age}");
            Console.WriteLine($"Total Monthly Salary: {monthlySalary}");
        }
        else
        {
            Console.WriteLine("No second oldest employee found.");
        }

        Console.WriteLine();
    }

    public void Task3()
    {
        //Implementation
        // Calculate the total Monthly, Performance, and Bonus salary for employees above 30 years old,
        // grouped by their age. The result is a sequence of anonymous objects with age, MonthlySalary,
        // PerformanceSalary, and BonusSalary.
        var employeesAbove30 = employeeList
                                        .Where(e => e.Age > 30)
                                        .GroupBy(e => e.Age)
                                        .Select(g => new
                                        {
                                            Age = g.Key,
                                            MonthlySalary = g.Sum(emp => salaryList
                                                                                .Where(s => s.EmployeeID == emp.EmployeeID && s.Type == SalaryType.Monthly)
                                                                                .Sum(s => s.Amount)),
                                            PerformanceSalary = g.Sum(emp => salaryList
                                                                                .Where(s => s.EmployeeID == emp.EmployeeID && s.Type == SalaryType.Performance)
                                                                                .Sum(s => s.Amount)),
                                            BonusSalary = g.Sum(emp => salaryList
                                                                                .Where(s => s.EmployeeID == emp.EmployeeID && s.Type == SalaryType.Bonus)
                                                                                .Sum(s => s.Amount))
                                        });

        Console.WriteLine("Means of Monthly, Performance, Bonus salary of employees above 30:");

        foreach (var item in employeesAbove30)
        {
            Console.WriteLine($"Age: {item.Age}");
            Console.WriteLine($"Monthly Salary: {item.MonthlySalary}");
            Console.WriteLine($"Performance Salary: {item.PerformanceSalary}");
            Console.WriteLine($"Bonus Salary: {item.BonusSalary}");
            Console.WriteLine();
        }
    }
}

public enum SalaryType
{
    Monthly,
    Performance,
    Bonus
}

public class Employee
{
    public int EmployeeID { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public int Age { get; set; }
}

public class Salary
{
    public int EmployeeID { get; set; }
    public int Amount { get; set; }
    public SalaryType Type { get; set; }
}