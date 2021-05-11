using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codyssey.Utils.Search
{
    /// <summary>
    /// BinaryTree.
    /// </summary>
    public class BTree<T>
    {
        public T Data { get; set; }

        public BTree<T> Left;
        public BTree<T> Right;
    }
}
