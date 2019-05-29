using System;
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
            class Client : Person
            {
                private int phoneNumber { get; set; }

                public Client(string name, string surname, int phoneNumber) : base(name, surname)
                {
                    this.phoneNumber = phoneNumber;
                }

                public override string interests(string interest)
                {
                    return base.interest = interest;
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

                    //indeksatory
                    Employee searchEmployee = ListaPracownikow["Johny","Okoń"];

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

                    //factory method
                    Employee nowyPracownik = Employee.createNewEmployee("Edek Paskudny", "Kierownik", 3000);
                    ListaPracownikow.addToList(nowyPracownik);
                    nowyPracownik.DisplayEmployeeInfo();
                    ListaPracownikow.createEmployeeAndAddToList("Franek Piątkiewicz", "Product Owner", 8000);
                    ListaPracownikow.printList();

                    //Zad 7 operatory
                    czlowieczek.setSalary(2000, 1000, 200);
                    czlowieczek2.setSalary(300, 1000, 200);
                    Console.WriteLine("Człowieczek 1 pensja: {0}, człowieczek 2 pensja: {1}", czlowieczek.getSalary(), czlowieczek2.getSalary());
                    Console.WriteLine("Pierwszy większa pensja od drugiego {0}",  czlowieczek < czlowieczek2);
                    Console.WriteLine(czlowieczek > czlowieczek2);
                    Console.WriteLine(czlowieczek < czlowieczek2);
                    Console.WriteLine(czlowieczek == czlowieczek2);
                    Console.WriteLine(Convert.ToDouble(czlowieczek));
                    Console.WriteLine(czlowieczek+500);

                    Console.ReadLine();


                }
            }
        }

    }

}
    
    