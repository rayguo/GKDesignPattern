using System;
using System.Collections.Generic;
using System.Text;

namespace EditablePerson
{
    partial class Person
    {
        private PersonState currentState;
        private PersonState editState;
        private PersonState viewState;

        public Person()
        {
            editState = new EditState(this);
            viewState = new ViewState(this);

            SetState(viewState);
        }

        private string name;

        public string Name
        {
            get { return currentState.Name; }
            set { currentState.Name = value; }
        }

        private int age;

        public int Age
        {
            get { return currentState.Age; }
            set { currentState.Age = value; }
        }

        public override string ToString()
        {
            return String.Format("{0}, Aged {1} years", name, age);
        }

        public void Edit()
        {
            currentState.Edit();    
        }

        public void Commit()
        {
            currentState.Commit();
        }

        private void SetState(PersonState newState)
        {
            currentState = newState;
        }
    }
}
