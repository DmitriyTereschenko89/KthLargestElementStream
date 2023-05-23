namespace KthLargestElementStream
{
    internal class Program
    {
        public class KthLargest
        {

            private class Node
            {
                public int value;
                public Node left;
                public Node right;

                public Node(int value, Node left = null, Node right = null)
                {
                    this.value = value;
                    this.left = left;
                    this.right = right;
                }
            }

            private class NodeInfo
            {
                public int visitedNode;
                public int lastValue;

                public NodeInfo(int visitedNode, int lastValue)
                {
                    this.visitedNode = visitedNode;
                    this.lastValue = lastValue;
                }
            }

            private class BST
            {
                private Node root;

                private int FindKthLargestValue(Node node, int kth, NodeInfo nodeInfo)
                {
                    if (node.right != null)
                    {
                        FindKthLargestValue(node.right, kth, nodeInfo);
                    }
                    if (nodeInfo.visitedNode >= kth)
                    {
                        return nodeInfo.lastValue;
                    }
                    nodeInfo.visitedNode += 1;
                    nodeInfo.lastValue = node.value;
                    if (nodeInfo.visitedNode < kth)
                    {
                        if (node.left != null)
                        {
                            FindKthLargestValue(node.left, kth, nodeInfo);
                        }
                    }
                    return nodeInfo.lastValue;
                }

                public void Insert(int value)
                {
                    if (root is null)
                    {
                        root = new Node(value);
                        return;
                    }
                    Node node = root;
                    while (true)
                    {
                        if (node.value >= value)
                        {
                            if (node.left is null)
                            {
                                node.left = new Node(value);
                                return;
                            }
                            node = node.left;
                        }
                        else
                        {
                            if (node.right is null)
                            {
                                node.right = new Node(value);
                                return;
                            }
                            node = node.right;
                        }
                    }
                }

                public int FindKthLargest(int k)
                {
                    return FindKthLargestValue(root, k, new NodeInfo(0, -1));
                }
            }

            private readonly BST bST;
            private readonly int kth;

            public KthLargest(int k, int[] nums)
            {
                kth = k;
                bST = new BST();
                foreach (int num in nums)
                {
                    bST.Insert(num);
                }
            }

            public int Add(int val)
            {
                bST.Insert(val);
                return bST.FindKthLargest(kth);
            }
        }

        static void Main(string[] args)
        {
            KthLargest kthLargest = new(3, new int[] { 4, 5, 8, 2 });
            Console.WriteLine(kthLargest.Add(3));
            Console.WriteLine(kthLargest.Add(5));
            Console.WriteLine(kthLargest.Add(10));
            Console.WriteLine(kthLargest.Add(9));
            Console.WriteLine(kthLargest.Add(4));
        }
    }
}