using System;
using System.Collections.Generic;

namespace Manage_Employees_Project_KS
{
    namespace Finances
    {
        namespace Employees
        {
            class EmployeesList
            {
                public List<Employee> allEmployees = new List<Employee>();
                
                public void addToList(Employee newEmployee)
                {
                    allEmployees.Add(newEmployee);
                   
                }

                public void printList()
                {
                    Console.WriteLine("Pełna lista pracowników:\n################################################\n");
                    foreach (Employee employee in allEmployees)
                    {                        
                        Console.WriteLine("Imię i nazwisko pracownika: " + employee.GetFullName() );
                    }
                    Console.WriteLine(" ");
                }

                public Employee this[string name, string surname]
                {
                    get
                    {                        
                        foreach (Employee employee in allEmployees)
                        {
                            if (employee.getName() == name && employee.getSurname() == surname)
                            {
                                Console.WriteLine("Znaleziono pracownika:\n Imię: {0}\n Nazwisko: {1}", employee.getName(), employee.getSurname());
                                return employee;
                            }
                            else
                            {
                                Console.WriteLine("Nie znaleziono takiego pracownika:" + name + " " + surname);
                                
                            }                            
                        }
                        return null;
                    }
                    
                }
            }
        }

    }

}
    
    