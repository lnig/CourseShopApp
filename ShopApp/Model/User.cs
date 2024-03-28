using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class User
    {

        private static int nextId = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; protected set; }

        public User(string name, string surname, string email, string password) 
        {
            Id = nextId++;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }
    }
}
