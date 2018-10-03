using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWork
{

    class Program
    {

        static Category[] categories = new Category[2];

        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Cart cart = new Cart();

            Category categoryWater = new Category { Name = "Вода" };
            Category categorySoda = new Category { Name = "Газировка" };

            categories[0] = categoryWater;
            categories[1] = categorySoda;

            Item item1 =new Item { Name =  "Вода минеральная есентуки 2L", Price = 351 , category = categoryWater };
            Item item2 =new Item { Name =  "Pepsi 1L", Price = 240, category = categorySoda };
            Item item3 =new Item { Name =  "Sprite 1L", Price = 240 , category = categorySoda };

            shop.Append(item1);
            shop.Append(item2);
            shop.Append(item3);

            Menu(shop, cart);

            //cart.PrintList();

            //Console.WriteLine($"Sum: {cart.SumItems()}");

            //shop.PrintList();


            //Shop filtShop = shop.FilterByCategory(categoryWater);
            //filtShop.PrintList();
            //SmsValidation();
            Console.Read();
        }
        
        static void ChooseItem(Cart cart , Shop shop)
        {
            Console.WriteLine("Хотите что нибудь приобрести? Введите номер товара из списка выше!");
            int choose = Convert.ToInt32(Console.ReadLine());
            if (choose == 0 || shop.LastAvailableIndex < choose )
            {
                Console.Write("Хорошо, вали тогда!");
                Menu(shop,cart);
                return;
            }
            cart.Append(shop[choose - 1]);
            Console.WriteLine($"Товар {shop[choose-1].Name} добавлен в корзину!\nНажмите любую кнопку для продолжения..");
            Console.ReadLine();
            Menu(shop, cart);
        }

        
        static void Menu(Shop shop, Cart cart)
        {
            Console.Clear();
            Console.WriteLine("1.Вход/Регистрация\n2.Списко всех товаров\n3.Посмотреть корзину\n4.Оплата\n5.По категориям");

            int choose = Convert.ToInt32(Console.ReadLine());

            switch (choose)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Введите ваше имя: ");
                    string name = Console.ReadLine();
                    Customer customer = new Customer(name);
                    if (customer.SmsValidation())
                    {
                        Console.WriteLine("Все хорошо!\nДля возвращние нажмите любую кнопку");
                        Console.ReadLine();
                        Menu(shop, cart);
                    }
                    else
                    {
                        Console.WriteLine("Ну все гг!");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    shop.PrintList();
                    ChooseItem(cart, shop);
                    break;
                case 3:
                    cart.PrintList();
                    Console.ReadLine();
                    Menu(shop, cart);
                    break;
                case 4:
                    Console.WriteLine($"Sum {cart.SumItems()}");
                    if(cart.SumItems() != 0)
                        Console.WriteLine("Товар куплен спасибо!");
                    cart.ClearCart();
                    Console.ReadLine();
                    break;
                case 5:
                    for (int i = 0; i < categories.Length; i++)
                    {
                        Console.WriteLine($"{i+1}. {categories[i].Name}");
                    }
                    int chosenCategory = Convert.ToInt32(Console.ReadLine());
                    Shop filtrShopList = shop.FilterByCategory(categories[chosenCategory-1]);
                    filtrShopList.PrintList();
                    ChooseItem(cart, filtrShopList);
                    break;
                default:
                    break;
            }
        }
    }
}
