namespace Quran
{
    partial class Frm_choixClasseur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_choixClasseur));
            this.txt_choixClasseur = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btAjout = new System.Windows.Forms.Button();
            this.btsave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_choixClasseur
            // 
            this.txt_choixClasseur.Font = new System.Drawing.Font("Arabic Typesetting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_choixClasseur.FormattingEnabled = true;
            this.txt_choixClasseur.Location = new System.Drawing.Point(103, 100);
            this.txt_choixClasseur.Name = "txt_choixClasseur";
            this.txt_choixClasseur.Size = new System.Drawing.Size(238, 27);
            this.txt_choixClasseur.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "اسم الكراس";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "اختيار اسم كراس العمل";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btAjout
            // 
            this.btAjout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btAjout.BackgroundImage")));
            this.btAjout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAjout.FlatAppearance.BorderSize = 0;
            this.btAjout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAjout.Location = new System.Drawing.Point(54, 97);
            this.btAjout.Name = "btAjout";
            this.btAjout.Size = new System.Drawing.Size(32, 25);
            this.btAjout.TabIndex = 15;
            this.btAjout.UseVisualStyleBackColor = true;
            this.btAjout.Click += new System.EventHandler(this.btAjout_Click);
            // 
            // btsave
            // 
            this.btsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btsave.Location = new System.Drawing.Point(385, 205);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(92, 40);
            this.btsave.TabIndex = 16;
            this.btsave.Text = "حفظ";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // Frm_choixClasseur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 249);
            this.Controls.Add(this.btsave);
            this.Controls.Add(this.btAjout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_choixClasseur);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_choixClasseur";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_choixClasseur_FormClosing);
            this.Load += new System.EventHandler(this.Frm_choixClasseur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox txt_choixClasseur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAjout;
        private System.Windows.Forms.Button btsave;
    }
}