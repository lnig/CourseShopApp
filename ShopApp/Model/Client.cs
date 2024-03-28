using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class Client : User
    {
        public Client(string name, string surname, string email, string password)
        : base(name, surname, email, password)
        {
            UserType = "Client";
        }
    }



}
