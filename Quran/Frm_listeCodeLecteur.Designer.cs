namespace Quran
{
    partial class Frm_listeCodeLecteur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btClose = new System.Windows.Forms.Button();
            this.btsupprimer = new System.Windows.Forms.Button();
            this.btModifier = new System.Windows.Forms.Button();
            this.btAjout = new System.Windows.Forms.Button();
            this.txt_recherche = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridListClasseur = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btActualiser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridListClasseur)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btClose.Location = new System.Drawing.Point(15, 408);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(95, 36);
            this.btClose.TabIndex = 19;
            this.btClose.Text = "اغلاق";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btsupprimer
            // 
            this.btsupprimer.Location = new System.Drawing.Point(17, 280);
            this.btsupprimer.Name = "btsupprimer";
            this.btsupprimer.Size = new System.Drawing.Size(95, 36);
            this.btsupprimer.TabIndex = 20;
            this.btsupprimer.Text = "حذف";
            this.btsupprimer.UseVisualStyleBackColor = true;
            this.btsupprimer.Click += new System.EventHandler(this.btsupprimer_Click);
            // 
            // btModifier
            // 
            this.btModifier.Location = new System.Drawing.Point(17, 148);
            this.btModifier.Name = "btModifier";
            this.btModifier.Size = new System.Drawing.Size(95, 36);
            this.btModifier.TabIndex = 22;
            this.btModifier.Text = "تعديل";
            this.btModifier.UseVisualStyleBackColor = true;
            this.btModifier.Click += new System.EventHandler(this.btModifier_Click);
            // 
            // btAjout
            // 
            this.btAjout.Location = new System.Drawing.Point(17, 91);
            this.btAjout.Name = "btAjout";
            this.btAjout.Size = new System.Drawing.Size(95, 36);
            this.btAjout.TabIndex = 23;
            this.btAjout.Text = "اضافة";
            this.btAjout.UseVisualStyleBackColor = true;
            this.btAjout.Click += new System.EventHandler(this.btAjout_Click);
            // 
            // txt_recherche
            // 
            this.txt_recherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_recherche.Location = new System.Drawing.Point(129, 65);
            this.txt_recherche.Name = "txt_recherche";
            this.txt_recherche.Size = new System.Drawing.Size(618, 20);
            this.txt_recherche.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(745, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 27);
            this.label2.TabIndex = 17;
            this.label2.Text = "بحث";
            // 
            // gridListClasseur
            // 
            this.gridListClasseur.AllowUserToAddRows = false;
            this.gridListClasseur.AllowUserToDeleteRows = false;
            this.gridListClasseur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridListClasseur.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridListClasseur.BackgroundColor = System.Drawing.Color.White;
            this.gridListClasseur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListClasseur.Location = new System.Drawing.Point(129, 91);
            this.gridListClasseur.Name = "gridListClasseur";
            this.gridListClasseur.ReadOnly = true;
            this.gridListClasseur.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridListClasseur.RowTemplate.Height = 32;
            this.gridListClasseur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridListClasseur.Size = new System.Drawing.Size(657, 362);
            this.gridListClasseur.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(783, 39);
            this.label1.TabIndex = 15;
            this.label1.Text = "قائمة رموز القراء";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btActualiser
            // 
            this.btActualiser.Location = new System.Drawing.Point(17, 199);
            this.btActualiser.Name = "btActualiser";
            this.btActualiser.Size = new System.Drawing.Size(95, 36);
            this.btActualiser.TabIndex = 24;
            this.btActualiser.Text = "تحديث";
            this.btActualiser.UseVisualStyleBackColor = true;
            this.btActualiser.Click += new System.EventHandler(this.btActualiser_Click);
            // 
            // Frm_listeCodeLecteur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(789, 465);
            this.Controls.Add(this.btActualiser);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btsupprimer);
            this.Controls.Add(this.btModifier);
            this.Controls.Add(this.btAjout);
            this.Controls.Add(this.txt_recherche);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridListClasseur);
            this.Controls.Add(this.label1);
            this.Name = "Frm_listeCodeLecteur";
            this.Text = "Frm_listeCodeLecteur";
            this.Load += new System.EventHandler(this.Frm_listeCodeLecteur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridListClasseur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btsupprimer;
        private System.Windows.Forms.Button btModifier;
        private System.Windows.Forms.Button btAjout;
        private System.Windows.Forms.TextBox txt_recherche;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridListClasseur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btActualiser;
    }
}