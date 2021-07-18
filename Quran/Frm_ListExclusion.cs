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
    public partial class Frm_ListExclusion : Form
    {
        public Frm_ListExclusion()
        {
            InitializeComponent();
        }
        DataTable dsListDifference = new DataTable();
        private void Frm_ListExclusion_Load(object sender, EventArgs e)
        {
            AfficherList();
        }

        private void AfficherList()
        {   
            dsListDifference.Clear();
            DataSet ds = new DataSet();
            ds.ReadXml("Exclusions.xml", XmlReadMode.InferSchema);
            try
            {
                ds.Tables[0].DefaultView.RowFilter = "IdClasseur = '" + Program.IdClasseur + "'";
            }
            catch (Exception) { }
            dsListDifference = ds.Tables[0].DefaultView.ToTable();

            gridListDifference.DataSource = dsListDifference;
            gridListDifference.Columns[0].HeaderText = "الاسم";
            gridListDifference.Columns[0].Width = 500;
             if (gridListDifference.Columns.GetColumnCount(DataGridViewElementStates.None) > 1)
                  gridListDifference.Columns[1].Visible = false;
        }

        private void txt_recherche_TextChanged(object sender, EventArgs e)
        {
            if (txt_recherche.Text != "")
                dsListDifference.DefaultView.RowFilter = "id like '" + txt_recherche.Text + "%'";
            else
                dsListDifference.DefaultView.RowFilter = string.Empty;
        }

        private void btModifier_Click(object sender, EventArgs e)
        {
            Frm_Exclusion myfrm = new Frm_Exclusion("Modif", gridListDifference.SelectedRows[0].Cells[0].Value.ToString());
            myfrm.ShowDialog();
            AfficherList();
        }

        private void btAjout_Click(object sender, EventArgs e)
        {
            Frm_Exclusion myfrm = new Frm_Exclusion();
            myfrm.ShowDialog();
            AfficherList();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btsupprimer_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Exclusions.xml"); // Load xml file data to xmlDocument
            if (MessageBox.Show(" هل انت متاكد من حذف " + gridListDifference.SelectedRows[0].Cells[0].Value.ToString(), "تنبيه", MessageBoxButtons.YesNo) == DialogResult.Yes)//recherer et supprimer 
            {
                XmlNode cas = doc.SelectSingleNode("/ListExclusions/Exclusions[id='" + gridListDifference.SelectedRows[0].Cells[0].Value.ToString() + "']");
                doc.ChildNodes[1].RemoveChild(cas);
                doc.Save("Exclusions.xml");
                AfficherList();
            }
        }

        private void btActualiser_Click(object sender, EventArgs e)
        {
                AfficherList();
        }
    }
}
