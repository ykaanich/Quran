using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
namespace Quran
{
    public partial class Frm_origine : Form
    {
        string Mode = "Ajout";
        string NomCas = "";
        TreeView myCopietreeLecteur;
        XmlDocument xml_Difference = new XmlDocument();
        public Frm_origine()
        {
            InitializeComponent();
        }
        public Frm_origine(string Mode,string NomCas)
        {
            this.Mode = Mode;
            this.NomCas = NomCas;
            InitializeComponent();
        }
            XmlDocument xml_doc = new XmlDocument();
        private void Frm_origine_Load(object sender, EventArgs e)
        {
            // Load the XML document.

            xml_doc.Load("lecteurstree.xml");
            
            //dans le cas de modification
            if(Mode=="Modif")
            {
                btAjout.Text = "تعديل";
                label1.Text = "تعديل خلاف";
                this.Text = " تعديل خلاف";
                xml_Difference.Load("Difference.xml");
               XmlNode  cas = xml_Difference.SelectSingleNode("/Differences/Difference[Nom='"+ NomCas +"'] [IdClasseur='" + Program.IdClasseur + "']" ) ;
               txt_nom.Text = NomCas;

               foreach (XmlNode item in cas.ChildNodes.Item(2))//ListCas
                 {
                  TreeNode new_node =   treeViewCas.Nodes.Add(item.FirstChild.InnerText);
                   //  XmlNode ListCasNode = item.SelectSingleNode("ListCas");
                     foreach (XmlNode item1 in item.LastChild)
                     {
                         new_node.Nodes.Add(item1.FirstChild.InnerText, item1.LastChild.InnerText);
                         
                         
                     }
                 }
               if (cas.ChildNodes.Item(3)!=null)
               foreach (XmlNode item in cas.ChildNodes.Item(3))//ListOrderLecteur
                 {
                  TreeNode new_node =   treeVOrderLecteur.Nodes.Add(item.FirstChild.FirstChild.InnerText,item.FirstChild.LastChild.InnerText);
                   //  XmlNode ListCasNode = item.SelectSingleNode("ListCas");
                     foreach (XmlNode item1 in item.LastChild)
                     {
                         new_node.Nodes.Add(item1.FirstChild.InnerText, item1.LastChild.InnerText);
                         
                         
                     }
                 }
               this.txt_nom.TextChanged += new System.EventHandler(this.txt_nom_TextChanged);
            }


            // Add the root node's children to the TreeView.

            ChargerListLecteurSelonCalsseur();
            treeVLecteur.CollapseAll();
            myCopietreeLecteur = new TreeView();
            CopyTreeNodes(treeVLecteur ,myCopietreeLecteur  );
        }
        public void CopyTreeNodes(TreeView treeview1, TreeView treeview2)
        {
            TreeNode newTn;
            foreach (TreeNode tn in treeview1.Nodes)
            {
                newTn = new TreeNode(tn.Text, tn.ImageIndex, tn.SelectedImageIndex);
                newTn.Name = tn.Name;
                CopyChildren(newTn, tn);
                treeview2.Nodes.Add(newTn);
            }
        }
        public void CopyChildren(TreeNode parent, TreeNode original)
        {
            TreeNode newTn;
            foreach (TreeNode tn in original.Nodes)
            {
                newTn = new TreeNode(tn.Text, tn.ImageIndex, tn.SelectedImageIndex);
                newTn.Name = tn.Name;
                parent.Nodes.Add(newTn);
                CopyChildren(newTn, tn);
            }
        } 
        XmlNode cas;
        private void ChargerListLecteurSelonCalsseur()
        {
             XmlDocument doc = new XmlDocument();
                doc.Load("Classeur.xml");
                cas = doc.SelectSingleNode("/Classeur/Classeur[IdClasseur='" + Program.IdClasseur + "']");
             XmlNode mynode = cas.ChildNodes.Item(4);

                if (cas.ChildNodes.Item(3).InnerText == "كبرى")
                {
                 AddTreeViewChildNodes(treeVLecteur.Nodes, xml_doc.DocumentElement);
                }else
                {
                    AddTreeViewChildNodesPetit(treeVLecteur.Nodes, xml_doc.DocumentElement);
                }

        }
        private void AddTreeViewChildNodesPetit(TreeNodeCollection parent_nodes, XmlNode xml_node)
        {
            foreach (XmlNode child_node in xml_node.ChildNodes)
            {
                // Make the new TreeView node.
     
 
                    XmlNode mynode = cas.ChildNodes.Item(4);
                    if (mynode.ChildNodes.Count > 0)
                    {
                        XmlNode myliste = mynode.SelectSingleNode("/Classeur/Classeur[IdClasseur='" + Program.IdClasseur + "']" + "/ListLecteur/Lecteur[IdLecteur='" + child_node.Attributes[0].Value + "']");
                        if (myliste != null)//chercher s'il y a le lecteur dans la liste  
                        {
                            TreeNode new_node = parent_nodes.Add(child_node.Attributes[0].Value, child_node.Attributes[2].Value);

                            foreach (XmlNode child_node2 in child_node.ChildNodes)
                            {
                                // Make the new TreeView node.

                                XmlNode myliste2 = mynode.SelectSingleNode("/Classeur/Classeur[IdClasseur='" + Program.IdClasseur + "']" + "/ListLecteur/Lecteur[IdLecteur='" + child_node2.Attributes[0].Value + "']");
                                if (myliste2 != null)//chercher s'il y a le lecteur dans la liste dans lemode modification
                                    new_node.Nodes.Add(child_node2.Attributes[0].Value, child_node2.Attributes[2].Value);


                            }
                        }
                    }
                    else
                    {
                        TreeNode new_node = parent_nodes.Add(child_node.Attributes[0].Value, child_node.Attributes[2].Value);

                        foreach (XmlNode child_node2 in child_node.ChildNodes)
                                new_node.Nodes.Add(child_node2.Attributes[0].Value, child_node2.Attributes[2].Value);
                    }
            }



        }
        private void AddTreeViewChildNodes( TreeNodeCollection parent_nodes, XmlNode xml_node)
        {
            foreach (XmlNode child_node in xml_node.ChildNodes)
            {
                 XmlNode mynode = cas.ChildNodes.Item(4);
                 if (mynode.ChildNodes.Count > 0)
                 {
                       XmlNode myliste = mynode.SelectSingleNode("/Classeur/Classeur[IdClasseur='" + Program.IdClasseur + "']" + "/ListLecteur/Lecteur[IdLecteur='" + child_node.Attributes[0].Value + "']");
                       if (myliste != null)//chercher s'il y a le lecteur dans la liste  
                       {
                           TreeNode new_node = parent_nodes.Add(child_node.Attributes[0].Value, child_node.Attributes[2].Value);

                           // Recursively make this node's descendants.
                           AddTreeViewChildNodes(new_node.Nodes, child_node);
                            if (new_node.Nodes.Count == 0) new_node.EnsureVisible();
                       }
                       
                 }
                 else
                 {
                     // Make the new TreeView node.
                     TreeNode new_node = parent_nodes.Add(child_node.Attributes[0].Value, child_node.Attributes[2].Value);
                     // Recursively make this node's descendants.
                     AddTreeViewChildNodes(new_node.Nodes, child_node);
                    // If this is a leaf node, make sure it's visible.
                     if (new_node.Nodes.Count == 0) new_node.EnsureVisible();
                 }
                
               
            }
        }

