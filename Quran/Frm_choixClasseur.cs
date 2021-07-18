using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quran
{
    public partial class Frm_choixClasseur : Form
    {
        public Frm_choixClasseur()
        {
            InitializeComponent();
        }
        DataSet dsListClasseur = new DataSet();
        private void Frm_choixClasseur_Load(object sender, EventArgs e)
        {
            ChargerClasseur();
        }
        private void ChargerClasseur()
        {
            dsListClasseur.Clear();
            dsListClasseur.ReadXml("Classeur.xml", XmlReadMode.InferSchema);
            if (dsListClasseur.Tables.Count > 0)
            {
                txt_choixClasseur.DataSource = dsListClasseur.Tables[0];
                txt_choixClasseur.DisplayMember = "nomClasseur";
                txt_choixClasseur.ValueMember = "IdClasseur";
                txt_choixClasseur.Text = "";
            }
        }

        private void btAjout_Click(object sender, EventArgs e)
        {

            Frm_Classeur myfrm = new Frm_Classeur();
            myfrm.ShowDialog();
            ChargerClasseur();             
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            if (txt_choixClasseur.Text == "")
                MessageBox.Show("الرجاء اختيار اسم الكراس");
            else
            {
                Program.NomClasseur = txt_choixClasseur.Text;
                Program.IdClasseur = txt_choixClasseur.SelectedValue.ToString();
                Close();
            }
        }

        private void Frm_choixClasseur_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (txt_choixClasseur.Text == "")
            //{
            //    MessageBox.Show("الرجاء اختيار اسم الكراس");
            //    e.Cancel = true;
            //}
            //else
            //{
            //    Program.NomClasseur = txt_choixClasseur.Text;
            //    Close();
            //}

        }
    }
}
