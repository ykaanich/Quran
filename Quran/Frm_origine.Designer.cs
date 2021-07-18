namespace Quran
{
    partial class Frm_origine
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
            this.label1 = new System.Windows.Forms.Label();
            this.btaddhala = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_type = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.treeViewCas = new System.Windows.Forms.TreeView();
            this.label6 = new System.Windows.Forms.Label();
            this.treeVLecteur = new System.Windows.Forms.TreeView();
            this.btLecteur = new System.Windows.Forms.Button();
            this.btAjout = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.treeVOrderLecteur = new System.Windows.Forms.TreeView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ckSelecetAll = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(953, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "اضافة خلاف";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btaddhala
            // 
            this.btaddhala.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btaddhala.Location = new System.Drawing.Point(496, 107);
            this.btaddhala.Name = "btaddhala";
            this.btaddhala.Size = new System.Drawing.Size(178, 28);
            this.btaddhala.TabIndex = 1;
            this.btaddhala.Text = "اضافة الحالة       ==>";
            this.btaddhala.UseVisualStyleBackColor = true;
            this.btaddhala.Click += new System.EventHandler(this.btaddhala_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(899, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "الاسم";
            // 
            // txt_nom
            // 
            this.txt_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nom.Location = new System.Drawing.Point(555, 42);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.Size = new System.Drawing.Size(338, 26);
            this.txt_nom.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(899, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "النوع";
            // 
            // txt_type
            // 
            this.txt_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_type.Location = new System.Drawing.Point(689, 75);
            this.txt_type.Name = "txt_type";
            this.txt_type.Size = new System.Drawing.Size(204, 26);
            this.txt_type.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(897, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "الحالة";
            // 
            // txt_cas
            // 
            this.txt_cas.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cas.Location = new System.Drawing.Point(689, 104);
            this.txt_cas.Name = "txt_cas";
            this.txt_cas.Size = new System.Drawing.Size(204, 32);
            this.txt_cas.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(893, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "قرأ بها";
            // 
            // treeViewCas
            // 
            this.treeViewCas.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewCas.Location = new System.Drawing.Point(228, 137);
            this.treeViewCas.Name = "treeViewCas";
            this.treeViewCas.RightToLeftLayout = true;
            this.treeViewCas.Size = new System.Drawing.Size(233, 287);
            this.treeViewCas.TabIndex = 5;
            this.treeViewCas.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewCas_AfterLabelEdit);
            this.treeViewCas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeViewCas_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(398, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "الحالات";
            // 
            // treeVLecteur
            // 
            this.treeVLecteur.CheckBoxes = true;
            this.treeVLecteur.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVLecteur.Indent = 30;
            this.treeVLecteur.Location = new System.Drawing.Point(496, 137);
            this.treeVLecteur.Name = "treeVLecteur";
            this.treeVLecteur.RightToLeftLayout = true;
            this.treeVLecteur.Size = new System.Drawing.Size(397, 287);
            this.treeVLecteur.TabIndex = 5;
            this.treeVLecteur.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeVLecteur_AfterCheck);
            // 
            // btLecteur
            // 
            this.btLecteur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLecteur.Location = new System.Drawing.Point(900, 161);
            this.btLecteur.Name = "btLecteur";
            this.btLecteur.Size = new System.Drawing.Size(50, 34);
            this.btLecteur.TabIndex = 1;
            this.btLecteur.Text = "القراء";
            this.btLecteur.UseVisualStyleBackColor = true;
            this.btLecteur.Visible = false;
            this.btLecteur.Click += new System.EventHandler(this.btLecteur_Click);
            // 
            // btAjout
            // 
            this.btAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAjout.Location = new System.Drawing.Point(875, 466);
            this.btAjout.Name = "btAjout";
            this.btAjout.Size = new System.Drawing.Size(75, 34);
            this.btAjout.TabIndex = 1;
            this.btAjout.Text = "اضافة";
            this.btAjout.UseVisualStyleBackColor = true;
            this.btAjout.Click += new System.EventHandler(this.btAjout_Click);
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(0, 467);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 34);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "غلق";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "ترتيب الاوجه للقارئ";
            // 
            // treeVOrderLecteur
            // 
            this.treeVOrderLecteur.AllowDrop = true;
            this.treeVOrderLecteur.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVOrderLecteur.Location = new System.Drawing.Point(12, 137);
            this.treeVOrderLecteur.Name = "treeVOrderLecteur";
            this.treeVOrderLecteur.RightToLeftLayout = true;
            this.treeVOrderLecteur.Size = new System.Drawing.Size(182, 287);
            this.treeVOrderLecteur.TabIndex = 5;
            this.treeVOrderLecteur.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeVOrderLecteur_ItemDrag);
            this.treeVOrderLecteur.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeVOrderLecteur_DragDrop);
            this.treeVOrderLecteur.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeVOrderLecteur_DragEnter);
            this.treeVOrderLecteur.DragOver += new System.Windows.Forms.DragEventHandler(this.treeVOrderLecteur_DragOver);
            this.treeVOrderLecteur.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeVOrderLecteur_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(496, 452);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "F2 : تغيير اسم الحالة";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(238, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 25);
            this.label9.TabIndex = 2;
            this.label9.Text = "supp : حذف  الحالة";
            // 
            // ckSelecetAll
            // 
            this.ckSelecetAll.AutoSize = true;
            this.ckSelecetAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSelecetAll.Location = new System.Drawing.Point(813, 427);
            this.ckSelecetAll.Name = "ckSelecetAll";
            this.ckSelecetAll.Size = new System.Drawing.Size(77, 21);
            this.ckSelecetAll.TabIndex = 6;
            this.ckSelecetAll.Text = "اختيار الكل";
            this.ckSelecetAll.UseVisualStyleBackColor = true;
            this.ckSelecetAll.CheckedChanged += new System.EventHandler(this.ckSelecetAll_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(323, 452);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 25);
            this.label10.TabIndex = 2;
            this.label10.Text = "F3 : تعديل الحالة";
            // 
            // Frm_origine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(955, 504);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ckSelecetAll);
            this.Controls.Add(this.treeVLecteur);
            this.Controls.Add(this.treeVOrderLecteur);
            this.Controls.Add(this.treeViewCas);
            this.Controls.Add(this.txt_cas);
            this.Controls.Add(this.txt_type);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_nom);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btAjout);
            this.Controls.Add(this.btLecteur);
            this.Controls.Add(this.btaddhala);
            this.Controls.Add(this.label1);
            this.Name = "Frm_origine";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافة خلاف";
            this.Load += new System.EventHandler(this.Frm_origine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btaddhala;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView treeViewCas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeVLecteur;
        private System.Windows.Forms.Button btLecteur;
        private System.Windows.Forms.Button btAjout;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TreeView treeVOrderLecteur;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ckSelecetAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
    }
}