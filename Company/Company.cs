using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances
{
    public class Company
    {
        string name { get; set; }
        public Company(string name)
        {
            this.name = name;
        }

        public void dispalyComapnyName()
        {
            Console.WriteLine("Nazwa firmy to: " + name);
        }
    }
}
