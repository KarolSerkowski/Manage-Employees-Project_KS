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

                public Employee createEmployeeAndAddToList(string fullName, string position, decimal baseWage)
                {
                    Employee employee = Employee.createNewEmployee(fullName, position, baseWage);
                    allEmployees.Add(employee);
                    return employee;
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

                public void addEmployee(Employee employee)
                {
                    if (!allEmployees.Contains(employee))
                    {
                        allEmployees.Add(employee);
                    }
                }

                public void removeEmployee(Employee employee)
                {
                    if (allEmployees.Contains(employee))
                    {
                        allEmployees.Remove(employee);
                    }
                }

                public Employee getEmployee(string name, string surname)
                {
                   return this[name, surname];
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
    
    