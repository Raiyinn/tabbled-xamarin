using Firebase.Database;
using Firebase.Database.Query;
using Projekat_133_100.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_133_100.ViewModel
{
    public class FirebaseHelper
    {
        public static FirebaseClient firebaseClient = new FirebaseClient("https://xamarindatabaseproject-6453f-default-rtdb.europe-west1.firebasedatabase.app/");

        internal static Task GetUser(object text)
        {
            throw new NotImplementedException();
        }


        //Read All    
        public static async Task<List<User>> GetAllUser()
        {
            try
            {
                var userlist = (await firebaseClient
                .Child("Users")
                .OnceAsync<User>()).Select(item =>
                new User
                {
                    Username = item.Object.Username,
                    Password = item.Object.Password
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Get User by Username
        public static async Task<User> GetUser(string username)
        {
            try
            {
                var allUsers = await GetAllUser();
                await firebaseClient
                .Child("Users")
                .OnceAsync<User>();
                return allUsers.Where(a => a.Username == username).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Add User
        public static async Task<bool> AddUser(string username, string email, string password, string confirm_password)
        {
            try
            {
                await firebaseClient
                .Child("Users")
                .PostAsync(new User() { Username = username, Email = email, Password = password, ConfirmPassword = confirm_password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
    }
}

