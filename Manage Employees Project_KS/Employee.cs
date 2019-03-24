using System;
using System.Collections.Generic;

namespace Manage_Employees_Project_KS
{
    namespace Finances
    {
        namespace Employees
        {
            class Employee : Person
            {
                public string Ocupation { get; set; }
                public Wage salary;

                public Employee(string name, string surname, string position) : base(name, surname)
                {
                    this.Ocupation = position;

                }

                public decimal getSalary()
                {                  
                    Authorization authorization = new Authorization();

                    if (authorization.checkAuthorization() == true)
                    {
                        Console.WriteLine("Logowanie poprawne.\n###############################################################################\n");
                        Console.WriteLine("Pensja podstawowa wynosi: {0}, aktualne premie: {1}, inne dodatki do pensji: {2}\nSuma zarobków wynosi: {3}", salary.basic, salary.bonus, salary.other, salary.getSumWages());
                        return salary.getSumWages();
                    }
                    else
                    {
                        Console.WriteLine("Błędne logowanie");
                        return 0;
                    }                    
                }

                public void setSalary(decimal basic, decimal bonus, decimal other)
                {                    
                    Authorization authorization = new Authorization();

                    if (authorization.checkAuthorization()== true)
                    {
                        Console.WriteLine("Logowanie poprawne.\n###############################################################################\n");
                        salary.basic = basic;
                        salary.bonus = bonus;
                        salary.other = other;

                        Console.WriteLine("Wprowadzono wartości:\nPensja podstawowa: {0}\nPremie: {1}\nInne: {2}", salary.basic, salary.bonus, salary.other);
                    }
                    else
                    {
                        Console.WriteLine("Błędne logowanie");                        
                    }
                }
                


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

                    public Wage(decimal basic = 0, decimal bonus =0, decimal other = 0)
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
        }

    }

}
    
    