using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWork
{
    public class Category
    {
        public string Name { get; set; }

        static public bool Compare(Category category1, Category category2)
        {
            if(String.Equals(category1.Name, category2.Name))
            {
                return true;
            }
            return false;
        }
    }
}
