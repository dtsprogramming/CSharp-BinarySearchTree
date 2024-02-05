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
            Console.WriteLine("1. Manually Insert Nodes");
            Console.WriteLine("2. Remove Node(s)");
            Console.WriteLine("3. Display Manual Tree");
            Console.WriteLine("4. Generate a Random Tree");
            Console.WriteLine("5. Exit");
            Console.Write("\nChoose 1, 2, 3, 4 or 5: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        bool continueInserting = true;
                        while (continueInserting)
                        {
                            Console.Write("\nEnter a value to insert: ");
                            if (int.TryParse(Console.ReadLine(), out int valueToInsert))
                            {
                                bst.Insert(valueToInsert);
                                TrackInsertedValues(valueToInsert);

                                Console.WriteLine($"\nValue {valueToInsert} has been inserted into the tree.");

                                Console.WriteLine("\nCurrent Tree Values:");
                                ListTreeValues();
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                            }

                            Console.Write("\nInsert another? (Y/N): ");
                            var response = Console.ReadLine();
                            continueInserting = response.Equals("Y", StringComparison.OrdinalIgnoreCase) || response.Equals("Yes", StringComparison.OrdinalIgnoreCase);
                        }
                        break;
                    case 2:
                        bool continueRemoving = true;
                        while (continueRemoving)
                        {
                            Console.WriteLine("Current Tree Values:");
                            ListTreeValues();

                            Console.Write("\nEnter a value to remove: ");
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

                            Console.Write("\nRemove another? (Y/N): ");
                            var response = Console.ReadLine();
                            continueRemoving = response.Equals("Y", StringComparison.OrdinalIgnoreCase) || response.Equals("Yes", StringComparison.OrdinalIgnoreCase);
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
                        Console.Write("\nEnter the number of nodes to generate: ");
                        if (int.TryParse(Console.ReadLine(), out int nodeCount))
                        {
                            bool printExcessive = false;
                            var rand = new Random();
                            var existingValues = new HashSet<int>();
                            // Adjust the range to be from 1 to 2 times the nodeCount
                            int rangeMax = nodeCount * 2; // Ensuring the range is twice the node count
                            while (existingValues.Count < nodeCount)
                            {
                                int newValue = rand.Next(1, rangeMax + 1); // Adjust the range here
                                if (existingValues.Add(newValue)) // Ensures only unique values are added
                                {
                                    bst.Insert(newValue);
                                    TrackInsertedValues(newValue); // Assuming you want to track these as well
                                }
                            }

                            Console.WriteLine("\nRandom Tree Generated with Unique Values:");
                            if (nodeCount <= 50)
                            {
                                Console.WriteLine("\nNode Values in the order that they were inserted:");
                                ListTreeValues();

                                Console.WriteLine("\nIn-Order Traversal of the BST:");
                                bst.InOrderTraversal();

                                bst.PrintTree();
                            }
                            else
                            {
                                Console.WriteLine($"\n**Excessive Node Count({nodeCount}) Detected**");
                                Console.WriteLine("\nWould you like to print the values anyway? (May impact PC performance).");
                                Console.Write("\nMy PC is a BEAST (Y) / Never Mind (N): ");
                                var response = Console.ReadLine();
                                printExcessive = response.Equals("Y", StringComparison.OrdinalIgnoreCase) || response.Equals("Yes", StringComparison.OrdinalIgnoreCase);

                                if (printExcessive)
                                {
                                    Console.WriteLine("\nNode Values in the order that they were inserted:");
                                    ListTreeValues();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                        }
                        break;
                    case 5:
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