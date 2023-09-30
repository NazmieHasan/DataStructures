namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
            {
                this.Element = element;
            }
        }

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            Node newTop = new Node(item);
            newTop.Next = this.top;
            this.top = newTop;
            this.Count++;
        }

        public T Pop()
        {
            this.ValidateNotEmpty();

            var oldTop = this.top;
            this.top = oldTop.Next;

            this.Count--;

            return oldTop.Element;
        }

        public T Peek()
        {
            this.ValidateNotEmpty();

            return this.top.Element; ;
        }

        public bool Contains(T item)
        {
            Node current = this.top;

            while (current != null)
            {
                if (current.Element.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.top;

            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void ValidateNotEmpty()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}