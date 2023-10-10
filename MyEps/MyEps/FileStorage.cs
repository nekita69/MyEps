using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MyEps
{
    internal class FileStorage
    {
        public UsersApp usersApp; //Все пользователи приложения;

        public FileStorage() //При инициализации считываем всех пользователей файла;
        {
            if (!File.Exists("users.json")) //Файл не существует;
            {
                string js = "";
                File.WriteAllText("users.json", js); //Создаем пустой файл;
                usersApp = new UsersApp();
                return;
            }
            //Файл существует;
            string jsread = File.ReadAllText("users.json");
            if (jsread == "")
            {
                usersApp = new UsersApp();
                return;
            }
            usersApp = JsonConvert.DeserializeObject<UsersApp>(jsread);
        }

        public User FindFile(string log, string pass) //Поиск пользователя;
        {
            //Если нашел - Объект пользователя, не нашел - null;
            return usersApp.FindUser(log, pass);
        }

        public bool AddFile(User user) //Добавление пользователя;
        {
            //Не добавит с равными logins;
            for (int i = 0; i < usersApp.users.Count; i++)
                if (usersApp.users[i].login.ToUpper() == user.login.ToUpper())
                    return false;
            usersApp.users.Add(user);
            return true;
        }

        public bool ChangeFile(User user) //Изменение объекта в хранилище;
        {
            for (int i = 0; i < usersApp.users.Count; i++)
                if (usersApp.users[i].login.ToUpper() == user.login.ToUpper())
                {
                    usersApp.users[i] = user;
                    return true;
                }
            return false;
        }

        public void SaveFile() //Сохранение файла;
        {
            string js = JsonConvert.SerializeObject(usersApp);
            File.WriteAllText("users.json", js);
        }
    }
}
