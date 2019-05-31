using System;
using System.Collections.Generic;
using System.Linq;

namespace Manage_Employees_Project_KS
{
    namespace Finances
    {
        namespace Employees
        {
            class Employees
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
                    Messages.displayAllEmployeesFromList(allEmployees, "wszystkich");                      
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
                        bool searchSuccessful = false;
                        foreach (Employee employee in allEmployees)
                        {
                            if (employee.getName() == name && employee.getSurname() == surname)
                            {                              
                                Messages.searchEmployeeByNameAndSurnameMessage(employee.getName(), employee.getSurname(), true);
                                searchSuccessful = true;
                                return employee;
                            }                                                      
                        }
                        if (searchSuccessful == false)
                        {
                            Messages.searchEmployeeByNameAndSurnameMessage(name, surname, false);
                        }
                        return null;
                    }
                    
                }

                public void sortByNameAndSurname()
                {
                    var SelectedEmployees = allEmployees.OrderBy(Employee => Employee.getName());
                    Console.WriteLine(SelectedEmployees);
                    //Messages.displayAllEmployeesFromList(SelectedEmployees, "posortowanych");
                }
            }
        }

    }

}
    
    