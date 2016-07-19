using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering
{
    public enum Gender { Male, Female };

    public class Employee
    {
        public Employee(Gender gender , string name , int age , double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Gender = gender;
        }

        private Gender gender;

        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        private double salary;

        public double Salary
        {
            get { return salary; }
            private set { salary = value; }
        }

        public override string ToString()
        {
            return String.Format("{0},{1} Earning {2}", name, age, salary);
        }

    }
}
