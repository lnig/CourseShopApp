using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model
{
    public class Administrator : User
    {

        public Administrator(string name, string surname, string email, string password)
        : base(name, surname, email, password)
        {
            UserType = "Administrator";
        }

    }
}
