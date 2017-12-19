using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class UI
    {
        Machine SodaMachine = new SodaMachine.Machine();

        public UI()
        {

        }
        public void StartMachine()
        {
            OutputText("Beep Boop! Welcome To Soda Drinker Pro!\n Press any button to continue");
            Console.ReadKey();
            SodaLoop();
        }

        public void SodaLoop()
        {
            OutputText("Which type of Soda would you like to purchase?");
            OutputSodaTypes();
            int SodaChoice = GetSodaChoice();
            List<Coin> payment = GetPayment();
            SodaMachine.InitiateTransation(payment,SodaChoice);
            AskToGoAgain();
        }

        public void OutputSodaTypes()
        {
            List<Soda> currentSodaSelection = SodaMachine.GetSodaSelection();
            string outputString = "";

            for(int i = 0; i < currentSodaSelection.Count(); i++)
            {
                outputString += (i+1) + ": " + currentSodaSelection[i].GetName() + " $" + currentSodaSelection[i].GetPrice() + "(There are " + currentSodaSelection[i].GetCount()+ " remaining)\n";
            }
            OutputText(outputString);
        }

        public int GetSodaChoice()
        {
            int choice = IsANumber(InputText());
            if (choice < 1 || choice > 3)
            {
                Console.Clear();
                OutputText("please enter a valid number");
                SodaLoop();
                return -1;
            }
            else
            {
                return choice;
            }
        }
        
        private int IsANumber(string input) 
        {
            try
            {
                int choice = Convert.ToInt32(input);
                return choice;
            }
            catch
            {
                return -1;
            }
        }
        public List<Coin> GetPayment()
        {
            List<Coin> payment = new List<Coin>();
            List<Coin> CoinSelection = SodaMachine.GetCashRegister();
            for(int i = 0;i< CoinSelection.Count; i++){
                Console.Clear();
                OutputText("Please enter the Amount of " +CoinSelection[i].GetName() +"s you would like to insert");
                int amount = IsANumber(InputText());
                if (amount>=0 && amount < 100)
                {
                    payment.Add(new Coin(CoinSelection[i].GetName(),CoinSelection[i].GetValue(),amount));
                }
                else
                {
                    i--;
                }
            }

            return payment;

        }
        public void AskToGoAgain()
        {
            OutputText("Transaction Complete, would you like to purchase another soda?\n1:yes\n2:no");
            int choice = IsANumber(InputText());
            if(choice == 1)
            {
                Console.Clear();
                SodaLoop();
            }
            if(choice == -1)
            {
                Console.Clear();
                OutputText("Please enter either 1 or 2");
                AskToGoAgain();
            }
        }
        public void OutputText(string text)
        {
            Console.WriteLine(text);
        }
        public string InputText()
        {
            return Console.ReadLine();
        }
    }


}
