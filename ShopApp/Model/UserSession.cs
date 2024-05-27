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

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }


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
            UserId = client.Id;
            Name = client.Name;
            Surname = client.Surname;
            Email = client.Email;
            Password = client.Password;
            UserType = "Client";
        }

        public void SetAdministrator(Administrator administrator)
        {
            UserId = administrator.Id;
            Name = administrator.Name;
            Surname = administrator.Surname;
            Email = administrator.Email;
            Password = administrator.Password;
            UserType = "Administrator";
        }

    }

}
