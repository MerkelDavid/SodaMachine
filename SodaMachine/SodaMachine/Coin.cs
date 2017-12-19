using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Coin
    {
        private String name;
        private double value;
        private int count;

        public Coin (string name, double value,int count)
        {
            this.name = name;
            this.value = value;
            this.count = count;
        }

        public string GetName()
        {
            return name;
        }

        public double GetValue()
        {
            return value;
        }
        public int GetCount()
        {
            return count;
        }
        public void SetCount(int count)
        {
            this.count = count;
        }
    }
}
