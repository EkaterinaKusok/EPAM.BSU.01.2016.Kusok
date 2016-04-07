using System;
using System.Collections;
using System.Collections.Generic;

// https://msdn.microsoft.com/en-us/library/ms379572%28v=vs.80%29.aspx

namespace BinarySearchTree
{
    public class BinaryTree<T> : ICollection<T>
    {
        private class Node<TValue>
        {
            public TValue Value { get; private set; }
            public Node<TValue> Left { get; set; }
            public Node<TValue> Right { get; set; }

            public Node(TValue value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        private Node<T> _root;
        private IComparer<T> _comparer;

        public BinaryTree() : this(Comparer<T>.Default){}
        public BinaryTree(IComparer<T> defaultComparer)
        {
            if (defaultComparer == null)
                throw new ArgumentNullException("Default comparer is null");
            _comparer = defaultComparer;
        }
        public BinaryTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default){}
        public BinaryTree(IEnumerable<T> collection, IComparer<T> defaultComparer) : this(defaultComparer)
        {
            AddRange(collection);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var value in collection)
                Add(value);
        }

        public IEnumerable<T> Inorder()
        {
            if (_root == null)
                yield break;

            var stack = new Stack<Node<T>>();
            var node = _root;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
                else
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }

        public IEnumerable<T> Preorder()
        {
            if (_root == null)
                yield break;

            var stack = new Stack<Node<T>>();
            stack.Push(_root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;
                if (node.Right != null)
                    stack.Push(node.Right);
                if (node.Left != null)
                    stack.Push(node.Left);
            }
        }

        public IEnumerable<T> Postorder()
        {
            if (_root == null)
                yield break;

            var stack = new Stack<Node<T>>();
            var node = _root;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    if (stack.Count > 0 && node.Right == stack.Peek())
                    {
                        stack.Pop();
                        stack.Push(node);
                        node = node.Right;
                    }
                    else
                    {
                        yield return node.Value;
                        node = null;
                    }
                }
                else
                {
                    if (node.Right != null)
                        stack.Push(node.Right);
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }
        
        #region ICollection<T> Members
        public int Count { get; protected set; }
        public virtual void Add(T item)
        {
            var node = new Node<T>(item);
            if (_root == null)
                _root = node;
            else
            {
                Node<T> current = _root, parent = null;
                int result;
                while (current != null)
                {
                    result = _comparer.Compare(item, current.Value);
                    parent = current;
                    if (result == 0) // they are equal - attempting to enter a duplicate - do nothing
                        return;
                    else if (result < 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }
                // We're ready to add the node
                if (_comparer.Compare(item, parent.Value) < 0)
                    parent.Left = node;
                else
                    parent.Right = node;
            }
            ++Count;
        }
        public virtual bool Remove(T item)
        {
            if (_root == null)
                return false;  // no items to remove
            // Now, try to find data in the tree
            Node<T> current = _root, parent = null;

            int result = _comparer.Compare(item, current.Value);
            while (result != 0)
            {
                if (result < 0)
                {   // current.Value > data, if data exists it's in the left subtree
                    parent = current;
                    current = current.Left;
                }
                else if (result > 0)
                {   // current.Value < data, if data exists it's in the right subtree
                    parent = current;
                    current = current.Right;
                }
                // If current == null, then we didn't find the item to remove
                if (current == null)
                    return false;
                else
                    result = _comparer.Compare(current.Value, item);
            }

            // At this point, we've found the node to remove
            // CASE 1: If current has no right child, then current's left child becomes
            //         the node pointed to by the parent
            if (current.Right == null)
            {
                if (current == _root)
                    _root = current.Left;
                else
                {
                    result = _comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Left;
                    else
                        parent.Right = current.Left;
                }
            }
            // CASE 2: If current's right child has no left child, then current's right child
            //         replaces current in the tree
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (current == _root)
                    _root = current.Right;
                else
                {
                    result = _comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Right;
                    else
                        parent.Right = current.Right;
                }
            }
            // CASE 3: If current's right child has a left child, replace current with current's
            //          right child's left-most descendent
            else
            {
                // We first need to find the right node's left-most child
                Node<T> leftmost = current.Right.Left, lmParent = current.Right;
                while (leftmost.Left != null)
                {
                    lmParent = leftmost;
                    leftmost = leftmost.Left;
                }
                lmParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (current == _root)
                    _root = leftmost;
                else
                {
                    result = _comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = leftmost;
                    else
                        parent.Right = leftmost;
                }
            }
            --Count;
            return true;
        }
        public void Clear()
        {
            _root = null;
            Count = 0;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var value in this)
                array[arrayIndex++] = value;
        }
        public virtual bool IsReadOnly
        {
            get { return false; }
        }
        public bool Contains(T item)
        {
            var current = _root;
            int result;
            while (current != null)
            {
                result = _comparer.Compare(item, current.Value);
                if (result == 0)
                    return true;
                else if (result < 0)
                    current = current.Left;
                else
                    current = current.Right;
            }
            return false;
        }
        #endregion

        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return Inorder().GetEnumerator();
        }
        #endregion

        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
