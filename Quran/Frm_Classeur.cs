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
    public partial class Frm_Classeur : Form
    {
        public Frm_Classeur()
        {
            InitializeComponent();
        }

        public Frm_Classeur(string Mode,string idClasseur, string nomClasseur)
        {

            this.Mode = Mode;
            this.idClasseur = idClasseur;
            this.nomClasseur = nomClasseur;
            InitializeComponent();
        }
        string Mode = "";
        string idClasseur = "";
         string nomClasseur { get; set; }
        XmlDocument xml_docLecteur = new XmlDocument();
        XmlNode cas;
        private void Frm_Classeur_Load(object sender, EventArgs e)
        {  
         
            xml_docLecteur.Load("lecteurstree.xml");

            //dans le cas de modification
            if (Mode == "Modif")
            {
                btAjout.Text = "تعديل";
                label1.Text = "تعديل كراس العمل";
                this.Text = " تعديل كراس العمل";
                XmlDocument doc = new XmlDocument();
                doc.Load("Classeur.xml");
                cas = doc.SelectSingleNode("/Classeur/Classeur[IdClasseur='" + idClasseur + "']");
                txt_nom.Text = nomClasseur;
                txt_remarque.Text = cas.ChildNodes.Item(2).InnerText;
                if (cas.ChildNodes.Item(3).InnerText == "كبرى")
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
                TreeNode  new_node = new TreeNode();
                new_node.Name=child_node.Attributes[0].Value;
                new_node.Text= child_node.Attributes[2].Value;
                if (Mode == "Modif")
                {
                    XmlNode mynode = cas.ChildNodes.Item(4);
                    XmlNode myliste = mynode.SelectSingleNode("/Classeur/Classeur[IdClasseur='" + idClasseur + "']" + "/ListLecteur/Lecteur[IdLecteur='" + new_node.Name + "']");
                    if (myliste!=null)//chercher s'il y a le lecteur dans la liste dans lemode modification
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
                    XmlNode mynode = cas.ChildNodes.Item(4);
                    XmlNode myliste = mynode.SelectSingleNode("/Classeur/Classeur[IdClasseur='" + idClasseur + "']" + "/ListLecteur/Lecteur[IdLecteur='" + child_node.Attributes[0].Value + "']");
                    if (myliste != null)//chercher s'il y a le lecteur dans la liste dans lemode modification
                        new_node.Checked = true;
                }
                foreach (XmlNode child_node2 in child_node.ChildNodes)
                {
                    // Make the new TreeView node.
                    TreeNode new_node2 = new_node.Nodes.Add(child_node2.Attributes[0].Value, child_node2.Attributes[2].Value);
                    if (Mode == "Modif")
                    {
                        XmlNode mynode = cas.ChildNodes.Item(4);
                        XmlNode myliste = mynode.SelectSingleNode("/Classeur/Classeur[IdClasseur='" + idClasseur + "']" + "/ListLecteur/Lecteur[IdLecteur='" + child_node2.Attributes[0].Value + "']");
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
        Classeur myclasseur;
        private string p1;
        private string p2;
        private void btAjout_Click(object sender, EventArgs e)
        {
            if (txt_nom.Text.Trim() == "")
                MessageBox.Show("الرجاء اختيار اسم الكراس");
            else
            {
                myclasseur = new Classeur();

                myclasseur.nomClasseur = txt_nom.Text;
                myclasseur.Remarque = txt_remarque.Text;
                if (ckGrand.Checked)
                    myclasseur.TypeGroupment = "كبرى";
                else
                    myclasseur.TypeGroupment = "صغرى";
                myclasseur.ListLecteur = new List<Lecteur>();

                GetCheckedNodes(treeVLecteur.Nodes);
                if (!File.Exists("Classeur.xml")) //check file exist or not
                {

                    XmlSerializer xSeriz = new XmlSerializer(typeof(Classeur));

                    FileStream fs = File.Open("Classeur.xml", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);


                    xSeriz.Serialize(fs, myclasseur);
                    fs.Close();


                }
                else //if file exist ie already have xml data
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("Classeur.xml"); // Load xml file data to xmlDocument
                    if (Mode == "Modif")//recherer et supprimer avant d'ajouter
                    {
                        XmlNode cas = doc.SelectSingleNode("/Classeur/Classeur[IdClasseur='" + idClasseur + "']");
                        myclasseur.IdClasseur = idClasseur;
                        doc.ChildNodes[1].RemoveChild(cas);
                    }
                    else
                        myclasseur.IdClasseur = Guid.NewGuid().ToString("N"); ;
                    XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "Classeur", null);
                    XmlSerializer xSeriz = new XmlSerializer(typeof(Classeur));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlWriterSettings writtersetting = new XmlWriterSettings();
                    writtersetting.OmitXmlDeclaration = true;
                    StringWriter stringwriter = new StringWriter();
                    using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
                    {
                        xSeriz.Serialize(xmlwriter, myclasseur, ns);
                    }
                    xnode.InnerXml = stringwriter.ToString();
                    XmlNode bindxnode = xnode.SelectSingleNode("Classeur");
                    doc.DocumentElement.AppendChild(bindxnode);


                    doc.Save("Classeur.xml");
                }

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
                    Lecteur mylecteur=new Lecteur();
                    mylecteur.IdLecteur=Convert.ToInt32( aNode.Name);
                    mylecteur.NomLecteur=aNode.Text;
                    myclasseur.ListLecteur.Add(mylecteur);
                }
                if (aNode.Nodes.Count != 0)
                    GetCheckedNodes(aNode.Nodes);
            }
        }

        private void CheckTreeViewNode(TreeNode node, Boolean isChecked)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;

                if (item.Nodes.Count > 0)
                {
                    this.CheckTreeViewNode(item, isChecked);
                }
            }
        }

        private void treeVLecteur_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckTreeViewNode(e.Node, e.Node.Checked);
        }
    }
}
