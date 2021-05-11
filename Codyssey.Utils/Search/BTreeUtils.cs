using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codyssey.Utils.Search
{
    /// <summary>
    /// Displays binary trees
    /// </summary>
    public class BTreeUtils
    {
        public IEnumerable<T> GetValuesInOrder<T>(BTree<T> root)
        {
            if (root == null)
            {
                yield break;
            }

            // let's go for iterative approach
            if (root != null)
            {
                yield return root.Data;
            }

            foreach (var leftValue in GetValuesInOrder(root.Left))
            {
                yield return leftValue;
            }

            foreach (var rightValue in GetValuesInOrder(root.Right))
            {
                yield return rightValue;
            }
        }
    }
}
