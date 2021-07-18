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
    public partial class Frm_main : Form
    {
        public Frm_main()
        {
            InitializeComponent();
        }

        private void المقاطعToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (testaffichacheenfant("Frm_secgment") == false)
            {
                Frm_segment myfrm = new Frm_segment();
                myfrm.MdiParent = this;

                myfrm.Show();

                myfrm.WindowState = FormWindowState.Maximized;
                //myfrm.Dock = DockStyle.Fill;
            }

        }

        private  bool testaffichacheenfant(string NomFrm)
        {
            if (testChoixClasseur(NomFrm) == true)
                return true;
            foreach (Form frm in this.MdiChildren)
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
        private bool testChoixClasseur(string NomFrm)
        {
            if (Program.IdClasseur == "" && NomFrm != "Frm_listClasseur")
            {
                MessageBox.Show(" الرجاءاختيار كراس العمل");
                return true;
            }
            else
                return false;
        }
        private void اضافةخلافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (testChoixClasseur("") == false)
            {
                Frm_origine myfrm = new Frm_origine();
                //  myfrm.MdiParent = this;
                myfrm.ShowDialog();
            }
        }

        private void قائمةالخلافاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (testaffichacheenfant("Frm_ListOrigine") == false)
            {
                Frm_ListOrigine mylist = new Frm_ListOrigine();
                mylist.MdiParent = this;
                mylist.Show();
                mylist.WindowState = FormWindowState.Maximized;
            }
        }

        private void اضافةامتناعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (testChoixClasseur("") == false)
            {
                Frm_Exclusion myfrm = new Frm_Exclusion();
                myfrm.ShowDialog();
            }
        }

        private void قائمةالامتناعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (testaffichacheenfant("Frm_ListExclusion") == false)
            {
                Frm_ListExclusion mylist = new Frm_ListExclusion();
                mylist.MdiParent = this;
                mylist.Show();
                mylist.WindowState = FormWindowState.Maximized;
            }
        }

        private void قائمةالمقاطعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (testaffichacheenfant("Frm_ListSegment") == false)
            {
                Frm_ListSegment mylist = new Frm_ListSegment();
                mylist.MdiParent = this;
                mylist.Show();
                mylist.WindowState = FormWindowState.Maximized;
            }
        }

        private void قائمةكراساتالعملToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (testaffichacheenfant("Frm_listClasseur") == false)
            {
                Frm_listClasseur mylist = new Frm_listClasseur();
                mylist.MdiParent = this;
                mylist.Show();
                mylist.WindowState = FormWindowState.Maximized;
            }
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {
            Frm_choixClasseur myfrm = new Frm_choixClasseur();
            myfrm.ShowDialog();
            this.Text = "كراس العمل " + Program.NomClasseur;
            label1.Text = "كراس العمل " + Program.NomClasseur;
        }

        private void اختياركراسالعملToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_choixClasseur myfrm = new Frm_choixClasseur();
            myfrm.ShowDialog();
            CloseAllChildren();
            this.Text = "كراس العمل " + Program.NomClasseur;
            label1.Text = "كراس العمل " + Program.NomClasseur;
        }
        public void CloseAllChildren()
        {
            foreach (Form frm in this.MdiChildren)
            {

                    frm.Dispose();
                    frm.Close();
                
            }
        }

        private void رموزالقراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (testaffichacheenfant("Frm_listeCodeLecteur") == false)
            {
                Frm_listeCodeLecteur mylist = new Frm_listeCodeLecteur();
                mylist.MdiParent = this;
                mylist.Show();
                mylist.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
