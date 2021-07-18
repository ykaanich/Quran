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
    public partial class Frm_Exclusion : Form
    {
        string Mode = "Ajout";
        string NomExclusion = "";
        XmlDocument xml_Exclusion = new XmlDocument();
        public Frm_Exclusion()
        {
            InitializeComponent();
        }
        public Frm_Exclusion(string Mode, string NomExclusion)
        {
            this.Mode = Mode;
            this.NomExclusion = NomExclusion;
            InitializeComponent();
        }
        DataSet dsListDifference = new DataSet();
        TreeNode TreeListeLecteur;
        List<List<string>> ListTableDifference = new List<List<string>>();
        List<List<int>> intersect = new List<List<int>>();
        List<intersection> MyIntersect = new List<intersection>();
        XmlDocument xml_doc = new XmlDocument();
        string[] TableDifference;
        string[] IdDifference;
        int compteur;
        private void Frm_Exclusion_Load(object sender, EventArgs e)
        {
            dsListDifference.ReadXml("Difference.xml", XmlReadMode.InferSchema);
            dsListDifference.Tables[0].DefaultView.RowFilter = "IdClasseur = '" + Program.IdClasseur + "'";
            dtDifference.DataSource = dsListDifference.Tables[0].DefaultView.ToTable();
            dtDifference.DisplayMember = "Nom";
            dtDifference.ValueMember = "Difference_id";
            dtDifference.Text = "";
            TreeListeLecteur = new TreeNode();

            xml_doc.Load("lecteurstree.xml");
            AddTreeViewChildNodes(TreeListeLecteur.Nodes, xml_doc.DocumentElement);
            if (Mode == "Modif")
            {
                btAjout.Text = "تعديل";
                label1.Text = "تعديل امتناع";
                this.Text = " تعديل امتناع";
                xml_Exclusion.Load("Exclusions.xml");
                XmlNode cas = xml_Exclusion.SelectSingleNode("/ListExclusions/Exclusions[id='" + NomExclusion + "']");
                foreach (XmlNode item in cas.ChildNodes.Item(1))//parcourir differenceCas et les affichers
                {
                    dtDifference.Text = item.FirstChild.InnerText;
                    if( dtDifference.Text!="" )
                        dtDifference_KeyUp(null, new KeyEventArgs(Keys.Enter));//pour le remplir dans la tree
                    foreach (XmlNode item1 in item.LastChild)
                    {
                        TreeNode[] trdetail = treeVdifference.Nodes.Find(item.FirstChild.InnerText, false);//chercher parmis les elements 
                        if (trdetail.Length > 0)
                        {
                             foreach (TreeNode itemcheck in trdetail[0].Nodes)
                                 if (itemcheck.Text == item1.InnerText)
                                     itemcheck.Checked = true;
                        }

                    }

                }
                 btGenerer_Click(null, null);//pour generer le Exclusions
                foreach (XmlNode item in cas.ChildNodes.Item(2))//parcourir differenceCas et les affichers
                {  
                    //selectionner parmi les elements 
                     TreeNode[] trdetail = treeVResultat.Nodes.Find(item.FirstChild.InnerText, true);//chercher parmis les elements 
                     if (trdetail.Length > 0)
                         trdetail[0].Checked = true;
                }
            }

        }
        private void AddTreeViewChildNodes(TreeNodeCollection parent_nodes, XmlNode xml_node)
        {
            foreach (XmlNode child_node in xml_node.ChildNodes)
            {
                // Make the new TreeView node.
                TreeNode new_node = parent_nodes.Add(child_node.Attributes[0].Value, child_node.Attributes[2].Value);
                new_node.Tag = child_node.Attributes[1].Value;
                // Recursively make this node's descendants.
                AddTreeViewChildNodes(new_node.Nodes, child_node);

                // If this is a leaf node, make sure it's visible.
                if (new_node.Nodes.Count == 0) new_node.EnsureVisible();
            }
        }
        bool copie = false;
        private void AddTreeViewChildNodes(TreeNodeCollection parent_nodes, XmlNode xml_node,string index)
        {
            foreach (XmlNode child_node in xml_node.ChildNodes)
            {
                if (child_node.Attributes[0].Value == index || copie == true)
                {
                    // Recursively make this node's descendants.
                    copie = true;
                    if (child_node.Attributes[0].Value == index)// pour ne pas copier le meme nom
                        AddTreeViewChildNodes(parent_nodes, child_node, index);
                    else
                    {
                        // Make the new TreeView node.
                        TreeNode new_node = parent_nodes.Add(child_node.Attributes[0].Value, child_node.Attributes[2].Value);
                        new_node.Tag = child_node.Attributes[1].Value;
                        AddTreeViewChildNodes(new_node.Nodes, child_node, index);
                        if (new_node.Nodes.Count == 0) new_node.EnsureVisible();
                    }

                    // If this is a leaf node, make sure it's visible.

                }
                else //pour parcourir tous les enfants
                    AddTreeViewChildNodes(parent_nodes, child_node, index);

                if (child_node.Attributes[0].Value == index)
                    copie = false;
            }

        }
        private void dtDifference_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dsListDifference.Tables["difference"].DefaultView.RowFilter = "IdClasseur = '" + Program.IdClasseur + "' and nom='" + dtDifference.Text + "'";
                string idlistcas = dsListDifference.Tables["difference"].DefaultView.ToTable().Rows[0]["difference_id"].ToString();

                dsListDifference.Tables["cas"].DefaultView.RowFilter = "listcas_id='" + idlistcas + "'";
                DataTable dtfilter = dsListDifference.Tables["cas"].DefaultView.ToTable();
                TreeNode trdetail = treeVdifference.Nodes.Add(dtDifference.Text, dtDifference.Text);
                for (int i = 0; i < dtfilter.Rows.Count; i++)
                    trdetail.Nodes.Add(dtfilter.Rows[i]["cas_id"].ToString(), dtfilter.Rows[i][0].ToString());


                dsListDifference.Tables["cas"].DefaultView.RowFilter = string.Empty;
                dsListDifference.Tables["difference"].DefaultView.RowFilter = "IdClasseur = '" + Program.IdClasseur + "'";
            }
        }

        private void btGenerer_Click(object sender, EventArgs e)
        {
            intersect.Clear();
            treeVResultat.Nodes.Clear();
            ListTableDifference.Clear();

            MyIntersect.Clear();
            compteur = 0;

            TableDifference = new string[treeVdifference.Nodes.Count];
            IdDifference = new string[treeVdifference.Nodes.Count];
            if (treeVdifference.Nodes.Count > 0)
            {
                ListTousIntersection(treeVdifference.Nodes[0].Nodes);
                PrintResult(MyIntersect);
            }
        }
        private void PrintResult(List<intersection> MyFilterIntersect)
        {

            for (int i = 0; i < MyFilterIntersect.Count; i++)
            {
                string caracretConcatenation = "  +  ";
                string listCas="";
                //afficher la resultat
                for (int k = 0; k < MyFilterIntersect[i].ListDifference.Count; k++)
                {
                    if (k == MyFilterIntersect[i].ListDifference.Count - 1)
                        caracretConcatenation = "   ";
                  listCas+=  MyFilterIntersect[i].ListDifference[k].Nom + caracretConcatenation;
                }
              TreeNode childNode=  treeVResultat.Nodes.Add(listCas);
                for (int l = 0; l < MyFilterIntersect[i].listTousLecteur.Count; l++)
                {

                    TreeNode[] ListeLecteurTrouve = TreeListeLecteur.Nodes.Find(MyFilterIntersect[i].listTousLecteur[l].ToString(), true);

                    if (ListeLecteurTrouve.Length > 0)
                    {
                       TreeNode sousLecteur= childNode.Nodes.Add(MyFilterIntersect[i].listTousLecteur[l].ToString(), ListeLecteurTrouve[0].Text.ToString());
                       
                       AddTreeViewChildNodes(sousLecteur.Nodes, xml_doc.DocumentElement,ListeLecteurTrouve[0].Name.ToString() );
                       sousLecteur.Collapse();
                    }

                }
            }
        }

        void ListTousIntersection(TreeNodeCollection treeNode)
        {

            for (int i = 0; i < treeNode.Count; i++)
            {
                if (treeNode[i].Checked)
                {
                    TableDifference[treeNode[i].Parent.Index] = treeNode[i].Text;
                    IdDifference[treeNode[i].Parent.Index] = treeNode[i].Name;
                    if (treeNode[i].Parent.NextNode != null)
                        ListTousIntersection(treeNode[i].Parent.NextNode.Nodes);
                    else
                    {
                        List<int>[] listTousLecteur = new List<int>[IdDifference.Length];

                        //get tous lecteur apartir du node parent
                        for (int j = 0; j < IdDifference.Length; j++)
                        {
                            dsListDifference.Tables["Lecteur"].DefaultView.RowFilter = "listlecteur_id='" + IdDifference[j] + "'";
                            DataTable dtfilter = dsListDifference.Tables["Lecteur"].DefaultView.ToTable();
                            listTousLecteur[j] = new List<int>();
                            for (int k = 0; k < dtfilter.Rows.Count; k++)
                                listTousLecteur[j].Add(Convert.ToInt16(dtfilter.Rows[k][0].ToString()));

                        }
                        List<int> Firstintersect = LintercectList(listTousLecteur);

                        if (Firstintersect.Count > 0)
                        {
                            List<string> templist = new List<string>();
                            //  Firstintersect.Insert(0, compteur);
                            intersect.Add(Firstintersect);
                            templist.Add(compteur.ToString());
                            foreach (string difference in TableDifference)
                                templist.Add(difference);
                            //remplir la liste des mots de difference dans une liste
                            ListTableDifference.Add(templist);

                            intersection tempinersect = new intersection();
                            tempinersect.id = compteur;
                            tempinersect.ordre = 0;
                            tempinersect.ListDifference = new List<ChoixDifference>();
                            for (int j = 0; j < IdDifference.Length; j++)
                            {
                                ChoixDifference mychoix = new ChoixDifference();
                                mychoix.code = Convert.ToInt16(IdDifference[j]);
                                mychoix.Nom = TableDifference[j];
                                tempinersect.ListDifference.Add(mychoix);
                            }
                            tempinersect.listTousLecteur = Firstintersect;
                            compteur++;//ce compteur est utiliser pour faire une corespendance entre list des lecteurs et liste des mots de difference
                            MyIntersect.Add(tempinersect);
                        }



                    }
                }

            }


        }
        List<int> LintercectList(List<int>[] listTousLecteur)
        {

            List<int> tableResultat = new List<int>();
            List<int> ResultatFinal = new List<int>();
            tableResultat = listTousLecteur[0];
            //parcourir tous les elements des lecteur
            for (int h = 1; h < listTousLecteur.Length; h++)
            {
                //compare le resultat des 2 intersection par les autres listes
                for (int i = 0; i < tableResultat.Count; i++)
                {
                    List<int> items2 = listTousLecteur[h];
                    //comparer avec chaque emlement du 2 eme liste
                    for (int j = 0; j < items2.Count; j++)
                    {
                        int nbdivision = 1000;
                        if (tableResultat[i].ToString().Length == 3)
                            nbdivision = 100;
                        //extraire le rang 1 
                        int val1 = Convert.ToInt16(tableResultat[i]) / nbdivision;
                        int val2 = Convert.ToInt16(items2[j]) / nbdivision;
                        if (val1 == val2)
                        {
                            //si ils sont egaux
                            if (Convert.ToInt16(tableResultat[i]) == Convert.ToInt16(items2[j]))
                                ResultatFinal.Add(Convert.ToInt16(tableResultat[i]));
                            else
                            {

                                //extraire le min et max
                                int valmin = Convert.ToInt16(tableResultat[i]) - Convert.ToInt16(items2[j]) < 0 ? Convert.ToInt16(tableResultat[i]) : Convert.ToInt16(items2[j]);
                                int valmax = Convert.ToInt16(tableResultat[i]) - Convert.ToInt16(items2[j]) > 0 ? Convert.ToInt16(tableResultat[i]) : Convert.ToInt16(items2[j]);
                                TreeNode[] ListeLecteurTrouve = TreeListeLecteur.Nodes.Find(valmax.ToString(), true);
                                TreeNode ParcourNodePArent = ListeLecteurTrouve[0];
                                //verifer si le petit est un enfant du grand
                                while (ParcourNodePArent.Parent != null)
                                    if (ParcourNodePArent.Parent.Name == valmin.ToString())
                                    {
                                        ResultatFinal.Add(valmax);
                                        break;
                                    }
                                    else
                                        ParcourNodePArent = ParcourNodePArent.Parent;
                            }

                        }
                    }

                }
                tableResultat.Clear();
                //copier le resultat
                foreach (int number in ResultatFinal)
                    tableResultat.Add(number);
                ResultatFinal.Clear();
            }
            return tableResultat;

        }

        private void btAjout_Click(object sender, EventArgs e)
        {
           // Addoldmethod_with_one_lecteur();
            TreeNode listeNodeChecked = new TreeNode();
            GetCheckedNodes(treeVResultat.Nodes, listeNodeChecked);
            if(listeNodeChecked.Nodes.Count==0)
                MessageBox.Show("  يجب ادخال امتناع");
            else
            {
                for (int i = 0; i < treeVResultat.Nodes.Count; i++)
                {
                    if (treeVResultat.Nodes[i].Checked == true)
                    {
                        Exclusions myExclustion = new Exclusions();

                        myExclustion.lecteur = new List<Lecteur>();
                        myExclustion.differenceCas = new List<DifferenceCas>();

                        var cas = treeVResultat.Nodes[i].Text.Split('+');
                        if (cas.Length > 1)
                        {
                            DifferenceCas mydiffcas = new DifferenceCas();
                            mydiffcas.NomCas = cas[0].Trim();
                            mydiffcas.NomDifference = FindNode(cas[0].Trim());

                            myExclustion.differenceCas.Add(mydiffcas);

                            DifferenceCas mydiffcas2 = new DifferenceCas();
                            mydiffcas2.NomCas = cas[1].Trim();
                            mydiffcas2.NomDifference = FindNode(cas[1].Trim());
                            myExclustion.differenceCas.Add(mydiffcas2);
                            string listNomLecteur = "";
                            TreeNode listeNodeResultChecked = new TreeNode();
                            GetCheckedNodes(treeVResultat.Nodes[i].Nodes, listeNodeResultChecked);
                            for (int j = 0; j < listeNodeResultChecked.Nodes.Count; j++)
                            {


                                Lecteur mylecteur = new Lecteur();
                                mylecteur.IdLecteur = Convert.ToInt16(listeNodeResultChecked.Nodes[j].Name);
                                mylecteur.NomLecteur = listeNodeResultChecked.Nodes[j].Text;
                                listNomLecteur += listeNodeResultChecked.Nodes[j].Text + " ";
                                myExclustion.lecteur.Add(mylecteur);

                            }
                            myExclustion.id = getNomDifferenceChecked() + " : " + treeVResultat.Nodes[i].Text + "   => " + listNomLecteur;
                            myExclustion.IdClasseur = Program.IdClasseur;
                            saveExcltion(myExclustion);
                        }
                    }
                    
                }
                MessageBox.Show("تمت العملية بنجاح");
                treeVdifference.Nodes.Clear();
                treeVResultat.Nodes.Clear();
            }
        }

        private void Addoldmethod_with_one_lecteur()
        {
            //tester s'il y a des nodes checked ou non
            bool checkedNode = false;
            for (int i = 0; i < treeVResultat.Nodes.Count && checkedNode == false; i++)
            {
                if (treeVResultat.Nodes[i].Checked == true)
                    for (int j = 0; j < treeVResultat.Nodes[i].Nodes.Count; j++)
                        if (treeVResultat.Nodes[i].Nodes[j].Checked == true)
                        {
                            checkedNode = true;
                            break;
                        }
            }
            if (checkedNode == false)
                MessageBox.Show("  يجب ادخال امتناع");
            else
            {
                for (int i = 0; i < treeVResultat.Nodes.Count; i++)
                {
                    if (treeVResultat.Nodes[i].Checked == true)
                    {
                        Exclusions myExclustion = new Exclusions();

                        myExclustion.lecteur = new List<Lecteur>();
                        myExclustion.differenceCas = new List<DifferenceCas>();

                        var cas = treeVResultat.Nodes[i].Text.Split('+');
                        if (cas.Length > 1)
                        {
                            DifferenceCas mydiffcas = new DifferenceCas();
                            mydiffcas.NomCas = cas[0].Trim();
                            mydiffcas.NomDifference = FindNode(cas[0].Trim());

                            myExclustion.differenceCas.Add(mydiffcas);

                            DifferenceCas mydiffcas2 = new DifferenceCas();
                            mydiffcas2.NomCas = cas[1].Trim();
                            mydiffcas2.NomDifference = FindNode(cas[1].Trim());
                            myExclustion.differenceCas.Add(mydiffcas2);
                            string listNomLecteur = "";
                            for (int j = 0; j < treeVResultat.Nodes[i].Nodes.Count; j++)
                            {

                                if (treeVResultat.Nodes[i].Nodes[j].Checked == true)
                                {
                                    Lecteur mylecteur = new Lecteur();
                                    mylecteur.IdLecteur = Convert.ToInt16(treeVResultat.Nodes[i].Nodes[j].Name);
                                    mylecteur.NomLecteur = treeVResultat.Nodes[i].Nodes[j].Text;
                                    listNomLecteur += treeVResultat.Nodes[i].Nodes[j].Text + " ";
                                    myExclustion.lecteur.Add(mylecteur);
                                }
                            }
                            myExclustion.id = getNomDifferenceChecked() + " : " + treeVResultat.Nodes[i].Text + "   => " + listNomLecteur;
                            myExclustion.IdClasseur = Program.IdClasseur;
                            saveExcltion(myExclustion);
                        }
                    }
                }
                MessageBox.Show("تمت العملية بنجاح");
                treeVdifference.Nodes.Clear();
                treeVResultat.Nodes.Clear();
            }
        }
        public void GetCheckedNodes(TreeNodeCollection nodes, TreeNode new_node)
        {
            foreach (System.Windows.Forms.TreeNode aNode in nodes)
            {
                //edit
                if (aNode.Checked)
                {

                    new_node.Nodes.Add(aNode.Name, aNode.Text);

                }
                if (aNode.Nodes.Count != 0)
                    GetCheckedNodes(aNode.Nodes, new_node);
            }
        }
        private string FindNode( string matchText)
        {
            for (int i = 0; i < treeVdifference.Nodes.Count; i++)
            {

                for (int j = 0; j < treeVdifference.Nodes[i].Nodes.Count; j++)
                {
                    if (treeVdifference.Nodes[i].Nodes[j].Text == matchText)
                        return treeVdifference.Nodes[i].Text;
                }
            }
            return "";
        }
        private string getNomDifferenceChecked()
        {
            string NomDifference = "";
            for (int i = 0; i < treeVdifference.Nodes.Count  ; i++)
            {
                    for (int j = 0; j < treeVdifference.Nodes[i].Nodes.Count; j++)
                        if (treeVdifference.Nodes[i].Nodes[j].Checked == true)
                        {
                            if(NomDifference=="")
                            NomDifference += treeVdifference.Nodes[i].Text ;
                            else
                            NomDifference +=" + " +treeVdifference.Nodes[i].Text;
                            break;
                        }
            }
            return NomDifference;
        }
        private  void saveExcltion(Exclusions myExclustion)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Exclusions.xml"); // Load xml file data to xmlDocument
            if (Mode == "Modif")//recherer et supprimer avant d'ajouter
            {
                XmlNode cas = doc.SelectSingleNode("/ListExclusions/Exclusions[id='" + NomExclusion + "']");
                doc.ChildNodes[1].RemoveChild(cas);
            }
            XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "Exclusion", null);
            XmlSerializer xSeriz = new XmlSerializer(typeof(Exclusions));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlWriterSettings writtersetting = new XmlWriterSettings();
            writtersetting.OmitXmlDeclaration = true;
            StringWriter stringwriter = new StringWriter();
            using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
            {
                xSeriz.Serialize(xmlwriter, myExclustion, ns);
            }
            xnode.InnerXml = stringwriter.ToString();
            XmlNode bindxnode = xnode.SelectSingleNode("Exclusions");
            doc.DocumentElement.AppendChild(bindxnode);


            doc.Save("Exclusions.xml");
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void treeVResultat_AfterCheck(object sender, TreeViewEventArgs e)
        {

            CheckTreeViewNode(e.Node, e.Node.Checked);
            if (e.Node.Checked == true)
            {
                if (e.Node.Parent.Parent == null)
                {
                    treeVResultat.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.treeVResultat_AfterCheck);
                    e.Node.Parent.Checked = true;
                    treeVResultat.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeVResultat_AfterCheck);
                }
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
    }
}
