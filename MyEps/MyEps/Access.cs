using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEps
{
    internal class Access
    {
        public bool acc; // будет отвечать за доступ пользователю;
        public Storage stor;
        public Access(Storage stor)
        {
            acc = false;
            this.stor = stor;
            //stor = new Storage();
        }

        public bool Registration(User us) //true - прошло, false - не;
        {
            if (stor.Add(us))
            {
                stor.Save();
                return true;
            }
            return false;
        }
        public User LogIn(string log, string pass) //User - авторизовался, null - нет;
        {
            return stor.Find(log, pass);
        }
        //public void Exit() => acc = false; // выход из акка
    }
}
