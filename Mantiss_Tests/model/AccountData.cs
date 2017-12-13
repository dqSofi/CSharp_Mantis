namespace Mantiss_Tests
{
    public class AccountData
    {
        public string ID { get; internal set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        

        public AccountData(string name,string pass)
        {
            Name = name;
            Password = pass;
        }

    }
}