using System.Collections.Generic;

namespace Codyssey.Utils.Search
{
    /// <summary>
    /// Builds the binary tree
    /// </summary>
    /// <typeparam name="TV">Node value type.</typeparam>
    public class BTreeBuilder<TV>
    {
        private BTree<TV> root;
        private readonly IComparer<TV> comparer;

        public BTreeBuilder(IComparer<TV> comparer)
        {
            this.comparer = comparer;
        }

        public void Add(IEnumerable<TV> values)
        {
            foreach (var value in values)
            {
                this.root = Add(this.root, value);
            }
        }

        public BTree<TV> Build()
        {
            return this.root;
        }

        private BTree<TV> Add(BTree<TV> root, TV value)
        {
            if (root == null)
            {
                return new BTree<TV> { Data = value };
            }

            if (this.comparer.Compare(value, root.Data) < 0)
            {
                var leftNode = Add(root.Left, value);
                if (root.Left == null)
                {
                    root.Left = leftNode;
                }
            }
            else
            {
                var rightNode = Add(root.Right, value);
                if (root.Right == null)
                {
                    root.Right = rightNode;
                }
            }

            return root;
        }
    }
}
