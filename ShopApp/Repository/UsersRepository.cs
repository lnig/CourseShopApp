using ShopApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repository
{
    public class UsersRepository
    {
        public Client GetClientById(int id)
        {
            using (var context = new DataContext())
            {
                return context.client.FirstOrDefault(client => client.Id == id);
            }
        }

        public Client GetClientByEmail(string email)
        {
            using (var context = new DataContext())
            {
                return context.client.FirstOrDefault(client => client.Email == email);
            }
        }

        public Administrator GetAdministratorByEmail(string email)
        {
            using (var context = new DataContext())
            {
                return context.administrator.FirstOrDefault(admin => admin.Email == email);
            }
        }

        public bool UserExist(string email, string password)
        {
            using (var context = new DataContext())
            {
                return context.client.Any(client => client.Email == email && client.Password == password)
                       || context.administrator.Any(admin => admin.Email == email && admin.Password == password);
            }
        }

        public object GetUserDetails(string email)
        {
            using (var context = new DataContext())
            {
                var client = context.client.FirstOrDefault(c => c.Email == email);
                if (client != null)
                {
                    return client;
                }

                var admin = context.administrator.FirstOrDefault(a => a.Email == email);
                return admin;
            }
        }
    }

}
