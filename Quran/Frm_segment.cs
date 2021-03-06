using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
namespace Quran
{
    public partial class Frm_segment : Form
    {
        public Frm_segment()
        {
            InitializeComponent();
        }
        string mode="Ajout";
        string nomSoura = "";
        string segment = "";
        string remarque = "";
        string IdEnsemble = "";
        DataTable  dtModifDifference;
        public Frm_segment(string mode, string nomSoura, string segment, string resultat, DataTable dtModifDifference,string remarque,string IdEnsemble)
        {
            this.mode = mode;
            this.nomSoura = nomSoura;
            this.segment = segment;
            this.remarque = remarque;
            this.dtModifDifference = dtModifDifference;
            this.IdEnsemble = IdEnsemble;
            InitializeComponent();

           
            txt_resultat.Rtf=resultat;


        }
        DataSet dataSet = new DataSet();
        DataSet dsListDifference = new DataSet();
        DataSet dsExclusion;
        DataSet dsCodeLecteur;
        TreeNode TreeListeLecteur ;
        List<List<int>> intersect = new List<List<int>>();
        List<intersection> MyIntersect = new List<intersection>();
        int selectedAya = 0;
        private void Form1_Load(object sender, EventArgs e)
        {

            ChargerQuran();
            ChargerDifference();
            ChargerLecteur();
            ChargerExclusion();
            ChargerdsCodeLecteur();
        }
        //pour corriger le pb d'affichage du richetextbox
        private void Frm_segment_Shown(object sender, EventArgs e)
        {
            if (mode == "Modif")
            {
                dt_sura.Text = nomSoura;
                txt_partie.Text = segment.Trim();
              txt_remarque.Text = remarque;
                //txt_quran.SelectionStart = txt_quran.Find("{" + 60 + "}");
                //txt_quran.ScrollToCaret();
                foreach (DataRow row in dtModifDifference.Rows)
                    RemplirTreeVdifference(row.ItemArray[0].ToString());
            }
        }
        private void ChargerExclusion()
        {
            //remplir exclusion
            dsExclusion = new DataSet();
            dsExclusion.ReadXml("Exclusions.xml", XmlReadMode.InferSchema);
           

        }
        private void ChargerdsCodeLecteur()
        {
            //remplir exclusion
            dsCodeLecteur = new DataSet();
            dsCodeLecteur.Reset();
            dsCodeLecteur.ReadXml("CodeLecteur.xml", XmlReadMode.InferSchema);
           

        }
        XmlDocument xml_doc;
        private void ChargerLecteur()
        {
            //Remplir list tous les lecteurs
            TreeListeLecteur = new TreeNode();
             xml_doc = new XmlDocument();
            xml_doc.Load("lecteurstree.xml");
           // AddTreeViewChildNodes(TreeListeLecteur.Nodes, xml_doc.DocumentElement);
            ChargerListLecteurSelonCalsseur();
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
                AddTreeViewChildNodes(TreeListeLecteur.Nodes, xml_doc.DocumentElement);
            }
            else
            {
                AddTreeViewChildNodesPetit(TreeListeLecteur.Nodes, xml_doc.DocumentElement);
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
                        new_node.Tag = child_node.Attributes[1].Value;
                        foreach (XmlNode child_node2 in child_node.ChildNodes)
                        {
                            // Make the new TreeView node.

                            XmlNode myliste2 = mynode.SelectSingleNode("/Classeur/Classeur[IdClasseur='" + Program.IdClasseur + "']" + "/ListLecteur/Lecteur[IdLecteur='" + child_node2.Attributes[0].Value + "']");
                            if (myliste2 != null)//chercher s'il y a le lecteur dans la liste dans lemode modification
                            {  
                                TreeNode new_node2=   new_node.Nodes.Add(child_node2.Attributes[0].Value, child_node2.Attributes[2].Value);
                                new_node2.Tag = child_node2.Attributes[1].Value;
                            }


                        }
                    }
                }
                else
                {
                    TreeNode new_node = parent_nodes.Add(child_node.Attributes[0].Value, child_node.Attributes[2].Value);
                    new_node.Tag = child_node.Attributes[1].Value;
                    foreach (XmlNode child_node2 in child_node.ChildNodes)
                    {
                       TreeNode new_node2 =  new_node.Nodes.Add(child_node2.Attributes[0].Value, child_node2.Attributes[2].Value);
                       new_node2.Tag = child_node2.Attributes[1].Value;
                    }
                }
            }



        }
        private void AddTreeViewChildNodes(TreeNodeCollection parent_nodes, XmlNode xml_node)
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
                        new_node.Tag = child_node.Attributes[1].Value;
                        // Recursively make this node's descendants.
                        AddTreeViewChildNodes(new_node.Nodes, child_node);
                        if (new_node.Nodes.Count == 0) new_node.EnsureVisible();
                    }

                }
                else
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
        }

        private void ChargerDifference()
        {
            dsListDifference.Clear();
            dsListDifference.Reset();
            dsListDifference.ReadXml("Difference.xml", XmlReadMode.InferSchema);
            dsListDifference.Tables[0].DefaultView.RowFilter = "IdClasseur = '" + Program.IdClasseur + "'";
            dtDifference.DataSource = dsListDifference.Tables[0].DefaultView.ToTable();
            dtDifference.DisplayMember = "Nom";
            dtDifference.ValueMember = "Difference_id";
            dtDifference.Text = "";
        }

        private void ChargerQuran()
        {
            dataSet.ReadXml("quran-uthmani.xml", XmlReadMode.InferSchema);
            dt_sura.DataSource = dataSet.Tables[0];
            dt_sura.DisplayMember = "name";
            dt_sura.ValueMember = "sura_id";
            dt_sura.Text = "";
        }


        private void dt_sura_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void dt_sura_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dt_sura.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    dataSet.Tables[1].DefaultView.RowFilter = "sura_id='" + dt_sura.SelectedValue + "'";
                    DataTable dtfilter = dataSet.Tables[1].DefaultView.ToTable();
                    dt_aya.DataSource = dtfilter;
                    dt_aya.DisplayMember = "index";
                    dt_aya.ValueMember = "index";
                    txt_quran.Text = "";
                    StringBuilder sb = new StringBuilder();
                    
                    for (int i = 0; i < dtfilter.Rows.Count; i++)
                    {
                        int numsura = i + 1;
                        sb.Append(dtfilter.Rows[i]["text"].ToString() + " {" + numsura + "} ");
                    }
                    txt_quran.Text = sb.ToString();
                   
                    
                }
            }
            catch (Exception) { }
        }

        private void btAjout_Click(object sender, EventArgs e)
        {
            Frm_origine myfrm = new Frm_origine();
            myfrm.ShowDialog();
        }

        private void txt_quran_MouseUp(object sender, MouseEventArgs e)
        {
            if (txt_quran.SelectedText != "")
            {
                txt_partie.Text = txt_quran.SelectedText;
                var splitsQuran = txt_quran.Text.Split('{').Where(x => x.Contains(txt_partie.Text)).ToList();
                if (splitsQuran.Count > 0)
                {
                    if (splitsQuran[0].Contains('}'))
                    {
                        var list1 = splitsQuran[0].Split('}')[0];
                        try
                        {
                            selectedAya = Convert.ToInt16(list1) + 1;
                        }
                        catch (Exception) { selectedAya = 0; }
                    }
                    else
                        selectedAya = 1;
                }
                else
                    selectedAya = 0;
            }
           
        }

        private void txt_partie_MouseUp(object sender, MouseEventArgs e)
        {
            if (txt_partie.SelectionBackColor != Color.LightBlue)
            txt_partie.SelectionBackColor = Color.LightBlue;
            else
            txt_partie.SelectionBackColor = Color.WhiteSmoke;
        }

        private void dtDifference_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RemplirTreeVdifference(dtDifference.Text);
            }
        }

        private void RemplirTreeVdifference(string nomDifference)
        {
            dsListDifference.Tables["difference"].DefaultView.RowFilter = "nom='" + nomDifference + "' and IdClasseur='" + Program.IdClasseur + "'  ";
            if (dsListDifference.Tables["difference"].DefaultView.ToTable().Rows.Count > 0)
            {
                string idlistcas = dsListDifference.Tables["difference"].DefaultView.ToTable().Rows[0]["difference_id"].ToString();

                dsListDifference.Tables["cas"].DefaultView.RowFilter = "listcas_id='" + idlistcas + "'";
                DataTable dtfilter = dsListDifference.Tables["cas"].DefaultView.ToTable();
                TreeNode trdetail = treeVdifference.Nodes.Add(nomDifference);//dtDifference.Text
                for (int i = 0; i < dtfilter.Rows.Count; i++)
                    trdetail.Nodes.Add(dtfilter.Rows[i]["cas_id"].ToString(), dtfilter.Rows[i][0].ToString());
            }
            else
                MessageBox.Show("لم يتم العثور على الخلاف  "+nomDifference);

            dsListDifference.Tables["cas"].DefaultView.RowFilter = string.Empty;
            dsListDifference.Tables["difference"].DefaultView.RowFilter = "IdClasseur='" + Program.IdClasseur + "'  ";
        }

        string[] TableDifference ;
        string[] IdDifference ;
        string[] NomDifference ;
        private void btadd_Click(object sender, EventArgs e)
        {
            intersect.Clear();
            ListTableDifference.Clear();

            MyIntersect.Clear();
            compteur = 0;
            txt_resultat.Text = "";

            TableDifference = new string[treeVdifference.Nodes.Count];
            IdDifference = new string[treeVdifference.Nodes.Count];
            NomDifference = new string[treeVdifference.Nodes.Count];
            if (treeVdifference.Nodes.Count > 0)
            {
                ListTousIntersection(treeVdifference.Nodes[0].Nodes);

                List<intersection> MyFilterIntersect = MyIntersect.ToList();
                AffectationOrder(treeVdifference.Nodes[0].Nodes, MyIntersect.ToList());

                PrintResult(MyIntersect.OrderBy(x => x.ordre).ToList());
                //     MyFilterIntersect = OldAffichage(MyFilterIntersect);
                // OrdonnerList();
                //   RemplirResultat();
                txt_resultat.Rtf = txt_resultat.Rtf;
            }
            else
            {
                txt_resultat.SelectedText = txt_partie.Text+":";

               string caracretConcatenation = " + ";
               

                string ListNomLecteur = "";
                for (int l = 0; l < TreeListeLecteur.Nodes.Count; l++)
                {
                    if (l == TreeListeLecteur.Nodes.Count - 1)
                        caracretConcatenation = "";
                    if(TreeListeLecteur.Nodes[l].Tag.ToString()=="")
                  ListNomLecteur += TreeListeLecteur.Nodes[l].Text+ caracretConcatenation;
                    else
                  ListNomLecteur += TreeListeLecteur.Nodes[l].Tag.ToString()+ caracretConcatenation;
                         

                }
                txt_resultat.SelectedText += ListNomLecteur;


               // MessageBox.Show("يجب اضافة الخلافات");
            }
        }
        List<int> listFilter = new List<int>();
        void AffectationOrder(TreeNodeCollection treeNode, List<intersection> MyFilterIntersect)
        {
            string listNomcas = "";
            
            Dictionary<int, int> orderNode = new Dictionary<int, int>();
            Dictionary<int, int> orderNodeLecteur = new Dictionary<int, int>();
            Dictionary<int, string> orderCas = new Dictionary<int, string>();
            Dictionary<int, int> orderCasfinal = new Dictionary<int, int>();
            for (int i = 0; i < treeNode.Count; i++)
            {
                string asupprimer = treeNode[i].Text;
                List<intersection> getListDifferenceByCode = MyFilterIntersect.Where(x => x.ListDifference.Any(y => y.code == Convert.ToInt16(treeNode[i].Name))).ToList();
                if (getListDifferenceByCode.Count > 0)
                {
                    int selectVal = getListDifferenceByCode.Select(x => x.listTousLecteur.Max()).OrderByDescending(y => y).First();
                    var listparcas = getListDifferenceByCode.Select(x => x.listTousLecteur.Max()).OrderByDescending(y => y).ToList();
                    //liste distinct des lecteurs puis pour chaque lecteur extrare la liste des enfants puis on compare  
                    selectVal = GetLecteurOrder(listparcas);
                    orderNode.Add(Convert.ToInt16(treeNode[i].Name), selectVal);
                    if(listNomcas=="")
                    listNomcas +="'"+ treeNode[i].Text + "'";
                    else
                    listNomcas +=" , '"+ treeNode[i].Text + "'";
                }
                listFilter.Remove(Convert.ToInt16(treeNode[i].Name));
            }
            //caluler le coefficiant de l'ordre
            int coefficiant = 1;
            TreeNode NodeChildren= treeNode[0].Parent;
            while (NodeChildren.NextNode != null)
            {
                NodeChildren = NodeChildren.NextNode;
                coefficiant *= 20;
            }
            bool trouveLeceur = false;
        //  trouveLeceur =  chercherNomCasMemeLecteur(treeNode, MyFilterIntersect, listNomcas, orderNode, coefficiant);
            //ordonner et MAJ l'ordre
            if (trouveLeceur == false)
            {
                var orderlist = orderNode.OrderByDescending(y => y.Value).ToList();
                //parcourire la liste pour chercher les lecteurs du meme hierachie
                for (int m = 0; m < orderlist.Count; m++)
                {
                    if (m < orderlist.Count - 1)
                    {
                        var trouveNode = TreeListeLecteur.Nodes.Find(orderlist[m + 1].Value.ToString(), true);
                        var trouveSousNode = trouveNode[0].Nodes.Find(orderlist[m].Value.ToString(), true);

                        if (trouveSousNode.Length != 0)
                        {
                            int ActiveLecteur = orderlist[m].Value;
                            orderNodeLecteur.Add(orderlist[m].Key, orderlist[m].Value);
                            while (trouveSousNode.Length != 0)
                            {

                                orderNodeLecteur.Add(orderlist[m + 1].Key, ActiveLecteur);
                                m++;
                                if (m < orderlist.Count - 1)
                                {
                                    trouveNode = TreeListeLecteur.Nodes.Find(orderlist[m + 1].Value.ToString(), true);
                                    trouveSousNode = trouveNode[0].Nodes.Find(ActiveLecteur.ToString(), true);
                                }
                                else
                                    break;
                            }
                        }
                        else
                            orderNodeLecteur.Add(orderlist[m].Key, orderlist[m].Value);
                    }
                    else
                        orderNodeLecteur.Add(orderlist[m].Key, orderlist[m].Value);
                 
                }

                //extraire liste des lecteurs qui se repette
                orderCasfinal.Clear();
                var result = orderNodeLecteur.GroupBy(x => x.Value).ToDictionary(x => x.Key, x => x.Count());
                int choixOrder = 100;
                //chercher ordre du meme lecteur
                foreach (var distinct in result )
                {
                    orderCas.Clear();
                     chercherNomCasMemeLecteur(treeNode[0].Parent.Text,   distinct.Key,orderCas);
                    //parcour les order 
                   var chercherlecteur= orderNodeLecteur.Where(y=>y.Value==distinct.Key).ToList();
                    //remplacer chaque lecteur par lecteur origine puis lecteur meme coieficient
                   chercherlecteur = RemplacerLecteur(orderNodeLecteur.Where(y => y.Value == distinct.Key).ToList(), orderlist);
                    int sousOrder=1;
                    for (int t = 0; t < chercherlecteur.Count; t++)
                    {
                        //cherecher si on trouve le nom du cas dans le tris des difference.xml 
                        string NomCas = treeNode.Find(chercherlecteur[t].Key.ToString(), false)[0].Text;
                        var tt = orderCas.FirstOrDefault(x => x.Value.ToString() == NomCas);
                        if (tt.Value == null)
                            orderCasfinal.Add(chercherlecteur[t].Key, choixOrder+chercherlecteur.Count  + sousOrder);
                        else
                            orderCasfinal.Add(chercherlecteur[t].Key, choixOrder+tt.Key  );//+ choixOrder

                        sousOrder++;
                    }
                   choixOrder+=100;
                }

                var orderlistFinal = orderCasfinal.OrderBy(y => y.Value).ToList();
                for (int h = 0; h < orderlistFinal.Count; h++)
                    for (int i = 0; i < MyIntersect.Count; i++)
                        for (int k = 0; k < MyIntersect[i].ListDifference.Count; k++)
                        {
                            var intersect = MyFilterIntersect.Where(x => x.id == Convert.ToInt16(MyIntersect[i].id)).ToList();
                            if (MyIntersect[i].ListDifference[k].code == orderlistFinal[h].Key && intersect.Count > 0)

                                MyIntersect[i].ordre += (h + 1) * coefficiant;
                               
                        }
                //parcourir les autre elements du meme ligne dans le tableau
                foreach (var item in orderlistFinal)
                {

                    List<intersection> getListDifference = MyFilterIntersect.Where(x => x.ListDifference.Any(y => y.code == Convert.ToInt16(item.Key))).ToList();
                    if (getListDifference.Count > 0 && treeNode[0].Parent.NextNode != null)
                        AffectationOrder(treeNode[0].Parent.NextNode.Nodes, getListDifference);

                }
            }

        }

        private List<KeyValuePair<int, int>> RemplacerLecteur(List<KeyValuePair<int, int>> orderNodeLecteur, List<KeyValuePair<int, int>> orderlist)
        {
            List<KeyValuePair<int, int>> chercherlecteur = new List<KeyValuePair<int, int>>();
            foreach (var item in orderNodeLecteur)
            {
                int LecteurCorespandant=orderlist.First(x=> x.Key==item.Key).Value;
                chercherlecteur.Add(new KeyValuePair<int, int>(item.Key,GetMemeOrdreLecteur(  LecteurCorespandant))) ;
            }
            return chercherlecteur.OrderByDescending(x => x.Value).ToList();//
        }

        private int GetLecteurOrder(List<int> listparcas)
        {
            int selectVal = 0;
           var distinctlecteur= listparcas.AsQueryable().Distinct();
           Dictionary<int, int> orderNodeLecteur = new Dictionary<int, int>();
            foreach(int item in distinctlecteur )
            {
              //on va chercher le meme ordre des lecteurs pour comparer
                                orderNodeLecteur.Add(item, GetMemeOrdreLecteur(item));

            }
            //trier selon le plus grand lecteur
             
                var itemChoisie  = orderNodeLecteur.Select(x => x).OrderByDescending(y => y.Value).ToList();
                if (itemChoisie.Count > 0)
                    return itemChoisie[0].Key;
                else
            return selectVal;
        }
        private int GetMemeOrdreLecteur(int lecteur)
        {
            TreeNode[] ListeLecteurTrouve = TreeListeLecteur.Nodes.Find(lecteur.ToString(), true);
            TreeNode NodePArent = ListeLecteurTrouve[0];
            if (NodePArent.Parent.Name == "")//cas ou c'est le premier element comme نافع"
                return Convert.ToInt32(NodePArent.FirstNode.Name);
            else
                return lecteur;
        }

        private bool chercherNomCasMemeLecteur(string NomDifference,     int  codelecteur, Dictionary<int, string> orderCas)
        {
           bool trouveLeceur = false;
            //on va chercher les nom du cas et voir si on trouve un order pour le meme lecteur ou de l'hiérarchie
            dsListDifference.Tables[0].DefaultView.RowFilter = "IdClasseur = '" + Program.IdClasseur + "' and Nom='" + NomDifference  + "'";

            int codeIdDifference = 0;
            if (dsListDifference.Tables[0].DefaultView.ToTable().Rows.Count > 0)
            {
                codeIdDifference = Convert.ToInt16(dsListDifference.Tables[0].DefaultView.ToTable().Rows[0]["Difference_Id"].ToString());
                dsListDifference.Tables["listordrelecteur"].DefaultView.RowFilter = "Difference_Id = '" + codeIdDifference + "'";
                int listorderLecteurId = 0;
                if (dsListDifference.Tables["listordrelecteur"].DefaultView.ToTable().Rows.Count > 0)
                {
                    listorderLecteurId = Convert.ToInt16(dsListDifference.Tables["listordrelecteur"].DefaultView.ToTable().Rows[0]["listordreLecteur_Id"].ToString());
                    dsListDifference.Tables["ordrelecteur"].DefaultView.RowFilter = "listordreLecteur_Id = '" + listorderLecteurId + "'";
                    //extraire les lecteur du ficher exclusion du cas selectionner
                    string ListCodeCasSelection = "0";
                    for (int m = 0; m < dsListDifference.Tables["ordrelecteur"].DefaultView.ToTable().Rows.Count; m++)
                    {
                        if (ListCodeCasSelection == "0")
                            ListCodeCasSelection = dsListDifference.Tables["ordrelecteur"].DefaultView.ToTable().Rows[m][0].ToString();
                        else
                            ListCodeCasSelection += "," + dsListDifference.Tables["ordrelecteur"].DefaultView.ToTable().Rows[m][0].ToString();
                    }
                    int ordreLecteurId = 0;
                    if (dsListDifference.Tables["ordrelecteur"].DefaultView.ToTable().Rows.Count > 0)
                    {

                        ordreLecteurId = Convert.ToInt16(dsListDifference.Tables["ordrelecteur"].DefaultView.ToTable().Rows[0]["ordreLecteur_Id"].ToString());
                    }

                    //il faut parcourir les lecteur actullle pour extraire le code pour filter dans les nom
                    //on doit extraire les exceptions du lecteur qu'on a 
                    //extraire les distinct lecteur pour voir il existe dans l'exception 
                    string distinctCodeLecteur = "0";
                    //IEnumerable<int> distinctLecteur = orderNode.Values.Distinct();
                    //foreach (var ParcourNode1 in distinctLecteur)
                    //{
                    //    if (distinctCodeLecteur == "0")
                    //        distinctCodeLecteur = ParcourNode1.ToString();
                    //    else
                    //        distinctCodeLecteur += "," + ParcourNode1.ToString();
                    //}
                    //filtersur les lecteur trouver
                    dsListDifference.Tables["lecteur"].DefaultView.RowFilter = "ordreLecteur_Id in( " + ListCodeCasSelection + ") and idlecteur in (" + codelecteur + ")";
                    //exraire les code
                    string ListCodeCas = "-1";
                    for (int m = 0; m < dsListDifference.Tables["lecteur"].DefaultView.ToTable().Rows.Count; m++)
                    {
                        if (ListCodeCas == "-1")
                            ListCodeCas = dsListDifference.Tables["lecteur"].DefaultView.ToTable().Rows[m][2].ToString();
                        else
                            ListCodeCas += "," + dsListDifference.Tables["lecteur"].DefaultView.ToTable().Rows[m][2].ToString();
                    }
                    //si on trouve des ligne sela veut dir qu'il faut trier selon ordre trouver
                    dsListDifference.Tables["string"].DefaultView.RowFilter = " nomcas_id in( " + ListCodeCas + ")";//ordreLecteurId string_text in(" + listNomcas + ") and
                    DataTable dtNomCas = dsListDifference.Tables["string"].DefaultView.ToTable();
                    for (int i=0;i< dtNomCas.Rows.Count ;i++)
                    {
                        orderCas.Add(i, dtNomCas.Rows[i][0].ToString());
                       
                    }
                }


            }
            return trouveLeceur;
        }
        private List<intersection> OldAffichage(List<intersection> MyFilterIntersect)
        {
            int maxVal = 1;
            int codeMinVal = -1;
            List<int> codeMax = new List<int>();
            bool sortir = false;
            bool print = false;
            while (sortir == false)
            {


                print = false;
                foreach (TreeNode aNode in treeVdifference.Nodes)
                {
                    if (aNode.Tag != null && aNode.Tag.ToString() != "-1")
                    {
                        codeMinVal = Convert.ToInt16(aNode.Tag.ToString());
                        codeMax.Add(codeMinVal);
                    }
                    else
                    {
                        foreach (TreeNode aNode1 in aNode.Nodes)
                        {
                            if (aNode1.Tag == null)
                            {
                                List<intersection> getListDifferenceByCode = MyFilterIntersect.Where(x => x.ListDifference.Any(y => y.code == Convert.ToInt16(aNode1.Name))).ToList();
                                if (getListDifferenceByCode.Count > 0)
                                {
                                    int selectVal = getListDifferenceByCode.Select(x => x.listTousLecteur.Max()).OrderByDescending(y => y).First();

                                    if (selectVal > maxVal)
                                    {
                                        codeMax.Clear();
                                        codeMinVal = Convert.ToInt16(aNode1.Name);
                                        codeMax.Add(codeMinVal);

                                        maxVal = selectVal;
                                    }
                                    else
                                        if (selectVal == maxVal)
                                        {
                                            codeMax.Add(Convert.ToInt16(aNode1.Name));
                                        }
                                }
                                else
                                    aNode1.Tag = "utiliser";
                            }
                            //  Console.WriteLine(aNode1.Name + " " + aNode1.Text+" min val ="+gg);
                        }
                        aNode.Tag = codeMinVal;
                    }
                    //sortir de la bouqule si on a parcourir tous la liste
                    if (aNode.PrevNode == null && codeMinVal == -1)
                    {
                        sortir = true;
                        break;
                    }
                    //
                    MyFilterIntersect = MyFilterIntersect.Where(x => x.ListDifference.Any(y => codeMax.Contains(y.code))).ToList();
                    if (MyFilterIntersect.Count > 0 && aNode.NextNode == null)
                    {
                        print = true;
                        PrintResult(MyFilterIntersect);
                        aNode.Nodes[aNode.Nodes.IndexOfKey(codeMinVal.ToString())].Tag = "utililser";
                        aNode.Tag = null;
                    }
                    maxVal = 1;
                    codeMinVal = -1;
                    codeMax.Clear();
                    if (MyFilterIntersect.Count == 0 || aNode.NextNode == null)
                    {
                        bool complet = true;
                        //test si on a competer tous les nodes
                        foreach (TreeNode aNode2 in aNode.Nodes)
                        {
                            if (aNode2.Tag == null)
                            {
                                complet = false;
                                break;
                            }
                        }
                        if (complet == true)
                            foreach (TreeNode aNode2 in aNode.PrevNode.Nodes)
                            {
                                if (aNode2.Name == aNode.PrevNode.Tag.ToString() || aNode.PrevNode.Tag.ToString() == "-1")
                                {
                                    aNode.PrevNode.Tag = null;
                                    aNode2.Tag = "utiliser";
                                    //mettre les autres node comme non utiliser
                                    foreach (TreeNode aNode3 in aNode.Nodes)
                                    {
                                        aNode3.Tag = null;
                                    }
                                    break;
                                }
                            }
                    }
                }
                if (print == false)
                    PrintResult(MyFilterIntersect);
                //
                //MyIntersect.RemoveAll(x => x.id == MyFilterIntersect[0].id);
                MyFilterIntersect = MyIntersect.ToList();
            }
            return MyFilterIntersect;
        }
        [System.Runtime.InteropServices.DllImport("user32", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, int wParam, ref PARAFORMAT lParam);
        const int PFM_SPACEBEFORE = 0x00000000;
        const int PFM_SPACEAFTER = 0x00000000;
        const int PFM_LINESPACING = 0x00000100;
        const int SCF_SELECTION = 1;
        const int EM_SETPARAFORMAT = 1095;
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct PARAFORMAT
        {
            public int cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            // PARAFORMAT2 from here onwards
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
        }
        private void setLineFormat(byte rule, int space)
        {
            PARAFORMAT fmt = new PARAFORMAT();
            fmt.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(fmt);
            fmt.dwMask = PFM_LINESPACING;
            fmt.dyLineSpacing = space;
            fmt.bLineSpacingRule = rule;
            fmt.dySpaceBefore = 15;
            fmt.dySpaceAfter = 25;
            txt_resultat.SelectAll();
            SendMessage(new System.Runtime.InteropServices.HandleRef(txt_resultat, txt_resultat.Handle),
                         EM_SETPARAFORMAT,
                         SCF_SELECTION,
                         ref fmt
                       );
        }
        private void PrintResult(List<intersection> MyFilterIntersect)
        {

            for (int i = 0; i < MyFilterIntersect.Count;i++ )
            {
                txt_resultat.SelectedText = "|";
                string caracretConcatenation = "  +";
                bool trouveSumulaire = false;
                RichTextBox myricheTexCount = new RichTextBox();
                myricheTexCount.SelectedText = "|";
                //afficher la resultat
                for (int k = 0; k < MyFilterIntersect[i].ListDifference.Count; k++)
                {
                    
                    if (k == MyFilterIntersect[i].ListDifference.Count - 1)
                        caracretConcatenation = "   ";
                    if (i > 0 && k != MyFilterIntersect[i].ListDifference.Count - 1 && MyFilterIntersect[i].ListDifference[k].code == MyFilterIntersect[i - 1].ListDifference[k].code && trouveSumulaire == false)
                    {
                        int nbcaractaire = MyFilterIntersect[i].ListDifference[k].Nom.Length;
                        //string tabs = new String(' ', nbcaractaire);+= tabs + "|" + tabs;   
                        txt_resultat.SelectionFont = new System.Drawing.Font(txt_resultat.SelectionFont, FontStyle.Regular);
                        txt_resultat.SelectionColor = Color.White;
                        txt_resultat.SelectedText ="  "+ MyFilterIntersect[i].ListDifference[k].Nom+"   ";
                        myricheTexCount.SelectedText ="  "+ MyFilterIntersect[i].ListDifference[k].Nom+"   ";
                        txt_resultat.SelectionColor = Color.Black;
                        txt_resultat.SelectionFont = new System.Drawing.Font(txt_resultat.SelectionFont, FontStyle.Regular);
                        if (i < MyFilterIntersect.Count - 1 && MyFilterIntersect[i].ListDifference[k].code == MyFilterIntersect[i + 1].ListDifference[k].code)
                        {
                            txt_resultat.SelectedText = "|"; //caracretConcatenation;    
                            myricheTexCount.SelectedText = "|";
                        }
                    }
                    else
                    {
                        txt_resultat.SelectionColor = Color.Black;

                        if (trouveSumulaire == false && txt_resultat.Text.Substring(txt_resultat.Text.Length - 1) != "|")//la premier fois ou il trouveune difference et on n'a pas ecrit le |
                        {
                            txt_resultat.SelectionFont = new System.Drawing.Font(txt_resultat.SelectionFont, FontStyle.Underline);
                            txt_resultat.SelectedText = "|";
                            myricheTexCount.SelectedText = "|";
                        }
                        
                        if(i>0)
                            txt_resultat.SelectionFont = new System.Drawing.Font(txt_resultat.SelectionFont, FontStyle.Underline);
                        else
                            txt_resultat.SelectionFont = new System.Drawing.Font(txt_resultat.SelectionFont, FontStyle.Regular);
                        txt_resultat.SelectedText="  "+ MyFilterIntersect[i].ListDifference[k].Nom + caracretConcatenation;
                        myricheTexCount.SelectedText="  "+ MyFilterIntersect[i].ListDifference[k].Nom + caracretConcatenation;
                        //si on a trouver une colonne different il faut afficher les autres colonne meme s'il est agale a ligne presedent
                        trouveSumulaire = true;
                    }
                }
                caracretConcatenation = " + ";
                txt_resultat.SelectionFont = new System.Drawing.Font(txt_resultat.SelectionFont, FontStyle.Underline);
                txt_resultat.SelectionColor = Color.Black;
                //allignement selon la plus grande ligne
                      Graphics gr = myricheTexCount.CreateGraphics();
                      SizeF text_size = gr.MeasureString(myricheTexCount.Text,myricheTexCount.Font);
                       float currentTextLength = text_size.Width;
                      float maxLength=160;
                      if (currentTextLength < maxLength)
                          txt_resultat.SelectedText = new string(' ', Convert.ToInt16((maxLength - currentTextLength) / 3)) + ":";
                      else
                          txt_resultat.SelectedText = new string(' ', 1) + ":";
                     // Console.WriteLine(Convert.ToInt16((maxLength - currentTextLength) / 3.666666) + "   "+(maxLength - currentTextLength) / 3.666666);
                /////

                string ListNomLecteur = "";
                for (int l = 0; l < MyFilterIntersect[i].listTousLecteur.Count; l++)
                {
                    if (l == MyFilterIntersect[i].listTousLecteur.Count - 1)
                        caracretConcatenation = "";
                    TreeNode[] ListeLecteurTrouve = TreeListeLecteur.Nodes.Find(MyFilterIntersect[i].listTousLecteur[l].ToString(), true);
               ////     MyFilterIntersect[i].listTousLecteur.Contains(dsCodeLecteur.Tables["CodeLecteur"].ToString());
                    //DataRow[] NomLecteur = dsListDifference.Tables["lecteur"].Select("idlecteur='" + MyFilterIntersect[i].listTousLecteur[l] + "'");
                    if (ListeLecteurTrouve.Length > 0)
                    {
                        if (ListeLecteurTrouve[0].Tag.ToString()!="")
                            ListNomLecteur += ListeLecteurTrouve[0].Tag.ToString() + caracretConcatenation;
                        else
                            ListNomLecteur += ListeLecteurTrouve[0].Text.ToString() + caracretConcatenation;
                    }

                }
                txt_resultat.SelectionFont = new System.Drawing.Font(txt_resultat.SelectionFont, FontStyle.Regular);
                txt_resultat.SelectedText="  "+ ListNomLecteur;
                txt_resultat.SelectedText= Environment.NewLine;
            }
        }

        private void RemplirResultat()
        {

            for (int i = 0; i < intersect.Count; i++)
            {
                for (int j = 0; j < ListTableDifference.Count; j++)
                {
                    if (Convert.ToInt16(ListTableDifference[j][0]) == intersect[i][0])
                    {
                        //parcourir et afficher les nom du difference
                        for (int k = 1; k < ListTableDifference[j].Count; k++)
                            txt_resultat.Text += ListTableDifference[j][k] + " + ";
                        txt_resultat.Text += " => ";
                        string ListNomLecteur = "";
                        for (int l = 1; l < intersect[i].Count; l++)
                        {

                            DataRow[] NomLecteur = dsListDifference.Tables["lecteur"].Select("idlecteur='" + intersect[i][l] + "'");
                            if (NomLecteur.Length > 0)
                                ListNomLecteur += NomLecteur[0][1].ToString() + " ,";

                        }
                        txt_resultat.Text += ListNomLecteur;
                        txt_resultat.Text += Environment.NewLine;

                    }
                }
            }
        }

        private void OrdonnerList()
        {
            int finlist = intersect.Count - 1;
            // intersect[5][3] = 4100;
            //   intersect[0].RemoveAt(3);
            while (finlist > 0)
            {
                bool trouve = false;
                //compare le dernier element avec l'element precedent
                for (int i = finlist - 1; i >= 0; i--) // Array Sorting
                {
                    //si l'element precedent est inferienr il faut le remplacer
                    if (intersect[i][1] > intersect[finlist][1])
                    {
                        intersect.Insert(i, intersect[finlist]);
                        intersect.RemoveAt(finlist + 1);
                        trouve = true;
                        break;
                    }
                    else if (intersect[i][1] == intersect[finlist][1])//si les 2 element sont egaux il faut comparer les sous elements
                    {
                        //int testi = intersect[i][1];
                        //int testfinish = intersect[finlist][1];
                        for (int h = 1; h < intersect[i].Count; h++)
                        {
                            if (h <= intersect[finlist].Count - 1)
                            {
                                //int testi1 = intersect[i][h];
                                //int testfinish1 = intersect[finlist][h];
                                //extraire le rang 1 
                                int val1 = Convert.ToInt16(intersect[i][h]) / 1000;
                                int val2 = Convert.ToInt16(intersect[finlist][h]) / 1000;
                                if (val1 == val2)//s'il sont egaux il prendrele plus grands
                                {
                                    if (intersect[i][h] < intersect[finlist][h])
                                    {
                                        intersect.Insert(i, intersect[finlist]);
                                        intersect.RemoveAt(finlist + 1);

                                        break;
                                    }
                                }
                                else//si non prendre le plus petit
                                {
                                    if (intersect[i][h] > intersect[finlist][h])
                                    {
                                        intersect.Insert(i, intersect[finlist]);
                                        intersect.RemoveAt(finlist + 1);

                                        break;
                                    }
                                }

                            }
                            else
                                break;
                        }
                    }

                }
                if (trouve == false)
                    finlist--;
            }
        }

        List<List<string>> ListTableDifference = new List<List<string>>();
        
        int compteur;
        void ListTousIntersection(TreeNodeCollection treeNode )
        {
           
            for (int i = 0; i < treeNode.Count;i++ )
            {
               

                //txt_resultat.Text += treeNode[i].Text + " ";
                TableDifference[treeNode[i].Parent.Index] = treeNode[i].Text;
                IdDifference[treeNode[i].Parent.Index] = treeNode[i].Name;
                NomDifference[treeNode[i].Parent.Index] = treeNode[i].Parent.Text;
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
                       listTousLecteur[j] =new List<int>();
                        for (int k = 0; k < dtfilter.Rows.Count;k++ )
                            listTousLecteur[j].Add(Convert.ToInt16( dtfilter.Rows[k][0].ToString()));

                    }
                     List<int> Firstintersect  = LintercectList(listTousLecteur);
                    //rechercher si on trouve une Exclusion

                    //parcour tous les exclusion 1 par 1 
                     dsExclusion.Tables["exclusions"].DefaultView.RowFilter = "IdClasseur = '" + Program.IdClasseur + "'";
                     DataTable dtexculion = dsExclusion.Tables["exclusions"].DefaultView.ToTable();
                     for (int b = 0; b < dtexculion.Rows.Count; b++)
                     {
                     bool trouveExclusion = false;
                         dsExclusion.Tables["DifferenceCas"].DefaultView.RowFilter = "DifferenceCas_id='"+ dtexculion.Rows[b]["exclusions_id"].ToString() +"'";
                         DataTable dtNomDifferenceCas = dsExclusion.Tables["DifferenceCas"].DefaultView.ToTable();
                                     //string ConcatDifference = "";
                                     //foreach(var item in NomDifference)
                                     //{
                                     //    if(ConcatDifference == "")
                                     //    ConcatDifference += item;
                                     //    else
                                     //    ConcatDifference +=" + "+ item;
                                     //}
                                     //    ConcatDifference +=" : ";

                                     //    for (int o = 0; o < TableDifference.LongLength;o++ )
                                     //        if(o==0)
                                     //            ConcatDifference +=  TableDifference[o].ToString();
                                     //        else
                                     //            ConcatDifference += "  +  " + TableDifference[o].ToString();

                                     //string [] exraireDifference=    dtexculion.Rows[b]["id"].ToString().Split('>');
                                     //string difference = "";
                                     //if(exraireDifference.Length>1)
                                     //{
                                     //     difference = exraireDifference[0].Replace("=", "").Trim();
                                     //}
                                     //if (difference == ConcatDifference)
                                     //    trouveExclusion = true;
                       
                         int nbtrouve=0;
                         for (int y = 0; y < dtNomDifferenceCas.Rows.Count; y++)
                         {
                             //il faut que le nom casexiste
                              for (int o = 0; o < TableDifference.LongLength;o++ )
                                 if(TableDifference[o].ToString()==dtNomDifferenceCas.Rows[y]["NomCas"].ToString())
                                 {
                                     if(NomDifference[o].ToString()==dtNomDifferenceCas.Rows[y]["Nomdifference"].ToString())
                                         nbtrouve++;
                                 }

                             //if (!TableDifference.Contains(dtNomDifferenceCas.Rows[y]["NomCas"].ToString()))
                             //{
                             //    trouveExclusion = false;
                             //}
                             ////et aussi nom difference
                             //if (!NomDifference.Contains(dtNomDifferenceCas.Rows[y]["Nomdifference"].ToString()))
                             //{
                             //    trouveExclusion = false;
                             //}


                        }
                         if (nbtrouve == dtNomDifferenceCas.Rows.Count)
                             trouveExclusion = true;
                         //sion trouve on doit supprimer les lecteurs trouver
                         if (trouveExclusion == true && Firstintersect.Count > 0)
                         {
                         //filter des lecteurs selon  exclusions_id
                         dsExclusion.Tables["Lecteur"].DefaultView.RowFilter = "lecteur_id = '" + dtexculion.Rows[b]["exclusions_id"].ToString() + "'";//puisque exclusions_id=lecteurid
                         DataTable dtLecteur = dsExclusion.Tables["Lecteur"].DefaultView.ToTable();

                         for (int y = 0; y < dtLecteur.Rows.Count; y++)
                             Firstintersect.Remove(Convert.ToInt16(dtLecteur.Rows[y]["IdLecteur"].ToString()));

                         }
                     }
                    if (Firstintersect.Count > 0)
                    {
                        List<string> templist=new List<string>();
                      //  Firstintersect.Insert(0, compteur);
                        intersect.Add(Firstintersect);
                            templist.Add(compteur.ToString());
                        foreach (string difference in TableDifference)
                            templist.Add( difference );
                        //remplir la liste des mots de difference dans une liste
                        ListTableDifference.Add(templist);
                       
                        intersection tempinersect = new intersection();
                        tempinersect.id = compteur;
                        tempinersect.ordre = 0;
                        tempinersect.ListDifference =new List<ChoixDifference>();
                        for (int j = 0; j < IdDifference.Length; j++)
                        {
                            ChoixDifference mychoix = new ChoixDifference();
                            mychoix.code =Convert.ToInt16( IdDifference[j]);
                            mychoix.Nom =  TableDifference[j] ;
                            tempinersect.ListDifference.Add(mychoix);
                        }
                        tempinersect.listTousLecteur = Firstintersect;
                         compteur++;//ce compteur est utiliser pour faire une corespendance entre list des lecteurs et liste des mots de difference
                        MyIntersect.Add(tempinersect);
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
                   List<int> items2=listTousLecteur[h];
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
                                if (ParcourNodePArent.Parent.Name == "")//cas ou c'est le premier element comme نافع"
                                {
                                    ResultatFinal.Add(valmax);
                                    ParcourNodePArent = ParcourNodePArent.Parent;
                                }
                                else
                                //verifer si le petit est un enfant du grand
                                while (ParcourNodePArent.Parent != null)
                                {
                                  
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

                }
               tableResultat.Clear();
                //copier le resultat
                foreach (int number in ResultatFinal)
                    tableResultat.Add(number);
                ResultatFinal.Clear();
            }
            return tableResultat;

        }
        private int checkPrint;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            checkPrint = txt_printresult.Print(checkPrint, txt_printresult.TextLength, e);

            if (checkPrint < txt_printresult.TextLength)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            txt_printresult.Text = "";

            txt_printresult.Rtf = txt_resultat.Rtf;
            //string[] listLigne = txt_resultat.Text.Split('\n');
            //int maxindexTrouve = 0;
            //for (int i = 0; i < listLigne.Length; i++)
            //{
            //    int indexTrouve = listLigne[i].ToString().IndexOf(':');
            //    if (indexTrouve > maxindexTrouve)
            //        maxindexTrouve = indexTrouve;
            //}
           // int sommeIndex = 0;
           // for(int i=0;i<listLigne.Length;i++)
           // {
           //   int indexTrouve=  listLigne[i].ToString().IndexOf(':');
           //   sommeIndex += indexTrouve;
           //  txt_resultat.SelectionStart =sommeIndex+(maxindexTrouve-indexTrouve) ;
           //  txt_resultat.SelectionLength = 10;
           // txt_resultat.SelectionFont = new System.Drawing.Font(txt_resultat.SelectionFont, FontStyle.Underline);
           // txt_resultat.SelectedText =  "   :";
           // }
            //string word = ":";
            //int s_start = txt_resultat.SelectionStart, startIndex = 0, index;
            //while ((index = txt_resultat.Text.IndexOf(word, startIndex)) != -1)
            //{
            //    txt_resultat.Select(index, word.Length);
            //    txt_resultat.SelectionColor = Color.Red;
            //    startIndex = index + word.Length;
            //}
            txt_printresult.SelectionStart = 0;
            txt_printresult .SelectionLength = 0;
            //txt_partie.Font = new System.Drawing.Font("Arial Unicode MS", 6);
            txt_printresult.SelectedRtf = txt_partie.Rtf;

           txt_printresult.SelectedText= Environment.NewLine ;
           txt_printresult.SelectionStart = txt_printresult.TextLength;
           txt_printresult.SelectionFont = new System.Drawing.Font(txt_printresult.SelectionFont, FontStyle.Regular);

           txt_printresult.SelectedText="\n\r"+txt_remarque.Text;
          //  txt_printresult.Rtf += Environment.NewLine;
            var ppDlg = new PrintPreviewDialog();
            ppDlg.SetBounds(30, 30, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            ppDlg.PrintPreviewControl.AutoZoom = true;
            ppDlg.PrintPreviewControl.Zoom = 1.0;
            ppDlg.Document = printDocument1;
            var dr = ppDlg.ShowDialog();

        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            checkPrint = 0;
        }

        private void treeVdifference_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 46)
            {
                if ( treeVdifference.SelectedNode.Parent == null)
                    treeVdifference.Nodes.Remove(treeVdifference.SelectedNode);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_resultat.Rtf = txt_resultat.Rtf.Replace("\\slmult1", "\\slmult0");
         //   setLineFormat(5, 5);

        }
    
        private void dt_aya_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dt_aya.SelectedValue.ToString() != "System.Data.DataRowView" && txt_quran.Text!="")
            {
                txt_quran.SelectionStart = txt_quran.Find("{" + dt_aya.SelectedValue + "}");
                txt_quran.ScrollToCaret();
            }
        }

        private void btclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            Ensemble myEnsemble = new Ensemble();
            myEnsemble.nomSoura = dt_sura.Text;
            if (selectedAya == 0)
                myEnsemble.numerSoura = Convert.ToInt16(dt_aya.Text);
            else
                myEnsemble.numerSoura = selectedAya;
            myEnsemble.segment = txt_partie.Text;
            myEnsemble.resultat = txt_resultat.Rtf;
            myEnsemble.remarque = txt_remarque.Text;
            myEnsemble.IdClasseur = Program.IdClasseur;
            myEnsemble.nomDifference=new List<string>();
            foreach (TreeNode aNode in treeVdifference.Nodes)
                myEnsemble.nomDifference.Add(aNode.Text);

            XmlDocument doc = new XmlDocument();
            doc.Load("Ensemble.xml"); // Load xml file data to xmlDocument
            if (mode == "Modif")//recherer et supprimer avant d'ajouter
            {
                myEnsemble.IdEnsemble =IdEnsemble ;
                XmlNode cas = doc.SelectSingleNode("/Ensembles/Ensemble[IdEnsemble='" + IdEnsemble + "']");
                doc.ChildNodes[1].RemoveChild(cas);
            }
            else
                myEnsemble.IdEnsemble = Guid.NewGuid().ToString("N");
            XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "Ensemble1", null);
            XmlSerializer xSeriz = new XmlSerializer(typeof(Ensemble));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlWriterSettings writtersetting = new XmlWriterSettings();
            writtersetting.OmitXmlDeclaration = true;
            StringWriter stringwriter = new StringWriter();
            using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
            {
                xSeriz.Serialize(xmlwriter, myEnsemble, ns);
            }
            xnode.InnerXml = stringwriter.ToString();
            XmlNode bindxnode = xnode.SelectSingleNode("Ensemble");
            doc.DocumentElement.AppendChild(bindxnode);

            doc.Save("Ensemble.xml");


            MessageBox.Show("تمت العملية بنجاح");

             myEnsemble.segment = "";
            myEnsemble.resultat = "";
            treeVdifference.Nodes.Clear();
        }

        private void btrefrech_Click(object sender, EventArgs e)
        {
            ChargerDifference();
        }


    }
}