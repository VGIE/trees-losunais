namespace Lists;

//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.
using Lists;
using System.Collections;
using System.Threading;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;


    public ListNode(T value)
    {
        Value = value;
        
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list

        int contador=0;
            ListNode<T> node= First;
            while(node!=null)
            {
                node=node.Next;
                contador++;
            }
            return contador;
        
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds
        
        ListNode<T> node= First;
            int contador = 0;
            if (index < Count())
            {
                while (contador < index)
                {
                    node = node.Next;
                    contador++;
                }
                return node.Value;
            }
            return default(T);
        
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list
        ListNode<T> node = First;
            if (node != null)
            {
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = new ListNode<T>(value);
            }
            else
            {
                First= new ListNode<T>(value);
            }
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds

        ListNode<T> node = First;
        T removed;
        int contador = 0;
        if (index >= Count())
        {
            return default(T);
        }
        while (contador < index-1 && node != null)
        {
            node = node.Next;
            contador++;
        }
        removed = Get(index);
        if (index == 0)
        {
            First= First.Next;
        }
        if (index == Count() - 1 && index != 0)
        {
            Last = node;
            node.Next = null;
        }
        if (0 < index && index < Count() - 1)
        {
            node.Next = node.Next.Next;
        }
        return removed;
     }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        First = null;
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        
        for (int i = 0; i < Count(); i++)
            { 
                yield return Get(i);
            }
        
    }
}
