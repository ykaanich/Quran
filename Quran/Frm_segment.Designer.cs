namespace Quran
{
    partial class Frm_segment
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_segment));
            this.dt_sura = new System.Windows.Forms.ComboBox();
            this.dt_aya = new System.Windows.Forms.ComboBox();
            this.txt_quran = new System.Windows.Forms.RichTextBox();
            this.dtDifference = new System.Windows.Forms.ComboBox();
            this.treeVdifference = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btAjout = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_partie = new System.Windows.Forms.RichTextBox();
            this.btadd = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btPrint = new System.Windows.Forms.Button();
            this.txt_resultat = new ExtendedRichTextBox.RichTextBoxPrintCtrl();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_printresult = new ExtendedRichTextBox.RichTextBoxPrintCtrl();
            this.btsave = new System.Windows.Forms.Button();
            this.btclose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_remarque = new System.Windows.Forms.TextBox();
            this.btrefrech = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dt_sura
            // 
            this.dt_sura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_sura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_sura.FormattingEnabled = true;
            this.dt_sura.Location = new System.Drawing.Point(1119, 25);
            this.dt_sura.Name = "dt_sura";
            this.dt_sura.Size = new System.Drawing.Size(177, 28);
            this.dt_sura.TabIndex = 0;
            this.dt_sura.SelectedIndexChanged += new System.EventHandler(this.dt_sura_SelectedIndexChanged);
            this.dt_sura.TextChanged += new System.EventHandler(this.dt_sura_TextChanged);
            // 
            // dt_aya
            // 
            this.dt_aya.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_aya.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_aya.FormattingEnabled = true;
            this.dt_aya.Location = new System.Drawing.Point(833, 22);
            this.dt_aya.Name = "dt_aya";
            this.dt_aya.Size = new System.Drawing.Size(107, 28);
            this.dt_aya.TabIndex = 1;
            this.dt_aya.SelectedValueChanged += new System.EventHandler(this.dt_aya_SelectedValueChanged);
            // 
            // txt_quran
            // 
            this.txt_quran.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_quran.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_quran.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txt_quran.Location = new System.Drawing.Point(774, 64);
            this.txt_quran.Name = "txt_quran";
            this.txt_quran.Size = new System.Drawing.Size(585, 571);
            this.txt_quran.TabIndex = 2;
            this.txt_quran.Text = "إِنَّ ٱلَّذِينَ كَفَرُوا۟ سَوَآءٌ عَلَيْهِمْ ءَأَنذَرْتَهُمْ أَمْ لَمْ تُنذِرْهُ" +
    "مْ لَا يُؤْمِنُون";
            this.txt_quran.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txt_quran_MouseUp);
            // 
            // dtDifference
            // 
            this.dtDifference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDifference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.dtDifference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dtDifference.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDifference.FormattingEnabled = true;
            this.dtDifference.Location = new System.Drawing.Point(357, 76);
            this.dtDifference.Name = "dtDifference";
            this.dtDifference.Size = new System.Drawing.Size(348, 32);
            this.dtDifference.Sorted = true;
            this.dtDifference.TabIndex = 4;
            this.dtDifference.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtDifference_KeyUp);
            // 
            // treeVdifference
            // 
            this.treeVdifference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeVdifference.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVdifference.Location = new System.Drawing.Point(357, 114);
            this.treeVdifference.Name = "treeVdifference";
            this.treeVdifference.RightToLeftLayout = true;
            this.treeVdifference.Size = new System.Drawing.Size(348, 198);
            this.treeVdifference.TabIndex = 5;
            this.treeVdifference.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeVdifference_KeyUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(711, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "الخلافات";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(715, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "المقطع";
            // 
            // btAjout
            // 
            this.btAjout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btAjout.BackgroundImage")));
            this.btAjout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAjout.FlatAppearance.BorderSize = 0;
            this.btAjout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAjout.Location = new System.Drawing.Point(12, 74);
            this.btAjout.Name = "btAjout";
            this.btAjout.Size = new System.Drawing.Size(32, 25);
            this.btAjout.TabIndex = 7;
            this.btAjout.UseVisualStyleBackColor = true;
            this.btAjout.Visible = false;
            this.btAjout.Click += new System.EventHandler(this.btAjout_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1309, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "السورة";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(958, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "لآية";
            // 
            // txt_partie
            // 
            this.txt_partie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_partie.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_partie.Location = new System.Drawing.Point(12, 19);
            this.txt_partie.Name = "txt_partie";
            this.txt_partie.Size = new System.Drawing.Size(697, 34);
            this.txt_partie.TabIndex = 8;
            this.txt_partie.Text = "";
            this.txt_partie.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txt_partie_MouseUp);
            // 
            // btadd
            // 
            this.btadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btadd.Location = new System.Drawing.Point(208, 278);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(140, 34);
            this.btadd.TabIndex = 9;
            this.btadd.Text = " إنتاج المخطط";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Location = new System.Drawing.Point(2, 419);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(92, 40);
            this.btPrint.TabIndex = 10;
            this.btPrint.Text = "طباعة";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // txt_resultat
            // 
            this.txt_resultat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_resultat.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_resultat.Location = new System.Drawing.Point(100, 318);
            this.txt_resultat.Name = "txt_resultat";
            this.txt_resultat.Size = new System.Drawing.Size(668, 339);
            this.txt_resultat.TabIndex = 11;
            this.txt_resultat.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(146, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_printresult
            // 
            this.txt_printresult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_printresult.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_printresult.Location = new System.Drawing.Point(187, 258);
            this.txt_printresult.Name = "txt_printresult";
            this.txt_printresult.Size = new System.Drawing.Size(108, 44);
            this.txt_printresult.TabIndex = 11;
            this.txt_printresult.Text = "";
            this.txt_printresult.Visible = false;
            // 
            // btsave
            // 
            this.btsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btsave.Location = new System.Drawing.Point(2, 346);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(92, 40);
            this.btsave.TabIndex = 10;
            this.btsave.Text = "حفظ";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // btclose
            // 
            this.btclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btclose.Location = new System.Drawing.Point(2, 595);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(92, 40);
            this.btclose.TabIndex = 10;
            this.btclose.Text = "غلق";
            this.btclose.UseVisualStyleBackColor = true;
            this.btclose.Click += new System.EventHandler(this.btclose_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(277, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "الملاحظات";
            // 
            // txt_remarque
            // 
            this.txt_remarque.Location = new System.Drawing.Point(12, 135);
            this.txt_remarque.Multiline = true;
            this.txt_remarque.Name = "txt_remarque";
            this.txt_remarque.Size = new System.Drawing.Size(335, 126);
            this.txt_remarque.TabIndex = 13;
            // 
            // btrefrech
            // 
            this.btrefrech.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btrefrech.BackgroundImage")));
            this.btrefrech.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btrefrech.FlatAppearance.BorderSize = 0;
            this.btrefrech.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btrefrech.Location = new System.Drawing.Point(315, 75);
            this.btrefrech.Name = "btrefrech";
            this.btrefrech.Size = new System.Drawing.Size(33, 31);
            this.btrefrech.TabIndex = 7;
            this.btrefrech.UseVisualStyleBackColor = true;
            this.btrefrech.Click += new System.EventHandler(this.btrefrech_Click);
            // 
            // Frm_segment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 682);
            this.Controls.Add(this.txt_remarque);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_printresult);
            this.Controls.Add(this.txt_resultat);
            this.Controls.Add(this.btclose);
            this.Controls.Add(this.btsave);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btadd);
            this.Controls.Add(this.txt_partie);
            this.Controls.Add(this.btrefrech);
            this.Controls.Add(this.btAjout);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeVdifference);
            this.Controls.Add(this.dtDifference);
            this.Controls.Add(this.txt_quran);
            this.Controls.Add(this.dt_aya);
            this.Controls.Add(this.dt_sura);
            this.Name = "Frm_segment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المقاطع";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Frm_segment_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dt_sura;
        private System.Windows.Forms.ComboBox dt_aya;
        private System.Windows.Forms.RichTextBox txt_quran;
        private System.Windows.Forms.ComboBox dtDifference;
        private System.Windows.Forms.TreeView treeVdifference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAjout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txt_partie;
        private System.Windows.Forms.Button btadd;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btPrint;
        private ExtendedRichTextBox.RichTextBoxPrintCtrl txt_resultat;
        private System.Windows.Forms.Button button1;
        private ExtendedRichTextBox.RichTextBoxPrintCtrl txt_printresult;
        private System.Windows.Forms.Button btsave;
        private System.Windows.Forms.Button btclose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_remarque;
        private System.Windows.Forms.Button btrefrech;
    }
}

