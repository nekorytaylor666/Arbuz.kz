using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWork
{
    public class Cart
    {
        private Item[] listOfItems;
        int index = 0;
        public int Sum { get; private set; }

        public Cart()
        {
            listOfItems = new Item[1];
        }

        public Item this[int index]
        {
            get { return listOfItems[index]; }
            set
            {
                if (value is Item)
                {
                    if (index + 1 > listOfItems.Length)
                    {
                        Array.Resize(ref listOfItems, listOfItems.Length + 1);
                        listOfItems[index] = value;
                    }
                    else
                    {
                        listOfItems[index] = value;
                    }
                }
            }
        }

        public void PrintList()
            {
            if(listOfItems[0] == null)
            {
                Console.WriteLine("Пусто в корзине");
            }
                for (int i = 0; i < listOfItems.Length; i++)
                {
                    if(listOfItems[i] != null)
                        Console.WriteLine($"{i + 1}. {listOfItems[i].Name}        {listOfItems[i].Price}");
                }
            }
       
        public int SumItems()
        {
            for (int i = 0; i < listOfItems.Length; i++)
            {
                if(listOfItems[i]!=null)
                Sum += listOfItems[i].Price;
            }
            return Sum;
        }

        public void ClearCart()
        {
            listOfItems = new Item[1];
            Sum = 0;
        }

        public void Append(Item item)
        {
            if (item is Item)
            {
                this[index] = item;
                index++;
            }
        }

    }
}
