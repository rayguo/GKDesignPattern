using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering
{
    public class HumanResources
    {
        private static HumanResources instance = new HumanResources();
        private List<Employee> employees = new List<Employee>();

        private HumanResources()
        {
            employees.Add( new Employee( Gender.Male ,"Andy" , 21 , 100 ));
            employees.Add(new Employee(Gender.Female, "Andrea", 32, 3000));
            employees.Add(new Employee(Gender.Female, "Emily", 25, 4000));
            employees.Add( new Employee(Gender.Male , "Kev" , 59, 5000 ) );
            employees.Add(new Employee(Gender.Female, "Lisa", 45, 10000));
            employees.Add( new Employee(Gender.Male , "Rich" , 60 , 90000 ) );
            employees.Add(new Employee(Gender.Male , "Si", 45, 2000));
            employees.Add(new Employee(Gender.Female, "Sally", 27, 8000));
            employees.Add(new Employee(Gender.Male , "Jason", 27, 6000));
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employees;
        }

        public static HumanResources GetInstance()
        {
            if (instance == null)
            {
                instance = new HumanResources();
            }
            return instance;
        }

    }

}
