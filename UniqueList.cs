using System;
using System.Collections.Generic;

public class UniqueList<T>
{
    Dictionary<int, int> indices;
    T[] items;
    int count;

    public FixUniqueList()
    {
        indices = new Dictionary<int, int>(1);
        items = new T[1];
    }

    public FixUniqueList(int capacity)
    {
        indices = new Dictionary<int, int>(capacity);
        items = new T[capacity];
    }

    public int Count
    {
        get { return count; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            return items[index];
        }

        set
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            
            items[index] = value;
        }
    }

    public bool Add(T item)
    {
        int key = null != item ? item.GetHashCode() : 0;
        if (indices.ContainsKey(key))
        {
            return false;
        }

        if (count >= items.Length)
        {
            T[] newItems = new T[items.Length * 2];
            items.CopyTo(newItems, 0);
            items = newItems;
        }

        items[count] = item;
        indices.Add(key, count);
        ++count;

        return true;
    }

    public bool Remove(T item)
    {
        int key = null != item ? item.GetHashCode() : 0;
        if (!indices.ContainsKey(key))
        {
            return false;
        }

        int index = indices[key];
        indices.Remove(key);

        if (index != count - 1)
        {
            items[index] = items[count - 1];
            key = items[index].GetHashCode();
            indices[key] = index;
        }

        items[count - 1] = default(T);

        --count;

        return true;
    }

    public void Clear()
    {
        indices.Clear();
        count = 0;
    }
}