        private void btLecteur_Click(object sender, EventArgs e)
        {
            Frm_Lecteur myfrm = new Frm_Lecteur();
            myfrm.ShowDialog();
         foreach (int item in   myfrm.listChecked)
         {
            var Vlecteur= treeVLecteur.Nodes.Find(item.ToString(),true);
             if(Vlecteur.Length>0)
            Vlecteur[0].Checked = true;
         }
        }

        private void btaddhala_Click(object sender, EventArgs e)
        {
            if (txt_cas.Text != "")
            {

                TreeNode new_node = treeViewCas.Nodes.Add(txt_cas.Text, txt_cas.Text);
                GetCheckedNodes(treeVLecteur.Nodes, new_node);


                if(new_node.GetNodeCount(true)==0)
                {
                 treeViewCas.Nodes.RemoveAt(   treeViewCas.Nodes.IndexOf(new_node));
                    MessageBox.Show("يجب ادخال القراء");
                }
                txt_cas.Text = "";
                treeVLecteur.CollapseAll();

                refreshList();

            }
            else
                MessageBox.Show("يجب ادخال اسم الحالة");
        }
        public void GetCheckedNodes(TreeNodeCollection nodes,TreeNode new_node)
        {
            foreach (System.Windows.Forms.TreeNode aNode in nodes)
            {
                //edit
                if (aNode.Checked)
                {


                    RemplirNodeOrder(aNode, txt_cas.Text, treeViewCas.Nodes.Count);
                    
                    new_node.Nodes.Add(aNode.Name, aNode.Text);
                    
                    aNode.Checked = false;
                }
                if (aNode.Nodes.Count != 0)
                    GetCheckedNodes(aNode.Nodes,new_node);
            }
        }

