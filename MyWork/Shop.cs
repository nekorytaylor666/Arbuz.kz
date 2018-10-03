using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWork
{
    public class Shop
    {
        private Item[] listOfItems;//Массив товаров с которым мы будем работать
        public int LastAvailableIndex { get; private set;}//последний доступный элемент (нужен для функции Append)
        


        public Shop()
        {
            listOfItems = new Item[1];
            LastAvailableIndex = 0;
        }

        public Item this[int index]
        {
            get { return listOfItems[index]; }
            set {
                if (value is Item)
                {
                    if (index+1 > listOfItems.Length)//проверяет размер массива, если что увеличивает на один размер
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

        public void PrintList()//выводит список товаров данного Shop 
        {
            
            for (int i = 0; i < listOfItems.Length; i++)
            {
                if(listOfItems[i] != null)
                    Console.WriteLine($"{i+1}. {listOfItems[i].Name}        {listOfItems[i].Price}");
            }
        }

        public void Append(Item item)//Добавление в конец листа передаваемый товар
        {
            if (item is Item)
            {
                this[LastAvailableIndex] = item;
                LastAvailableIndex++;
            }
        }

        public Shop FilterByCategory(Category category) //Создает новый шоп и заносит туда товары которые имеют 
            //нужную категорию, затем мы уже работаем с отфильтрованным шопом.
        {
            Shop filtredListItems = new Shop();

            for (int i = 0; i < listOfItems.Length; i++)
            {
                if(Category.Compare(category, listOfItems[i].Category))
                {
                    filtredListItems.Append(listOfItems[i]);
                }
            }

            return filtredListItems; 
        }
    }
}
