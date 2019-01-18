using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using N_ary_Tree;

namespace N_ary_Tree_Lib_Test
{
    [TestFixture]
    public class TreeTest
    {
        [TestCase]        
        public void TestTreeAddChild()
        {
            // Arrange
            var NAryTreeInt = new Tree<int>();
            var NAryTreeStr = new Tree<string>();
            // Act
            var root_int = NAryTreeInt.AddChildNode(null, 1);
            var child1_int = NAryTreeInt.AddChildNode(root_int, 2);
            var root_str = NAryTreeStr.AddChildNode(null, "A");
            var child1_str = NAryTreeStr.AddChildNode(root_str, "B");
            // Assert
            Assert.Multiple(() =>
            {
                // Check Count
                Assert.That(NAryTreeInt.Count == 2);
                Assert.That(NAryTreeStr.Count == 2);

                // Check CountLeaf
                Assert.That(NAryTreeInt.LeafCount == 1);
                Assert.That(NAryTreeStr.LeafCount == 1);

                // Check if it is added
                Assert.Contains(child1_int, NAryTreeInt.TheTree);

                // If root has a child
                Assert.Contains(child1_int, root_int.Child);

            });
        }

        [TestCase]
        public void TestTreeRemoveNode()
        {
            // Arrange
            var NAryTreeInt = new Tree<int>();
            var NAryTreeStr = new Tree<string>();
            // Act
            var root_int = NAryTreeInt.AddChildNode(null, 1);
            var child1_int = NAryTreeInt.AddChildNode(root_int, 2);
            var child2_int = NAryTreeInt.AddChildNode(root_int, 3);
            var child3_int = NAryTreeInt.AddChildNode(child1_int, 4);
            NAryTreeInt.removeNode(child1_int);
            var root_str = NAryTreeStr.AddChildNode(null, "A");
            var child1_str = NAryTreeStr.AddChildNode(root_str, "B");
            var child2_str = NAryTreeStr.AddChildNode(root_str, "C");
            var child3_str = NAryTreeStr.AddChildNode(child1_str, "D");
            NAryTreeStr.removeNode(child1_str);
            // Assert
            Assert.Multiple(() =>
            {
                // Check Count
                Assert.That(NAryTreeInt.Count == 2);
                Assert.That(NAryTreeStr.Count == 2);

                // Check CountLeaf
                Assert.That(NAryTreeInt.LeafCount == 1);
                Assert.That(NAryTreeStr.LeafCount == 1);

                // Check if the childs of the child are deleted and child himself is deleted
                for (int i = 0; i< NAryTreeInt.TheTree.Count; i++)
                {
                    Assert.AreNotSame(child1_int, NAryTreeInt.TheTree[i]);
                    Assert.AreNotSame(child3_int, NAryTreeInt.TheTree[i]);

                }
                ;
            });
        }
        [TestCase]
        public void TestTreeTraverseNode()
        {
            // Arrange
            var NAryTreeInt = new Tree<int>();
            var NAryTreeStr = new Tree<string>();
            // Act
            var root_int = NAryTreeInt.AddChildNode(null, 1);
            var child1_int = NAryTreeInt.AddChildNode(root_int, 2);
            var child2_int = NAryTreeInt.AddChildNode(root_int, 3);
            var child3_int = NAryTreeInt.AddChildNode(child1_int, 4);
            List<int> real = NAryTreeInt.TraverseNodes();
            // Assert
            // Check if values correspond with input
            for (int i=0; i <4; i++)
            {
                Assert.That(i + 1 == real[i]);
            }      

        }
        [TestCase]
        public void TestTreeSumToLeafs()
        {
            // Arrange
            var NAryTreeInt = new Tree<int>();
            var NAryTreeStr = new Tree<string>();
            // Act
            var root_int = NAryTreeInt.AddChildNode(null, 1);
            var child1_int = NAryTreeInt.AddChildNode(root_int, 2);
            var child2_int = NAryTreeInt.AddChildNode(root_int, 3);
            var child3_int = NAryTreeInt.AddChildNode(child1_int, 4);
            List<int> real = NAryTreeInt.SumToLeafs();
            List<int> test = new List<int>();
            test.Add(4);
            test.Add(7);
            // Assert
            // Check if values correspond with input
            for (int i = 0; i < real.Count; i++)
            {
                Assert.That(test[i] == real[i]);
            }
        }

    }
}
