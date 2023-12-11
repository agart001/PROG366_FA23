using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG366_Assignment7_WF
{
    public partial class TreeVisualizer<T> : Form where T : IComparable<T>
    {
        private Tree<T> tree;

        public TreeVisualizer(Tree<T> tree)
        {
            InitializeComponent();

            // Initialize the tree with the provided tree.
            this.tree = tree;

            // Set up the form and draw the tree.
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Set the form properties.
            Text = "Tree Visualizer";
            Size = new Size(1000, 1800);
            CenterToScreen();

            // Handle the Paint event to draw the tree.
            Paint += TreeVisualizerForm_Paint;
        }

        public void UpdateTree(Tree<T> newTree)
        {
            // Update the tree and redraw.
            tree = newTree;
            Invalidate(); // Forces a repaint of the form.
        }

        private void TreeVisualizerForm_Paint(object sender, PaintEventArgs e)
        {
            // Draw the tree on the form.
            DrawTree(e.Graphics, tree.Root, ClientSize.Width / 2, 50, 200, 50);
        }

        private void DrawTree(Graphics graphics, Node<T>? currentNode, int x, int y, int xOffset, int yOffset)
        {
            if (currentNode != null)
            {
                graphics.FillEllipse(Brushes.LightBlue, x - 15, y - 15, 30, 30);
                graphics.DrawEllipse(Pens.Black, x - 15, y - 15, 30, 30);
                graphics.DrawString(currentNode.GetData().ToString(), Font, Brushes.Black, x - 7, y - 7);

                // Draw lines to the left and right children.
                if (currentNode.GetLeftChild() != null)
                {
                    int leftX = x - xOffset;
                    int leftY = y + 15 + yOffset;
                    graphics.DrawLine(Pens.Black, x, y + 15, leftX, leftY);
                    DrawTree(graphics, currentNode.GetLeftChild(), leftX, leftY, xOffset / 2, yOffset);
                }

                if (currentNode.GetRightChild() != null)
                {
                    int rightX = x + xOffset;
                    int rightY = y + 15 + yOffset;
                    graphics.DrawLine(Pens.Black, x, y + 15, rightX, rightY);
                    DrawTree(graphics, currentNode.GetRightChild(), rightX, rightY, xOffset / 2, yOffset);
                }
            }
        }

    }
}


