using System;
using System.Collections.Generic;
using System.Text;

namespace EditablePerson
{
    public partial class Person
    {
        private abstract class PersonState
        {
            protected Person innerPerson;

            protected PersonState(Person person)
            {
                innerPerson = person;
            }

            public virtual string Name
            {
                get {throw new InvalidOperationException("Get Name not supported at this time");}
                set {throw new InvalidOperationException("Set Name not supported at this time");}
            }

            public virtual int Age
            {
                get { throw new InvalidOperationException("Get Age is not supported at this time"); }
                set { throw new InvalidOperationException("Set Age is not supported at this time"); }
            }

            public virtual void Edit()
            {
                throw new InvalidOperationException("Edit e is not supported at this time");
            }

            public virtual void Commit()
            {
                throw new InvalidOperationException("Commit is not supported at this time");
            }
        }
    }
}
