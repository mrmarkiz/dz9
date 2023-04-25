using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz9
{
    public delegate void DelegateTask3();

    internal class Task3
    {
        public static void Run()
        {
            int choice;
            uint sum;
            CreditCard card = new CreditCard();
            do
            {
                Console.WriteLine("Enter what to do(1-show current state, 2-top up, 3-spend, 4-start using credit money, 5-stop using credit money, 6-reach limit, 7-change Pin):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        card.action = card.Show;
                        break;
                    case 2:
                        card.action = card.TopUp;
                        break;
                    case 3:
                        card.action = card.Spend;
                        break;
                    case 4:
                        card.action = card.StartUsingCredits;
                        break;
                    case 5:
                        card.action = card.StopUsingCredits;
                        break;
                    case 6:
                        card.action = card.ReachLimit;
                        break;
                    case 7:
                        card.action = card.ChangePin;
                        break;
                    default:
                        card.action = null;
                        break;
                }
                if (card.action != null)
                {
                    card.action();
                }
                Console.WriteLine();
            } while (choice != 0);
        }
    }

    class CreditCard
    {
        public string Number { get; set; }
        public string Initials { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Pin { get; set; }
        public int CreditLimit { get; set; }
        private bool UseCredit { get; set; }
        private int UsedCredits { get; set; }
        public int Balance { get; set; }
        public DelegateTask3 action { get; set; }

        public CreditCard()
        {
            Init();
        }
        public void Init()
        {
            Console.WriteLine("Enter card's number: ");
            Number = Console.ReadLine();
            Console.WriteLine("Enter owner's initials:");
            Initials = Console.ReadLine();
            Console.WriteLine("Enter card's expire date:");
            DateTime.TryParse(Console.ReadLine(), out DateTime date);
            ExpireDate = date;
            Console.WriteLine("Enter card's PIN:");
            Pin = Console.ReadLine();
            Console.WriteLine("Enter credit limit:");
            int.TryParse(Console.ReadLine(), out int number);
            CreditLimit = number;
            Console.WriteLine("Enter current balance:");
            int.TryParse(Console.ReadLine(), out number);
            Balance = number;
            UseCredit = false;
            UsedCredits = 0;
            action = null;
        }

        public void Show()
        {
            Console.WriteLine($"Card's number: {Number}");
            Console.WriteLine($"Owner's initials: {Initials}");
            Console.WriteLine($"Card's expire date: {ExpireDate.ToShortDateString()}");
            Console.WriteLine($"Card's PIN: {Pin}");
            Console.WriteLine($"Credit limit: {CreditLimit}");
            Console.WriteLine($"Current balance: {Balance}");
            Console.WriteLine($"Using credit money: {UseCredit}");
            Console.WriteLine($"Used credit money: {UsedCredits}\n");
        }

        public void TopUp()
        {
            Console.WriteLine("Enter sum of topping up:");
            uint.TryParse(Console.ReadLine(), out uint sum);
            if (UseCredit)
            {
                UsedCredits -= (int)sum;
                if (UsedCredits < 0)
                {
                    Balance -= UsedCredits;
                    UsedCredits = 0;
                }                    
            }
            else
            {
                Balance += (int)sum;
            }
        }
        public void Spend()
        {
            Console.WriteLine("Enter sum to spend:");
            uint.TryParse(Console.ReadLine(), out uint sum);
            if (UseCredit)
            {
                if (UsedCredits + (int)sum > CreditLimit)
                {
                    Console.WriteLine("Not enough money. Declined");
                    return;
                }
                UsedCredits += (int)sum;
            }
            else
            {
                if (Balance < sum)
                {
                    Console.WriteLine("Not enough money. Declined");
                    return;
                }
                Balance -= (int)sum;
            }
        }
        public void StartUsingCredits()
        {
            UseCredit = true;
        }
        public void StopUsingCredits()
        {
            UseCredit = false;
        }
        public void ReachLimit()
        {
            UsedCredits = CreditLimit;
            Balance = 0;
        }
        public void ChangePin()
        {
            Console.Write("Enter current Pin: ");
            string input = Console.ReadLine();
            if (input == Pin)
            {
                Console.WriteLine("Enter new Pin:");
                Pin = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wrong Pin. Bye");
            }
        }

    }
}
