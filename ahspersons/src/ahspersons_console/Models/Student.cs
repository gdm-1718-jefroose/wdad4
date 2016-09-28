using System;

namespace Models
{
   public class Student : Person
   {
       protected string _studentNumber;
       public Student(int id, string firstName, string surName, string studentNumber) : base (id, firstName, surName)
       {
           this._studentNumber = studentNumber;
       }

       public override string ToString()
       {
           return String.Format("Student: {0} {1} {2}",
           this._firstName, this._surName, this._studentNumber);
       }
   }
}