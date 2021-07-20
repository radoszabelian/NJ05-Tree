using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJ05_Tree
{
    public class Node<T> : IEnumerable<T>
    {
        private List<Node<T>> children;
        public T Value { get; set; }

        private Node()
        {
        }

        public Node(T _value, List<T> _children = null)
        {
            Value = _value;
            children = new List<Node<T>>();

            if (_children != null)
            {
                foreach (var item in _children)
                {
                    children.Add(new Node<T>()
                    {
                        Value = item,
                        children = null,
                    });
                }
            }
        }

        public Node<T> this[int index]
        {
            get
            {
                return children[index];
            }
            set
            {
                children[index] = value;
            }
        }

        public void AddChild(T value)
        {
            if (children == null) children = new List<Node<T>>();

            children.Add(new Node<T>()
            {
                children = null,
                Value = value
            });
        }

        public void AddChild(Node<T> value)
        {
            if (value != null)
            {
                children.Add(value);
            }
        }

        public bool RemoveChild(T value)
        {
            Node<T> result = null;

            foreach (var child in children)
            {
                if (child.Value.Equals(value))
                {
                    result = child;
                }
            }

            if (result != null)
            {
                children.Remove(result);
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new TreeEnumerator<T>(children);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return children.GetEnumerator();
        }

        public bool Contains(T item)
        {
            if (Value.Equals(item)) return true;

            if (children != null)
            {
                foreach (var child in children)
                {
                    if (child.Contains(item))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Contains(Func<T, bool> predicate)
        {
            if (predicate(Value)) return true;

            if (children != null)
            {
                foreach (var child in children)
                {
                    if (child.Contains(predicate))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            return ToString(0);
        }

        private string ToString(int level)
        {
            StringBuilder sb = new StringBuilder();
            string prefix = "";

            if (level > 1)
            {
                for (int i = 1; i <= level - 1; i++)
                {
                    prefix += "|\t";
                }
            }
            prefix += "|---";

            if (level == 0) prefix = "";

            sb.Append(prefix + Value);
            sb.Append(Environment.NewLine);

            if (children != null)
            {
                foreach (var child in children)
                {
                    sb.Append(child.ToString(level + 1));
                }
            }

            return sb.ToString();
        }

        public int NumberOfChildren
        {
            get => children.Count;
        }
    }

    class TreeEnumerator<T> : IEnumerator<T>
    {
        private int index;
        private List<Node<T>> listRef;

        public TreeEnumerator(List<Node<T>> _listRef, int idx = -1)
        {
            index = idx;
            listRef = _listRef;
        }

        public T Current => listRef[index].Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            index++;
            return index < listRef.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}