﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Employees_Project_KS
{
    namespace Finances
    {
        namespace Employees
        {
            class Messages
            {
                public static void displayAllEmployeesFromList(List<Employee> listEmployees, string type)
                {
                    if (listEmployees != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Lista " + type + " pracowników: ");
                        foreach (Employee employee in listEmployees)
                        {                            
                            Console.WriteLine("Imię i nazwisko pracownika: " + employee.GetFullName());
                        }
                        Console.WriteLine();
                    }
                }

                public static void autorizationMessage(bool isLogged)
                {
                    if (isLogged)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Logowanie poprawne!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Błędne logowanie");
                        Console.WriteLine();
                    }
                    
                }

                public static void displayDetailsAboutWages(Employee employee)
                {
                    Console.WriteLine("Pensja podstawowa wynosi: {0}, aktualne premie: {1}, inne dodatki do pensji: {2}\nSuma zarobków wynosi: {3}", employee.salary.basic, employee.salary.bonus, employee.salary.other, employee.salary.getSumWages());
                }                   

                public static void printOperationInfo(Operation operation)
                {
                    Console.WriteLine();
                    Console.WriteLine("Transakcja o tytule: {0}\n typ transakcji: {1}\n kwota transakcji: {2}\n\n", operation.title, operation.type, operation.amount);
                }


                public static void searchEmployeeByNameAndSurnameMessage(string name, string surname, bool resultSearch)
                {
                    if (resultSearch)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Znaleziono pracownika:\n Imię: {0}\n Nazwisko: {1}", name, surname);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Nie znaleziono takiego pracownika:" + name + " " + surname);
                    }                    
                }

                // delegaty - func
                public static string messageAfterNameOrSurnameChanged(string oldData, string newData, string typeData)
                {
                    Console.WriteLine();
                    string textMessage = typeData + " zostało zmienione:\n stare " + typeData + ": " + oldData + ",\n nowe " + typeData + ": " + newData;
                    Console.WriteLine(textMessage);
                    return textMessage;
                }

                //eventy
                public static void messageAfterWageChanged(object source, Employee.WageEventArgs args)
                {
                    Console.WriteLine();
                    string textMessage = " Pensja została zmieniona:\n stara pensja: " + args.oldWage + ",\n nowa pesja " + args.newWage;
                    Console.WriteLine(textMessage);

                }

                public static void messageAfterContractTypeChanged(object source, Employee.ContractEventArgs args)
                {
                    Console.WriteLine();
                    string textMessage = " Forma zatrudnienia została zmieniona:\n stara forma zatrudnienia: " + args.oldContract + ",\n nowa forma zatrudnienia " + args.newContract;
                    Console.WriteLine(textMessage);

                }

                public static void displayAllEmployeesWithWage(List<Employee> listEmployees)
                {
                    if (listEmployees != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Lista pracowników: ");
                        foreach (Employee employee in listEmployees)
                        {
                            Console.WriteLine("Imię i nazwisko pracownika: " + employee.GetFullName()+" pensja: "+employee.getSalary());
                        }
                        Console.WriteLine();
                    }
                }


            }
        }
    }
}
