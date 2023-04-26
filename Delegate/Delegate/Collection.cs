using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Collection<T>
    {
        private List<T> items;

        public Collection()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public int Count(Func<T, bool> predicate)
        {
            return items.Count(predicate);
        }

        public T1 Aggregate<T1>(Func<T, T1, T1> func, T1 defval)
        {
            return items.Aggregate(defval, (acc, x) => func(x, acc));
        }


        public int _Count
        {
            get { return items.Count; }
        }

        public T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }
    }

}
