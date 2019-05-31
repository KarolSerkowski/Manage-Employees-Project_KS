using System;

namespace Manage_Employees_Project_KS
{
    namespace Finances
    {
        namespace Employees
        {
            class Authorization
            {
                private string password;
                private string login;
                private static bool isLogged = false;
                public static int loginAttemptNumber { get; } = 0;
              

                public void displayFieldsToLogin()
                {
                    if (isLogged != true)
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
    
    