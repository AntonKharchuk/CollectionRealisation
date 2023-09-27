using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionRealisation.ConsoleDemo
{
    public class ShowIEnumerable<T>
    {
        public static void Show(IEnumerable<T> values)
        {
            Console.WriteLine();
            Console.WriteLine(values);

            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

    }
}
