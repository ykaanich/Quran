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
    public partial class Frm_listeCodeLecteur : Form
    {
        public Frm_listeCodeLecteur()
        {
            InitializeComponent();
        }
        DataSet dsListCodeLecteur = new DataSet();
        private void Frm_listeCodeLecteur_Load(object sender, EventArgs e)
        {
            AfficherList();
        }
        private void AfficherList()
        {
            dsListCodeLecteur.Clear();
            dsListCodeLecteur.Reset();
            dsListCodeLecteur.ReadXml("CodeLecteur.xml", XmlReadMode.InferSchema);
            if (dsListCodeLecteur.Tables.Count > 0)
            {
                dsListCodeLecteur.Tables[0].DefaultView.RowFilter = "nomCodeLecteur <>'' ";

                gridListClasseur.DataSource = dsListCodeLecteur.Tables[0].DefaultView.ToTable();
                gridListClasseur.Columns[1].HeaderText = "اسم الرموز";
                gridListClasseur.Columns[1].Width = 200;
                gridListClasseur.Columns[3].HeaderText = "القراء";
                gridListClasseur.Columns[3].Width = 200;
                gridListClasseur.Columns[2].HeaderText = "الجمع";
                gridListClasseur.Columns[2].Width = 80;
                gridListClasseur.Columns[0].Visible = false;
                 gridListClasseur.Columns[4].Visible = false;

            }
        }
        private void btAjout_Click(object sender, EventArgs e)
        {
            Frm_CodeLecteur myfrm = new Frm_CodeLecteur();
            myfrm.ShowDialog();
            AfficherList();
        }

        private void btModifier_Click(object sender, EventArgs e)
        {
            Frm_CodeLecteur myfrm = new Frm_CodeLecteur("Modif", gridListClasseur.SelectedRows[0].Cells[0].Value.ToString());
            myfrm.ShowDialog();
            AfficherList();
        }

        private void btsupprimer_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("CodeLecteur.xml"); // Load xml file data to xmlDocument
            if (MessageBox.Show(" هل انت متاكد من حذف " + gridListClasseur.SelectedRows[0].Cells[1].Value.ToString(), "تنبيه", MessageBoxButtons.YesNo) == DialogResult.Yes)//recherer et supprimer 
            {
                XmlNode cas = doc.SelectSingleNode("/CodeLecteur/CodeLecteur[IdCodeLecteur='" +  gridListClasseur.SelectedRows[0].Cells[0].Value.ToString() + "']");
                doc.ChildNodes[1].RemoveChild(cas);
                doc.Save("CodeLecteur.xml");
                AfficherList();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btActualiser_Click(object sender, EventArgs e)
        {
                AfficherList();
        }
    }
}
