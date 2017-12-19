using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Soda
    {
        private string name;
        private Double price;
        private int count;
        
        public Soda(string name,Double price,int count)
        {
            this.name = name;
            this.price = price;
            this.count = count;
        }

        public string GetName()
        {
            return name;
        }
        public double GetPrice()
        {
            return price;
        }
        public int GetCount()
        {
            return count;
        }
        public void DecrementCount()
        {
            count--;
        }
    }
}
