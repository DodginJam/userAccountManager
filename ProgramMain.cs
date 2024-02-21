using UserAccountManager;

    class Program
    {
        static void Main(string[] args)
        {
            Account JamesDoran = new Student("James", "Doran", "ThisIsMyPassword1!", new string[] { "History", "Government & Politics", "Law", "English Literature"});
            Account RuonanLiao = new Staff("Ruonan", "Liao", "123HeyThere!?", "Teacher");
            Account RuonanLiao2 = new Staff("Ruonan", "Liao", "Pa$$w0r", "Cleaner");

            Account[] AccountList = new Account[] {JamesDoran, RuonanLiao, RuonanLiao2};

            foreach (Account element in AccountList)
            {
                element.DisplayAccountInformation(displayPassword: true);
            }
        }
    }