        private void RemplirNodeOrder(System.Windows.Forms.TreeNode aNode, string nomCas, int maxid)
        {
            bool trouve = chercherLecteurCommun(aNode.Name,nomCas,maxid);
            //if (trouve == false)//si on n'a pas trouver un lecteur on doit chercher par son pere
            //{
                TreeNode listeParent = aNode.Parent;
                while (listeParent != null)//parcour sur tous les parents jusqu'a trouver une jointure  --&& trouve == false
                {
                    trouve = chercherLecteurCommunParent(listeParent.Name, aNode.Text, aNode.Name,nomCas,maxid);
                    listeParent = listeParent.Parent;
                }
            //}
            //if (trouve == false)//si on n'a pas trouver un lecteur on doit chercher par ses fils
            //{

                var copietree = myCopietreeLecteur.Nodes.Find(aNode.Name, true);

                trouve = ChercherTousFils(copietree[0].Nodes, nomCas, maxid);
                //while (listeFils != null && trouve == false)//parcour sur tous les parents jusqu'a trouver une jointure
                //{

                //trouve = chercherLecteurCommunFils(listeParent.Text,aNode.Text,aNode.Name);
                //listeParent = listeParent.Parent;
                // }
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void refreshList()
        {

            treeVOrderLecteur.Nodes.Clear();
            for (int i = treeViewCas.Nodes.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < treeViewCas.Nodes[i].Nodes.Count; j++)
                {
                    //findLecteurComun(treeViewCas.Nodes[i].Nodes[j].Name, treeViewCas.Nodes[i].Text, i);
                    TreeNode[] trouveNode = treeVLecteur.Nodes.Find(treeViewCas.Nodes[i].Nodes[j].Name, true);
                    if (trouveNode.Length > 0)
                        RemplirNodeOrder(trouveNode[0], treeViewCas.Nodes[i].Text, i);
                }
            }
        }

        void findLecteurComun(string idLecteur, string nomCas, int maxid)
        {
            for (int i = 0; i < maxid; i++)
            {
                for (int j = 0; j < treeViewCas.Nodes[i].Nodes.Count; j++)
                {
                    if (treeViewCas.Nodes[i].Nodes[j].Name == idLecteur)
                    {

                        var trouveNode = treeVOrderLecteur.Nodes.Find(treeViewCas.Nodes[i].Nodes[j].Name, false);
                        if (trouveNode.Length > 0)
                        {
                            var trouveSousNode = trouveNode[0].Nodes.Find(nomCas, false);
                            if (trouveSousNode.Length == 0)
                                trouveNode[0].Nodes.Add(nomCas, nomCas);
                        }
                        else
                        {
                            TreeNode new_node = treeVOrderLecteur.Nodes.Add(treeViewCas.Nodes[i].Nodes[j].Name, treeViewCas.Nodes[i].Nodes[j].Text);
                            new_node.Nodes.Add(treeViewCas.Nodes[i].Text, treeViewCas.Nodes[i].Text);
                            new_node.Nodes.Add(nomCas, nomCas);

                        }

                    }

                }
            }
        }

