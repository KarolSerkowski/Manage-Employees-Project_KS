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
            class Person
            {
                private string name { get; set; }
                private string surname { get; set; }

                public Person(String name, String surname)
                {
                    this.name = name;
                    this.surname = surname;
                }
                public void setName(string name)
                {
                    this.name = name;
                }

                public void setSurname(string Surname)
                {
                    this.surname = surname;
                }

                public string GetFullName()
                {
                    return name + " " + surname;
                }

            }

            class Employee : Person
            {
                public string Ocupation { get; set; }
                public Wage salary { get; set; }
                public static decimal HolidayBonus { get; set; } = 1000;
                public ContractTypes contractType { get; set; }

                public void setHolidayBonus(decimal newBonus)
                {
                    HolidayBonus = newBonus;
                }

                public decimal getHolidayBonus()
                {
                    return HolidayBonus;
                }

                public Employee(string name, string surname, string position) : base(name, surname)
                {
                    this.Ocupation = position;

                }

                public void DisplayEmployeeInfo()
                {
                    Console.WriteLine("Dane prawcownika \n Imię i nazwisko:{0}\n Zatrudniony na umowę: {1}\n Wynagrodzenie: {2}", this.GetFullName(), this.getContractName(contractType), this.salary.getSumWages());
                }

                public List<Operation> Operations = new List<Operation>();

                public void FullListOperations()
                {
                    Console.WriteLine("Lista operacji dla {0}", this.GetFullName());
                    foreach (Operation operation in Operations)
                    {
                        printOperationInfo(operation);
                    }
                }

                public void printOperationInfo(Operation operation)
                {
                    Console.WriteLine("Transakcja o tytule: {0}\n typ transakcji: {1}\n kwota transakcji: {2}\n\n", operation.title, operation.type, operation.amount);
                }

                public enum ContractTypes
                {
                    fullTime,
                    partTime,
                    contract
                }

                public string getContractName(ContractTypes contract)
                {
                    switch (contract)
                    {
                        case ContractTypes.contract:
                            return "Kontrakt";
                        case ContractTypes.fullTime:
                            return "Pełen etat";
                        case ContractTypes.partTime:
                            return "Niepełny etat";
                        default:
                            return "Błędnie wprowadzona informacja o zatrudnieniu";

                    }
                }

                public struct Wage
                {
                    public decimal basic { get; set; }
                    public decimal bonus { get; set; }
                    public decimal other { get; set; }

                    public Wage(decimal basic, decimal bonus, decimal other = 0)
                    {
                        this.basic = basic;
                        this.bonus = bonus;
                        this.other = other;
                    }

                    public decimal getSumWages()
                    {
                        return basic + bonus + other;
                    }
                }
            }

            class Operation
            {
                public string title { get; set; }
                public string type { get; set; }
                public decimal amount { get; set; }

                public Operation (string title, string type, decimal amount)
                {
                    this.title = title;
                    this.type = type;
                    this.amount = amount;
                }
            }

            class Program
            {
                static void Main(string[] args)
                {
                    Employee czlowieczek = new Employee("Johny", "Okoń", "Tynkarz - akrobata");
                    czlowieczek.contractType = Employee.ContractTypes.fullTime;
                    czlowieczek.salary = new Employee.Wage(3000, 250, 0);
                    czlowieczek.Operations.Add(new Operation("Wypłata 01/2019", "Płatność", czlowieczek.salary.getSumWages()));
                    
                    czlowieczek.DisplayEmployeeInfo();       
                    czlowieczek.setName("Wacław");             
                    czlowieczek.FullListOperations();
                    czlowieczek.setHolidayBonus(2000);
                    Console.WriteLine("Nowa wartość premi świątecznej to " + czlowieczek.getHolidayBonus());                  

                    Console.ReadLine();


                }
            }
        }

    }

}
    
    