namespace UserAccountManager
{
    class Staff : Account
    {
        // Constructor
        public Staff(string FirstNamePara, string SecondNamePara, string PasswordPara, string jobRolePara) : base(FirstNamePara, SecondNamePara, PasswordPara)
        {
            this.JobRole = jobRolePara;
        }

        // Auto-Properties.
        public string JobRole
        { get; set; }

        // Methods.
        public override void DisplayAccountInformation(bool displayPassword)
        {

            Console.WriteLine($"Username:\t\t{this.UserName}");
            Console.WriteLine($"First Name:\t\t{this.FirstName}");
            Console.WriteLine($"Second Name:\t\t{this.SecondName}");
            Console.WriteLine($"UserID Number:\t\t{this.UserIDNumber}");
            if (displayPassword)
            {
                Console.WriteLine($"Password:\t\t{this.Password}");
            }
            else
            {
                Console.WriteLine($"Password:\t\tXXXXXXXXXX");
            }
            Console.WriteLine($"Job Role:\t\t{this.JobRole}");
            Console.WriteLine();
        }
    }
}