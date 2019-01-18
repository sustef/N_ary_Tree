using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ary_Tree
{
    public class Tree<T>
    {
        // Properties Tree
        public int Count { get; set; }
        public int LeafCount { get; set;}

        // Place to save the tree
        public List<TreeNode<T>> TheTree = new List<TreeNode<T>>();

        // Constructor
        public Tree()
        {
            Count = 0;
            LeafCount = 0;
        }

        // To add new childs
        public TreeNode<T> AddChildNode(TreeNode<T> parentNode, T Value)
        {
            Count++; // one extra node is added
            TreeNode<T> newNode = new TreeNode<T>(Value, parentNode);
            if (parentNode != null) // if it is not the root
            {
                TheTree.Add(newNode); // add new node to the tree
                parentNode.Child.Add(newNode); // add new child to the parent
            }
            else
            {
                TheTree.Add(newNode); // it is the root so only add to the tree

            }
            // function to count the leafnodes every time that you added a new node
            LeafCount = 0;
            foreach (TreeNode<T> leaf in TheTree)
            {
                if (leaf.Child.Count == 0)
                {
                    LeafCount++;
                }
            }

            return newNode;
        }

     public void removeNode(TreeNode<T> node)
        {
            this.TheTree.Remove(node); // remove node from tree
            Count--; 
            var parentNode = node.Parent; // search parent node
            parentNode.Child.Remove(node); // remove the removed node from the parents child list

            if(node.Child.Count != 0) // when the removed node has childs, remove them as well
            {
                for (int i = node.Child.Count-1; i>=0; i--)
                {
                    removeNode(node.Child[i]);
                }
            }
            // function to count the leafnodes every time that you added a new node
            LeafCount = 0;
            foreach (TreeNode<T> leaf in TheTree)
            {
                if (leaf.Child.Count == 0)
                {
                    LeafCount++;
                }
            }
        }

        // so you can display the values of the nodes
        public List<T> TraverseNodes()
        {
            List<T> traversednodes = new List<T>();

            foreach (TreeNode<T> node in TheTree)
            {
                traversednodes.Add(node.Value);
            }
            return traversednodes;

        }

        // sum of every leafnode in the tree
        public List<T> SumToLeafs()
        {

            List<T> AllSom = new List<T>();
            List<TreeNode<T>> AllLeafs = new List<TreeNode<T>>();

            // save all nodes which are leafnodes
            foreach (TreeNode<T> leaf in TheTree)
            {
                if (leaf.Child.Count == 0)
                {
                    AllLeafs.Add(leaf);
                }
            }
                
                foreach (TreeNode<T> leafs in AllLeafs)
            {
                
                TreeNode<T> Parent = leafs; // save leafnode
                List<dynamic> Som = new List<dynamic>(); // with List dynamic it is possible to save int and string with add
                // otherwise it is difficult to create a empty int or string. Not the best way but it works
                Som.Add(Parent.Value);
                while(Parent.Parent != null)
                {
                    Som[0] = Som[0] + Parent.Parent.Value; // only use first element of list
                    Parent = Parent.Parent;
                }
                AllSom.Add(Som[0]);
            }
            return AllSom;
        }

    }
}
