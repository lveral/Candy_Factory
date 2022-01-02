using System;
using System.Collections.Generic;
using System.Text;

namespace Candy_Factory
{
    class Box
    {
        protected string type;
        protected Candy candy;
        protected int count;
        protected int cost { get; set; }

        public delegate void BoxCreated(string mes);
        public event BoxCreated Created;

        public Box(Candy _candy, int _count)
        {
            candy = _candy;
            count = _count;
            cost = candy.cost * count;
            type = "Стандартная";
        }
        public void LogEntry()
        {
            Created?.Invoke("Конфеты упакованы в коробку.Информация о коробке:" + "Кoличество:" + count + " Стоимость: " + cost);
        }
        

        public string GetInfoToString()
        {
            return candy.GetFlavor() + "\n" + candy.GetGlaze() + "\n" + candy.GetWrapper() + "\nКoличество:" + count +"\nСтоимость: " +  cost;
        }

        public List<string> GetInfoToList()
        {
            List<string> info = new List<string>();
            info.Add(candy.GetFlavor());
            info.Add(candy.GetGlaze());
            info.Add(candy.GetWrapper());
            info.Add(count.ToString());
            info.Add(cost.ToString());
            return info;
        }

        public int GetCost()
        {
            return cost;
        }

        public string GetFlavor()
        {
            return candy.GetFlavor();
        }
    }
}
