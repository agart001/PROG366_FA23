using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace PROG366_Assignment7_WF
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            int[] unsortedscores = File.ReadAllLines($"{Directory.GetCurrentDirectory()}\\scores.txt").Select(s => int.Parse(s)).ToArray();

            Tree<int> tree = new Tree<int>();
            if(BoolQuestion("Sort and Visualize Data", "y", "n"))
            {
                int[] sorted = unsortedscores.OrderBy(s => s).ToArray();
                PopulateTree(tree, sorted);
            }
            else
            {
                PopulateTree(tree, unsortedscores);
            }

            TreeVisualizer<int> visual = new TreeVisualizer<int>(tree);

            Application.Run(visual);
        }

        static bool BoolQuestion(string question, string confirm, string cancel)
        {
            var result = MessageBox.Show($"{question}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        static void PopulateTree<T>(Tree<T> tree, T[] data) where T : IComparable<T>
        {
            foreach(T point in data)
            {
                tree.AddNode(new Node<T>(point));
            }
        }
    }


    #region Classes

    #region BaseSerializable

    /// <summary>
    /// Provides a base implementation of the <see cref="ISerializable"/> interface.
    /// </summary>
    public abstract class BaseSerializable : ISerializable
    {
        #region ISerializable Implementation
        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> object with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="StreamingContext"/>) for this serialization.</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // The base implementation does not provide any serialization data.
            // This method is marked as virtual to allow derived classes to implement their own serialization logic.

            // Throw an exception indicating that the serialization is not implemented.
            throw new NotImplementedException();
        }
        #endregion
    }

    #endregion

    #region Node<T>

    /// <summary>
    /// Represents a generic tree node that stores data of type T.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the node.</typeparam>
    public class Node<T> : BaseSerializable where T : IComparable<T>
    {
        #region Structure

        /// <summary>
        /// Unique identifier for the node, generated using a new GUID.
        /// </summary>
        string ID = Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");

        /// <summary>
        /// Data stored in the node.
        /// </summary>
        T Data;

        /// <summary>
        /// Reference to the parent node.
        /// </summary>
        Node<T>? Parent = null;

        /// <summary>
        /// Reference to the left child node.
        /// </summary>
        Node<T>? LeftChild = null;

        /// <summary>
        /// Reference to the right child node.
        /// </summary>
        Node<T>? RightChild = null;

        /// <summary>
        /// Constructor to initialize a new node with the given data.
        /// </summary>
        /// <param name="data">The data to be stored in the node.</param>
        public Node(T data)
        {
            Data = data;
        }
        #endregion

        #region Functionality

        #region Node Data

        /// <summary>
        /// Gets the unique identifier of the node.
        /// </summary>
        /// <returns>The unique identifier of the node.</returns>
        public string GetID() => ID;

        /// <summary>
        /// Sets the data of the node.
        /// </summary>
        /// <param name="data">The data to be set in the node.</param>
        public void SetData(T data) => Data = data;

        /// <summary>
        /// Gets the data stored in the node.
        /// </summary>
        /// <returns>The data stored in the node.</returns>
        public T GetData() => Data;

        #endregion

        #region Relational Data

        #region Parent

        /// <summary>
        /// Sets the parent node of the current node.
        /// </summary>
        /// <param name="parent">The parent node to be set.</param>
        public void SetParent(Node<T> parent) => Parent = parent;

        /// <summary>
        /// Gets the parent node of the current node.
        /// </summary>
        /// <returns>The parent node of the current node.</returns>
        public Node<T>? GetParent() => Parent;

        #endregion

        #region Left Child

        /// <summary>
        /// Sets the left child node of the current node.
        /// </summary>
        /// <param name="left">The left child node to be set.</param>
        public void SetLeftChild(Node<T> left)
        {
            LeftChild = left;
            if (LeftChild != null) { LeftChild.SetParent(this); }
        }

        /// <summary>
        /// Gets the left child node of the current node.
        /// </summary>
        /// <returns>The left child node of the current node.</returns>
        public Node<T>? GetLeftChild() => LeftChild;

        #endregion

        #region Right Child

        /// <summary>
        /// Sets the right child node of the current node.
        /// </summary>
        /// <param name="right">The right child node to be set.</param>
        public void SetRightChild(Node<T> right)
        {
            RightChild = right;
            if (RightChild != null) { RightChild.SetParent(this); }
        }

        /// <summary>
        /// Gets the right child node of the current node.
        /// </summary>
        /// <returns>The right child node of the current node.</returns>
        public Node<T>? GetRightChild() => RightChild;

        #endregion

        #endregion

        #region Apply

        /// <summary>
        /// Applies an action to the data of the node.
        /// </summary>
        /// <param name="action">The action to be applied to the data.</param>
        public void Apply(Action<T> action) => action(Data);

        /// <summary>
        /// Applies an action to the current node.
        /// </summary>
        /// <param name="action">The action to be applied to the node.</param>
        public void Apply(Action<Node<T>> action) => action(this);

        #endregion

        #region Json

        /// <summary>
        /// Converts the node to a JSON string representation.
        /// </summary>
        /// <returns>A JSON string representing the node and its data.</returns>
        public string ToJson()
        {
            string parent = string.Empty;
            string left = string.Empty;
            string right = string.Empty;

            if (Parent != null)
            {
                parent = Parent.GetID();
            }

            if (LeftChild != null)
            {
                left = LeftChild.GetID();
            }

            if (RightChild != null)
            {
                right = RightChild.GetID();
            }

            var json = new
            {
                ID = ID,
                Data = Data.ToString(),
                Parent = parent,
                LeftChild = left,
                RightChild = right
            };
            return JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);
        }

        #endregion

        #endregion
    }

    #endregion

    #region Tree<T>

    /// <summary>
    /// Represents a generic tree data structure.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the tree, must implement <see cref="IComparable{T}"/>.</typeparam>
    public class Tree<T> : BaseSerializable where T : IComparable<T>
    {
        #region Structure
        /// <summary>
        /// Gets or sets the count of nodes in the tree.
        /// </summary>
        public int Count = 0;

        /// <summary>
        /// Gets or sets the root node of the tree.
        /// </summary>
        public Node<T>? Root;
        #endregion

        #region Functionality

        #region Add Node

        /// <summary>
        /// Adds a node to the tree.
        /// </summary>
        /// <param name="node">The node to be added.</param>
        public void AddNode(Node<T> node)
        {
            // If the root is null, set the root to the new node.
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                // Otherwise, recursively add the node to the tree.
                AddNode(Root, node);
            }

            // Increment the count of nodes.
            Count++;
        }

        /// <summary>
        /// Recursively adds a node to the tree.
        /// </summary>
        /// <param name="currentNode">The current node being considered.</param>
        /// <param name="newNode">The new node to be added.</param>
        private void AddNode(Node<T> currentNode, Node<T> newNode)
        {
            // Compare the data of the new node with the data of the current node.
            if (newNode.GetData().CompareTo(currentNode.GetData()) < 0)
            {
                var left = currentNode.GetLeftChild();
                // If less, go to the left child.
                if (left == null)
                {
                    currentNode.SetLeftChild(newNode);
                }
                else
                {
                    // Recursively add the node to the left subtree.
                    AddNode(left, newNode);
                }
            }
            else
            {
                var right = currentNode.GetRightChild();
                // If greater or equal, go to the right child.
                if (right == null)
                {
                    currentNode.SetRightChild(newNode);
                }
                else
                {
                    // Recursively add the node to the right subtree.
                    AddNode(right, newNode);
                }
            }
        }

        #endregion

        #region Traverse

        #region Traverse (Action)

        #region Action<T>

        /// <summary>
        /// Traverses the tree and applies an action to each element.
        /// </summary>
        /// <param name="action">The action to be applied to each element.</param>
        public void Traverse(Action<T> action)
        {
            TraverseNodes(Root, action);
        }

        /// <summary>
        /// Recursively traverses the nodes of the tree and applies an action to each element.
        /// </summary>
        /// <param name="node">The current node being considered.</param>
        /// <param name="action">The action to be applied to each element.</param>
        private void TraverseNodes(Node<T>? node, Action<T> action)
        {
            // If the node is not null, traverse its left child, apply the action, and traverse its right child.
            if (node != null)
            {
                if (node.GetLeftChild() != null) { TraverseNodes(node.GetLeftChild(), action); }
                node.Apply(action);
                if (node.GetRightChild() != null) { TraverseNodes(node.GetRightChild(), action); }
            }
        }

        #endregion

        #region Action<Node<T>>

        /// <summary>
        /// Traverses the tree and applies an action to each node.
        /// </summary>
        /// <param name="action">The action to be applied to each node.</param>
        public void Traverse(Action<Node<T>> action)
        {
            TraverseNodes(Root, action);
        }

        /// <summary>
        /// Recursively traverses the nodes of the tree and applies an action to each node.
        /// </summary>
        /// <param name="node">The current node being considered.</param>
        /// <param name="action">The action to be applied to each node.</param>
        private void TraverseNodes(Node<T>? node, Action<Node<T>> action)
        {
            // If the node is not null, traverse its left child, apply the action, and traverse its right child.
            if (node != null)
            {
                if (node.GetLeftChild() != null) { TraverseNodes(node.GetLeftChild(), action); }
                node.Apply(action);
                if (node.GetRightChild() != null) { TraverseNodes(node.GetRightChild(), action); }
            }
        }

        #endregion

        #endregion

        #region Traverse (Func)

        #region Func<Node<T>, O>

        /// <summary>
        /// Traverses the tree and applies a function to each node, collecting the results in a list.
        /// </summary>
        /// <typeparam name="O">The type of the results collected by the function.</typeparam>
        /// <param name="action">The function to be applied to each node.</param>
        /// <returns>An array of results collected from each node.</returns>
        public O[] Traverse<O>(Func<Node<T>, O> action)
        {
            if(Root == null) throw new ArgumentNullException(nameof(Root));

            // Initialize a list to collect the results.
            List<O> result = new List<O>();

            // Start the traversal from the root node.
            TraverseNodes(Root, action, result);

            // Convert the list to an array and return.
            return result.ToArray();
        }

        /// <summary>
        /// Recursively traverses the nodes of the tree and applies a function to each node, collecting the results in a list.
        /// </summary>
        /// <typeparam name="O">The type of the results collected by the function.</typeparam>
        /// <param name="node">The current node being considered.</param>
        /// <param name="action">The function to be applied to each node.</param>
        /// <param name="result">The list to collect the results.</param>
        private void TraverseNodes<O>(Node<T> node, Func<Node<T>, O> action, List<O> result)
        {
            // If the node is not null, apply the function, and recursively traverse its left and right children.
            if (node != null)
            {
                result.Add(action(node));
                var left = node.GetLeftChild();
                var right = node.GetRightChild(); 
                if (left != null) { TraverseNodes(left, action, result); }
                if (right!= null) { TraverseNodes(right, action, result); }
            }
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }

    #endregion

    #endregion


}