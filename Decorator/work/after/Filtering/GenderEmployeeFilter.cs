using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering
{
    class GenderEmployeeFilter: EnumerableEmployeeDecorator
    {
        private Gender genderToMatch;
        public GenderEmployeeFilter( Gender genderToMatch ,
            IEnumerable<Employee> employees) : base(employees)
        {
            this.genderToMatch = genderToMatch;
        }

        public override IEnumerator<Employee> GetEnumerator()
        {
            foreach (Employee employee in wrappedObject)
            {
                if (employee.Gender == genderToMatch)
                {
                    yield return employee;
                }
            }
        }
    }
}
