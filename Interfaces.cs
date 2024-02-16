namespace UserAccountManager
{
    public interface IAccounts
    {
        string UserName
        {get;}

        string UserIDNumber
        {get;}

        string FirstName
        {get;}

        string SecondName
        {get;}

        string Password
        {get;}

        string UserNameGenerate(string firstNamePara, string secondNamePara);

        string ValidateNames(string nameToValidate, bool isFirstName);

        string ValidatePassword(string userPassword);

        string GenerateRandomPassword();

    }

}
