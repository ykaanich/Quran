namespace Quran
{
    partial class Frm_Exclusion
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
            this.label1 = new System.Windows.Forms.Label();
            this.treeVdifference = new System.Windows.Forms.TreeView();
            this.dtDifference = new System.Windows.Forms.ComboBox();
            this.btGenerer = new System.Windows.Forms.Button();
            this.treeVResultat = new System.Windows.Forms.TreeView();
            this.btClose = new System.Windows.Forms.Button();
            this.btAjout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(779, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "الخلافات";
            // 
            // treeVdifference
            // 
            this.treeVdifference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeVdifference.CheckBoxes = true;
            this.treeVdifference.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVdifference.Location = new System.Drawing.Point(425, 57);
            this.treeVdifference.Name = "treeVdifference";
            this.treeVdifference.RightToLeftLayout = true;
            this.treeVdifference.Size = new System.Drawing.Size(348, 228);
            this.treeVdifference.TabIndex = 8;
            // 
            // dtDifference
            // 
            this.dtDifference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDifference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.dtDifference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dtDifference.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDifference.FormattingEnabled = true;
            this.dtDifference.Location = new System.Drawing.Point(425, 19);
            this.dtDifference.Name = "dtDifference";
            this.dtDifference.Size = new System.Drawing.Size(348, 32);
            this.dtDifference.Sorted = true;
            this.dtDifference.TabIndex = 7;
            this.dtDifference.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtDifference_KeyUp);
            // 
            // btGenerer
            // 
            this.btGenerer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenerer.Location = new System.Drawing.Point(327, 75);
            this.btGenerer.Name = "btGenerer";
            this.btGenerer.Size = new System.Drawing.Size(92, 87);
            this.btGenerer.TabIndex = 10;
            this.btGenerer.Text = "إنتاج الامتناعات\r\n--->";
            this.btGenerer.UseVisualStyleBackColor = true;
            this.btGenerer.Click += new System.EventHandler(this.btGenerer_Click);
            // 
            // treeVResultat
            // 
            this.treeVResultat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeVResultat.CheckBoxes = true;
            this.treeVResultat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeVResultat.Location = new System.Drawing.Point(12, 57);
            this.treeVResultat.Name = "treeVResultat";
            this.treeVResultat.RightToLeftLayout = true;
            this.treeVResultat.Size = new System.Drawing.Size(309, 228);
            this.treeVResultat.TabIndex = 8;
            this.treeVResultat.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeVResultat_AfterCheck);
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(0, 311);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 34);
            this.btClose.TabIndex = 11;
            this.btClose.Text = "غلق";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btAjout
            // 
            this.btAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAjout.Location = new System.Drawing.Point(762, 311);
            this.btAjout.Name = "btAjout";
            this.btAjout.Size = new System.Drawing.Size(75, 34);
            this.btAjout.TabIndex = 12;
            this.btAjout.Text = "اضافة";
            this.btAjout.UseVisualStyleBackColor = true;
            this.btAjout.Click += new System.EventHandler(this.btAjout_Click);
            // 
            // Frm_Exclusion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(845, 357);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btAjout);
            this.Controls.Add(this.btGenerer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeVResultat);
            this.Controls.Add(this.treeVdifference);
            this.Controls.Add(this.dtDifference);
            this.Name = "Frm_Exclusion";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الامتناعات";
            this.Load += new System.EventHandler(this.Frm_Exclusion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeVdifference;
        private System.Windows.Forms.ComboBox dtDifference;
        private System.Windows.Forms.Button btGenerer;
        private System.Windows.Forms.TreeView treeVResultat;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btAjout;
    }
}