        private bool ChercherTousFils(  TreeNodeCollection listeFils,string nomCas, int maxid)
        {bool trouve=false;

             
            for (int l = 0; l < listeFils.Count; l++)
            {
                trouve = chercherLecteurCommunFils(listeFils[l].Name,nomCas,maxid);
                if (listeFils[l].Nodes.Count > 0)
                    ChercherTousFils(listeFils[l].Nodes,nomCas,maxid);

            }
            return trouve;
        }
        private bool chercherLecteurCommun(string idLecteur,string nomCas, int maxid)
        {
            bool trouve = false;
          for(int i=0;i< maxid;i++)
          {
              for(int j=0;j< treeViewCas.Nodes[i].Nodes.Count;j++)
              {
                  if (treeViewCas.Nodes[i].Nodes[j].Name == idLecteur)
                  {
                     
                      var trouveNode = treeVOrderLecteur.Nodes.Find(treeViewCas.Nodes[i].Nodes[j].Name,false);
                      if (trouveNode.Length > 0)
                      {
                          var trouveSousNode = trouveNode[0].Nodes.Find(nomCas, false);
                          if (trouveSousNode.Length == 0)
                              trouveNode[0].Nodes.Add(nomCas, nomCas);
                      }
                      else
                      {
                         TreeNode  new_node = treeVOrderLecteur.Nodes.Add(treeViewCas.Nodes[i].Nodes[j].Name, treeViewCas.Nodes[i].Nodes[j].Text);
                          new_node.Nodes.Add( treeViewCas.Nodes[i].Text,treeViewCas.Nodes[i].Text);
                          new_node.Nodes.Add(nomCas, nomCas);

                      }
                      trouve = true;
                  }
                 
              }
          }

          return trouve;
               
        }
        private bool chercherLecteurCommunParent(string idLecteur, string lecteurOrigine, string codeOrigine, string nomCas, int maxid)
        {
            bool trouve = false;
            for (int i = 0; i < maxid; i++)
            {
                for (int j = 0; j < treeViewCas.Nodes[i].Nodes.Count; j++)
                {
                    if (treeViewCas.Nodes[i].Nodes[j].Name == idLecteur)
                    {

                        var trouveNode = treeVOrderLecteur.Nodes.Find(codeOrigine, false);
                        if (trouveNode.Length > 0)
                        {
                            var trouveSousNode = trouveNode[0].Nodes.Find(nomCas, true);
                            if (trouveSousNode.Length == 0)
                              trouveNode[0].Nodes.Add(nomCas, nomCas);
                           
                            var trouveSousNode1 = trouveNode[0].Nodes.Find(treeViewCas.Nodes[i].Text, false);
                            if (trouveSousNode1.Length == 0)
                                trouveNode[0].Nodes.Add(treeViewCas.Nodes[i].Text, treeViewCas.Nodes[i].Text);
                        }
                        else
                        {
                            TreeNode new_node = treeVOrderLecteur.Nodes.Add(codeOrigine, lecteurOrigine);
                            new_node.Nodes.Add(treeViewCas.Nodes[i].Text,treeViewCas.Nodes[i].Text);
                            new_node.Nodes.Add(nomCas, nomCas);

                        }
                        trouve = true;
                    }

                }
            }

            return trouve;

        }
        private bool chercherLecteurCommunFils(string idLecteur, string nomCas, int maxid)
        {
            bool trouve = false;
            for (int i = 0; i < maxid; i++)
            {
                for (int j = 0; j < treeViewCas.Nodes[i].Nodes.Count; j++)
                {
                    if (treeViewCas.Nodes[i].Nodes[j].Name == idLecteur)
                    {

                        var trouveNode = treeVOrderLecteur.Nodes.Find(treeViewCas.Nodes[i].Nodes[j].Name, false);
                        if (trouveNode.Length > 0)
                        {
                            var trouveSousNode = trouveNode[0].Nodes.Find(nomCas, false);
                            if (trouveSousNode.Length == 0)
                                trouveNode[0].Nodes.Add(nomCas, nomCas);
                        }
                        else
                        {
                            TreeNode new_node = treeVOrderLecteur.Nodes.Add(treeViewCas.Nodes[i].Nodes[j].Name, treeViewCas.Nodes[i].Nodes[j].Text);//idLecteur
                            new_node.Nodes.Add(treeViewCas.Nodes[i].Text, treeViewCas.Nodes[i].Text);
                            new_node.Nodes.Add(nomCas, nomCas);

                        }
                        trouve = true;
                    }

                }
            }

            return trouve;

        }
        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAjout_Click(object sender, EventArgs e)
        {
            Difference myDifference = new Difference();
            myDifference.Nom = txt_nom.Text;
            myDifference.Type = txt_type.Text;
            myDifference.IdClasseur = Program.IdClasseur;
            myDifference.ListCas = new List<Cas>();
            foreach (TreeNode aNode in treeViewCas.Nodes)
            {
                Cas myCas = new Cas();
                myCas.NomCas = aNode.Text;
                    myCas.ListLecteur = new List<Lecteur>();
                foreach (TreeNode aNode1 in aNode.Nodes)
                {

                    Lecteur myLecteur = new Lecteur();
                    myLecteur.IdLecteur =Convert.ToInt16( aNode1.Name);
                    myLecteur.NomLecteur = aNode1.Text;
                    myCas.ListLecteur.Add(myLecteur);
                }

                myDifference.ListCas.Add(myCas);

            }
            myDifference.listOrdreLecteur = new List<ordreLecteur>();
            foreach (TreeNode aNode in treeVOrderLecteur.Nodes)
            {
                ordreLecteur myOrderLecteur = new ordreLecteur();
                myOrderLecteur.lecteur = new Lecteur();
                myOrderLecteur.lecteur.IdLecteur =Convert.ToInt16( aNode.Name);
                myOrderLecteur.lecteur.NomLecteur = aNode.Text;
                myOrderLecteur.nomCas = new List<string>();
                foreach (TreeNode aNode1 in aNode.Nodes)
                    myOrderLecteur.nomCas.Add(aNode1.Text);

                myDifference.listOrdreLecteur.Add(myOrderLecteur);
            }

            if (!File.Exists("Difference.xml")) //check file exist or not
            {

                XmlSerializer xSeriz = new XmlSerializer(typeof(Difference));

                FileStream fs = File.Open("Difference.xml", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);


                xSeriz.Serialize(fs, myDifference);
                fs.Close();

            }
            else //if file exist ie already have xml data
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Difference.xml"); // Load xml file data to xmlDocument
                if(Mode=="Modif")//recherer et supprimer avant d'ajouter
                {
                    XmlNode cas = doc.SelectSingleNode("/Differences/Difference[Nom='" + NomCas + "']");
                    doc.ChildNodes[1].RemoveChild(cas);
                }
             
                
                XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "Difference1", null);
                XmlSerializer xSeriz = new XmlSerializer(typeof(Difference));
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlWriterSettings writtersetting = new XmlWriterSettings();
                writtersetting.OmitXmlDeclaration = true;
                StringWriter stringwriter = new StringWriter();
                using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
                {
                    xSeriz.Serialize(xmlwriter, myDifference, ns);
                }
                xnode.InnerXml = stringwriter.ToString();
                XmlNode bindxnode = xnode.SelectSingleNode("Difference");
                doc.DocumentElement.AppendChild(bindxnode);
 

