using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering
{
    class NullFilter : EnumerableEmployeeDecorator
    {

        public NullFilter(IEnumerable<Employee> employees) : base( employees)
        {

        }

        public override IEnumerator<Employee> GetEnumerator()
        {
            foreach (Employee employee in wrappedObject)
            {
                yield return employee;
            }
        }
    }
}
