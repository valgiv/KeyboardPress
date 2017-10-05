using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer.Helper
{
    public static class Helper
    {
        public static readonly int[] ltLettersArray = new int[] { 260, 261, 269, 268, 281, 280, 279, 278, 303, 303, 353, 352, 371, 370, 363, 362, 382, 381 };

        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> collection, int n)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "n must be 0 or greater");

            LinkedList<T> temp = new LinkedList<T>();

            foreach (var value in collection.Reverse())
            {
                temp.AddFirst(value);
                if (temp.Count == n)
                    break;
            }

            return temp;
        }

        public static void DeleteFromBegin<T>(ref List<T> list, int itemsToDelete, ref List<T> deletedItemslist)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (itemsToDelete < 1)
                throw new ArgumentOutOfRangeException(nameof(itemsToDelete));
            
            for(int i = 0; i<itemsToDelete; i++)
            {
                if (list.LongCount() > 0)
                {
                    if (deletedItemslist != null)
                        deletedItemslist.Add(list[0]);
                    list.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }
        }

    }
}
