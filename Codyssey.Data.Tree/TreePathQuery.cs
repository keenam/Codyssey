using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codyssey.Data.Tree
{
    /// <summary>
    /// Query tree path
    /// </summary>
    public class TreePathQuery<T>
    {
        private readonly Tree<T> root;

        public TreePathQuery(Tree<T> root)
        {
            this.root = root;
        }

        /// <summary>
        /// Gets path to the value via depth first search.
        /// </summary>
        public IEnumerable<IEnumerable<T>> GetDfsPathTo(T value)
        {
            return GetDfsPathTo(root, value);
        }

        private IEnumerable<IEnumerable<T>> GetDfsPathTo(Tree<T> tree, T value)
        {
            if (tree == null)
            {
                yield break;
            }
            else if (tree.Value.Equals(value))
            {
                yield return Enumerable.Repeat(tree.Value, 1);
            }

            if (tree.Value.Equals("y"))
            {
                var task = Task.Delay(5000);
                task.Wait();
            }

            foreach (var leaf in tree)
            {
                foreach (var path in GetDfsPathTo(leaf, value))
                {
                    yield return Enumerable.Repeat(tree.Value, 1).Concat(path);
                }
            }
        }
    }
}
