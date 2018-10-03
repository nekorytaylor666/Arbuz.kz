using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWork
{
    class Customer
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public bool Verified { get; private set; }

        public Customer(string name, string Number = "+77783973990")
        {
            Name = name;
            Verified = false;
        }

        public bool SmsValidation()
        {
            MessageSender sender = new MessageSender("+77783973990");
            sender.SendMessage();
            Console.Clear();
            Console.WriteLine($"{Name} Введите код валидации или вас не впустят: ");
            string value = Console.ReadLine();
            if (sender.CheckCode(value))
            {
                Console.WriteLine("верно!");
                Verified = true;
                return true;
            }
            else
                Console.WriteLine("РОБОТ ЧЕРТОВ!!! КОЖАННЫЕ МЕШКИ ПОБЕДЯТ");
            return false;
        }

    }
}
