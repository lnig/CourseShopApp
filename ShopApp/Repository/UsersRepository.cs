using ShopApp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

        public void UpdateUser(UserSession user)
        {
            using (var context = new DataContext())
            {
                if (user.UserType == "Client")
                {
                    var dbClient = context.client.Find(user.UserId);
                    if (dbClient != null)
                    {
                        dbClient.Name = user.Name;
                        dbClient.Surname = user.Surname;
                        dbClient.Email = user.Email;
                        dbClient.Password = user.Password;
                        context.SaveChanges();
                    }
                }
                else if (user.UserType == "Administrator")
                {
                    var dbAdmin = context.administrator.Find(user.UserId);
                    if (dbAdmin != null)
                    {
                        dbAdmin.Name = user.Name;
                        dbAdmin.Surname = user.Surname;
                        dbAdmin.Email = user.Email;
                        dbAdmin.Password = user.Password;
                        context.SaveChanges();
                    }
                }
            }
        }

        public bool EmailTaken(string Email)
        {
            bool emailfound = false;
            List<string> allEmails = new List<string>();
            using (var context = new DataContext())
            {
                allEmails.AddRange(context.client.Select(c => c.Email));
                allEmails.AddRange(context.administrator.Select(a => a.Email));

                emailfound= allEmails.Contains(Email);

            }
            return emailfound;
        }

        public void AddUser(Client client)
        {
            using (var context = new DataContext())
            {
                context.client.Add(client);
                context.SaveChanges();
            }
        }



    }

}
