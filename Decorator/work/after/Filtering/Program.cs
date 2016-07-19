using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = HumanResources.GetInstance().GetEmployees();

            employees = new GenderEmployeeFilter(Gender.Male, employees);
            employees = new SalaryFilter(3000, employees);
          
            employees = new SalarySorter(employees);
            
            PrintEmployees(employees);
        }


        private static void PrintEmployees(IEnumerable<Employee> employees)
        {
            int nRow = 0;

            foreach (Employee employee in employees)
            {
                if (nRow % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }

                nRow++;

                Console.WriteLine("{0,-3} {1,-7} \t {2,-20} {3,-4}  {4,-8}" , nRow ,  employee.Gender , employee.Name , employee.Age , employee.Salary ); 
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
