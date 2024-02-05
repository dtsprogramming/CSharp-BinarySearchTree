using BSTConsoleApp;

internal class Program
{
    static List<int> insertedValues = new List<int>();

    private static void Main()
    {
        BinarySearchTree bst = new BinarySearchTree();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Create A BST:");
            Console.WriteLine("1. Insert a Node Value");
            Console.WriteLine("2. Remove a Node Value");
            Console.WriteLine("3. Generate a Tree");
            Console.WriteLine("4. Exit");
            Console.Write("\nChoose 1, 2, 3, or 4: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter a value to insert: ");
                        if (int.TryParse(Console.ReadLine(), out int valueToInsert))
                        {
                            bst.Insert(valueToInsert);
                            TrackInsertedValues(valueToInsert);

                            Console.WriteLine("\nCurrent Tree Values:");
                            ListTreeValues();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                        }
                        break;
                    case 2:
                        Console.Write("Enter a value to Remove: ");
                        if (int.TryParse(Console.ReadLine(), out int valueToRemove))
                        {
                            bst.Remove(valueToRemove);
                            TrackRemovedValues(valueToRemove);

                            Console.WriteLine("\nCurrent Tree Values:");
                            ListTreeValues();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nNode Values in the order that they were inserted:");
                        ListTreeValues();

                        Console.WriteLine("\nIn-Order Traversal of the BST:");
                        bst.InOrderTraversal();

                        Console.WriteLine("\n\nTree Structure:");
                        bst.PrintTree();
                        break;
                    case 4:
                        Console.WriteLine("\nExiting the Program.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please enter a valid option (1, 2, 3, or 4).");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option (1, 2, 3, or 4).");
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    private static void TrackRemovedValues(int newValue)
    {
        bool valueExists = false;

        foreach (var value in insertedValues)
        {
            if (value == newValue)
            {
                valueExists = true;
            }
        }

        if (valueExists)
        {
            insertedValues.Remove(newValue);
            Console.WriteLine($"\nNode: {newValue} has been removed from the tree.");
        }
        else
        {
            Console.WriteLine("\nSpecified value does not exist in the current tree.");
        }
    }

    private static void ListTreeValues()
    {
        foreach (var value in insertedValues)
        {
            Console.Write(value + " ");
        }

        Console.WriteLine();
    }

    static void TrackInsertedValues(int newValue)
    {
        foreach (var value in insertedValues)
        {
            if (value == newValue) { return; }
        }

        insertedValues.Add(newValue);
    }
}