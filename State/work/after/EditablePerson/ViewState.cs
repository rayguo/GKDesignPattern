using System;
using System.Collections.Generic;
using System.Text;

namespace EditablePerson
{
    public partial class Person
    {
        private class ViewState : PersonState
        {
            public ViewState(Person person) : base(person) { }

            public override int Age
            {
                get
                {
                    return innerPerson.age;
                }
            }

            public override string Name
            {
                get
                {
                    return innerPerson.name;
                }
            }

            public override void Edit()
            {
                innerPerson.SetState(innerPerson.editState);
            }
        }
    }
}
