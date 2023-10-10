using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEps
{
    public class Storage
    {
        FileStorage file;

        public Storage()
        {
            file = new FileStorage();
        }

        public User Find(string login, string password) //Поиск в хранилище;
        {
            return file.FindFile(login, password); //User or null;
        }

        public bool Add(User user) { return file.AddFile(user); } //true/false;
        public bool Change(User user) { return file.ChangeFile(user); } //true/false;
        public void Save() { file.SaveFile(); } //void;

    }
}
