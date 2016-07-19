using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering
{
    class SalaryFilter : EnumerableEmployeeDecorator
    {
        private double employeeSalaryOver;
        public SalaryFilter(double salaryOver , IEnumerable<Employee>  employees) : base(employees)
        {
            employeeSalaryOver = salaryOver;
        }
        public override IEnumerator<Employee> GetEnumerator()
        {
            foreach (Employee employee in wrappedObject)
            {
                if (employee.Salary > employeeSalaryOver)
                {
                    yield return employee;
                }
            }
        }
    }
}
