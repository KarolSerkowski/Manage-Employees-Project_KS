using System;

namespace Manage_Employees_Project_KS
{
    namespace Finances
    {
        namespace Employees
        {
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
        }

    }

}
    
    