namespace Manage_Employees_Project_KS
{
    namespace Finances
    {
        namespace Employees
        {
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
        }

    }

}
    
    