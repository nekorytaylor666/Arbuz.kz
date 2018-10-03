using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWork
{
    public class Cart
    {
        private Item[] listOfItems;//Массив товаров в корзина
        int LastAvailableIndex = 0;//Последний доступный индекс , нужен для Append
        public int Sum { get; private set; } //Сумма всех цен товаров в корзине

        public Cart()
        {
            listOfItems = new Item[1];
        }

        public Item this[int LastAvailableIndex]
        {
            get { return listOfItems[LastAvailableIndex]; }
            set
            {
                if (value is Item)
                {
                    if (LastAvailableIndex + 1 > listOfItems.Length)
                    {
                        Array.Resize(ref listOfItems, listOfItems.Length + 1);
                        listOfItems[LastAvailableIndex] = value;
                    }
                    else
                    {
                        listOfItems[LastAvailableIndex] = value;
                    }
                }
            }
        }

        public void PrintList()
            {
                if(listOfItems[0] == null)
                {
                    Console.WriteLine("Пусто в корзине");
                return;
                }
                for (int i = 0; i < listOfItems.Length; i++)
                {
                    if(listOfItems[i] != null)
                        Console.WriteLine($"{i + 1}. {listOfItems[i].Name}        {listOfItems[i].Price}");
                }
            }
       
        public int SumItems()//Сумма всех элементов в корзине
        {
            for (int i = 0; i < listOfItems.Length; i++)
            {
                if(listOfItems[i]!=null)
                Sum += listOfItems[i].Price;
            }
            return Sum;
        }

        public void ClearCart()//Очистка корзины после оплаты
        {
            listOfItems = new Item[1];
            Sum = 0;
        }

        public void Append(Item item)//добавление в конец корзины товара
        {
            if (item is Item)
            {
                this[LastAvailableIndex] = item;
                LastAvailableIndex++;
            }
        }

    }
}
