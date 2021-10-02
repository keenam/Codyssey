using System;
using System.Collections;
using System.Collections.Generic;

namespace Codyssey.Data.Tree
{
    /// <summary>
    /// Tree data.
    /// </summary>
    public class Tree<T> : IEnumerable<Tree<T>>
    {
        public Tree(T value)
        {
            Value = value;
            this.leaves = new();
        }

        public T Value { get; }

        public void Add(Tree<T> leaf)
        {
            this.leaves.Add(leaf);
        }

        public IEnumerator<Tree<T>> GetEnumerator()
        {
            return this.leaves.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerable<Tree<T>> Leaves { get; }

        private readonly List<Tree<T>> leaves;
    }
}
