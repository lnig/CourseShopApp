using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class UserSession
    {

        private static UserSession _instance;
        private static readonly object _lock = new object();

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string UserType { get; private set; }


        private UserSession() { }

        public static UserSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserSession();
                        }
                    }
                }
                return _instance;
            }
        }

        public void SetClient(Client client)
        {
            Name = client.Name;
            Surname = client.Surname;
            Email = client.Email;
            Password = client.Password;
            UserType = "Client";
        }

        public void SetAdministrator(Administrator administrator)
        {
            Name = administrator.Name;
            Surname = administrator.Surname;
            Email = administrator.Email;
            Password = administrator.Password;
            UserType = "Administrator";
        }

    }

}
