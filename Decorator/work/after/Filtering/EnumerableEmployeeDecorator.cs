using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering
{
    public abstract class EnumerableEmployeeDecorator : IEnumerable<Employee>
    {
        protected IEnumerable<Employee> wrappedObject;

        public EnumerableEmployeeDecorator(IEnumerable<Employee> employees)
        {
            this.wrappedObject = employees;
        }
       
        public abstract IEnumerator<Employee> GetEnumerator();
       
        // Non generic version
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        } 
    }
}
