namespace UserAccountManager
{
    class Student : Account
    {
        // Constructor
        public Student(string FirstNamePara, string SecondNamePara, string PasswordPara, string[] coursesEnrolledPara) : base(FirstNamePara, SecondNamePara, PasswordPara)
        {
            this.CoursesEnrolled = coursesEnrolledPara;
        }

        // Auto-Properties.
        public string[] CoursesEnrolled
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
            Console.Write($"Courses Enrolled:\t");
            for (int i = 0; i < CoursesEnrolled.Length; i++)
            {
                if (i < CoursesEnrolled.Length - 1)
                {
                    Console.Write($"{CoursesEnrolled[i]}, ");
                }
                else
                { 
                    Console.WriteLine($"{CoursesEnrolled[i]}.");
                }
            }

            Console.WriteLine();
        }
    }
}
