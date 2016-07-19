using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering
{
    class SalarySorter : EnumerableEmployeeDecorator
    {

        public SalarySorter(IEnumerable<Employee> employees) : base(employees) { }

        public override IEnumerator<Employee> GetEnumerator()
        {
            SortedList<double, Employee> employees = new SortedList<double, Employee>();

            foreach (Employee employee in wrappedObject)
            {
                employees.Add(employee.Salary, employee);
            }

            return employees.Values.GetEnumerator();
        }
    }
}
