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
        }

    }

}
    
    