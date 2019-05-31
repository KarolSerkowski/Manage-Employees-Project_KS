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
                    wageChanged += Messages.messageAfterWageChanged;
                    contractTypeChanged += Messages.messageAfterContractTypeChanged;

                }

                virtual public void setName(string name )
                {
                    string oldName = this.name;                    
                    this.name = name;
                    if (oldName != name)
                    {
                        nameOrSurnameHasBeenChanged(oldName, name, "imię");
                    }                    
                }

                virtual public void setSurname(string surname)
                {
                    string oldSurname = this.surname;
                    this.surname = surname;

                    if (oldSurname != surname)
                    {
                        nameOrSurnameHasBeenChanged(oldSurname, surname, "nazwisko");
                    }                    
                }

                public static Employee createNewEmployee(string fullName, string position, decimal baseWage)
                {
                    string[] name = fullName.Split(new string[] { " " }, StringSplitOptions.None);                    

                    Employee newEmployee = new Employee(name[0], name[1], position);
                    newEmployee.salary = new Employee.Wage(baseWage, 0, 0); ;
                    return newEmployee;

                }

                public decimal getSalary()
                {
                    Authorization authorization = new Authorization();                    

                    if (authorization.checkAuthorization() == true)
                    {                        
                        return salary.getSumWages();
                    }
                    else
                    {
                        authorization.displayFieldsToLogin();
                        return 0;
                    }                    
                }

                public void detailsAboutWages()
                {
                    Messages.displayDetailsAboutWages(this);
                }

                public void setSalary(decimal basic, decimal bonus, decimal other)
                {
                    Authorization authorization = new Authorization();                    

                    if (authorization.checkAuthorization()== true)
                    {                        
                        decimal oldBasicWage = salary.basic;
                        salary.basic = basic;
                        
                        OnWageChanged(oldBasicWage, basic);

                        salary.bonus = bonus;
                        salary.other = other;

                        Console.WriteLine("Wprowadzono wartości:\nPensja podstawowa: {0}\nPremie: {1}\nInne: {2}", salary.basic, salary.bonus, salary.other);
                    }
                    else
                    {
                        authorization.displayFieldsToLogin();
                    }
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
                private ContractTypes contractType;                
                public ContractTypes ContractType
                {
                    get
                    { 
                        return contractType;
                    }
                    set
                    {
                        ContractTypes oldContractType = contractType;
                        contractType = value;
                        if (oldContractType != contractType)
                        {
                            OnContractChanged(oldContractType, contractType);
                        }
                        
                    }
                }

                public static decimal HolidayBonus { get; set; } = 1000;

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
                        Messages.printOperationInfo(operation);
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

                public override string interests(string interest)
                {
                    return base.interest = interest;
                }

                public static bool operator ==(Employee employee1, Employee employee2)
                {
                    if (employee1.getName() != employee2.getName())
                    {                        
                        return false;
                    };

                    if (employee1.getSurname() != employee2.getSurname())
                    {                    
                        return false;
                    };
                    return true;
                    
                }

                public static bool operator !=(Employee employee1, Employee employee2)
                {
                    if (employee1.getName() == employee2.getName())
                    {
                        return false;
                    };

                    if (employee1.getSurname() == employee2.getSurname())
                    {
                        return false;
                    };
                    return true;

                }

                public static bool operator <(Employee employee1, Employee employee2)
                {
                    if (employee1.getSalary() > employee2.getSalary())
                    {
                        return false;
                    };

                    if (employee1.getSalary() == employee2.getSalary())
                    {
                        return false;
                    };

                    return true;

                }

                public static bool operator >(Employee employee1, Employee employee2)
                {
                    if (employee1.getSalary() < employee2.getSalary())
                    {
                        return false;
                    };

                    if (employee1.getSalary() == employee2.getSalary())
                    {
                        return false;
                    };

                    return true;

                }

                public static implicit operator double(Employee employee)
                {
                    return Convert.ToDouble(employee.salary.getSumWages());
                }

                public static double operator +(Employee employee, double liczba)
                {
                    double sum = Convert.ToDouble(employee.salary.getSumWages());

                    return sum + liczba;

                }


                //Operatory których nie wolno przeciążać:

                //logiczne warunkowe: &&, ||,
                //konwersji: () - służą do tego słowa kluczowe explicit i implicit,
                //indeksacji: [] - stosujemy w tym celu indeksatory,
                //przypisań: +=, -=, *=, %=, <<=, >>=, |=, ^=, &=, /=,
                //pozostałe: =, ., new, is, sizeof, typeof, ?:.



                // delegaty - func
                Func<string, string, string, string> nameOrSurnameHasBeenChanged = Messages.messageAfterNameOrSurnameChanged;


                // zdarzenia
               
                public class WageEventArgs: EventArgs
                {
                    public decimal oldWage { get; set; }
                    public decimal newWage { get; set; }
                }

                public event EventHandler<WageEventArgs> wageChanged;

                public async void OnWageChanged(decimal oldWage, decimal newWage)
                {
                    if (wageChanged != null)
                    wageChanged(this, new WageEventArgs() { oldWage = oldWage, newWage = newWage });
                }

                public class ContractEventArgs : EventArgs
                {
                    public ContractTypes oldContract { get; set; }
                    public ContractTypes newContract { get; set; }
                }
                public event EventHandler<ContractEventArgs> contractTypeChanged;

                public async void OnContractChanged(ContractTypes oldContract, ContractTypes newContract)
                {
                    if (contractTypeChanged != null)
                        contractTypeChanged(this, new ContractEventArgs() { oldContract = oldContract, newContract = newContract });
                }
  
            }
        }

    }

}
    
    