using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class CustomQueue<T>
    {
        private Node _head, _tail;
        public int Count { get; private set; }

        public CustomQueue()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public void Enqueue(T value)
        {
            Node currentNode = new Node { Value = value };
            if (_head == null)
            {
                _head = currentNode;
                _tail = currentNode;
            }
            else
            {
                _tail.Next = currentNode;
                _tail = currentNode;
            }
            Count++;
        }

        public T Dequeue()
        {
            if (Count < 1)
                throw new InvalidOperationException("Queue is empty!"); //Exception("Очередь пустая!");
            T tmp = _head.Value;
            _head = _head.Next;
            Count--;
            return tmp;
        }
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty!");
            return _head.Value;
        }

        private class Node
        {
            internal Node Next { get; set; }
            internal T Value { get; set; }
        }
    }

}
