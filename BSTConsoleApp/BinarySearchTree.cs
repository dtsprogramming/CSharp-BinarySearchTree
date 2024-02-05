namespace BSTConsoleApp
{
    internal class BinarySearchTree
    {
        private Node? root;

        public BinarySearchTree()
        {
            root = null;
        }

        public void Insert(int data)
        {
            if (!Contains(root, data))
            {
                root = InsertRec(root, data);
            }
            else
            {
                Console.WriteLine($"\nValue {data} already exists in the tree. Duplicates are not allowed.");
            }
        }

        private Node InsertRec(Node? root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            if (data < root.Data)
            {
                root.Left = InsertRec(root.Left, data);
            }
            else if (data > root.Data)
            {
                root.Right = InsertRec(root.Right, data);
            }

            return root;
        }

        public void Remove(int data)
        {
            root = RemoveRec(root, data);
        }

        private Node? RemoveRec(Node? root, int data)
        {
            if (root == null) { return root; }

            if (data < root.Data)
            {
                root.Left = RemoveRec(root.Left, data);
            }
            else if(data > root.Data)
            {
                root.Right = RemoveRec(root.Right, data);
            }
            else
            {
                // Node with one child or no child
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }

                // Node with two children
                root.Data = MinValue(root.Right);

                // Delete the in-order successor
                root.Right = RemoveRec(root.Right, root.Data);
            }

            return root;
        }

        private int MinValue(Node root)
        {
            int minValue = root.Data;
            while (root.Left != null)
            {
                minValue = root.Data;
                root = root.Left;
            }
            return minValue;
        }

        private bool Contains(Node? root, int data)
        {
            if (root == null)
            {
                return false;
            }

            if (data == root.Data)
            {
                return true;
            }

            if (data < root.Data)
            {
                return Contains(root.Left, data);
            }
            else
            {
                return Contains(root.Right, data);
            }
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(root);
        }

        private void InOrderTraversal(Node? root)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left);
                Console.Write(root.Data + " ");
                InOrderTraversal(root.Right);
            }
        }

        public void PrintTree()
        {
            PrintTree(root, 0);
        }

        private void PrintTree(Node? root, int level)
        {
            if (root != null)
            {
                PrintTree(root.Right, level + 1);
                Console.WriteLine($"{new string(' ', 3 * level)}{root.Data}");
                PrintTree(root.Left, level + 1);
            }
        }
    }
}
