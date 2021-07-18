namespace Quran
{
    partial class Frm_ListSegment
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
            this.gridListDifference = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btActualiser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridListDifference)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btClose.Location = new System.Drawing.Point(-6, 405);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(95, 36);
            this.btClose.TabIndex = 10;
            this.btClose.Text = "اغلاق";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btsupprimer
            // 
            this.btsupprimer.Location = new System.Drawing.Point(-6, 273);
            this.btsupprimer.Name = "btsupprimer";
            this.btsupprimer.Size = new System.Drawing.Size(95, 36);
            this.btsupprimer.TabIndex = 11;
            this.btsupprimer.Text = "حذف";
            this.btsupprimer.UseVisualStyleBackColor = true;
            this.btsupprimer.Click += new System.EventHandler(this.btsupprimer_Click);
            // 
            // btModifier
            // 
            this.btModifier.Location = new System.Drawing.Point(-6, 149);
            this.btModifier.Name = "btModifier";
            this.btModifier.Size = new System.Drawing.Size(95, 36);
            this.btModifier.TabIndex = 12;
            this.btModifier.Text = "تعديل";
            this.btModifier.UseVisualStyleBackColor = true;
            this.btModifier.Click += new System.EventHandler(this.btModifier_Click);
            // 
            // btAjout
            // 
            this.btAjout.Location = new System.Drawing.Point(-6, 92);
            this.btAjout.Name = "btAjout";
            this.btAjout.Size = new System.Drawing.Size(95, 36);
            this.btAjout.TabIndex = 13;
            this.btAjout.Text = "اضافة";
            this.btAjout.UseVisualStyleBackColor = true;
            this.btAjout.Click += new System.EventHandler(this.btAjout_Click);
            // 
            // txt_recherche
            // 
            this.txt_recherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_recherche.Location = new System.Drawing.Point(106, 69);
            this.txt_recherche.Name = "txt_recherche";
            this.txt_recherche.Size = new System.Drawing.Size(859, 20);
            this.txt_recherche.TabIndex = 9;
            this.txt_recherche.TextChanged += new System.EventHandler(this.txt_recherche_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(971, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "بحث";
            // 
            // gridListDifference
            // 
            this.gridListDifference.AllowUserToAddRows = false;
            this.gridListDifference.AllowUserToDeleteRows = false;
            this.gridListDifference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridListDifference.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridListDifference.BackgroundColor = System.Drawing.Color.White;
            this.gridListDifference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListDifference.Location = new System.Drawing.Point(106, 92);
            this.gridListDifference.Name = "gridListDifference";
            this.gridListDifference.ReadOnly = true;
            this.gridListDifference.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridListDifference.RowTemplate.Height = 32;
            this.gridListDifference.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridListDifference.Size = new System.Drawing.Size(901, 361);
            this.gridListDifference.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1013, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "قائمة المقاطع";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btActualiser
            // 
            this.btActualiser.Location = new System.Drawing.Point(-6, 201);
            this.btActualiser.Name = "btActualiser";
            this.btActualiser.Size = new System.Drawing.Size(95, 36);
            this.btActualiser.TabIndex = 12;
            this.btActualiser.Text = "تحديث";
            this.btActualiser.UseVisualStyleBackColor = true;
            this.btActualiser.Click += new System.EventHandler(this.btActualiser_Click);
            // 
            // Frm_ListSegment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1015, 466);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btsupprimer);
            this.Controls.Add(this.btActualiser);
            this.Controls.Add(this.btModifier);
            this.Controls.Add(this.btAjout);
            this.Controls.Add(this.txt_recherche);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridListDifference);
            this.Controls.Add(this.label1);
            this.Name = "Frm_ListSegment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "قائمة المقاطع";
            this.Load += new System.EventHandler(this.Frm_ListSegment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridListDifference)).EndInit();
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
        private System.Windows.Forms.DataGridView gridListDifference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btActualiser;
    }
}