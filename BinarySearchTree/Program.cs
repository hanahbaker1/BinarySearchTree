namespace BinarySearchTree;

public class Program
{
    public static void Main()
    {
        var root = new Node(30);
        var n1 = new Node(15);
        var n2 = new Node(45);
        var n3 = new Node(6);
        var n4 = new Node(41);
        var n5 = new Node(54);

        root.LeftChild = n1;
        root.RightChild = n2;
        n1.LeftChild = n3;
        n2.LeftChild = n4;
        n2.RightChild = n5;

        var value = Console.ReadLine();
        var tryParse = int.TryParse(value, out int intValue);
        if (!tryParse)
        {
            Console.WriteLine("not a number innit");
        }
        else
        {
            var nodeToFind = BinarySearchTree.Search(root, intValue);

            if (nodeToFind is null)
            {
                nodeToFind = BinarySearchTree.Insert(root, intValue);
            }

            //Console.WriteLine(nodeToFind.RightChild?.RightChild?.RightChild?.Value);
            Console.WriteLine("InOrderTraversal");
            BinarySearchTree.InOrderTraversal(nodeToFind);

            Console.WriteLine("PostOrderTraversal");
            BinarySearchTree.PostOrderTraversal(nodeToFind);

            Console.WriteLine("PreOrderTraversal");
            BinarySearchTree.PreOrderTraversal(nodeToFind);
        }
    }
}

public class Node
{
    public int Value;
    public Node? LeftChild;
    public Node? RightChild;

    public Node(int value)
    {
        Value = value;
    }
}

public class BinarySearchTree
{
    public static Node? Search(Node? root, int value)
    {
        if (root?.Value == value)
        {
            return root;
        }

        if (value < root?.Value)
        {//go left
            root = Search(root.LeftChild, value);
        }

        if (value > root?.Value)
        {//go right
            root = Search(root.RightChild, value);
        }

        return root;
    }

    public static Node Insert(Node root, int value)
    {
        if (root.Value == value)
        {
            return root;
        }

        if (value < root.Value)
        {//go left
            if (root.LeftChild is not null)
            {
                root.LeftChild = Insert(root.LeftChild, value);
            }
            else
            {
                var newNode = new Node(value);
                root.LeftChild = newNode;
            }
            
        }

        if (value > root.Value)
        {//go right
            if (root.RightChild is not null)
            {
                root.RightChild = Insert(root.RightChild, value);
            }
            else
            {
                var newNode = new Node(value);
                root.RightChild = newNode;
            }
        }

        return root;
    }

    public static void InOrderTraversal(Node root)
    {
        if (root.LeftChild is not null)
        {
            InOrderTraversal(root.LeftChild);
        }

        Console.WriteLine(root.Value);

        if (root.RightChild is not null)
        {
            InOrderTraversal(root.RightChild);
        }
    }

    public static void PostOrderTraversal(Node root)
    {
        if (root.LeftChild is not null)
        {
            PostOrderTraversal(root.LeftChild);
        }
        if (root.RightChild is not null)
        {
            PostOrderTraversal(root.RightChild);
        }

        Console.WriteLine(root.Value);
    }

    public static void PreOrderTraversal(Node root)
    {
        Console.WriteLine(root.Value);

        if (root.LeftChild is not null)
        {
            PreOrderTraversal(root.LeftChild);
        }
       
        if (root.RightChild is not null)
        {
            PreOrderTraversal(root.RightChild);
        }
    }
}