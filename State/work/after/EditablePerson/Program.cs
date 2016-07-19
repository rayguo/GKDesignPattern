using System;
using System.Collections.Generic;
using System.Text;

namespace EditablePerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Person dilbert = new Person();

            dilbert.Edit();

            dilbert.Name = "Dilbert";
            dilbert.Age = 21;

            dilbert.Commit();

            Console.WriteLine(dilbert);
        }
    }
}
