using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Quran
{
    public partial class Frm_listClasseur : Form
    {
        public Frm_listClasseur()
        {
            InitializeComponent();
        }
         DataSet dsListClasseur = new DataSet();
        private void Frm_listClasseur_Load(object sender, EventArgs e)
        {
             AfficherList();
        }

        private void AfficherList()
        {
            dsListClasseur.Clear();
            dsListClasseur.Reset();
            dsListClasseur.ReadXml("Classeur.xml", XmlReadMode.InferSchema);
            if (dsListClasseur.Tables.Count > 0)
            {
                    dsListClasseur.Tables[0].DefaultView.RowFilter = "nomClasseur <>'' ";
                    
                gridListClasseur.DataSource = dsListClasseur.Tables[0].DefaultView.ToTable();
                gridListClasseur.Columns[1].HeaderText = "اسم الكراس";
                gridListClasseur.Columns[1].Width = 200;
                gridListClasseur.Columns[2].HeaderText = "الملاحظات";
                gridListClasseur.Columns[2].Width = 200;
                gridListClasseur.Columns[3].HeaderText = "الجمع";
                gridListClasseur.Columns[3].Width = 80;
                gridListClasseur.Columns[0].Visible = false;
              //  gridListClasseur.Columns[4].Visible = false;

            }
        }

        private void btAjout_Click(object sender, EventArgs e)
        {

                Frm_Classeur myfrm = new Frm_Classeur();
                myfrm.ShowDialog();
                AfficherList();

        }
        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btModifier_Click(object sender, EventArgs e)
        {
            Frm_Classeur myfrm = new Frm_Classeur("Modif", gridListClasseur.SelectedRows[0].Cells[0].Value.ToString(), gridListClasseur.SelectedRows[0].Cells[1].Value.ToString());
            myfrm.ShowDialog();
            AfficherList();
        }

        private void btsupprimer_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Classeur.xml"); // Load xml file data to xmlDocument
            if (MessageBox.Show(" هل انت متاكد من حذف " + gridListClasseur.SelectedRows[0].Cells[0].Value.ToString(), "تنبيه", MessageBoxButtons.YesNo) == DialogResult.Yes)//recherer et supprimer 
            {
                XmlNode cas = doc.SelectSingleNode("/Classeur/Classeur[idClasseur='" + gridListClasseur.SelectedRows[0].Cells[0].Value.ToString() + "']");
                doc.ChildNodes[1].RemoveChild(cas);
                doc.Save("Classeur.xml");
                AfficherList();
            }
        }

        private void txt_recherche_TextChanged(object sender, EventArgs e)
        {
            if (txt_recherche.Text != "")
                dsListClasseur.Tables[0].DefaultView.RowFilter = "nomClasseur like '" + txt_recherche.Text + "%'";
            else
                dsListClasseur.Tables[0].DefaultView.RowFilter = string.Empty;
            gridListClasseur.DataSource = dsListClasseur.Tables[0].DefaultView.ToTable();
        }



       
    }
}
