using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWork
{
    public class Shop
    {
        public string ShopName { get; set; }
        private Item[] listOfItems;
        public int LastAvailableIndex { get; private set;}
        


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
                    if (index+1 > listOfItems.Length)
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
            
            for (int i = 0; i < listOfItems.Length; i++)
            {
                if(listOfItems[i] != null)
                    Console.WriteLine($"{i+1}. {listOfItems[i].Name}        {listOfItems[i].Price}");
            }
        }

        public void Append(Item item)
        {
            if (item is Item)
            {
                this[LastAvailableIndex] = item;
                LastAvailableIndex++;
            }
        }

        public Shop FilterByCategory(Category category)
        {
            Shop filtredListItems = new Shop();

            for (int i = 0; i < listOfItems.Length; i++)
            {
                if(Category.Compare(category, listOfItems[i].category))
                {
                    filtredListItems.Append(listOfItems[i]);
                }
            }

            return filtredListItems; 
        }
    }
}
