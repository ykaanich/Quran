using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Quran
{
    public partial class Frm_CodeLecteur : Form
    {
        public Frm_CodeLecteur()
        {
            InitializeComponent();
        }

        public Frm_CodeLecteur(string Mode, string IdCodeLecteur)
        {
            // TODO: Complete member initialization
            this.Mode = Mode;
            this.IdCodeLecteur = IdCodeLecteur;
            InitializeComponent();
        }
        XmlDocument xml_docLecteur = new XmlDocument();
        string Mode = "";
        string IdCodeLecteur = "";
        string nomCodeLecteur { get; set; }
        XmlNode cas;
        private void Frm_CodeLecteur_Load(object sender, EventArgs e)
        {
            xml_docLecteur.Load("lecteurstree.xml");
            //dans le cas de modification
            if (Mode == "Modif")
            {
                btAjout.Text = "تعديل";
                label1.Text = "تعديل رموز القراء";
                this.Text = " تعديل رموز القراء";
                XmlDocument doc = new XmlDocument();
                doc.Load("CodeLecteur.xml");
                cas = doc.SelectSingleNode("/CodeLecteur/CodeLecteur[IdCodeLecteur='" + IdCodeLecteur + "']");
                txt_nom.Text =  cas.ChildNodes.Item(1).InnerText;
                if (cas.ChildNodes.Item(2).InnerText == "كبرى")
                    ckGrand.Checked = true;
                else
                    ckPetit.Checked = true;
            }
            else
                ckGrand.Checked = true;
        }
        private void AddTreeViewChildNodes(TreeNodeCollection parent_nodes, XmlNode xml_node)
        {
            foreach (XmlNode child_node in xml_node.ChildNodes)
            {
                // Make the new TreeView node.
                TreeNode new_node = new TreeNode();
                new_node.Name = child_node.Attributes[0].Value;
                new_node.Text = child_node.Attributes[2].Value;
                if (Mode == "Modif")
                {
                    XmlNode mynode = cas.ChildNodes.Item(5);
                    XmlNode myliste = mynode.SelectSingleNode("/CodeLecteur/CodeLecteur[IdCodeLecteur='" + IdCodeLecteur + "']" + "/ListLecteur/Lecteur[IdLecteur='" + new_node.Name + "']");
                    if (myliste != null)//chercher s'il y a le lecteur dans la liste dans lemode modification
                        new_node.Checked = true;
                }
                parent_nodes.Add(new_node);

                // Recursively make this node's descendants.
                AddTreeViewChildNodes(new_node.Nodes, child_node);

                // If this is a leaf node, make sure it's visible.
                if (new_node.Nodes.Count == 0) new_node.EnsureVisible();
            }
        }
        private void AddTreeViewChildNodesPetit(TreeNodeCollection parent_nodes, XmlNode xml_node)
        {
            foreach (XmlNode child_node in xml_node.ChildNodes)
            {
                // Make the new TreeView node.
                TreeNode new_node = parent_nodes.Add(child_node.Attributes[0].Value, child_node.Attributes[2].Value);
                if (Mode == "Modif")
                {
                    XmlNode mynode = cas.ChildNodes.Item(5);
                    XmlNode myliste = mynode.SelectSingleNode("/CodeLecteur/CodeLecteur[IdCodeLecteur='" + IdCodeLecteur + "']" + "/ListLecteur/Lecteur[IdLecteur='" + new_node.Name + "']");
                    if (myliste != null)//chercher s'il y a le lecteur dans la liste dans lemode modification
                        new_node.Checked = true;
                }
                foreach (XmlNode child_node2 in child_node.ChildNodes)
                {
                    // Make the new TreeView node.
                    TreeNode new_node2 = new_node.Nodes.Add(child_node2.Attributes[0].Value, child_node2.Attributes[2].Value);
                    if (Mode == "Modif")
                    {
                        XmlNode mynode = cas.ChildNodes.Item(5);
                        XmlNode myliste = mynode.SelectSingleNode("/CodeLecteur/CodeLecteur[IdCodeLecteur='" + IdCodeLecteur + "']" );
                        if (myliste != null)//chercher s'il y a le lecteur dans la liste dans lemode modification
                            new_node2.Checked = true;
                    }

                }
            }



        }
        private void ckGrand_CheckedChanged(object sender, EventArgs e)
        {
            if (ckGrand.Checked == true)
            {
                treeVLecteur.Nodes.Clear();
                AddTreeViewChildNodes(treeVLecteur.Nodes, xml_docLecteur.DocumentElement);
                treeVLecteur.CollapseAll();
            }
        }

        private void ckPetit_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPetit.Checked == true)
            {
                treeVLecteur.Nodes.Clear();
                AddTreeViewChildNodesPetit(treeVLecteur.Nodes, xml_docLecteur.DocumentElement);
                treeVLecteur.CollapseAll();
            }
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        CodeLecteur myCodeLecteur;
        private string p1;
        private string p2;
        private void btAjout_Click(object sender, EventArgs e)
        {
            if (txt_nom.Text.Trim() == "")
                MessageBox.Show("الرجاء اختيار اسم رموز القراء");
            else
            {
                myCodeLecteur = new  CodeLecteur();

                myCodeLecteur.nomCodeLecteur = txt_nom.Text;

                if (ckGrand.Checked)
                    myCodeLecteur.TypeGroupment = "كبرى";
                else
                    myCodeLecteur.TypeGroupment = "صغرى";
                myCodeLecteur.ListLecteur = new List<Lecteur>();

                GetCheckedNodes(treeVLecteur.Nodes);

                    XmlDocument doc = new XmlDocument();
                    doc.Load("CodeLecteur.xml"); // Load xml file data to xmlDocument
                    if (Mode == "Modif")//recherer et supprimer avant d'ajouter
                    {
                        XmlNode cas = doc.SelectSingleNode("/CodeLecteur/CodeLecteur[IdCodeLecteur='" + IdCodeLecteur + "']");
                        myCodeLecteur.IdCodeLecteur = IdCodeLecteur;
                        doc.ChildNodes[1].RemoveChild(cas);
                    }
                    else
                        myCodeLecteur.IdCodeLecteur = Guid.NewGuid().ToString("N"); ;
                    XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "CodeLecteur", null);
                    XmlSerializer xSeriz = new XmlSerializer(typeof(CodeLecteur));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlWriterSettings writtersetting = new XmlWriterSettings();
                    writtersetting.OmitXmlDeclaration = true;
                    StringWriter stringwriter = new StringWriter();
                    using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
                    {
                        xSeriz.Serialize(xmlwriter, myCodeLecteur, ns);
                    }
                    xnode.InnerXml = stringwriter.ToString();
                    XmlNode bindxnode = xnode.SelectSingleNode("CodeLecteur");
                    doc.DocumentElement.AppendChild(bindxnode);


                    doc.Save("CodeLecteur.xml");
            

                MessageBox.Show("تمت العملية بنجاح");
                Close();
            }
        }
        public void GetCheckedNodes(TreeNodeCollection nodes)
        {
            foreach (System.Windows.Forms.TreeNode aNode in nodes)
            {
                //edit
                if (aNode.Checked)
                {
                    Lecteur mylecteur = new Lecteur();
                    mylecteur.IdLecteur = Convert.ToInt32(aNode.Name);
                    mylecteur.NomLecteur = aNode.Text;
                    myCodeLecteur.NomLecteur+=aNode.Text+",";
                    myCodeLecteur.ListeCodeLecteur+=aNode.Name+",";
                    myCodeLecteur.ListLecteur.Add(mylecteur);
                }
                if (aNode.Nodes.Count != 0)
                    GetCheckedNodes(aNode.Nodes);
            }
        }
    }
}
