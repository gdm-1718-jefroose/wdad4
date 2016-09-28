using System;

namespace Models
{
   public class Person
   {
       protected int _id;
       protected string _firstName;
       protected string _surName;

       public Person(int id, string firstName, string surName)
       {
           this._id = id;
           this._firstName = firstName;
           this._surName = surName;
       }

       public string FullName
       {
           get
           {
               return this._firstName + " " + this._surName;
           }
       }

       public virtual string ToString()
       {
           return String.Format("Person: {0} {1}", this._firstName, this._surName);
       }
   }
}