namespace BSTConsoleApp
{
    internal class Node
    {
        public int Data;
        public Node? Left, Right;

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