                doc.Save("Difference.xml");
            }

            MessageBox.Show("تمت العملية بنجاح");
            if (Mode == "Ajout")
            {
                txt_nom.Text = "";
                txt_type.Text = "";
                treeViewCas.Nodes.Clear();
                treeVOrderLecteur.Nodes.Clear();
            }
            else
                Close();
        }

        private void treeViewCas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                if(treeViewCas.SelectedNode.Parent ==null)//on supprime que le cas et non pas les lescteurs
                if (MessageBox.Show("  هل انت متاكد من حذف  " + treeViewCas.SelectedNode.Text, " تنبيه", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                  var item=  treeVOrderLecteur.Nodes.Find(treeViewCas.SelectedNode.Name, true);
                  for (int i =0;i<item.Length ;i++)
                  {
                      if (item[i].Parent != null)
                      {
                          item[i].Remove();
                      }
                      else
                      {
                          if (item[i].Nodes.Count > 1)
                          {
                              item[i].Nodes.RemoveByKey(treeViewCas.SelectedNode.Parent.Text);
                          }
                      }
                  }
                    treeViewCas.Nodes.Remove(treeViewCas.SelectedNode);
                    //supprimer tous les lecteurs qui on un seul cas
                    for  (int j=0;j< treeVOrderLecteur.Nodes.Count;j++)
                    {
                        if (treeVOrderLecteur.Nodes[j].Nodes.Count == 1)
                            treeVOrderLecteur.Nodes[j].Remove();
                    }
                }
            }
            //if (e.KeyValue == 113 && treeViewCas.SelectedNode.Parent == null)
            //{
            //    treeViewCas.LabelEdit = true;
            //    treeViewCas.SelectedNode.BeginEdit();
            //}
            if (e.KeyValue == 114 && treeViewCas.SelectedNode.Parent == null)
            {
               txt_cas.Text= treeViewCas.SelectedNode.Text;
               for (int i = 0; i < treeViewCas.SelectedNode.Nodes.Count; i++)
                {
                  var trouveLecteur=  treeVLecteur.Nodes.Find(treeViewCas.SelectedNode.Nodes[i].Name, true);
                   if(trouveLecteur.Length>0)
                   {
                       trouveLecteur[0].Checked = true;

                       ExpandAllParent(trouveLecteur[0]);
                   }
                    
                }
               treeViewCas.Nodes.Remove(treeViewCas.SelectedNode);
             
            }
        }

        private static void ExpandAllParent(TreeNode trouveLecteur)
        {
            if (trouveLecteur.Parent != null)
            {
                trouveLecteur .Expand();
                if(trouveLecteur.Parent!=null)
                trouveLecteur.Parent.Expand();
                ExpandAllParent(trouveLecteur .Parent);
                
            }
        }

        private void treeVOrderLecteur_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeVOrderLecteur_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeVOrderLecteur_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.  
            Point targetPoint = treeVOrderLecteur.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.  
            TreeNode targetNode = treeVOrderLecteur.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.  
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not   
            // the dragged node or a descendant of the dragged node.  
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current   
                // location and add it to the node at the drop location.  
                if (e.Effect == DragDropEffects.Move)
                {
                  
                  //  targetNode.Nodes.Add(draggedNode);
                    if (targetNode.Parent != null && draggedNode.Parent != null)
                    {
                        if (targetNode.Parent == draggedNode.Parent)
                        { 
                            draggedNode.Remove();
                            targetNode.Parent.Nodes.Insert(targetNode.Index, draggedNode);
                        }
                    }
                }

                // If it is a copy operation, clone the dragged node   
                // and add it to the node at the drop location.  
                //else if (e.Effect == DragDropEffects.Copy)
                //{
                //    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                //}

                // Expand the node at the location   
                // to show the dropped node.  
                targetNode.Expand();
            }  
        }
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.  
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node,   
            // call the ContainsNode method recursively using the parent of   
            // the second node.  
            return ContainsNode(node1, node2.Parent);
        }

        private void treeVOrderLecteur_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.  
            Point targetPoint = treeVOrderLecteur.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.  
            treeVOrderLecteur.SelectedNode = treeVOrderLecteur.GetNodeAt(targetPoint);  
        }

        private void treeViewCas_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            treeViewCas.LabelEdit = false;
            try
            {
                if (Mode == "Modif")
                {
                    Program.ExeciteOrigine(NomCas);
                  string TrouveNonCan=  Program.ExisteNomCasDansExclusion(e.Label);
                    if(TrouveNonCan!="")
                        throw new Exception("تم استعمال الخلاف في امتناع  :" + TrouveNonCan);
                }
                foreach (TreeNode aNode in treeVOrderLecteur.Nodes)
                    foreach (TreeNode aNode1 in aNode.Nodes)
                        if (aNode1.Text == e.Node.Text)
                            aNode1.Text = e.Label;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                e.CancelEdit = true;
            }
        }

        private void ckSelecetAll_CheckedChanged(object sender, EventArgs e)
        {
            if(ckSelecetAll.Checked)
            {
                foreach (TreeNode item in treeVLecteur.Nodes)
                {
 
                        item.Checked = true;
                }
            } else
            {
                foreach (TreeNode item in treeVLecteur.Nodes)
                {
 
                        item.Checked = false;
                }
            }
        }

        private void treeVOrderLecteur_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                if (MessageBox.Show("  هل انت متاكد من حذف  " + treeVOrderLecteur.SelectedNode.Text, " تنبيه", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    treeVOrderLecteur.Nodes.Remove(treeVOrderLecteur.SelectedNode);
            }
        }




        private void txt_nom_TextChanged(object sender, EventArgs e)
        {
            if(Mode=="Modif")
            {
                try
                {
                    
                      Program.ExeciteOrigine(NomCas);
 
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                     txt_nom.Text = NomCas;
                }
               
            }
        }

        private void treeVLecteur_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Checked==true)
            {
                e.Node.Nodes.Clear();
                //si on trouve tous les node sont cocher, il faut chocher le pere
                bool allChildrenIsCheck = true;
                if (e.Node.Parent != null)
                {
                    foreach (TreeNode item in e.Node.Parent.Nodes)
                        if (item.Checked == false)
                            allChildrenIsCheck = false;
                    if (allChildrenIsCheck == true)
                        e.Node.Parent.Checked = true;
                }
            }
            else
            {
                //on ajouter tous les enfants si on decoche 
              var copietree=  myCopietreeLecteur.Nodes.Find(e.Node.Name, true);
              CopyChildren(e.Node, copietree[0]);
            }
        }

    
    }
}