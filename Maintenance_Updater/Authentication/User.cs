namespace Maintenance_Updater.Authentication
{
    public class User
    {
        public string Username;
        public string Password;
        public Domain PublixDomain;

        public User(string username, string password, Domain domain)
        {
            Username = username;
            Password = password;
            PublixDomain = domain;
        }

        public User(User user)
        {
            Username = user.Username;
            Password = user.Password;
            PublixDomain = user.PublixDomain;
        }
    }
}
