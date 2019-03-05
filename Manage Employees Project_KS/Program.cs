using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Employees_Project_KS 
{
    
    class Person
    {
        private string name;
        private string surname { get; set; }
        
    }

    class Employee : Person
    {
        public string Position { get; set; }
        public static decimal HolidayBonus { get; set; } = 1000;

        enum Wage
        {
            basic,
            bonus,
            other
        }

    }

    class Operation
    {

    }

    class Program
    {
        static void Main(string[] args)
        {


        }
    }
}
