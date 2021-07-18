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
    public partial class Frm_ListSegment : Form
    {
        public Frm_ListSegment()
        {
            InitializeComponent();
        }
        DataSet dsListSegment = new DataSet();
        private void Frm_ListSegment_Load(object sender, EventArgs e)
        {
            AfficherList();
        }

        private void AfficherList()
        {
            dsListSegment.Clear();
            dsListSegment.ReadXml("Ensemble.xml", XmlReadMode.InferSchema);
            try
            {
                dsListSegment.Tables[0].DefaultView.RowFilter = "IdClasseur = '" + Program.IdClasseur + "'";
            }
            catch (Exception) { }

            gridListDifference.DataSource = dsListSegment.Tables[0].DefaultView.ToTable();
            gridListDifference.Columns[0].HeaderText = "السورة";
            gridListDifference.Columns[0].Width = 70;
            gridListDifference.Columns[1].HeaderText = "لآية";
            gridListDifference.Columns[1].Width = 70;
            gridListDifference.Columns[2].HeaderText = "المقطع";
          //  gridListDifference.Columns[2].Width = 370;
            gridListDifference.Columns[3].Visible = false;
            if (gridListDifference.Columns.GetColumnCount(DataGridViewElementStates.None) > 4)
            {
                gridListDifference.Columns[4].Visible = false;
                gridListDifference.Columns[5].Visible = false;
                gridListDifference.Columns[6].Visible = false;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAjout_Click(object sender, EventArgs e)
        {
            if (testaffichacheenfant("Frm_secgment") == false)
            {
                Frm_segment myfrm = new Frm_segment();
                myfrm.MdiParent = this.MdiParent;

                myfrm.Show();
                myfrm.FormClosed += myfrm_FormClosed;
                myfrm.WindowState = FormWindowState.Maximized;
                //myfrm.Dock = DockStyle.Fill;
            }
        }
        private bool testaffichacheenfant(string NomFrm)
        {
            foreach (Form frm in this.MdiParent.MdiChildren)
            {
                if (frm.Name == NomFrm)
                {
                    frm.Hide();
                    frm.Show();
                    return true;
                }
            }
            return false;
        }

        private void btModifier_Click(object sender, EventArgs e)
        {

            if (testaffichacheenfant("Frm_secgment") == false)
            {
                dsListSegment.Tables["Ensemble"].DefaultView.RowFilter = "IdClasseur = '" + Program.IdClasseur + "' and segment='" + gridListDifference.SelectedRows[0].Cells[2].Value.ToString() + "'";
                string idEnsemble = dsListSegment.Tables["Ensemble"].DefaultView.ToTable().Rows[0]["Ensemble_id"].ToString();

                dsListSegment.Tables["string"].DefaultView.RowFilter = "nomDifference_id='" + idEnsemble + "'";
                DataTable dtfilter = dsListSegment.Tables["string"].DefaultView.ToTable();


                string remarque = "";
                string idSegment = "";
                if (gridListDifference.Columns.GetColumnCount(DataGridViewElementStates.None) > 4)
                {
                    remarque = gridListDifference.SelectedRows[0].Cells[4].Value.ToString();
                    idSegment = gridListDifference.SelectedRows[0].Cells[5].Value.ToString();
                }

                Frm_segment myfrm = new Frm_segment("Modif", gridListDifference.SelectedRows[0].Cells[0].Value.ToString(), gridListDifference.SelectedRows[0].Cells[2].Value.ToString(), gridListDifference.SelectedRows[0].Cells[3].Value.ToString(), dtfilter,remarque,idSegment);
                myfrm.MdiParent = this.MdiParent;
                myfrm.Show();

                dsListSegment.Tables["string"].DefaultView.RowFilter = string.Empty;
                dsListSegment.Tables["Ensemble"].DefaultView.RowFilter = "IdClasseur = '" + Program.IdClasseur + "'";
                myfrm.FormClosed +=myfrm_FormClosed;
                myfrm.WindowState = FormWindowState.Maximized;
                //myfrm.Dock = DockStyle.Fill;
            }
        }

        private void myfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AfficherList();
        }

        private void btsupprimer_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Ensemble.xml"); // Load xml file data to xmlDocument
            if (MessageBox.Show(" هل انت متاكد من حذف " + gridListDifference.SelectedRows[0].Cells[2].Value.ToString(), "تنبيه", MessageBoxButtons.YesNo) == DialogResult.Yes)//recherer et supprimer 
            {
                XmlNode cas = doc.SelectSingleNode("/Ensembles/Ensemble[IdEnsemble='" + gridListDifference.SelectedRows[0].Cells[5].Value.ToString() + "']");
                doc.ChildNodes[1].RemoveChild(cas);
                doc.Save("Ensemble.xml");
                AfficherList();
            }
        }

        private void txt_recherche_TextChanged(object sender, EventArgs e)
        {
            if (txt_recherche.Text != "")
                dsListSegment.Tables[0].DefaultView.RowFilter = "segment like '" + txt_recherche.Text + "%' or numerSoura like '" + txt_recherche.Text + "%' or nomSoura like '" + txt_recherche.Text + "%'";
            else
                dsListSegment.Tables[0].DefaultView.RowFilter = string.Empty;
            gridListDifference.DataSource = dsListSegment.Tables[0].DefaultView.ToTable();
        }

        private void btActualiser_Click(object sender, EventArgs e)
        {
            AfficherList();
        }
    }
}
