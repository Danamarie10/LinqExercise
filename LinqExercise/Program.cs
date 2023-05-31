using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            int sum = numbers.Sum();
            Console.WriteLine(sum);
            int sumQuery = (from num in numbers select num).Sum();
            Console.WriteLine(sumQuery);

            //TODO: Print the Average of numbers
            double average = numbers.Average();
            Console.WriteLine(average);
            double averageQuery = (from num in numbers select num).Average();

            //TODO: Order numbers in ascending order and print to the console
            var ascendingNumbers = numbers.OrderBy(num => num);
            Console.WriteLine("Ascending Order");
            foreach (var num in ascendingNumbers)
            {

                Console.WriteLine(num);
            }

            //TODO: Order numbers in descending order and print to the console
            var descendingNumbers = numbers.OrderByDescending(num => num);
            Console.WriteLine("Descending Order");
            foreach (var num in descendingNumbers)
            {
                Console.WriteLine(num);
            }

            //TODO: Print to the console only the numbers greater than 6
            var numbersGreaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("Numbers greater than 6");
            foreach (var num in numbersGreaterThanSix)
            {
                Console.WriteLine(num);
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var orderedNumbers = numbers.OrderBy(num => num);
            Console.WriteLine("Ordered numbers ascending");
            int count = 0;

            foreach (var num in orderedNumbers)
            {
                Console.WriteLine(num);
                count++;
                if (count >= 4)
                {
                    break;
                }
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 27;
            var descendingnumbers = numbers.OrderByDescending(num => num);
            Console.WriteLine("Numbers in descending order");

            foreach (var num in descendingnumbers)
            {
                Console.WriteLine(num);
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();


            var filteredEmployees = employees.Where(emp => emp.FirstName.StartsWith('C') || emp.FirstName.StartsWith('S')).OrderBy(emp => emp.FirstName).ToList();

            foreach (var employee in filteredEmployees)
            {
                Console.WriteLine(employee.FirstName);
            }

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var filteredEmployeeAge = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);
            foreach (var employee in filteredEmployeeAge)
            {
                Console.WriteLine($"FullName: {employee.FirstName}, Age: {employee.Age}");
            }
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var filteredEmployeeYOE = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35);
            int sumYearsOfExperience = filteredEmployeeYOE.Sum(emp => emp.YearsOfExperience);
            double averageYearsOfExperience = filteredEmployeeYOE.Average(emp => emp.YearsOfExperience);
            Console.WriteLine($"{sumYearsOfExperience}");
            Console.WriteLine($"{averageYearsOfExperience}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Dana", "Patrick", 27, 2)).ToList();
            Console.WriteLine("Updated employees List: ");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Full Name:{employee.FirstName} {employee.LastName}, Age: {employee.Age}, YearsOfExperience: {employee.YearsOfExperience}.");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
    }

        
    
}
