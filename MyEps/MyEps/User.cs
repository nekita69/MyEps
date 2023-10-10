using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEps
{
    public class User //Класс пользователя;
    {
        public string login = "";
        public string password = "";
        public List<string> history; //История за месяц;
        public List<string> monhist { get; set; } //История за год;

        public User()
        {
            history = new List<string>();
            monhist = new List<string>();
        } //Конструктор по умолчанию, нужен для десерилизации;

        public User(string log, string psss)
        {
            login = log;
            password = psss;

            history = new List<string>();
            monhist = new List<string>();
        }
    }


    internal class UsersApp //Класс для серилизации всех пользователей приложения;
    {
        public List<User> users = new List<User>();
        public UsersApp() { }

        public User FindUser(string log, string pass) //Поиск пользователя;
        {
            for (int i = 0; i < users.Count; i++)
                if (users[i].login.ToLower() == log.ToLower() && users[i].password == pass)
                    return users[i];
            return null;
        }
    }
}
