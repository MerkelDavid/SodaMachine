using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Machine
    {
        List<Soda> SodaSelection;
        List<Coin> CashRegister;
        double totalCash;

        public Machine()
        {
            SodaSelection = new List<Soda>();
            CashRegister = new List<Coin>();

            PopulateSodaSelection();
            PopulateCashRegister();
            totalCash = CalculateTotalCash(CashRegister);
        }

        public List<Soda> GetSodaSelection()
        {
            return SodaSelection;
        }

        public List<Coin> GetCashRegister()
        {
            return CashRegister;
        }
        public void PopulateSodaSelection()
        {
            SodaSelection.Add(new SodaMachine.Soda("Grape", .60,10));
            SodaSelection.Add(new SodaMachine.Soda("Orange", .35,10));
            SodaSelection.Add(new SodaMachine.Soda("Lemon", .06,3));
        }

        public void PopulateCashRegister()
        {
            CashRegister.Add(new SodaMachine.Coin("Quarter", .25, 20));
            CashRegister.Add(new SodaMachine.Coin("Dime", .10, 10));
            CashRegister.Add(new SodaMachine.Coin("Nickel", .05, 20));
            CashRegister.Add(new SodaMachine.Coin("Penny", .01, 50));
        }

        public double CalculateTotalCash(List<Coin> money)
        {
            Double total = 0;
            for (int i = 0; i < money.Count(); i++)
            {
                total += money[i].GetValue() * money[i].GetCount();
            }
            return total;
        }

        public void InitiateTransation(List<Coin> payment,int Choice)
        {
            double payTotal = CalculateTotalCash(payment);
            Soda SodaChoice = SodaSelection[(Choice - 1)];

            if(payTotal == SodaChoice.GetPrice())
            {
                if (SodaChoice.GetCount() > 0)
                {
                    Console.WriteLine("You have Successfully purchased " + SodaChoice.GetName() + " Soda");
                    AddPaymentToCashRegister(payment);
                    SodaChoice.DecrementCount();
                    return;
                }
                else
                {
                    Console.WriteLine("There are none left! refunding purchase.");
                    DispenceChange(payment);
                    return;
                }
            }
            else if(payTotal < SodaChoice.GetPrice())
            {
                Console.WriteLine("Insufficient funds. dispencing change.");
                DispenceChange(payment);
                return;
            }
            else//if pay total > soda price
            {
                if (SodaChoice.GetCount() > 0)
                {
                    AddPaymentToCashRegister(payment);
                    List<Coin> change = MakeChange(payTotal - SodaChoice.GetPrice());
                    if(change == null)
                    {
                        Console.WriteLine("Could not create sufficient change. Refunding purchase.");
                         DispenceChange(payment);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("You have Successfully purchased " + SodaChoice.GetName() + " Soda.\nDispensing change.");
                        SodaChoice.DecrementCount();
                        DispenceChange(change);
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("There are none left! refunding purchase.");
                    DispenceChange(payment);
                    return;
                }
            }
        }

        public void AddPaymentToCashRegister(List<Coin> payment)
        {
            for(int i=0; i < CashRegister.Count; i++)
            {

                CashRegister[i].SetCount((CashRegister[i].GetCount() + payment[i].GetCount()));
            }
            totalCash = CalculateTotalCash(CashRegister);
        }

        public List<Coin> MakeChange(double payTotal)
        {
            double change = 0;
            List<Coin> changeCoins = new List<Coin>();
            for (int i = 0; i < CashRegister.Count; i++)
            {
                changeCoins.Add(new Coin(CashRegister[i].GetName(), CashRegister[i].GetValue(), 0));
                while (payTotal > change && CashRegister[i].GetCount()!=0)
                {
                    change += CashRegister[i].GetValue();
                    CashRegister[i].SetCount(CashRegister[i].GetCount() - 1);
                    changeCoins[i].SetCount(changeCoins[i].GetCount()+1);

                }
                if(Math.Round(change,2) == payTotal)
                {
                    //forgot how to round to hundreths(double is giving me a wrong number)
                    return changeCoins;
                }
                else
                {
                    change -= CashRegister[i].GetValue();
                    CashRegister[i].SetCount(CashRegister[i].GetCount() + 1);
                    changeCoins[i].SetCount(changeCoins[i].GetCount() - 1);
                }
            }
            return null;
        }

        public void DispenceChange(List<Coin> change)
        {
            string changeText = "You have recieved\n";
            for(int i = 0; i < change.Count(); i++)
            {
                changeText += change[i].GetCount() + " " + change[i].GetName() + "s\n";
            }
            Console.WriteLine(changeText);
        }
        public bool isEnoughMoney(double payTotal)
        {
            if (payTotal > totalCash)
            {
                return false;
            }
            else return true;
        }
    }
}
