namespace Quran
{
    partial class Frm_Lecteur
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
            this.treeVLecteur = new System.Windows.Forms.TreeView();
            this.btValider = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.treeVLecteur2 = new System.Windows.Forms.TreeView();
            this.treeVLecteur3 = new System.Windows.Forms.TreeView();
            this.treeVLecteur4 = new System.Windows.Forms.TreeView();
            this.treeVLecteur5 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeVLecteur
            // 
            this.treeVLecteur.CheckBoxes = true;
            this.treeVLecteur.Font = new System.Drawing.Font("Arial Unicode MS", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVLecteur.Indent = 20;
            this.treeVLecteur.Location = new System.Drawing.Point(935, 2);
            this.treeVLecteur.Name = "treeVLecteur";
            this.treeVLecteur.RightToLeftLayout = true;
            this.treeVLecteur.Size = new System.Drawing.Size(229, 613);
            this.treeVLecteur.TabIndex = 6;
            // 
            // btValider
            // 
            this.btValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btValider.Location = new System.Drawing.Point(1085, 617);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(76, 27);
            this.btValider.TabIndex = 7;
            this.btValider.Text = "اضافة";
            this.btValider.UseVisualStyleBackColor = true;
            this.btValider.Click += new System.EventHandler(this.btValider_Click);
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(5, 616);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(76, 27);
            this.btClose.TabIndex = 8;
            this.btClose.Text = "غلق";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // treeVLecteur2
            // 
            this.treeVLecteur2.CheckBoxes = true;
            this.treeVLecteur2.Font = new System.Drawing.Font("Arial Unicode MS", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVLecteur2.Indent = 20;
            this.treeVLecteur2.Location = new System.Drawing.Point(703, 2);
            this.treeVLecteur2.Name = "treeVLecteur2";
            this.treeVLecteur2.RightToLeftLayout = true;
            this.treeVLecteur2.Size = new System.Drawing.Size(229, 613);
            this.treeVLecteur2.TabIndex = 6;
            // 
            // treeVLecteur3
            // 
            this.treeVLecteur3.CheckBoxes = true;
            this.treeVLecteur3.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVLecteur3.Indent = 20;
            this.treeVLecteur3.Location = new System.Drawing.Point(472, 2);
            this.treeVLecteur3.Name = "treeVLecteur3";
            this.treeVLecteur3.RightToLeftLayout = true;
            this.treeVLecteur3.Size = new System.Drawing.Size(229, 613);
            this.treeVLecteur3.TabIndex = 6;
            // 
            // treeVLecteur4
            // 
            this.treeVLecteur4.CheckBoxes = true;
            this.treeVLecteur4.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVLecteur4.Indent = 20;
            this.treeVLecteur4.Location = new System.Drawing.Point(241, 4);
            this.treeVLecteur4.Name = "treeVLecteur4";
            this.treeVLecteur4.RightToLeftLayout = true;
            this.treeVLecteur4.Size = new System.Drawing.Size(229, 613);
            this.treeVLecteur4.TabIndex = 6;
            // 
            // treeVLecteur5
            // 
            this.treeVLecteur5.CheckBoxes = true;
            this.treeVLecteur5.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVLecteur5.Indent = 20;
            this.treeVLecteur5.Location = new System.Drawing.Point(6, 2);
            this.treeVLecteur5.Name = "treeVLecteur5";
            this.treeVLecteur5.RightToLeftLayout = true;
            this.treeVLecteur5.Size = new System.Drawing.Size(229, 613);
            this.treeVLecteur5.TabIndex = 6;
            // 
            // Frm_Lecteur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 643);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btValider);
            this.Controls.Add(this.treeVLecteur5);
            this.Controls.Add(this.treeVLecteur4);
            this.Controls.Add(this.treeVLecteur3);
            this.Controls.Add(this.treeVLecteur2);
            this.Controls.Add(this.treeVLecteur);
            this.Name = "Frm_Lecteur";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "القراء";
            this.Load += new System.EventHandler(this.Frm_Lecteur_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeVLecteur;
        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TreeView treeVLecteur2;
        private System.Windows.Forms.TreeView treeVLecteur3;
        private System.Windows.Forms.TreeView treeVLecteur4;
        private System.Windows.Forms.TreeView treeVLecteur5;
    }
}