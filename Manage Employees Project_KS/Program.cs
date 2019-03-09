using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage_Employees_Project_KS;
using Finances;

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

            class displaySecurityMessage
            {
                private string login;
                private string password;

                public displaySecurityMessage()
                {                   
                    Console.WriteLine("Aby wyświetlić informacje o zarobkach lub dokonać zmian w wartościach wypłaty zaloguj się:\n Wprowadź login:");
                    login = Console.ReadLine();
                    Console.WriteLine("wporwadź hasło:");
                    password = Console.ReadLine();

                }

                public string getLogin()
                {
                    return login;
                }

                public string getPassword()
                {
                    return password;
                }
            }

            class Authorization
            {
                private string password;
                private string login;
                private static bool isLogged = false;
                public Authorization()
                {
                    if(isLogged != true)
                    {
                        displaySecurityMessage tryLogin = new displaySecurityMessage();
                        login = tryLogin.getLogin();
                        password = tryLogin.getPassword();
                    }                      
                    
                }

                public bool checkAuthorization()
                {
                    if (this.login == "admin" && this.password == "admin"|| isLogged == true)
                    {
                        isLogged = true;
                        return true;
                    }
                      
                    else
                    return false;
                }

                public void logout()
                {
                    isLogged = false;
                    Console.WriteLine("Nastąpiło wylogowanie");
                }
            }


            class Client : Person
            {
                private int phoneNumber { get; set; }

                public Client(string name, string surname, int phoneNumber) : base(name, surname)
                {
                    this.phoneNumber = phoneNumber;
                }
            }

            class Manager : Employee
            {
                public  string department{get; set;}
                public Manager(string name, string surname, string ocupation, string department) : base(name, surname, ocupation)
                {
                    this.department = department;
                }
            }

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
            }

            class Program
            {
                static void Main(string[] args)
                {
                    EmployeesList ListaPracownikow = new EmployeesList();
                    Employee czlowieczek = new Employee("Johny", "Okoń", "Tynkarz - akrobata");
                    Employee czlowieczek2 = new Employee("Jacek", "Kapeć", "Informatyk");
                    Employee czlowieczek3 = new Employee("Władysław", "Kleszcz", "Elektronik");
                    Employee czlowieczek4 = new Employee("Jadwiga", "Wolna", "Księgowa");

                    ListaPracownikow.addToList(czlowieczek);
                    ListaPracownikow.addToList(czlowieczek2);
                    ListaPracownikow.addToList(czlowieczek3);
                    ListaPracownikow.addToList(czlowieczek4);

                    ListaPracownikow.printList();
                    czlowieczek.contractType = Employee.ContractTypes.fullTime;
                    czlowieczek.salary = new Employee.Wage(3000, 250, 0);
                    czlowieczek.Operations.Add(new Operation("Wypłata 01/2019", "Płatność", czlowieczek.salary.getSumWages()));
                    
                    czlowieczek.DisplayEmployeeInfo();       
                    czlowieczek.setName("Wacław");             
                    czlowieczek.FullListOperations();
                    czlowieczek.setHolidayBonus(2000);
                    czlowieczek.getSalary();
                    czlowieczek.setSalary(5000, 250, 200);
                    czlowieczek.getSalary();
                    
                    Console.WriteLine("Nowa wartość premi świątecznej to " + czlowieczek.getHolidayBonus());
                    Company firma = new Company("Firemka");
                    firma.dispalyComapnyName();

                    Console.ReadLine();


                }
            }
        }

    }

}
    
    