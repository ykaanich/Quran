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
    public partial class Frm_ListOrigine : Form
    {
        public Frm_ListOrigine()
        {
            InitializeComponent();
        }
        DataTable dsListDifference = new DataTable();
        private void Frm_ListOrigine_Load(object sender, EventArgs e)
        {

            AfficherList();
        }

        private void AfficherList()
        {
            dsListDifference.Clear();
            DataSet ds=new DataSet();
            ds.ReadXml("Difference.xml", XmlReadMode.InferSchema);
            ds.Tables[0].DefaultView.RowFilter = "IdClasseur = '" + Program.IdClasseur + "'";
            dsListDifference = ds.Tables[0].DefaultView.ToTable();
            gridListDifference.DataSource = dsListDifference;
            gridListDifference.Columns[0].HeaderText = "الاسم";
            gridListDifference.Columns[0].Width = 500;
            gridListDifference.Columns[1].Visible = false;
             if (gridListDifference.Columns.GetColumnCount(DataGridViewElementStates.None) > 2)
                gridListDifference.Columns[2].Visible = false;
            this.gridListDifference.Sort(this.gridListDifference.Columns[0], ListSortDirection.Ascending);
        }

        private void txt_recherche_TextChanged(object sender, EventArgs e)
        {
            if (txt_recherche.Text != "")
                dsListDifference.DefaultView.RowFilter = "Nom like '" + txt_recherche.Text + "%'";
            else
                dsListDifference.DefaultView.RowFilter = string.Empty;
        }

        private void btModifier_Click(object sender, EventArgs e)
        {
            if (gridListDifference.Rows.Count >0 )
            {
                Frm_origine myfrm = new Frm_origine("Modif", gridListDifference.SelectedRows[0].Cells[0].Value.ToString());
                myfrm.ShowDialog();
                AfficherList();
            }
        }

        private void btAjout_Click(object sender, EventArgs e)
        {
            Frm_origine myfrm = new Frm_origine();
            myfrm.ShowDialog();
            AfficherList();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btsupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                Program.ExeciteOrigine(gridListDifference.SelectedRows[0].Cells[0].Value.ToString());
                
                XmlDocument doc = new XmlDocument();
                doc.Load("Difference.xml"); // Load xml file data to xmlDocument
                if (MessageBox.Show(" هل انت متاكد من حذف " + gridListDifference.SelectedRows[0].Cells[0].Value.ToString(), "تنبيه", MessageBoxButtons.YesNo) == DialogResult.Yes)//recherer et supprimer 
                {
                    XmlNode cas = doc.SelectSingleNode("/Differences/Difference[Nom='" + gridListDifference.SelectedRows[0].Cells[0].Value.ToString() + "']");
                    doc.ChildNodes[1].RemoveChild(cas);
                    doc.Save("Difference.xml");
                    AfficherList();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
      
        private void btcopie_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Difference.xml"); // Load xml file data to xmlDocument
            if (MessageBox.Show(" هل انت متاكد من نسخ الخلاف " + gridListDifference.SelectedRows[0].Cells[0].Value.ToString(), "تنبيه", MessageBoxButtons.YesNo) == DialogResult.Yes)//recherer et supprimer 
            {
                XmlNode cas = doc.SelectSingleNode("/Differences/Difference[Nom='" + gridListDifference.SelectedRows[0].Cells[0].Value.ToString() + "']");
                XmlNode copiecas = cas.CloneNode(true);
                copiecas.FirstChild.InnerText = gridListDifference.SelectedRows[0].Cells[0].Value.ToString() + " ( نسخة )";
                doc.DocumentElement.AppendChild(copiecas);
                doc.Save("Difference.xml");
                AfficherList();
            }
        }
        private void btActualiser_Click(object sender, EventArgs e)
        {
            AfficherList();
        }
    }
}
