using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Quran
{   
    public partial class Frm_Lecteur : Form
    {
        public Frm_Lecteur()
        {
            InitializeComponent();
        }

        private void Frm_Lecteur_Load(object sender, EventArgs e)
        {
            // Load the XML document.
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load("lecteurstree.xml");

            // Add the root node's children to the TreeView.

            AddTreeViewChildNodes(treeVLecteur5.Nodes, xml_doc.DocumentElement,100,2000);
            AddTreeViewChildNodes(treeVLecteur4.Nodes, xml_doc.DocumentElement,2000,4000);
            AddTreeViewChildNodes(treeVLecteur3.Nodes, xml_doc.DocumentElement,4000,6000); 
            AddTreeViewChildNodes(treeVLecteur2.Nodes, xml_doc.DocumentElement,6000,8000); 
            AddTreeViewChildNodes(treeVLecteur.Nodes, xml_doc.DocumentElement,8000,10000);    
       
        }
        private void AddTreeViewChildNodes(TreeNodeCollection parent_nodes, XmlNode xml_node,int indexMin,int indexMax)
        {
            foreach (XmlNode child_node in xml_node.ChildNodes)
            { 
                int index =Convert.ToInt16( child_node.Attributes[0].Value);
                if (index>=indexMin && index<indexMax)
                {              
                    // Make the new TreeView node.
                    TreeNode new_node = parent_nodes.Add(child_node.Attributes[0].Value,child_node.Attributes[2].Value);
                    if (index.ToString().Contains("000"))
                    {
                        Font boldFont = new Font(treeVLecteur5.Font, FontStyle.Bold);
                        new_node.NodeFont = boldFont;
                        new_node.Text = child_node.Attributes[2].Value;
                    }
                    // Recursively make this node's descendants.
                    AddTreeViewChildNodes(new_node.Nodes, child_node,indexMin, indexMax);
                // If this is a leaf node, make sure it's visible.
                if (new_node.Nodes.Count == 0) new_node.EnsureVisible();
                }

            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btValider_Click(object sender, EventArgs e)
        {
            GetCheckedNodes(treeVLecteur.Nodes);  
            GetCheckedNodes(treeVLecteur2.Nodes); 
            GetCheckedNodes(treeVLecteur3.Nodes);  
            GetCheckedNodes(treeVLecteur4.Nodes); 
            GetCheckedNodes(treeVLecteur5.Nodes);
            Close();
        }
        public List<int> listChecked = new List<int>();
        public void GetCheckedNodes(TreeNodeCollection nodes)
        {
            foreach (System.Windows.Forms.TreeNode aNode in nodes)
            {
                //edit
                if (aNode.Checked)
                {
                    listChecked.Add(Convert.ToInt16( aNode.Name));
                    
                }
                if (aNode.Nodes.Count != 0)
                    GetCheckedNodes(aNode.Nodes);
            }
        }
    }
}