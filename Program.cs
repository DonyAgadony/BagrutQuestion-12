public class Node<T> // <T> = generic
{
    private T value; // The value of the current cell

    private Node<T>? next; // Pointer to the next cell

    public Node(T value)
    {
        this.value = value;
        next = null;
    }

    public Node(T value, Node<T> next)
    {
        this.value = value;
        this.next = next;
    }

    public T GetValue()
    {
        return this.value;
    }

    public void SetValue(T value)
    {
        this.value = value;
    }

    public Node<T>? GetNext()
    {
        return this.next;
    }

    public void SetNext(Node<T>? next)
    {
        this.next = next;
    }

    public bool HasNext()
    {
        return next != null;
    }

    public override string ToString()
    {
        return value!.ToString()!;
    }
}
public static class ListOperations
{
    public static void AddToTail<T>(Node<T>? head, T newvalue)
    {
        if (head == null) throw new ArgumentNullException("Head can't be null value.");

        while (head!.HasNext())
        {
            head = head.GetNext();
        }

        head.SetNext(new Node<T>(newvalue));
    }

    public static string ToString<T>(Node<T>? head)
    {
        string result = "";

        while (head != null)
        {
            result += head.ToString() + ", ";
            head = head.GetNext();
        }

        return result;
    }

    public static int GetLength<T>(Node<T>? head)
    {
        int len = 0;

        while (head != null)
        {
            len++;
            head = head.GetNext();
        }

        return len;
    }

    public static bool Contains<T>(Node<T>? head, T value)
    {
        while (head != null)
        {
            if (head.GetValue()!.Equals(value))
            {
                return true;
            }

            head = head.GetNext();
        }

        return false;
    }

    public static int GetMax(Node<int>? head)
    {
        int max = int.MinValue;
        while (head != null)
        {
            if (head.GetValue() > max)
            {
                max = head.GetValue();
            }
            head = head.GetNext();
        }
        return max;
    }

    public static void Insert<T>(Node<T>? head, T value, int index)
    {
        for (; index > 1; index--)
        {
            head = head!.GetNext();
        }
        var temp = new Node<T>(value);
        temp.SetNext(head!.GetNext());
        head.SetNext(temp);
    }
}
class Program
{
    public static bool IsL(Node<int> first)
    {
        int Size = 0;
        Node<int> temp = first;
        while (temp != null)
        {
            Size++;
            temp = temp.GetNext();
        }
        if (Size % 3 == 0 && Size > 0)
        {
            Node<int> node = first;
            Queue<int> q1 = new();
            Queue<int> q2 = new();

            for (int i = 0; i < Size / 3; i++)
            {
                q1.Enqueue(node.GetValue());
                node = node.GetNext();
            }
            for (int i = 0; i < Size / 3; i++)
            {
                q2.Enqueue(node.GetValue());
                node = node.GetNext();
            }
            for (int i = 0; i < Size / 3; i++)
            {
                if (node.GetValue() != q1.Dequeue() && q1.Dequeue() != q2.Dequeue())
                {
                    return false;
                }
                node = node.GetNext();
            }
        }
        return true;

    }
}