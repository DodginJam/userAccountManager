namespace UserAccountManager
{
    abstract class Account : IAccounts
    {
        // Constructor.
        public Account(string FirstNamePara, string SecondNamePara, string PasswordPara)
        {
            this.FirstName = FirstNamePara.ToUpper();
            this.SecondName = SecondNamePara.ToUpper();
            this.Password = PasswordPara;
            this.UserName = UserNameGenerate(this.FirstName, this.SecondName);
            this.UserIDNumber = GenerateUserID();
        }
        // Fields.
        private string userIDNumber = "";
        private string firstName = "";
        private string secondName = "";
        private string password = "";

        // Properties.
        public string UserName
        { get; protected set; }

        public string UserIDNumber
        {
            get { return userIDNumber; }
            private set { userIDNumber = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value != null)
                {
                    firstName = ValidateNames(value, true);
                }
            }
        }

        public string SecondName
        {
            get { return secondName; }
            set
            {
                if (value != null)
                {
                    secondName = ValidateNames(value, false);
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value != null)
                {
                    password = ValidatePassword(value);
                }
            }
        }

        // Methods.

        public virtual void DisplayAccountInformation(bool displayPassword)
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

            Console.WriteLine();
        }

        // Used in the setter of Password Property to ensure it is valid. If it is not valid, then this method calls the GeneratePassword method.
        public string ValidatePassword(string userEntry)
        {
            // Check to see if password is long enough.
            bool correctLength;
            int minimumPasswordLength = 8;

            if (userEntry.Length >= minimumPasswordLength)
            {
                correctLength = true;
            }
            else
            {
                correctLength = true;
                Console.WriteLine("Password must be atleast 8 character in length.");
            }

            // Check to see if password contains atleast one alphabetical character.
            bool alphabeticalCharacter = false;
            char[] alphabeticalCharacters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            foreach (char item in alphabeticalCharacters)
            {
                if (userEntry.Contains(item))
                {
                    alphabeticalCharacter = true;
                    break;
                }
                else
                {
                    alphabeticalCharacter = false;
                }
            }
            if (alphabeticalCharacter == false)
            {
                Console.WriteLine("Password must contains atleast one Alphabetical Character.");
            }

            // Check to see if password contains atleast one special character.
            bool specialCharacter = false;
            char[] specialCharacters = "!\"£$%^&*()-=_+[]{};:'@#~,<.>/?\\|".ToCharArray();
            foreach (char item in specialCharacters)
            {
                if (userEntry.Contains(item))
                {
                    specialCharacter = true;
                    break;
                }
                else
                {
                    specialCharacter = false;
                }
            }
            if (specialCharacter == false)
            {
                Console.WriteLine("Password must contains atleast one Special Character.");
            }


            // Check to see if password contains atleast one numerical character.
            bool numericCharacter = false;
            for (int i = 0; i <= 10; i++)
            {
                if (userEntry.Contains(i.ToString()))
                {
                    numericCharacter = true;
                    break;
                }
                else
                {
                    numericCharacter = false;
                }
            }
            if (numericCharacter == false)
            {
                Console.WriteLine("Password must contains atleast one Numerical Character.");
            }

            if (correctLength && alphabeticalCharacter && specialCharacter && numericCharacter)
            {
                return userEntry;
            }
            else
            {
                return GenerateRandomPassword();
            }
        }

        // This method is called by the ValidatePassword method via the Password setter, only if the password being passed is not validated.
        public string GenerateRandomPassword()
        {
            char[][] characterArrays = new char[3][];
            characterArrays[0] = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            characterArrays[1] = "0123456789".ToCharArray();
            characterArrays[2] = "!\"£$%^&*()-=_+;:@#,./?".ToCharArray();

            Random random = new Random();
            int passwordLength = random.Next(8, 15);

            char[] generatedPassword = new char[passwordLength];

            for (int i = 0; i < generatedPassword.Length; i++)
            {
                // First 7/10 of password are characters that are either letters or numbers.
                double LettersNumberPercentageOfLength = 0.7;
                if (i < (generatedPassword.Length * LettersNumberPercentageOfLength))
                {
                    int arrayIndex = random.Next(0, 2);
                    int indexNumber = random.Next(0, characterArrays[arrayIndex].Length);
                    char letterToAdd = characterArrays[arrayIndex][indexNumber];
                    generatedPassword[i] = letterToAdd;
                }
                // Rest are special characters.
                else
                {
                    int indexNumber = random.Next(0, characterArrays[2].Length);
                    char letterToAdd = characterArrays[2][indexNumber];
                    generatedPassword[i] = letterToAdd;
                }
            }

            string newPassword = String.Join("", generatedPassword);

            Console.WriteLine("Random password generated.");
            // This ensures that the generated password complies by the validation standards - if not for this, there is a very small chance the generated password would not meet the validation standards yet it would get set as the password.
            return ValidatePassword(newPassword);
        }

        // This method ensures names are not blank or white space - returns default values if non-valid entry.
        public string ValidateNames(string nameToValidate, bool isFirstName)
        {
            string firstNameDefault = "JOHN";
            string secondNameDefault = "DOE";
            if (String.IsNullOrWhiteSpace(nameToValidate))
            {
                if (isFirstName == true)
                {
                    Console.WriteLine($"No entry for FirstName entered - Default value {firstNameDefault} provided.");
                    return firstNameDefault;
                }
                else
                {
                    Console.WriteLine($"No entry for SecondName entered - Default value {secondNameDefault} provided.");
                    return secondNameDefault;
                }
            }
            else
            {
                return nameToValidate;
            }
        }

        /* Generates a username based on First Name, Second Name and random number added to end. 
        If name provided is too short, additional random letters are inserted to ensure 3 letters for each respective name enter into username. */
        public string UserNameGenerate(string firstNamePara, string secondNamePara)
        {
            int minimumNameLength = 3;
            Random randomNum = new Random();
            string userId = randomNum.Next(1, 100000).ToString("D5");
            string alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
            string userName;

            // do... while loop ensures that, in small chance user generated name already exisits, it loops to generate again.
            do
            {
                while (firstNamePara.Length < minimumNameLength)
                {
                    for (int i = firstNamePara.Length; i < minimumNameLength; i++)
                    {
                        char randomLetter = alphabet[randomNum.Next(0, alphabet.Length)];
                        firstNamePara += randomLetter;
                    }
                }
                while (secondNamePara.Length < minimumNameLength)
                {
                    for (int i = secondNamePara.Length; i < minimumNameLength; i++)
                    {
                        char randomLetter = alphabet[randomNum.Next(0, alphabet.Length)];
                        secondNamePara += randomLetter;
                    }
                }
                // The type of class get's appended to the end of username to designate whether staff or student. This means the class name must reflect the role of account.
                userName = $"{firstNamePara.Substring(0, 3)}{secondNamePara.Substring(0, 3)}{userId}{this.GetType().Name.ToUpper()}";
            } while (UserNameList.Contains(userName));

            UserNameList.Add(userName);
            return userName;
        }

        // Statics.
        static Account()
        {
            UserNameList = new List<string> { };
        }

        protected static List<string> userNameList = new List<string> { };
        public static List<string> UserNameList
        { get; private set; }

        private static int userIDNumberCounter = 0;
        public static int UserIDNumberCounter
        {
            get { return userIDNumberCounter; }
            private set
            {
                userIDNumberCounter = value;
            }
        }
        private static string GenerateUserID()
        {
            int currentUserID = UserIDNumberCounter;
            UserIDNumberCounter++;

            string formattedNumber = $"{currentUserID.ToString("D8")}";
            return formattedNumber;
        }
    }
}
