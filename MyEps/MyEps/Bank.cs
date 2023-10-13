using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyEps
{
    internal class Bank //Логика, работа с суммами;
    {
        User user;
        public decimal balance { get; private set; } //Баланс пользователя;

        public Bank(User us)
        {
            user = us;
            balance = 0;
            for (int i = 0; i < user.history.Count; i++) balance += Convert.ToDecimal(user.history[i]);
        }

        public bool AddSumm(decimal summ) //Добавление в историю;
        {
            if (balance - summ < 0) return false;
            else
            {
                balance -= summ;
                user.history.Add(Convert.ToString(summ));
                return true;
            }
        }

        public bool ChangeMonth() //Смена месяца;
        {
            DateTime dt = DateTime.Now;
            string[] date = dt.ToString().Split(' ');
            int mont = Convert.ToInt32(date[1]) - 1;

            decimal up = 0;
            decimal down = 0;

            for (int i = 0; i < user.history.Count(); i++)
            {
                if (Convert.ToInt32(user.history[i]) < 0) down += Convert.ToInt32(user.history[i]);
                else up += Convert.ToInt32(user.history[i]);
            }
            //Как хранится история по месяцам; (month: 10000; -900)
            user.monhist.Add(Convert.ToString(mont) + ": " + Convert.ToString(up) + "; " + Convert.ToString(down));
            user.history = new List<string>();
            user.history.Add(Convert.ToString(up - down)); //Добавляем остаток с прошлого месяца;
            return true;
        }

        public List<string> GetHistory() //История;
        {
            return user.history;
        }

        public List<string> GetMonHistory() //История по месяцам;
        {
            return user.monhist;
        }

        public void UpBalance(decimal sum) // Обновление баланса
        {
            if (sum < 0)
            {
                if (balance-sum < 0)
                {
                    
                }
            }
            else
            {
                balance += sum;
            }
        }
    }
}
