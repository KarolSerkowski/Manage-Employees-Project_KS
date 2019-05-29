using System;

namespace Manage_Employees_Project_KS
{
    namespace Finances
    {
        namespace Employees
        {
            abstract class Person
            {
                private string name;
                private string surname;
                protected string interest;

                public Person(String name, String surname)
                {
                    this.name = name;
                    this.surname = surname;
                }
                public void setName(string name)
                {
                    this.name = name;
                }

                public void setSurname(string surname)
                {
                    this.surname = surname;
                }

                public string GetFullName()
                {
                    return name + " " + surname;
                }

                public string getName()
                {
                    return this.name;
                }

                public string getSurname()
                {
                    return this.surname;
                }

                public abstract string interests(string interest);

            }
        }

    }

}
    
    